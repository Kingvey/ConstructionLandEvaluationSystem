using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Controls;

namespace ConstructionLandEvaluationSystem
{
    public partial class FormOverlayAnalysis : Form
    {
        //输出路径
        public string strOutputPath;

        public FormOverlayAnalysis(string tempPath)
        {
            InitializeComponent();
            strOutputPath = tempPath;
        }

        private void FormOverlayAnalysis_Load(object sender, EventArgs e)
        {
            //加载叠置方式
            this.cmbOverlayType.Items.Add("叠置求交(Intersect)");
            this.cmbOverlayType.Items.Add("叠置求并(Union)");
            this.cmbOverlayType.Items.Add("叠置标识(Identity)");
            this.cmbOverlayType.SelectedIndex = 0;
            //设置默认输出路径
            //string tempDir = @"D:\Temp\";
            txtOutputLayerPath.Text = strOutputPath;
        }
        //选择输入图层
        private void btnInputLayer_Click(object sender, EventArgs e)
        {
            //定义OpenfileDialog
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "选择输入图层";
            //检验文件和路径是否存在
            openDlg.CheckFileExists = true;
            openDlg.CheckPathExists = true;
            //初试化初试打开路径
            //openDlg.InitialDirectory = strOutputPath;
            //读取文件路径到txtFeature1中
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtInputLayer.Text = openDlg.FileName;
            }
        }
        //选择叠置图层
        private void btnOverlayLayer_Click(object sender, EventArgs e)
        {
            //定义OpenfileDialog
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "选择叠置图层";
            //检验文件和路径是否存在
            openDlg.CheckFileExists = true;
            openDlg.CheckPathExists = true;
            //初试化初试打开路径
            //openDlg.InitialDirectory = strOutputPath;
            //读取文件路径到txtFeature2中
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOverlayLayer.Text = openDlg.FileName;
            }
        }
        //设置输出路径
        private void btnOutputLayerPath_Click(object sender, EventArgs e)
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
            saveDlg.FileName = (string)cmbOverlayType.SelectedItem + ".shp";

            //读取文件输出路径到txtOutputPath
            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputLayerPath.Text = saveDlg.FileName;
        }
        //开始分析
        private void btnOK_Click(object sender, EventArgs e)
        {
            //判断是否选择要素
            if (this.txtInputLayer.Text == "" || this.txtInputLayer.Text == null ||
                this.txtOverlayLayer.Text == "" || this.txtOverlayLayer.Text == null)
            {
                txtMessage.Text = "请选择参加叠置分析的图层！";
                return;
            }
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            gp.OverwriteOutput = true;

            //设置参与叠置分析的多个对象
            object inputFeat = this.txtInputLayer.Text;
            object overlayFeat = this.txtOverlayLayer.Text;
            IGpValueTableObject pObject = new GpValueTableObjectClass();
            pObject.SetColumns(2);
            pObject.AddRow(ref inputFeat);
            pObject.AddRow(ref overlayFeat);

            //获取要素名称
            string str = System.IO.Path.GetFileName(this.txtInputLayer.Text);
            int index = str.LastIndexOf(".");
            string strName = str.Remove(index);

            //设置输出路径
            strOutputPath = txtOutputLayerPath.Text;

            //叠置分析结果
            IGeoProcessorResult result = null;

            //创建叠置分析实例，执行叠置分析
            string strOverlay = cmbOverlayType.SelectedItem.ToString();
            try
            {
                //添加处理过程消息
                txtMessage.Text = "开始叠置分析……" + "\r\n";
                switch (strOverlay)
                {
                    case "叠置求交(Intersect)":
                        Intersect intersectTool = new Intersect();
                        //设置输入要素
                        intersectTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_intersect.shp";
                        intersectTool.out_feature_class = strOutputPath;
                        //执行求交运算
                        result = gp.Execute(intersectTool, null) as IGeoProcessorResult;
                        break;
                    case "叠置求并(Union)":
                        Union unionTool = new Union();
                        //设置输入要素
                        unionTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_union.shp";
                        unionTool.out_feature_class = strOutputPath;
                        //执行联合运算
                        result = gp.Execute(unionTool, null) as IGeoProcessorResult;
                        break;
                    case "叠置标识(Identity)":
                        Identity identityTool = new Identity();
                        //设置输入要素
                        identityTool.in_features = inputFeat;
                        identityTool.identity_features = overlayFeat;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_identity.shp";
                        identityTool.out_feature_class = strOutputPath;
                        //执行标识运算
                        result = gp.Execute(identityTool, null) as IGeoProcessorResult;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //添加处理过程消息
                txtMessage.Text += "叠置分析过程出现错误：" + ex.Message + "\r\n";
            }

            //判断叠置分析是否成功
            if (result.Status != ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
                txtMessage.Text += "叠置失败!";
            else
            {
                this.DialogResult = DialogResult.OK;
                txtMessage.Text += "叠置成功!";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
