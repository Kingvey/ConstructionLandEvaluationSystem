using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

using ESRI.ArcGIS;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Catalog;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace GISManager
{
    public class MapDocumentOperation
    {
        //打开地图文档
        public static void OpenFromFile(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            try
            {
                ICommand pCommand;
                pCommand = new ControlsOpenDocCommandClass();
                pCommand.OnCreate(axMapControl.Object);
                pCommand.OnClick();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //保存地图文档
        public static void SaveMapDocument(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            string m_mapDocumentName = axMapControl.DocumentFilename;
            if (axMapControl.CheckMxFile(m_mapDocumentName))
            {
                //新建地图文档接口
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);
                //确定文档非只读文件
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }
                //用当前地图替换文档内容
                mapDoc.ReplaceContents((IMxdContents)axMapControl.Map);
                //保存文档
                mapDoc.Save(mapDoc.UsesRelativePaths, false);
                //关闭文档
                mapDoc.Close();
            }
        }
        //地图文档另存
        public static void SaveAsMapDocument(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            try
            {
                ICommand command;
                command = new ControlsSaveAsDocCommandClass();
                command.OnCreate(axMapControl.Object);
                command.OnClick();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
        }
        //新建地图文档
        public static void NewMapDocument(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            try
            {
                ICommand command = new CreateNewMapDocument();
                command.OnCreate(axMapControl.Object);
                command.OnClick();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
        }
        //添加图层
        public static void AddLayerData(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            try
            {
                ICommand pCommand;
                pCommand = new ControlsAddDataCommandClass();
                pCommand.OnCreate(axMapControl.Object);
                pCommand.OnClick();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } 
        }
    }
}
