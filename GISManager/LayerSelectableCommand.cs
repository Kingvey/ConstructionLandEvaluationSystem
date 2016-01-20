using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;

namespace GISManager
{
    public sealed class LayerSelectableCommand : BaseCommand, ICommandSubType
    {
        private IMapControl3 m_mapControl;
        private long m_subType;         //用来分类的

        public LayerSelectableCommand()
        {}

        public override string Caption　　//重写标题
        {
            get
            {
                if (m_subType == 1) return "图层可选";
                else return "图层不可选";
            }
        }

        public override bool Enabled　　//重写 Enabled 属性
        {
            get
            {
                ILayer layer = (ILayer)m_mapControl.CustomProperty;
                if (layer is IFeatureLayer)
                {
                    IFeatureLayer featureLayer = (IFeatureLayer)layer;
                    if (m_subType == 1) return !featureLayer.Selectable;
                    else return featureLayer.Selectable;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void OnCreate(object hook)      //重写 OnCreate 事件响应函数
        {
            m_mapControl = (IMapControl3)hook;
        }

        public override void OnClick()      //重写 OnClick 事件响应函数
        {
            IFeatureLayer layer = (IFeatureLayer)m_mapControl.CustomProperty;
            if (m_subType == 1) layer.Selectable = true;
            if (m_subType == 2) layer.Selectable = false;
        }

        #region //重写 ICommandSubType 接口的方法
        //重写 ICommandSubType 的 GetCount 方法
        public int GetCount()       //？？？
        {
            return 2;
        }
        //重写 ICommandSubType 的 SetSubType 方法
        public void SetSubType(int SubType)     //设置类型
        {
            m_subType = SubType;
        }
        #endregion
    }
}
