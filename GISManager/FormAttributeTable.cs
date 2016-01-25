using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;  

namespace GISManager
{
    public partial class FormAttributeTable : Form
    {
        #region     //预定义变量
        AxMapControl _MapControl;
        IMapControl3 m_mapControl;
        IFeatureLayer pFLayer;
        IFeatureClass pFClass;
        IFeatureCursor pFCuror;
        public DataTable dt2;
        ITableSort pTs;//处理排序  
        bool up = true;
        int row_index = 0;
        int col_index = 0;
        public string strAddField;
        private string curColumnName;
        RowAndCol[] pRowAndCol = new RowAndCol[10000];
        int count = 0;

        #endregion

        public FormAttributeTable(AxMapControl pMapControl, IMapControl3 pMapCtrl)
        {
            InitializeComponent();
            _MapControl = pMapControl;
            m_mapControl = pMapCtrl;
            ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            pFLayer = pLayer as IFeatureLayer;
            pFClass = pFLayer.FeatureClass;
        }

        private void FormAttributeTable_Load(object sender, EventArgs e)
        {
            pFCuror = pFClass.Search(null, false);
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }
        
        #region     //点击事件
        
        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddField formaddfield = new FormAddField(pFLayer, gdvAttribute);
            formaddfield.Show();
            pFCuror = pFClass.Search(null, false);
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }

