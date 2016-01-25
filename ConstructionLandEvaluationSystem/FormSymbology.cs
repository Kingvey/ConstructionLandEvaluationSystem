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

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.esriSystem;

namespace ConstructionLandEvaluationSystem
{
    public partial class FormSymbology : Form
    {
        esriSymbologyStyleClass pStyleClass;　　//获取显示的为点类、线类还是填充类等的，赋值给 symbologyControl 控件，然后就显示这一类符号
        public IStyleGalleryItem pStyleGalleryItem;　　//获取选择的项
        ILegendClass pLegendClass;　　//获取传递进来的图例
        ILayer pLayer;
        bool contextMenuMoreSymbolInitiated = false;　　//判断右键菜单是否已经初始化了
        bool change = false;

        public FormSymbology(ILegendClass tempLegendClass, ILayer tempLayer)
        {
            InitializeComponent();
            //this.ControlBox = false;   // 设置不出现关闭按钮
            pLegendClass = tempLegendClass;　　//通过点击 toccontrol 时候可以获得要素类的 LegendClass！
            pLayer = tempLayer;　　//点击的图层
        }

        private void SymbologyForm_Load(object sender, EventArgs e)
        {
            switch (((IFeatureLayer)pLayer).FeatureClass.ShapeType)　　//判断图层中要素类的图形类型，不同类型显示的调节值的控件不同
            {
                case esriGeometryType.esriGeometryPoint:　　//点
                    pStyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    lbColor.Visible = true;
                    lbWidth.Visible = true;
                    lbWidth.Text = "符号大小";
                    //lbAngle.Visible = true;
                    //btColor.Visible = true;
                    nudWidth.Visible = true;
                    cbColor.Visible = true;
                    //nudAngle.Visible = true;
                    break;
                case esriGeometryType.esriGeometryPolyline:　　//线
                    pStyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    lbColor.Visible = true;
                    lbColor.Location = System.Drawing.Point.Add(lbColor.Location, new Size(0, 12));
                    lbWidth.Visible = true;
                    lbWidth.Location = System.Drawing.Point.Add(lbWidth.Location, new Size(0, 24));
                    lbWidth.Text = "线符号粗细";
                    //btColor.Visible = true;
                    cbColor.Visible = true;
                    //btColor.Location = System.Drawing.Point.Add(btColor.Location, new Size(0, 12));
                    cbColor.Location = System.Drawing.Point.Add(cbColor.Location, new Size(0, 12));
                    nudWidth.Visible = true;
                    nudWidth.Location = System.Drawing.Point.Add(nudWidth.Location, new Size(0, 24));
                    break;
                case esriGeometryType.esriGeometryPolygon:　　//面
                    pStyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    lbColor.Visible = true;
                    lbWidth.Visible = true;
                    lbWidth.Text = "框线宽度";
                    lbOutlineColor.Visible = true;
                    //btColor.Visible = true;
                    //btOutlineColor.Visible = true;
                    nudWidth.Visible = true;
                    cbColor.Visible = true;
                    cbOutlineColor.Visible = true;
                    break;
                default:
                    this.Close();
                    break;
            }
            //ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path 可以获得 ArcGIS 的安装目录
            //获取 ESRI.ServerStyle 文件并加载入axSymbologyControl控件
            string stylePath = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path + @"Styles\ESRI.ServerStyle";
            if (!File.Exists(stylePath)) return;
            axSymbologyControl1.LoadStyleFile(stylePath);
            axSymbologyControl1.StyleClass = pStyleClass;　　//将上面获得的 pStyleClass 赋给axSymbologyControl控件，点线面
            //新建符号实例，用当前图例的符号类型 赋值，并将其添加到axSymbologyControl中
            IStyleGalleryItem pCurrentStyleGalleryItem = new StyleGalleryItem();
            pCurrentStyleGalleryItem.Name = "当前符号";
            pCurrentStyleGalleryItem.Item = pLegendClass.Symbol;　　
            ISymbologyStyleClass pSymbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);　　//QI，加入这个新建项
            pSymbologyStyleClass.AddItem(pCurrentStyleGalleryItem, 0);
            pSymbologyStyleClass.SelectItem(0);     //设置为选中状态
        }

        #region      //事件

