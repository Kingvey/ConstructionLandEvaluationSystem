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
    public sealed class ScaleThresholdsCommand : BaseCommand, ICommandSubType
    {
        private IMapControl3 m_mapControl;
        private long m_subType;         //用来分类的

        public ScaleThresholdsCommand()
        {}

        public override string Caption　　//重写标题
        {
            get
            {
                if (m_subType == 1)
                {
                    return "设置最大显示比例尺";
                }
                else if (m_subType == 2)
                {
                    return "设置最小显示比例尺";
                }
                else
                {
                    return "取消比例尺显示限制";
                }
            }
        }

        public override bool Enabled　　//重写 Enabled 属性
        {
            get
            {
                bool enabled = true;　　　　//默认情况下都是 true 的
                ILayer layer = (ILayer)m_mapControl.CustomProperty;　　//获取所指的 layer，在 MouseDown 事件中有获取到这个 layer。

                if (m_subType == 3)　　//如果选择的是 3，且最大和最小比例尺都没有设置，则为 false！
                {
                    if ((layer.MaximumScale == 0) && (layer.MinimumScale == 0))
                    {
                        enabled = false;
                    }
                }
                return enabled;
            }
        }

        public override void OnCreate(object hook)      //重写 OnCreate 事件响应函数
        {
            m_mapControl = (IMapControl3)hook;
        }

        public override void OnClick()      //重写 OnClick 事件响应函数
        {
            ILayer layer = (ILayer)m_mapControl.CustomProperty;
            if (m_subType == 1) layer.MaximumScale = m_mapControl.MapScale;
            if (m_subType == 2) layer.MinimumScale = m_mapControl.MapScale;
            if (m_subType == 3)
            {
                layer.MaximumScale = 0;
                layer.MinimumScale = 0;
            }
            m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        #region //重写 ICommandSubType 接口的方法
        //重写 ICommandSubType 的 GetCount 方法
        public int GetCount()       //？？？
        {
            return 3;
        }
        //重写 ICommandSubType 的 SetSubType 方法
        public void SetSubType(int SubType)     //设置类型
        {
            m_subType = SubType;
        }
        #endregion
    }
}
