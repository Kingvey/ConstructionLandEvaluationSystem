using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geoprocessor;  

namespace GISManager
{
    public partial class FormAttributeSelection : Form
    {
        private IFeatureLayer _FeatureLayer = null;
        private DataGridView Gridviwe;
        private string Field = "";

        public FormAttributeSelection(IFeatureLayer pFeatureLayer, DataGridView dataGridView)
        {
            InitializeComponent();
            _FeatureLayer = pFeatureLayer;
        }

        private void FormFieldCalculation_Load(object sender, EventArgs e)
        {
            IFeatureClass pFeatureCls = _FeatureLayer.FeatureClass;
            int FieldCount = pFeatureCls.Fields.FieldCount;
            for (int i = 0; i < FieldCount; i++)
            {
                IField pField = pFeatureCls.Fields.get_Field(i);
                //去除shape字段  
                if (pField.Name == "shape")
                {
                    continue;
                }
                ltbFields.Items.Add("[" + pField.Name + "]");
            } 
        }

        //双击字段列表，添加字段至选择表达式
        private void ltbFields_DoubleClick(object sender, EventArgs e)
        {
            string strSelectField = this.ltbFields.SelectedItem.ToString();
            txtExpression.Text += strSelectField; 
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //执行计算，输出计算结果信息字符串
        private string FieldCal(IFeatureLayer pFtLayer, string strExpression)
        {
            txtMessage.Text = "正在计算请稍后……\r\n";
            try
            {
                Geoprocessor Gp = new Geoprocessor();
                Gp.OverwriteOutput = true;
                CalculateField calField = new CalculateField();
                
                calField.expression = strExpression;

                Gp.Execute(calField, null);

                for (int i = 0; i < Gp.MessageCount; i++)
                {
                    txtMessage.Text += Gp.GetMessage(i).ToString() + "\r\n";
                }
                return "计算成功";
            }
            catch (Exception e)
            {
                txtMessage.Text += e.Message;
                return "计算失败" + e.Message;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }  
    }
}
