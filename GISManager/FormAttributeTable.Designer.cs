namespace GISManager
{
    partial class FormAttributeTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gdvAttribute = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.正序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逆序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字段运算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.集合计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttribute)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdvAttribute
            // 
            this.gdvAttribute.AllowUserToResizeRows = false;
            this.gdvAttribute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdvAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvAttribute.Location = new System.Drawing.Point(0, 25);
            this.gdvAttribute.Name = "gdvAttribute";
            this.gdvAttribute.ReadOnly = true;
            this.gdvAttribute.RowTemplate.Height = 23;
            this.gdvAttribute.Size = new System.Drawing.Size(584, 336);
            this.gdvAttribute.TabIndex = 0;
            this.gdvAttribute.DataSourceChanged += new System.EventHandler(this.gdvAttribute_DataSourceChanged);
            this.gdvAttribute.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvAttribute_CellValueChanged);
            this.gdvAttribute.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gdvAttribute_ColumnHeaderMouseClick);
            this.gdvAttribute.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gdvAttribute_RowHeaderMouseClick);
            this.gdvAttribute.SelectionChanged += new System.EventHandler(this.gdvAttribute_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加字段ToolStripMenuItem,
            this.编辑属性ToolStripMenuItem,
            this.保存编辑ToolStripMenuItem,
            this.取消编辑ToolStripMenuItem,
            this.删除选中ToolStripMenuItem,
            this.导出ExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加字段ToolStripMenuItem
            // 
            this.添加字段ToolStripMenuItem.Name = "添加字段ToolStripMenuItem";
            this.添加字段ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.添加字段ToolStripMenuItem.Text = "添加字段";
            this.添加字段ToolStripMenuItem.Click += new System.EventHandler(this.添加字段ToolStripMenuItem_Click);
            // 
            // 编辑属性ToolStripMenuItem
            // 
            this.编辑属性ToolStripMenuItem.Name = "编辑属性ToolStripMenuItem";
            this.编辑属性ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.编辑属性ToolStripMenuItem.Text = "编辑属性";
            this.编辑属性ToolStripMenuItem.Click += new System.EventHandler(this.编辑属性ToolStripMenuItem_Click);
            // 
            // 保存编辑ToolStripMenuItem
            // 
            this.保存编辑ToolStripMenuItem.Name = "保存编辑ToolStripMenuItem";
            this.保存编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.保存编辑ToolStripMenuItem.Text = "保存编辑";
            this.保存编辑ToolStripMenuItem.Click += new System.EventHandler(this.保存编辑ToolStripMenuItem_Click);
            // 
            // 取消编辑ToolStripMenuItem
            // 
            this.取消编辑ToolStripMenuItem.Name = "取消编辑ToolStripMenuItem";
            this.取消编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.取消编辑ToolStripMenuItem.Text = "取消编辑";
            this.取消编辑ToolStripMenuItem.Click += new System.EventHandler(this.取消编辑ToolStripMenuItem_Click);
            // 
            // 删除选中ToolStripMenuItem
            // 
            this.删除选中ToolStripMenuItem.Name = "删除选中ToolStripMenuItem";
            this.删除选中ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.删除选中ToolStripMenuItem.Text = "删除选中行";
            this.删除选中ToolStripMenuItem.Click += new System.EventHandler(this.删除选中ToolStripMenuItem_Click);
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel";
            this.导出ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出ExcelToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.正序ToolStripMenuItem,
            this.逆序ToolStripMenuItem,
            this.删除字段ToolStripMenuItem,
            this.字段运算ToolStripMenuItem,
            this.集合计算ToolStripMenuItem,
            this.属性ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 136);
            // 
            // 正序ToolStripMenuItem
            // 
            this.正序ToolStripMenuItem.Name = "正序ToolStripMenuItem";
            this.正序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.正序ToolStripMenuItem.Text = "正序";
            this.正序ToolStripMenuItem.Click += new System.EventHandler(this.正序ToolStripMenuItem_Click);
            // 
            // 逆序ToolStripMenuItem
            // 
            this.逆序ToolStripMenuItem.Name = "逆序ToolStripMenuItem";
            this.逆序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.逆序ToolStripMenuItem.Text = "逆序";
            this.逆序ToolStripMenuItem.Click += new System.EventHandler(this.逆序ToolStripMenuItem_Click);
            // 
            // 删除字段ToolStripMenuItem
            // 
            this.删除字段ToolStripMenuItem.Name = "删除字段ToolStripMenuItem";
            this.删除字段ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除字段ToolStripMenuItem.Text = "删除字段";
            this.删除字段ToolStripMenuItem.Click += new System.EventHandler(this.删除字段ToolStripMenuItem_Click);
            // 
            // 字段运算ToolStripMenuItem
            // 
            this.字段运算ToolStripMenuItem.Name = "字段运算ToolStripMenuItem";
            this.字段运算ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.字段运算ToolStripMenuItem.Text = "字段运算";
            this.字段运算ToolStripMenuItem.Click += new System.EventHandler(this.字段运算ToolStripMenuItem_Click);
            // 
            // 集合计算ToolStripMenuItem
            // 
            this.集合计算ToolStripMenuItem.Name = "集合计算ToolStripMenuItem";
            this.集合计算ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.集合计算ToolStripMenuItem.Text = "几何运算";
            this.集合计算ToolStripMenuItem.Click += new System.EventHandler(this.几何计算ToolStripMenuItem_Click);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel1.Text = "选中 0 个（共 0 个）";
            // 
            // FormAttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gdvAttribute);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAttributeTable";
            this.Text = "属性表";
            this.Load += new System.EventHandler(this.FormAttributeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttribute)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvAttribute;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消编辑ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 正序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逆序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字段运算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 集合计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}