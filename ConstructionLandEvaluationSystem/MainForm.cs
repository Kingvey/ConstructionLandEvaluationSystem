using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Display;

using DevExpress.XtraTreeList;
using DevExpress.XtraTab;
using DevExpress.XtraRichEdit;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using DevExpress.XtraPdfViewer;


using GISManager;
using LandEvaluationBll;

namespace ConstructionLandEvaluationSystem
{
    public partial class MainForm : Form
    {
        #region//右键相关设置--变量
        private ITOCControl2 pTocControl; 
        private IMapControl3 pMapControl;
        private IToolbarMenu pToolMenuMap; 
        private IToolbarMenu pToolMenuLayer;
        esriTOCControlItem pTocItem = esriTOCControlItem.esriTOCControlItemNone;
        IBasicMap pBasicMap = null;
        ILayer pLayer = null;
        object oLegendGroup = null;
        object oIndex = null;
        #endregion

        private char separator = '|'; //根目录变量间隔符

        public MainForm()
        {
            InitializeComponent();

            //读取配置文件中的根目录
            this.comboBox_RootPathSelector.DataSource =
                LandEvaluationBll.BindingDataTable.GetRootPathDataTable(ConfigurationManager.AppSettings["RootPathes"], separator);
            this.comboBox_RootPathSelector.ValueMember = "RootPath";
            this.comboBox_RootPathSelector.DisplayMember = "RootPath";
            FileListReSet();
        }
        //加载主界面
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.axMapControl1.Map.Name = "Map"; //修改初始地图名为Map3的bug
            string strInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            #region     //右键功能相关设置--添加功能项
            pTocControl = (ITOCControl2)axTOCControl1.Object;
            pMapControl = (IMapControl3)axMapControl1.Object;
            pToolMenuMap = new ToolbarMenuClass(); 
            pToolMenuLayer = new ToolbarMenuClass();
            pToolMenuLayer.AddItem(new RemoveLayerCommand(), 0, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.AddItem(new ZoomToLayerCommand(), 0, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.AddItem(new ScaleThresholdsCommand(), 1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.AddItem(new ScaleThresholdsCommand(), 2, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.AddItem(new ScaleThresholdsCommand(), 3, 4, false, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.AddItem(new LayerSelectableCommand(), 1, 5, true, esriCommandStyles.esriCommandStyleTextOnly);
            pToolMenuLayer.SetHook(pMapControl);
            #endregion
        }

        #region 地图菜单栏按钮响应事件

        #region 文件操作
        //打开地图文档
        private void btn_OpenMapDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MapDocumentOperation.OpenFromFile(this.axMapControl1);
            this.xtraTabControl1.SelectedTabPageIndex = 1;
        }
        //添加图层
        private void btn_AddLayerData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MapDocumentOperation.AddLayerData(this.axMapControl1);
        }
        //新建空白地图文档
        private void btn_NewMapDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MapDocumentOperation.NewMapDocument(this.axMapControl1);
        }
        //保存修改
        private void btn_SaveMapDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MapDocumentOperation.SaveMapDocument(this.axMapControl1);
        }
        //另存为
        private void btn_SaveAsMapDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MapDocumentOperation.SaveAsMapDocument(this.axMapControl1);
        }
        #endregion

