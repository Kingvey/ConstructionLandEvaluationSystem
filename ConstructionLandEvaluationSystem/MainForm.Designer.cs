namespace ConstructionLandEvaluationSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_OpenMapDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_AddLayerData = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NewMapDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SaveMapDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SaveAsMapDoc = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_SetNull = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_Pan = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ZoomOutFixed = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ZoomInFixed = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ExtentBack = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ExtentForward = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_ZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_FullExtent = new DevExpress.XtraBars.BarButtonItem();
            this.btn_MapTool_Query = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup_ZoomChangeFixd = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonGroup_ExtentChange = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonGroup2 = new DevExpress.XtraBars.BarButtonGroup();
            this.ribbonPage_Map = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup_MapFileOperation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_MapBrowsingTools = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_Files = new DevExpress.XtraTab.XtraTabPage();
            this.comboBox_RootPathSelector = new System.Windows.Forms.ComboBox();
            this.btn_AddRootPath = new DevExpress.XtraEditors.SimpleButton();
            this.treeList_FileList = new DevExpress.XtraTreeList.TreeList();
            this.imageList_File = new System.Windows.Forms.ImageList(this.components);
            this.xtraTabPage_Layers = new DevExpress.XtraTab.XtraTabPage();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_DataView = new DevExpress.XtraTab.XtraTabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage_Files.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_FileList)).BeginInit();
            this.xtraTabPage_Layers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage_DataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.btn_OpenMapDoc,
            this.btn_AddLayerData,
            this.btn_NewMapDoc,
            this.btn_SaveMapDoc,
            this.btn_SaveAsMapDoc,
            this.btn_MapTool_SetNull,
            this.btn_MapTool_Pan,
            this.btn_MapTool_ZoomOutFixed,
            this.btn_MapTool_ZoomInFixed,
            this.btn_MapTool_ExtentBack,
            this.btn_MapTool_ExtentForward,
            this.btn_MapTool_ZoomOut,
            this.btn_MapTool_ZoomIn,
            this.btn_MapTool_FullExtent,
            this.btn_MapTool_Query,
            this.barButtonGroup_ZoomChangeFixd,
            this.barButtonGroup_ExtentChange,
            this.barButtonGroup1,
            this.barButtonGroup2});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage_Map});
            this.ribbonControl.Size = new System.Drawing.Size(884, 120);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btn_OpenMapDoc
            // 
            this.btn_OpenMapDoc.Caption = "打开地图";
            this.btn_OpenMapDoc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_OpenMapDoc.Id = 1;
            this.btn_OpenMapDoc.LargeGlyph = global::ConstructionLandEvaluationSystem.Properties.Resources.OpenFile;
            this.btn_OpenMapDoc.Name = "btn_OpenMapDoc";
            this.btn_OpenMapDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_OpenMapDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_OpenMapDoc_ItemClick);
            // 
            // btn_AddLayerData
            // 
            this.btn_AddLayerData.Caption = "添加图层";
            this.btn_AddLayerData.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_AddLayerData.Id = 2;
            this.btn_AddLayerData.LargeGlyph = global::ConstructionLandEvaluationSystem.Properties.Resources.AddLayer;
            this.btn_AddLayerData.Name = "btn_AddLayerData";
            this.btn_AddLayerData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_AddLayerData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AddLayerData_ItemClick);
            // 
            // btn_NewMapDoc
            // 
            this.btn_NewMapDoc.Caption = "新建";
            this.btn_NewMapDoc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_NewMapDoc.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.NewFile;
            this.btn_NewMapDoc.Id = 3;
            this.btn_NewMapDoc.Name = "btn_NewMapDoc";
            this.btn_NewMapDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.btn_NewMapDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NewMapDoc_ItemClick);
            // 
            // btn_SaveMapDoc
            // 
            this.btn_SaveMapDoc.Caption = "保存";
            this.btn_SaveMapDoc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_SaveMapDoc.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.Save;
            this.btn_SaveMapDoc.Id = 4;
            this.btn_SaveMapDoc.Name = "btn_SaveMapDoc";
            this.btn_SaveMapDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.btn_SaveMapDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveMapDoc_ItemClick);
            // 
            // btn_SaveAsMapDoc
            // 
            this.btn_SaveAsMapDoc.Caption = "另存为...";
            this.btn_SaveAsMapDoc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_SaveAsMapDoc.Id = 5;
            this.btn_SaveAsMapDoc.LargeGlyph = global::ConstructionLandEvaluationSystem.Properties.Resources.SaveAs;
            this.btn_SaveAsMapDoc.Name = "btn_SaveAsMapDoc";
            this.btn_SaveAsMapDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_SaveAsMapDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveAsMapDoc_ItemClick);
            // 
            // btn_MapTool_SetNull
            // 
            this.btn_MapTool_SetNull.Caption = "指针";
            this.btn_MapTool_SetNull.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_SetNull.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.MousePointer;
            this.btn_MapTool_SetNull.Id = 6;
            this.btn_MapTool_SetNull.Name = "btn_MapTool_SetNull";
            this.btn_MapTool_SetNull.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_MapTool_SetNull.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_SetNull_ItemClick);
            // 
            // btn_MapTool_Pan
            // 
            this.btn_MapTool_Pan.Caption = "平移";
            this.btn_MapTool_Pan.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_Pan.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.Pan;
            this.btn_MapTool_Pan.Id = 7;
            this.btn_MapTool_Pan.Name = "btn_MapTool_Pan";
            this.btn_MapTool_Pan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_MapTool_Pan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_Pan_ItemClick);
            // 
            // btn_MapTool_ZoomOutFixed
            // 
            this.btn_MapTool_ZoomOutFixed.Caption = "逐级缩小";
            this.btn_MapTool_ZoomOutFixed.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ZoomOutFixed.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.ZoomOutFixed;
            this.btn_MapTool_ZoomOutFixed.Id = 8;
            this.btn_MapTool_ZoomOutFixed.Name = "btn_MapTool_ZoomOutFixed";
            this.btn_MapTool_ZoomOutFixed.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ZoomOutFixed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ZoomOutFixed_ItemClick);
            // 
            // btn_MapTool_ZoomInFixed
            // 
            this.btn_MapTool_ZoomInFixed.Caption = "逐级放大";
            this.btn_MapTool_ZoomInFixed.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ZoomInFixed.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.ZoomInFixed;
            this.btn_MapTool_ZoomInFixed.Id = 9;
            this.btn_MapTool_ZoomInFixed.Name = "btn_MapTool_ZoomInFixed";
            this.btn_MapTool_ZoomInFixed.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ZoomInFixed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ZoomInFixed_ItemClick);
            // 
            // btn_MapTool_ExtentBack
            // 
            this.btn_MapTool_ExtentBack.Caption = "上一视图";
            this.btn_MapTool_ExtentBack.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ExtentBack.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.ExtentBack;
            this.btn_MapTool_ExtentBack.Id = 10;
            this.btn_MapTool_ExtentBack.Name = "btn_MapTool_ExtentBack";
            this.btn_MapTool_ExtentBack.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ExtentBack.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ExtentBack_ItemClick);
            // 
            // btn_MapTool_ExtentForward
            // 
            this.btn_MapTool_ExtentForward.Caption = "下一视图";
            this.btn_MapTool_ExtentForward.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ExtentForward.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.ExtentForward;
            this.btn_MapTool_ExtentForward.Id = 11;
            this.btn_MapTool_ExtentForward.Name = "btn_MapTool_ExtentForward";
            this.btn_MapTool_ExtentForward.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ExtentForward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ExtentForward_ItemClick);
            // 
            // btn_MapTool_ZoomOut
            // 
            this.btn_MapTool_ZoomOut.Caption = "缩小";
            this.btn_MapTool_ZoomOut.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ZoomOut.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.Zoomout;
            this.btn_MapTool_ZoomOut.Id = 12;
            this.btn_MapTool_ZoomOut.Name = "btn_MapTool_ZoomOut";
            this.btn_MapTool_ZoomOut.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ZoomOut_ItemClick);
            // 
            // btn_MapTool_ZoomIn
            // 
            this.btn_MapTool_ZoomIn.Caption = "放大";
            this.btn_MapTool_ZoomIn.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_ZoomIn.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.ZoomIn;
            this.btn_MapTool_ZoomIn.Id = 13;
            this.btn_MapTool_ZoomIn.Name = "btn_MapTool_ZoomIn";
            this.btn_MapTool_ZoomIn.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_ZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_ZoomIn_ItemClick);
            // 
            // btn_MapTool_FullExtent
            // 
            this.btn_MapTool_FullExtent.Caption = "全局视图";
            this.btn_MapTool_FullExtent.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_FullExtent.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.FullExtend;
            this.btn_MapTool_FullExtent.Id = 14;
            this.btn_MapTool_FullExtent.Name = "btn_MapTool_FullExtent";
            this.btn_MapTool_FullExtent.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_FullExtent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_FullExtent_ItemClick);
            // 
            // btn_MapTool_Query
            // 
            this.btn_MapTool_Query.Caption = "属性查询";
            this.btn_MapTool_Query.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_MapTool_Query.Glyph = global::ConstructionLandEvaluationSystem.Properties.Resources.Query;
            this.btn_MapTool_Query.Id = 15;
            this.btn_MapTool_Query.Name = "btn_MapTool_Query";
            this.btn_MapTool_Query.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btn_MapTool_Query.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_MapTool_Query_ItemClick);
            // 
            // barButtonGroup_ZoomChangeFixd
            // 
            this.barButtonGroup_ZoomChangeFixd.Caption = "逐级缩放";
            this.barButtonGroup_ZoomChangeFixd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonGroup_ZoomChangeFixd.Id = 16;
            this.barButtonGroup_ZoomChangeFixd.ItemLinks.Add(this.btn_MapTool_ZoomOutFixed);
            this.barButtonGroup_ZoomChangeFixd.ItemLinks.Add(this.btn_MapTool_ZoomInFixed);
            this.barButtonGroup_ZoomChangeFixd.Name = "barButtonGroup_ZoomChangeFixd";
            // 
            // barButtonGroup_ExtentChange
            // 
            this.barButtonGroup_ExtentChange.Caption = "视图变换";
            this.barButtonGroup_ExtentChange.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonGroup_ExtentChange.Id = 17;
            this.barButtonGroup_ExtentChange.ItemLinks.Add(this.btn_MapTool_ExtentBack);
            this.barButtonGroup_ExtentChange.ItemLinks.Add(this.btn_MapTool_ExtentForward);
            this.barButtonGroup_ExtentChange.Name = "barButtonGroup_ExtentChange";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonGroup1.Id = 18;
            this.barButtonGroup1.ItemLinks.Add(this.btn_MapTool_ZoomIn);
            this.barButtonGroup1.ItemLinks.Add(this.btn_MapTool_FullExtent);
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonGroup2
            // 
            this.barButtonGroup2.Caption = "barButtonGroup2";
            this.barButtonGroup2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonGroup2.Id = 19;
            this.barButtonGroup2.ItemLinks.Add(this.btn_MapTool_ZoomOut);
            this.barButtonGroup2.ItemLinks.Add(this.btn_MapTool_Query);
            this.barButtonGroup2.Name = "barButtonGroup2";
            // 
            // ribbonPage_Map
            // 
            this.ribbonPage_Map.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup_MapFileOperation,
            this.ribbonPageGroup_MapBrowsingTools});
            this.ribbonPage_Map.Name = "ribbonPage_Map";
            this.ribbonPage_Map.Text = "地图";
            // 
            // ribbonPageGroup_MapFileOperation
            // 
            this.ribbonPageGroup_MapFileOperation.ItemLinks.Add(this.btn_NewMapDoc);
            this.ribbonPageGroup_MapFileOperation.ItemLinks.Add(this.btn_SaveMapDoc);
            this.ribbonPageGroup_MapFileOperation.ItemLinks.Add(this.btn_OpenMapDoc);
            this.ribbonPageGroup_MapFileOperation.ItemLinks.Add(this.btn_AddLayerData);
            this.ribbonPageGroup_MapFileOperation.ItemLinks.Add(this.btn_SaveAsMapDoc);
            this.ribbonPageGroup_MapFileOperation.Name = "ribbonPageGroup_MapFileOperation";
            this.ribbonPageGroup_MapFileOperation.Text = "文件操作";
            // 
            // ribbonPageGroup_MapBrowsingTools
            // 
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.btn_MapTool_SetNull);
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.btn_MapTool_Pan);
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.barButtonGroup_ZoomChangeFixd);
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.barButtonGroup1);
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.barButtonGroup_ExtentChange);
            this.ribbonPageGroup_MapBrowsingTools.ItemLinks.Add(this.barButtonGroup2);
            this.ribbonPageGroup_MapBrowsingTools.Name = "ribbonPageGroup_MapBrowsingTools";
            this.ribbonPageGroup_MapBrowsingTools.Text = "地图浏览";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 120);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(884, 441);
            this.splitContainerControl1.SplitterPosition = 248;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Files;
            this.xtraTabControl1.Size = new System.Drawing.Size(248, 441);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_Files,
            this.xtraTabPage_Layers});
            // 
            // xtraTabPage_Files
            // 
            this.xtraTabPage_Files.Controls.Add(this.comboBox_RootPathSelector);
            this.xtraTabPage_Files.Controls.Add(this.btn_AddRootPath);
            this.xtraTabPage_Files.Controls.Add(this.treeList_FileList);
            this.xtraTabPage_Files.Name = "xtraTabPage_Files";
            this.xtraTabPage_Files.Size = new System.Drawing.Size(242, 412);
            this.xtraTabPage_Files.Text = "文件";
            // 
            // comboBox_RootPathSelector
            // 
            this.comboBox_RootPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_RootPathSelector.FormattingEnabled = true;
            this.comboBox_RootPathSelector.Location = new System.Drawing.Point(2, 3);
            this.comboBox_RootPathSelector.Name = "comboBox_RootPathSelector";
            this.comboBox_RootPathSelector.Size = new System.Drawing.Size(207, 20);
            this.comboBox_RootPathSelector.TabIndex = 4;
            this.comboBox_RootPathSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox_RootPathSelector_SelectedIndexChanged);
            // 
            // btn_AddRootPath
            // 
            this.btn_AddRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddRootPath.Location = new System.Drawing.Point(215, 3);
            this.btn_AddRootPath.Name = "btn_AddRootPath";
            this.btn_AddRootPath.Size = new System.Drawing.Size(24, 20);
            this.btn_AddRootPath.TabIndex = 3;
            this.btn_AddRootPath.Text = "...";
            this.btn_AddRootPath.Click += new System.EventHandler(this.btn_AddRootPath_Click);
            // 
            // treeList_FileList
            // 
            this.treeList_FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList_FileList.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White;
            this.treeList_FileList.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.treeList_FileList.ImageIndexFieldName = "";
            this.treeList_FileList.KeyFieldName = "";
            this.treeList_FileList.Location = new System.Drawing.Point(0, 29);
            this.treeList_FileList.Name = "treeList_FileList";
            this.treeList_FileList.OptionsBehavior.Editable = false;
            this.treeList_FileList.OptionsBehavior.EnableFiltering = true;
            this.treeList_FileList.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeList_FileList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.treeList_FileList.OptionsView.ShowColumns = false;
            this.treeList_FileList.OptionsView.ShowHorzLines = false;
            this.treeList_FileList.OptionsView.ShowIndicator = false;
            this.treeList_FileList.OptionsView.ShowVertLines = false;
            this.treeList_FileList.ParentFieldName = "";
            this.treeList_FileList.SelectImageList = this.imageList_File;
            this.treeList_FileList.Size = new System.Drawing.Size(242, 388);
            this.treeList_FileList.TabIndex = 0;
            this.treeList_FileList.DoubleClick += new System.EventHandler(this.treeList_FileList_DoubleClick);
            // 
            // imageList_File
            // 
            this.imageList_File.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_File.ImageStream")));
            this.imageList_File.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_File.Images.SetKeyName(0, "folder.png");
            this.imageList_File.Images.SetKeyName(1, "Word16.png");
            this.imageList_File.Images.SetKeyName(2, "Excel16.png");
            this.imageList_File.Images.SetKeyName(3, "PowerPoint16.png");
            this.imageList_File.Images.SetKeyName(4, "PDF16.png");
            this.imageList_File.Images.SetKeyName(5, "Picture16.png");
            this.imageList_File.Images.SetKeyName(6, "Database16.png");
            this.imageList_File.Images.SetKeyName(7, "INI16.png");
            this.imageList_File.Images.SetKeyName(8, "EXE16.png");
            this.imageList_File.Images.SetKeyName(9, "Map16.png");
            this.imageList_File.Images.SetKeyName(10, "OtherFile16.png");
            // 
            // xtraTabPage_Layers
            // 
            this.xtraTabPage_Layers.Controls.Add(this.axMapControl2);
            this.xtraTabPage_Layers.Controls.Add(this.axTOCControl1);
            this.xtraTabPage_Layers.Name = "xtraTabPage_Layers";
            this.xtraTabPage_Layers.Size = new System.Drawing.Size(242, 412);
            this.xtraTabPage_Layers.Text = "图层";
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(242, 253);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.OnMouseUp += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseUpEventHandler(this.axTOCControl1_OnMouseUp);
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Images = this.imageList_File;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage_DataView;
            this.xtraTabControl2.Size = new System.Drawing.Size(631, 441);
            this.xtraTabControl2.TabIndex = 0;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_DataView});
            this.xtraTabControl2.CloseButtonClick += new System.EventHandler(this.xtraTabControl2_CloseButtonClick);
            // 
            // xtraTabPage_DataView
            // 
            this.xtraTabPage_DataView.Controls.Add(this.axMapControl1);
            this.xtraTabPage_DataView.ImageIndex = 9;
            this.xtraTabPage_DataView.Name = "xtraTabPage_DataView";
            this.xtraTabPage_DataView.Size = new System.Drawing.Size(625, 410);
            this.xtraTabPage_DataView.Text = "地图数据视图";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(625, 410);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(852, 0);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl2.Location = new System.Drawing.Point(0, 250);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(242, 162);
            this.axMapControl2.TabIndex = 1;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "建设用地空间拓展定量评价系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage_Files.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList_FileList)).EndInit();
            this.xtraTabPage_Layers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage_DataView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage_Map;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup_MapFileOperation;
        private DevExpress.XtraBars.BarButtonItem btn_OpenMapDoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup_MapBrowsingTools;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Files;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Layers;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_DataView;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private DevExpress.XtraBars.BarButtonItem btn_AddLayerData;
        private DevExpress.XtraBars.BarButtonItem btn_NewMapDoc;
        private DevExpress.XtraBars.BarButtonItem btn_SaveMapDoc;
        private DevExpress.XtraBars.BarButtonItem btn_SaveAsMapDoc;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_SetNull;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_Pan;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ZoomOutFixed;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ZoomInFixed;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ExtentBack;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ExtentForward;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ZoomOut;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_ZoomIn;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_FullExtent;
        private DevExpress.XtraBars.BarButtonItem btn_MapTool_Query;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup_ZoomChangeFixd;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup_ExtentChange;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup2;
        private DevExpress.XtraEditors.SimpleButton btn_AddRootPath;
        private DevExpress.XtraTreeList.TreeList treeList_FileList;
        private System.Windows.Forms.ComboBox comboBox_RootPathSelector;
        private System.Windows.Forms.ImageList imageList_File;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
    }
}