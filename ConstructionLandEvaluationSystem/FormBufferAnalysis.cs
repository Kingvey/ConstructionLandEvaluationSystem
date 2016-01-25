using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;

namespace ConstructionLandEvaluationSystem
{
    public partial class FormBufferAnalysis : Form
    {
        //接收MapControl中的数据
        private IHookHelper mHookHelper = new HookHelperClass();
        private string tempDir;
        //缓冲区文件输出路径
        public string strOutputPath;

        public FormBufferAnalysis(object hook, string tempPath)
        {
            InitializeComponent();
            this.mHookHelper.Hook = hook;
            tempDir = tempPath;
        }

        private void BufferAnalysisForm_Load(object sender, EventArgs e)
        {
            //传入数据为空时返回
            if (null == mHookHelper || null == mHookHelper.Hook || 0 == mHookHelper.FocusMap.LayerCount)
                return;

            //获取图层名称并加入cboLayers
            for (int i = 0; i < this.mHookHelper.FocusMap.LayerCount; i++)
            {
                ILayer pLayer = this.mHookHelper.FocusMap.get_Layer(i);
                cmbLayerName.Items.Add(pLayer.Name);
            }

            //cboLayers控件中默认显示第一个选项
            if (cmbLayerName.Items.Count > 0)
                cmbLayerName.SelectedIndex = 0;

            //设置生成文件的默认输出路径和名称
            txtOutputLayer.Text = System.IO.Path.Combine(tempDir, ((string)cmbLayerName.SelectedItem + "_buffer.shp"));

            //设置默认地图单位
            string strUnit = Convert.ToString(mHookHelper.FocusMap.MapUnits);
            strUnit = strUnit.Replace("esri", "");
            labMapUnit.Text = strUnit;
        }

        //根据名称获取图层
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            IFeatureLayer pFeatureLayer = null;
            //遍历图层，获取与名称匹配的图层
            for (int i = 0; i < this.mHookHelper.FocusMap.LayerCount; i++)
            {
                ILayer pLayer = this.mHookHelper.FocusMap.get_Layer(i);
                if (pLayer.Name == layerName)
                {
                    pFeatureLayer = pLayer as IFeatureLayer;
                    break;
                }
            }

            if (pFeatureLayer != null)
                return pFeatureLayer;
            else
                return null;
        }
        //设置输出路径
        private void btnOutputLayer_Click(object sender, EventArgs e)
        {
            //定义输出文件路径
            SaveFileDialog saveDlg = new SaveFileDialog();
            //检查路径是否存在
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            //保存时覆盖同名文件
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "输出路径";
            //对话框关闭前还原当前目录
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)cmbLayerName.SelectedItem + "_buffer.shp";

            //读取文件输出路径到txtOutputPath
            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputLayer.Text = saveDlg.FileName;
        }
        //开始分析
        private void btnBufferStart_Click(object sender, EventArgs e)
        {
            //缓冲距离
            double bufferDistance;
            //输入的缓冲距离转换为double
            double.TryParse(txtBufferDistance.Text.ToString(), out bufferDistance);

            //判断输出路径是否合法
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtOutputLayer.Text)) ||
              System.IO.Path.GetExtension(txtOutputLayer.Text) != ".shp")
            {
                MessageBox.Show("输出路径错误!");
                return;
            }

            //判断图层个数
            if (mHookHelper.FocusMap.LayerCount == 0)
                return;
            //获取图层
            IFeatureLayer pFeatureLayer = GetFeatureLayer((string)cmbLayerName.SelectedItem);
            if (null == pFeatureLayer)
            {
                MessageBox.Show("图层" + (string)cmbLayerName.SelectedItem + "不存在!\r\n");
                return;
            }

            //获取一个geoprocessor的实例
            Geoprocessor gp = new Geoprocessor();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            gp.OverwriteOutput = true;
            //缓冲区保存路径
            strOutputPath = txtOutputLayer.Text;
            //创建一个Buffer工具的实例
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(pFeatureLayer, strOutputPath, bufferDistance.ToString());
            //执行缓冲区分析
            IGeoProcessorResult results = null;
            results = (IGeoProcessorResult)gp.Execute(buffer, null);
            //判断缓冲区是否成功生成
            if (results.Status != esriJobStatus.esriJobSucceeded)
                MessageBox.Show("图层" + pFeatureLayer.Name + "缓冲区生成失败！");
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("缓冲区生成成功！");
            }
        }
        //取消分析
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
