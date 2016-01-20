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
    public class ViewTools
    {
        //设置当前工具为空
        public static void SetNull(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            IMapControl2 mapControl = (IMapControl2)axMapControl.Object;
            mapControl.MousePointer = esriControlsMousePointer.esriPointerArrow;
            mapControl.CurrentTool = null;
        }
        //平移
        public static void Pan(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapPanToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        //放大
        public static void ZoomIn(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomInToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        //缩小
        public static void ZoomOut(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomOutToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        // 比例放大
        public static void ZoomInFixed(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomInFixedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        //比例缩小
        public static void ZoomOutFixed(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomOutFixedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        //上一场景
        public static void ZoomToLastExtentBack(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomToLastExtentBackCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        //下一场景
        public static void ZoomToLastExtentForward(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsMapZoomToLastExtentForwardCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        //全局显示
        public static void FullExtend(ESRI.ArcGIS.Controls.AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsMapFullExtentCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }

        // 选择
        public static void Select(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
        // 反选
        public static void SwitchSelection(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSwitchSelectionCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        // 放大到选择对象
        public static void ZoomToSelected(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsZoomToSelectedCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        // 清除选择
        public static void ClearSelection(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsClearSelectionCommand();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        // 全选
        public static void SelectAll(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectAllCommandClass();
            pCommand.OnCreate(axMapControl.Object);
            pCommand.OnClick();
        }
        // 选择并查询
        public static void SelectFeatures(AxMapControl axMapControl)
        {
            if (axMapControl == null)
            {
                return;
            }
            ICommand pCommand;
            pCommand = new ControlsSelectFeaturesToolClass();
            pCommand.OnCreate(axMapControl.Object);
            axMapControl.CurrentTool = (ITool)pCommand;
        }
    }
}