        //axSymbologyControl空间SymbolItem选中事件相应函数
        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            pStyleGalleryItem = e.styleGalleryItem as IStyleGalleryItem;　　//获取选择项
            PreviewPicture();　　//在图片框中显示
            //点，将属性传递到调节的控件上
            if (((IFeatureLayer)pLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)　　
            {
                IRgbColor pColor = ((IMarkerSymbol)pStyleGalleryItem.Item).Color as IRgbColor;
                //btColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);      //颜色
                nudAngle.Value = Convert.ToDecimal(((IMarkerSymbol)pStyleGalleryItem.Item).Angle);  //角度
                nudWidth.Value = Convert.ToDecimal(((IMarkerSymbol)pStyleGalleryItem.Item).Size);   //大小
            }
            //线
            if (((IFeatureLayer)pLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                IRgbColor pColor = ((ILineSymbol)pStyleGalleryItem.Item).Color as IRgbColor;
                //btColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);      //颜色
                nudWidth.Value = Convert.ToDecimal(((ILineSymbol)pStyleGalleryItem.Item).Width);    //宽度
            }
            //面
            if (((IFeatureLayer)pLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                IRgbColor pColor = ((IFillSymbol)pStyleGalleryItem.Item).Color as IRgbColor;
                //btColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);      //填充色
                cbColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);      //填充色
                nudWidth.Value = Convert.ToDecimal(((IFillSymbol)pStyleGalleryItem.Item).Outline.Width);    //边框宽度
                pColor = ((IFillSymbol)pStyleGalleryItem.Item).Outline.Color as IRgbColor;
                //btOutlineColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);   //边框颜色
                cbOutlineColor.BackColor = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);   //边框颜色
            }
        }
        