        #region 地图浏览
        //指针
        private void btn_MapTool_SetNull_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.SetNull(this.axMapControl1);
        }
        //平移
        private void btn_MapTool_Pan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.Pan(this.axMapControl1);
        }
        //逐级放大
        private void btn_MapTool_ZoomInFixed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomInFixed(this.axMapControl1);
        }
        //逐级缩小
        private void btn_MapTool_ZoomOutFixed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomOutFixed(this.axMapControl1);
        }
        //放大
        private void btn_MapTool_ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomIn(this.axMapControl1);
        }
        //缩小
        private void btn_MapTool_ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomOut(this.axMapControl1);
        }
        //上一视图
        private void btn_MapTool_ExtentBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomToLastExtentBack(this.axMapControl1);
        }
        //下一视图
        private void btn_MapTool_ExtentForward_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.ZoomToLastExtentForward(this.axMapControl1);
        }
        //全局视图
        private void btn_MapTool_FullExtent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewTools.FullExtend(this.axMapControl1);
        }
        //属性查询
        private void btn_MapTool_Query_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        #endregion

        #endregion

        #region 左边栏相关事件
        //文本页，添加根目录路径按钮单击事件
        private void btn_AddRootPath_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            FolderDialog openFolder = new FolderDialog();
            if (openFolder.DisplayDialog() == DialogResult.OK)
                selectedPath = openFolder.Path.ToString();
            else return;
            if (Directory.Exists(selectedPath))
            {
                string newRootPath = selectedPath;
                DataTable dt =  (DataTable)(this.comboBox_RootPathSelector.DataSource);
                LandEvaluationBll.BindingDataTable.AddRowForRootPathDataTable(newRootPath, ref dt);
                string newValue = ConfigurationManager.AppSettings["RootPathes"] + separator + newRootPath;
                //ConfigurationHelper.SetAppSettingsKey("RootPathes",  newValue);
                ConfigurationHelper.UpdateNoteValue("appSettings","RootPathes", newValue);
                
                this.comboBox_RootPathSelector.SelectedIndex = dt.Rows.Count - 1;
            }
        }
        //根目录变更响应事件
        private void comboBox_RootPathSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileListReSet();
        }
        //文件列表控件显示设置
        private void FileListReSet()
        {
            DataTable fileListTable = LandEvaluationBll.BindingDataTable.GetFileListDataTable(
                this.comboBox_RootPathSelector.SelectedValue.ToString());

            if (fileListTable == null || fileListTable.Rows.Count == 0) return;

            this.treeList_FileList.DataSource = fileListTable;
            this.treeList_FileList.KeyFieldName = "ID";
            this.treeList_FileList.ParentFieldName = "ParentID";
            this.treeList_FileList.ImageIndexFieldName = "ImageIndex";

            List<string> imageIndex = new List<string>();
            foreach (DataRow dr in fileListTable.Rows)
            {
                imageIndex.Add(dr["ImageIndex"].ToString());
            }
            //按名称排序
            this.treeList_FileList.BeginSort();
            this.treeList_FileList.Columns["ExtName"].SortOrder = SortOrder.Descending;
            this.treeList_FileList.Columns["Name"].SortOrder = SortOrder.Ascending;
            this.treeList_FileList.EndSort();

            //隐藏除"name"的列
            for (int i = 0; i < this.treeList_FileList.Columns.Count; i++)
            {
                if (this.treeList_FileList.Columns[i].FieldName != "Name")
                {
                    this.treeList_FileList.Columns[i].Visible = false;
                }
            }

            this.treeList_FileList.CollapseAll();
        }
        //文件列表控件双击事件
        private void treeList_FileList_DoubleClick(object sender, EventArgs e)
        {
            TreeList treeList = (TreeList)sender;
            if (treeList.HasFocus && treeList.FocusedNode.GetValue("ExtName").ToString() != "")
            {
                string FilePath = treeList.FocusedNode.GetValue("FilePath").ToString();
                OpenFileByPath(FilePath);
            }
        }
        #endregion

        //关闭显示页面
        private void xtraTabControl2_CloseButtonClick(object sender, EventArgs e)
        {
            if (this.xtraTabControl2.SelectedTabPageIndex == 0)
            {
                return; //如果是关闭主页，则返回
            }
            XtraTabPage tabPage = this.xtraTabControl2.SelectedTabPage;
            this.xtraTabControl2.SelectedTabPageIndex -= 1;
            this.xtraTabControl2.TabPages.Remove(tabPage);
            tabPage.Dispose();
            GC.Collect();
        }
        //根据路径打开文件
        private void OpenFileByPath(string FilePath)
        {
            string ExtName = (System.IO.Path.GetExtension(FilePath)).Replace(".", "").ToLower();
            int index = LandEvaluationBll.BindingDataTable.GetImageIndexByExtName(ExtName);
            XtraTabPage tabPage = new XtraTabPage();
            tabPage.Text = System.IO.Path.GetFileName(FilePath);
            tabPage.ImageIndex = index;
            Control fileViewerControl=null;
            if (index == 1)
            {
                RichEditControl richEditControl = new RichEditControl();
                richEditControl.LoadDocument(FilePath);
                fileViewerControl = richEditControl;
            }
            else if (index == 2)
            {
                SpreadsheetControl spreadsheetControl = new SpreadsheetControl();
                spreadsheetControl.LoadDocument(FilePath);
                fileViewerControl = spreadsheetControl;
            }
            else if (index == 4)
            {
                PdfViewer pdfViewer = new PdfViewer();
                pdfViewer.LoadDocument(FilePath);
                fileViewerControl = pdfViewer;
            }
            else if (index == 5)
            {
                PdfViewer pdfViewer = new PdfViewer();
                pdfViewer.LoadDocument(FilePath);
                fileViewerControl = pdfViewer;
            }
            else if (index == 9)
            {
                this.axMapControl1.LoadMxFile(FilePath);
                this.xtraTabControl2.SelectedTabPageIndex = 0;
                this.xtraTabControl1.SelectedTabPageIndex = 1;
                return;
            }
            tabPage.Controls.Add(fileViewerControl);
            fileViewerControl.Dock = DockStyle.Fill;
            this.xtraTabControl2.TabPages.Add(tabPage);
            this.xtraTabControl2.SelectedTabPage = tabPage;
            //this.xtraTabControl2.Refresh();
        }
        //TOCControl1鼠标点击事件，左键 符号变更，右键菜单
        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            this.axTOCControl1.HitTest(e.x, e.y, ref pTocItem, ref pBasicMap, ref pLayer, ref oLegendGroup, ref oIndex);
            axMapControl1.CustomProperty = pLayer;
            if (e.button == 1)  //符号变更
            {
                if(pTocItem == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    ILegendClass pLegend = new LegendClassClass();　　　　　　　　//首先获取图例，然后赋值过去
                ISymbol symbol = null;　　　　　　　　　　　　　　　　　　　　//新建 symbol，从符号窗体中最后就是获得这个东西
                if (oLegendGroup is ILegendGroup && (int)oIndex != -1)
                    pLegend = ((ILegendGroup)oLegendGroup).get_Class((int)oIndex) as ILegendClass;　　//给上面建的图例类赋值

                SymbologyForm frm = new SymbologyForm(pLegend, pLayer);　　　　　　//新建符号窗体，并将该赋值的赋值过去
                frm.ShowDialog();　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//显示对话框，之后就获得了 symbol 了
                symbol = frm.pStyleGalleryItem.Item as ISymbol;　　　　　　　　　　　　　　//调用窗体的 public 字段
                pLegend.Symbol = symbol;　　　　　　　　　　　　　　　　　　　　　　　　//将 symbol 赋值给图例
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);　　//刷新地图
                }
            }
            else if (e.button == 2) //加载右键菜单
            {
                if (pTocItem == esriTOCControlItem.esriTOCControlItemMap)
                {
                    
                }
                else if (pTocItem == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    pToolMenuLayer.PopupMenu(e.x, e.y, pTocControl.hWnd);
                    ITOCControl toc = axTOCControl1.Object as ITOCControl;
                    toc.Update();
                }
            }
        }
        //axMapControl1地图切换，axMapControl2同步
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            this.axMapControl2.Map = new MapClass();
            // 添加主地图控件中的所有图层到鹰眼控件中 
            for (int i = 1; i <= this.axMapControl1.LayerCount; i++)
            {
                this.axMapControl2.AddLayer(this.axMapControl1.get_Layer(this.axMapControl1.LayerCount - i));
            }
            // 设置 MapControl 显示范围至数据的全局范围 
            this.axMapControl2.Extent = this.axMapControl1.FullExtent;
            // 刷新鹰眼控件地图 
            this.axMapControl2.Refresh(); 
        }
        //axMapControl1显示范围变化，axMapControl2绘制矩形框
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // 得到新范围 
            IEnvelope pEnv = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
            IActiveView pAv = pGra as IActiveView;
            // 在绘制前，清除 axMapControl2 中的任何图形元素 
            pGra.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pEle = pRectangleEle as IElement;
            pEle.Geometry = pEnv;
            // 设置鹰眼图中的红线框 
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            // 产生一个线符号对象 
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 2;
            pOutline.Color = pColor;
            // 设置颜色属性 
            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;
            // 设置填充符号的属性 
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGra.AddElement((IElement)pFillShapeEle, 0);
            // 刷新 
            pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        //axMapControl2鼠标响应，左键移动矩形框，右键绘制矩形框
        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (this.axMapControl2.Map.LayerCount != 0)
            {
                // 按下鼠标左键移动矩形框 
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    IEnvelope pEnvelope = this.axMapControl1.Extent;
                    pEnvelope.CenterAt(pPoint);
                    this.axMapControl1.Extent = pEnvelope;
                    this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                } 
                // 按下鼠标右键绘制矩形框 
                else if (e.button == 2)
                {
                    IEnvelope pEnvelop = this.axMapControl2.TrackRectangle();
                    this.axMapControl1.Extent = pEnvelop;
                    this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null); 
                }
            }
        }
        //移动axMapControl2矩形框，同时也改变axMapControl1显示范围。
        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            // 如果不是左键按下就直接返回 
            if (e.button != 1) return;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(e.mapX, e.mapY);
            this.axMapControl1.CenterAt(pPoint);
            this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }
    }
}
