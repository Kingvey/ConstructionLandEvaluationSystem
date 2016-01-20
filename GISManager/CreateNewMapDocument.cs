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
            //�޸Ļ�������
            base.m_category = "��ͼ�ĵ�����";
            base.m_caption = "�½���ͼ�ĵ�";
            base.m_message = "�����µĵ�ͼ�ĵ�";
            base.m_toolTip = "�½���ͼ�ĵ�";
            base.m_name = base.m_category + "_" + base.m_caption;
        }

        #region Overriden Class Methods

        //�����¼���Ӧ����
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;
        }

        //����¼���Ӧ����
        public override void OnClick()
        {
            IMapControl3 mapControl = null;

            //���������ToolbatControl��ͨ��hook��������ȡ��MapControl
            if (m_hookHelper.Hook is IToolbarControl)
            {
                mapControl = (IMapControl3)((IToolbarControl)m_hookHelper.Hook).Buddy;
            }
            //���������MapControl
            else if (m_hookHelper.Hook is IMapControl3)
            {
                mapControl = (IMapControl3)m_hookHelper.Hook;
            }
            else
            {
                MessageBox.Show("��ǰ�ؼ�������MapControl!", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //��ʾ�û��Ƿ񱣴浱ǰ��ͼ�ĵ�
            DialogResult res = MessageBox.Show("�Ƿ񱣴浱ǰ��ͼ�ĵ�?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //������������
                ICommand command = new ControlsSaveAsDocCommandClass();
                command.OnCreate(m_hookHelper.Hook);
                command.OnClick();
            }

            //������Map
            IMap map = new MapClass();
            map.Name = "Map";

            //�����µ�ͼ
            mapControl.DocumentFilename = string.Empty;
            mapControl.Map = map;
        }

        #endregion
    }
}