        private void 编辑属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gdvAttribute.ReadOnly = false;
            this.gdvAttribute.CurrentCell = this.gdvAttribute.Rows[this.gdvAttribute.Rows.Count - 2].Cells[0];
        }
        
        private void 保存编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITable pTable;
            //pTable = pFeatureClass.CreateFeature().Table;//很重要的一种获取shp表格的一种方式           
            pTable = pFLayer as ITable;
            //将改变的记录值传给shp中的表  
            int i = 0;
            while (pRowAndCol[i].Column != 0 || pRowAndCol[i].Row != 0)
            {
                IRow pRow;
                pRow = pTable.GetRow(pRowAndCol[i].Row);
                pRow.set_Value(pRowAndCol[i].Column, pRowAndCol[i].Value);
                pRow.Store();
                i++;
            }
            count = 0;
            for (int j = 0; j < i; j++)
            {
                pRowAndCol[j].Row = 0;
                pRowAndCol[j].Column = 0;
                pRowAndCol[j].Value = null;
            }
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK);
            this.gdvAttribute.ReadOnly = true;
            pFCuror = pFClass.Search(null, false);
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }
        
        private void 取消编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gdvAttribute.DataSource = null;
            this.gdvAttribute.ReadOnly = true;
            pFCuror = pFClass.Search(null, false);
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }
        
        private void 删除选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((MessageBox.Show("确定要删除吗", "警告", MessageBoxButtons.YesNo)) == DialogResult.Yes))
            {
                ITable pTable = pFLayer as ITable;
                IRow pRow = pTable.GetRow(row_index);
                pRow.Delete();
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK);
                _MapControl.ActiveView.Refresh();

                pFCuror = pFClass.Search(null, false);
                RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
            }
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;
            ExportExcel(gdvAttribute, pFields);  
        }

        //点击gdvAttribute数据表行头
        private void gdvAttribute_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (gdvAttribute.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
            //    gdvAttribute.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        //点击gdvAttribute表列头，，，显示右键菜单
        private void gdvAttribute_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (gdvAttribute.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
            //    gdvAttribute.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            if (e.Button == MouseButtons.Right && e.ColumnIndex > -1)  //e.RowIndex>-1 非表头的Cell  
            {
                col_index = e.ColumnIndex;
                curColumnName = this.gdvAttribute.Columns[col_index].Name;
                Point _Point = gdvAttribute.PointToClient(System.Windows.Forms.Cursor.Position);
                this.contextMenuStrip1.Show(gdvAttribute, _Point);
            }
        }

        #endregion

        #region     //右键相关事件

        private void 正序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up = true;
            SortFeatures(pFClass); 
        }

        private void 逆序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up = false;
            SortFeatures(pFClass);  
        }

        private void 删除字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strResult = "";
            if ((MessageBox.Show("确定要删除该字段吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                strResult = DeleteField(pFLayer, curColumnName);
                gdvAttribute.Columns.Remove(curColumnName);
                MessageBox.Show(strResult, "提示", MessageBoxButtons.OK);
            }   
        }

        private void 字段运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFieldCalculation formcalfield = new FormFieldCalculation(pFLayer, gdvAttribute, curColumnName);
            formcalfield.Show();
            pFCuror = pFClass.Search(null, false);
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }

        private void 几何计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region     //辅助函数

        /*
        /// <summary>
        /// 加载图层属性表
        /// </summary>
        public void TableShow()
        {
            //获取当前图层
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;

            if (pFeatureClass == null) return;

            DataTable dt = new DataTable();
            DataColumn dc = null;

            //添加属性列
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                dt.Columns.Add(dc);
            }

            //获取要素游标
            IFeatureCursor pFeatureCuror = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCuror.NextFeature();

            DataRow dr = null;
            //根据要素游标获取图层中所有要素属性
            while (pFeature != null)
            {
                dr = dt.NewRow();
                for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                {
                    if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                    {
                        //图层类型字段
                        dr[j] = pFeatureClass.ShapeType.ToString();
                    }
                    else
                    {
                        dr[j] = pFeature.get_Value(j).ToString();
                    }
                }
                dt.Rows.Add(dr);
                pFeature = pFeatureCuror.NextFeature();
            }
            gdvAttribute.DataSource = dt;
            dt2 = dt;
        }
        */

        /// <summary>
        /// 记录修改过的字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAttribute_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //记录值一旦改变触发此事件  
            //在dataGridView中获取改变记录的行数，列数和记录值  
            pRowAndCol[count].Row = gdvAttribute.CurrentCell.RowIndex;
            pRowAndCol[count].Column = gdvAttribute.CurrentCell.ColumnIndex;
            pRowAndCol[count].Value = gdvAttribute.Rows[gdvAttribute.CurrentCell.RowIndex].Cells[gdvAttribute.CurrentCell.ColumnIndex].Value.ToString();
            count++;
        }
        
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="pFeatureLayer"></param>
        public static DataTable GetAttributeTable(IFeatureClass pFeatureClass, IFeatureCursor pFeatureCuror)
        {
            if (pFeatureClass == null) return null;

            DataTable dt = new DataTable();
            DataColumn dc = null;

            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                dc = new DataColumn(pFeatureClass.Fields.get_Field(i).Name);
                dt.Columns.Add(dc);
            }

            //IFeatureCursor pFeatureCuror = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCuror.NextFeature();

            DataRow dr = null;
            while (pFeature != null)
            {
                dr = dt.NewRow();
                for (int j = 0; j < pFeatureClass.Fields.FieldCount; j++)
                {
                    if (pFeatureClass.FindField(pFeatureClass.ShapeFieldName) == j)
                    {

                        dr[j] = pFeatureClass.ShapeType.ToString();
                    }
                    else
                    {
                        dr[j] = pFeature.get_Value(j).ToString();

                    }
                }

                dt.Rows.Add(dr);
                pFeature = pFeatureCuror.NextFeature();
            }
            //dataGridView.DataSource = dt;
            return dt;
        }
        
        /// <summary>
        /// 刷新数据表
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="dt"></param>
        public static void RefreshDataGridViewDataSource(DataGridView dataGridView, DataTable dt)
        {
            DataGridViewSelectionMode selMode = dataGridView.SelectionMode;
            dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView.DataSource = dt;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dataGridView.SelectionMode = selMode;
        }

        /// <summary>
        /// 导出DataGridView至Excel
        /// </summary>
        /// <param name="myDGV"></param>
        /// <param name="pFields"></param>
        private void ExportExcel(DataGridView myDGV, IFields pFields)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消   

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

            //写入标题  
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Columns.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值  
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }

            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
                xlApp.Quit();
                GC.Collect();//强行销毁   
                MessageBox.Show("资料保存成功", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 定义单元格属性结构体
        /// </summary>
        public struct RowAndCol
        {
            /*
            //字段  
            private int row;
            private int column;
            private string _value;
            
            //行属性  
            public int Row
            {
                get
                {
                    return row;
                }
                set
                {
                    row = value;
                }
            }
            //列属性  
            public int Column
            {
                get
                {
                    return column;
                }
                set
                {
                    column = value;
                }
            }
            //值属性  
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
            */

            public int Row;
            public int Column;
            public string Value;
        }

        /// <summary>
        /// 选中行高亮显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAttribute_SelectionChanged(object sender, EventArgs e)
        {
            IFeatureSelection pFeatSelection;
            pFeatSelection = pFLayer as IFeatureSelection;
            int count = this.gdvAttribute.SelectedRows.Count;
            string strSelectionStatus = toolStripStatusLabel1.Text;
            toolStripStatusLabel1.Text = "选中 " + count + " 个" + strSelectionStatus.Substring(strSelectionStatus.IndexOf("（"));
            if (count == 0)
            {
                pFeatSelection.Clear();
                _MapControl.ActiveView.Refresh();
                return;
            } 
            
            IQueryFilter pQuery = new QueryFilterClass();
            string val;
            string col;
            col = this.gdvAttribute.Columns[0].Name;
            for (int i = 0; i < count - 1; i++)
            {
                val = this.gdvAttribute.SelectedRows[i].Cells[col].Value.ToString();
                pQuery.WhereClause += col + "=" + val + " OR ";
            }
            val = this.gdvAttribute.SelectedRows[count - 1].Cells[col].Value.ToString();
            pQuery.WhereClause += col + "=" + val;

            try
            {
                pFeatSelection.SelectFeatures(pQuery, esriSelectionResultEnum.esriSelectionResultNew, false);
                _MapControl.ActiveView.Refresh();
            }
            catch { }
        }

        /// <summary>
        /// 数据排序
        /// </summary>
        /// <param name="pFeatureClass"></param>
        private void SortFeatures(IFeatureClass pFeatureClass)
        {
            ITableSort pTableSort = new TableSortClass();
            IFields pFields = pFeatureClass.Fields;
            IField pField = pFields.get_Field(col_index);

            pTableSort.Fields = pField.Name;
            pTableSort.set_Ascending(pField.Name, up); 
            pTableSort.set_CaseSensitive(pField.Name, true);
            pTableSort.Table = pFeatureClass as ITable;
            pTableSort.Sort(null);
            pFCuror = (IFeatureCursor)pTableSort.Rows;
            pTs = pTableSort;
            RefreshDataGridViewDataSource(gdvAttribute, GetAttributeTable(pFClass, pFCuror));
        }

        /// <summary>
        /// 删除属性字段
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string DeleteField(IFeatureLayer layer, string fieldName)
        {
            try
            {
                ITable pTable = (ITable)layer;
                IFields pfields;
                IField pfield;
                pfields = pTable.Fields;
                int fieldIndex = pfields.FindField(fieldName);
                pfield = pfields.get_Field(fieldIndex);
                pTable.DeleteField(pfield);
                return "删除成功!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  

        #endregion

        private void gdvAttribute_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gdvAttribute.DataSource;
            toolStripStatusLabel1.Text = "选中 0 个（共 "+dt.Rows.Count.ToString()+" 个）";
        }

        
    }
}
