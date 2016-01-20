using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;

namespace GISManager
{
    public sealed class CreateNewMapDocument : BaseCommand
    {
        private IHookHelper m_hookHelper = null;

        public CreateNewMapDocument()
        {
            //修改基础设置
            base.m_category = "地图文档操作";
            base.m_caption = "新建地图文档";
            base.m_message = "创建新的地图文档";
            base.m_toolTip = "新建地图文档";
            base.m_name = base.m_category + "_" + base.m_caption;
        }

        #region Overriden Class Methods

        //创建事件响应函数
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;
        }

        //点击事件响应函数
        public override void OnClick()
        {
            IMapControl3 mapControl = null;

            //如果容器是ToolbatControl，通过hook（钩）获取到MapControl
            if (m_hookHelper.Hook is IToolbarControl)
            {
                mapControl = (IMapControl3)((IToolbarControl)m_hookHelper.Hook).Buddy;
            }
            //如果容器是MapControl
            else if (m_hookHelper.Hook is IMapControl3)
            {
                mapControl = (IMapControl3)m_hookHelper.Hook;
            }
            else
            {
                MessageBox.Show("当前控件必须是MapControl!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //提示用户是否保存当前地图文档
            DialogResult res = MessageBox.Show("是否保存当前地图文档?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //启动保存命令
                ICommand command = new ControlsSaveAsDocCommandClass();
                command.OnCreate(m_hookHelper.Hook);
                command.OnClick();
            }

            //创建新Map
            IMap map = new MapClass();
            map.Name = "Map";

            //加载新地图
            mapControl.DocumentFilename = string.Empty;
            mapControl.Map = map;
        }

        #endregion
    }
}
