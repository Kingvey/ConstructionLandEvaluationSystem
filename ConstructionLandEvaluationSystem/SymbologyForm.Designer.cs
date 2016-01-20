namespace ConstructionLandEvaluationSystem
{
    partial class SymbologyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbologyForm));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbAngle = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.lbOutlineColor = new System.Windows.Forms.Label();
            this.cbOutlineColor = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btMore = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.btOutlineColor = new System.Windows.Forms.Button();
            this.btColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axSymbologyControl1.Location = new System.Drawing.Point(2, 2);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(397, 357);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(15, 27);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(53, 12);
            this.lbColor.TabIndex = 1;
            this.lbColor.Text = "填充颜色";
            this.lbColor.Visible = false;
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(15, 59);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(53, 12);
            this.lbWidth.TabIndex = 2;
            this.lbWidth.Text = "框线宽度";
            this.lbWidth.Visible = false;
            // 
            // lbAngle
            // 
            this.lbAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAngle.AutoSize = true;
            this.lbAngle.Location = new System.Drawing.Point(555, 325);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(29, 12);
            this.lbAngle.TabIndex = 3;
            this.lbAngle.Text = "角度";
            this.lbAngle.Visible = false;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(89, 57);
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(64, 21);
            this.nudWidth.TabIndex = 5;
            this.nudWidth.Visible = false;
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // cbColor
            // 
            this.cbColor.BackColor = System.Drawing.SystemColors.Window;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.IntegralHeight = false;
            this.cbColor.Location = new System.Drawing.Point(89, 24);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(64, 20);
            this.cbColor.TabIndex = 6;
            this.cbColor.Visible = false;
            this.cbColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cbColor_MouseUp);
            // 
            // nudAngle
            // 
            this.nudAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAngle.Location = new System.Drawing.Point(520, 340);
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Size = new System.Drawing.Size(64, 21);
            this.nudAngle.TabIndex = 7;
            this.nudAngle.Visible = false;
            this.nudAngle.ValueChanged += new System.EventHandler(this.nudAngle_ValueChanged);
            // 
            // lbOutlineColor
            // 
            this.lbOutlineColor.AutoSize = true;
            this.lbOutlineColor.Location = new System.Drawing.Point(15, 91);
            this.lbOutlineColor.Name = "lbOutlineColor";
            this.lbOutlineColor.Size = new System.Drawing.Size(53, 12);
            this.lbOutlineColor.TabIndex = 8;
            this.lbOutlineColor.Text = "框线颜色";
            this.lbOutlineColor.Visible = false;
            // 
            // cbOutlineColor
            // 
            this.cbOutlineColor.DropDownHeight = 1;
            this.cbOutlineColor.FormattingEnabled = true;
            this.cbOutlineColor.IntegralHeight = false;
            this.cbOutlineColor.Location = new System.Drawing.Point(89, 88);
            this.cbOutlineColor.Name = "cbOutlineColor";
            this.cbOutlineColor.Size = new System.Drawing.Size(64, 20);
            this.cbOutlineColor.TabIndex = 10;
            this.cbOutlineColor.Visible = false;
            this.cbOutlineColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cbOutlineColor_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.cbOutlineColor);
            this.groupBox1.Controls.Add(this.lbWidth);
            this.groupBox1.Controls.Add(this.nudWidth);
            this.groupBox1.Controls.Add(this.lbOutlineColor);
            this.groupBox1.Controls.Add(this.cbColor);
            this.groupBox1.Location = new System.Drawing.Point(405, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 118);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 74);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(405, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // btMore
            // 
            this.btMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMore.Location = new System.Drawing.Point(451, 257);
            this.btMore.Name = "btMore";
            this.btMore.Size = new System.Drawing.Size(75, 23);
            this.btMore.TabIndex = 14;
            this.btMore.Text = "更多符号";
            this.btMore.UseVisualStyleBackColor = true;
            this.btMore.Click += new System.EventHandler(this.btMore_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(451, 286);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 16;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(451, 311);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 17;
            this.btOK.Text = "确定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(367, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 18;
            // 
            // btOutlineColor
            // 
            this.btOutlineColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOutlineColor.Location = new System.Drawing.Point(532, 297);
            this.btOutlineColor.Name = "btOutlineColor";
            this.btOutlineColor.Size = new System.Drawing.Size(52, 23);
            this.btOutlineColor.TabIndex = 9;
            this.btOutlineColor.Text = "btOutlineColor";
            this.btOutlineColor.UseVisualStyleBackColor = true;
            this.btOutlineColor.Visible = false;
            // 
            // btColor
            // 
            this.btColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btColor.Location = new System.Drawing.Point(532, 268);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(52, 23);
            this.btColor.TabIndex = 4;
            this.btColor.Text = "btColor";
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Visible = false;
            // 
            // SymbologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btMore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOutlineColor);
            this.Controls.Add(this.nudAngle);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.lbAngle);
            this.Controls.Add(this.axSymbologyControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SymbologyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "符号库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SymbologyForm_FormClosing);
            this.Load += new System.EventHandler(this.SymbologyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbAngle;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Label lbOutlineColor;
        private System.Windows.Forms.ComboBox cbOutlineColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btMore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button btOutlineColor;
        private System.Windows.Forms.Button btColor;
    }
}