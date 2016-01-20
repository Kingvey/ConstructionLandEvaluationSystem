using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace GISManager
{
    public sealed class RemoveLayerCommand : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public RemoveLayerCommand()
        {
            base.m_caption = "移除图层";
        }
        //创建事件响应函数
        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
        //点击事件响应函数
        public override void OnClick()
        {
            ILayer layer = (ILayer)m_mapControl.CustomProperty;
            m_mapControl.Map.DeleteLayer(layer);
        }
    }
}