        //点的大小、线的宽度、填充边框宽度变化响应事件
        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            switch (((IFeatureLayer)pLayer).FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    ((IMarkerSymbol)pStyleGalleryItem.Item).Size = Convert.ToDouble(nudWidth.Value);　　//点的大小，注意改后要在图片上显示
                    PreviewPicture();
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    ((ILineSymbol)pStyleGalleryItem.Item).Width = Convert.ToDouble(nudWidth.Value);　　//线的宽度
                    PreviewPicture();
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    ILineSymbol pLineSymbol = ((IFillSymbol)pStyleGalleryItem.Item).Outline;　　//实例化一个 linesymbol 然后赋值过去，直接赋值的话没有反应
                    pLineSymbol.Width = Convert.ToDouble(nudWidth.Value);　　　　　　　　//赋值
                    ((IFillSymbol)pStyleGalleryItem.Item).Outline = pLineSymbol;　　　　　　//在赋值给填充的外框
                    PreviewPicture();
                    break;
                default:
                    break;
            }
        }
        
        //点的角度变化响应事件
        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            ((IMarkerSymbol)pStyleGalleryItem.Item).Angle = Convert.ToDouble(nudAngle.Value);
            PreviewPicture();
        }
        
        //更多符号按钮点击响应事件
        private void btMore_Click(object sender, EventArgs e)
        {
            if (contextMenuMoreSymbolInitiated == false)　　　　　　　　//如果没有初始化，则首先初始化
            {
                //获取 styles 文件夹，并将里面 *.ServerStyle 文件赋值到数组中，用于加载
                string stylePath = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path + @"Styles";  
                string[] strFiles = Directory.GetFiles(stylePath, "*.ServerStyle");
                ToolStripMenuItem[] symbolContextMenuItem = new ToolStripMenuItem[strFiles.Length + 1];　　//定义菜单项，最后一个为另类
                for (int i = 0; i < strFiles.Length; i++)
                {
                    symbolContextMenuItem[i] = new ToolStripMenuItem();　　　　//首先新建，然后允许选中时是否有 checked 变化
                    symbolContextMenuItem[i].CheckOnClick = true;
                    symbolContextMenuItem[i].Text = System.IO.Path.GetFileNameWithoutExtension(strFiles[i]);　　//将名字赋值给 text 属性，完整地址赋值给 name，便于加载
                    if (symbolContextMenuItem[i].Text == "ESRI")
                        symbolContextMenuItem[i].Checked = true;　　　　　　//默认是加载的这个文件，所以默认选中
                    symbolContextMenuItem[i].Name = strFiles[i];
                }
                symbolContextMenuItem[strFiles.Length] = new ToolStripMenuItem();　　//最后一个菜单项
                symbolContextMenuItem[strFiles.Length].Text = "更多工具";
                symbolContextMenuItem[strFiles.Length].Name = "AddMoreSymbol";

                contextMenuStrip1.Items.AddRange(symbolContextMenuItem);　　　　//将菜单项添加到右键菜单中
                contextMenuMoreSymbolInitiated = true;　　　　　　　　　　　　　　//将此值赋值为 true，以便之后不用执行这一部分了
            }
            contextMenuStrip1.Show(btMore.Location);　　　　//弹出右键菜单
        }
        
        //右键菜单点击响应事件
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem pToolStripMenuItem = e.ClickedItem as ToolStripMenuItem;　　//首先获取点击项
            if (pToolStripMenuItem.Name == "AddMoreSymbol")　　　　　　　　　　　　　　//最后一项，打开对话框，浏览想要打开的文件
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "添加符号库文件";
                openFileDialog1.Filter = "符号库文件|*.ServerStyle";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    axSymbologyControl1.LoadStyleFile(openFileDialog1.FileName);
                    axSymbologyControl1.Refresh();
                }
            }
            else　//其他项
            {
                if (pToolStripMenuItem.Checked == false)　//之前若是没有选中的，则加载，同时也就选中了
                {
                    axSymbologyControl1.LoadStyleFile(pToolStripMenuItem.Name);
                    axSymbologyControl1.Refresh();
                }
                else　//之前若是选中的，现在就要删除，同时也就不再选中了
                {
                    axSymbologyControl1.RemoveFile(pToolStripMenuItem.Name);
                    axSymbologyControl1.Refresh();
                }
            }
        }
        
        //点、线、面填充颜色变化响应事件
        private void cbColor_MouseUp(object sender, MouseEventArgs e)
        {
            IRgbColor pColor = new RgbColor();　　　　//颜色实例
            pColor.RGB = 255;
            tagRECT pTag = new tagRECT();　　　　//用于下面显示 ColorPalette 的位置
            pTag.left = cbColor.PointToScreen(System.Drawing.Point.Empty).X;　　　　　　　　　　　　//按钮控件的左边全局横坐标
            pTag.bottom = cbColor.PointToScreen(System.Drawing.Point.Empty).Y + cbColor.Height;　　//按钮控件的下边全局纵坐标
            IColorPalette pColorPalette = new ColorPalette();
            pColorPalette.TrackPopupMenu(ref pTag, pColor, false, 0);　　   //显示 ColorPalette
            pColor = pColorPalette.Color as IRgbColor;　　　　　　　　　　//获取选中的颜色
            Color color = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);　　//将颜色转为 C# 颜色
            btColor.BackColor = color;
            cbColor.BackColor = color;

            switch (((IFeatureLayer)pLayer).FeatureClass.ShapeType)　　//判断几何体样式
            {
                case esriGeometryType.esriGeometryPoint:　　　　　　　　　　//点
                    ((IMarkerSymbol)pStyleGalleryItem.Item).Color = pColor;　　//转为 IMarkerSymbol，注意改好后要在图片上显示
                    PreviewPicture();
                    break;
                case esriGeometryType.esriGeometryPolyline:　　　　　　　　//线
                    ((ILineSymbol)pStyleGalleryItem.Item).Color = pColor;　　//转为 ILineSymbol
                    PreviewPicture();
                    break;
                case esriGeometryType.esriGeometryPolygon:　　　　　　//面
                    ((IFillSymbol)pStyleGalleryItem.Item).Color = pColor;　　//转为 IFillSymbol
                    PreviewPicture();
                    break;
                default:
                    break;
            }
        }
        
        //填充外边框颜色变化响应事件
        private void cbOutlineColor_MouseUp(object sender, MouseEventArgs e)
        {
            IRgbColor pColor = new RgbColor();
            pColor.RGB = 255;
            tagRECT ptagRECT = new tagRECT();
            ptagRECT.left = cbOutlineColor.PointToScreen(System.Drawing.Point.Empty).X;
            ptagRECT.bottom = cbOutlineColor.PointToScreen(System.Drawing.Point.Empty).Y + cbOutlineColor.Height;
            IColorPalette pColorPalette = new ColorPalette();
            pColorPalette.TrackPopupMenu(ref ptagRECT, pColor, false, 0);
            pColor = pColorPalette.Color as IRgbColor;
            Color color = Color.FromArgb(pColor.Red, pColor.Green, pColor.Blue);
            //btOutlineColor.BackColor = color;
            cbOutlineColor.BackColor = color;
            ILineSymbol pLineSymbol = ((IFillSymbol)pStyleGalleryItem.Item).Outline;
            pLineSymbol.Color = pColor;
            ((IFillSymbol)pStyleGalleryItem.Item).Outline = pLineSymbol;
            PreviewPicture();
        }
        
        //确认按钮点击响应事件
        private void btOK_Click(object sender, EventArgs e)
        {
            change = true;
            this.Close();
        }
        
        //取消按钮点击响应事件
        private void btCancel_Click(object sender, EventArgs e)
        {
            change = false;
            this.Close();
        }
        
        //关闭按钮
        private void SymbologyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!change)
            {
                IStyleGalleryItem pCurrentStyleGalleryItem = new StyleGalleryItem();
                pCurrentStyleGalleryItem.Name = "当前符号";
                pCurrentStyleGalleryItem.Item = pLegendClass.Symbol;
                pStyleGalleryItem = pCurrentStyleGalleryItem;
            }
        }

        #endregion

        // 预览   将 pStyleGalleryItem 反映到 picture 上
        private void PreviewPicture()
        {
            ISymbologyStyleClass pSymbologyStyle = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);
            stdole.IPictureDisp picture = pSymbologyStyle.PreviewItem(pStyleGalleryItem, pictureBox1.Width, pictureBox1.Height);　　//建立实例
            Image image = Image.FromHbitmap(new IntPtr(picture.Handle));　　//转成 C# 支持的 Image 实例
            pictureBox1.Image = image;
        }
    }
}
