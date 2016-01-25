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
    public sealed class OpenAttributeCommand : BaseCommand
    {
        IMapControl3 m_mapControl;  
        AxMapControl _MapControl;

        public OpenAttributeCommand(AxMapControl pMapControl)  
        {  
            base.m_caption = "查看属性表";  
            _MapControl = pMapControl;  
        }  
  
        public override void OnClick()  
        {
            FormAttributeTable formtable = new FormAttributeTable(_MapControl, m_mapControl);  
            formtable.Show();  
  
        }  
  
        public override void OnCreate(object hook)  
        {  
            m_mapControl = (IMapControl3)hook;  
        } 
    }
}
