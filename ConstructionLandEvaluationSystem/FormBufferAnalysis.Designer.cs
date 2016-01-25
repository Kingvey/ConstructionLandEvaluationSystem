namespace ConstructionLandEvaluationSystem
{
    partial class FormBufferAnalysis
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBufferStart = new System.Windows.Forms.Button();
            this.btnOutputLayer = new System.Windows.Forms.Button();
            this.txtOutputLayer = new System.Windows.Forms.TextBox();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.cmbLayerName = new System.Windows.Forms.ComboBox();
            this.labOutputLayer = new System.Windows.Forms.Label();
            this.labMapUnit = new System.Windows.Forms.Label();
            this.labBufferDistance = new System.Windows.Forms.Label();
            this.labSelectLayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(343, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBufferStart
            // 
            this.btnBufferStart.BackColor = System.Drawing.Color.White;
            this.btnBufferStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBufferStart.FlatAppearance.BorderSize = 2;
            this.btnBufferStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnBufferStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBufferStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBufferStart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBufferStart.ForeColor = System.Drawing.Color.Black;
            this.btnBufferStart.Location = new System.Drawing.Point(262, 109);
            this.btnBufferStart.Name = "btnBufferStart";
            this.btnBufferStart.Size = new System.Drawing.Size(75, 23);
            this.btnBufferStart.TabIndex = 18;
            this.btnBufferStart.Text = "确  定";
            this.btnBufferStart.UseVisualStyleBackColor = false;
            this.btnBufferStart.Click += new System.EventHandler(this.btnBufferStart_Click);
            // 
            // btnOutputLayer
            // 
            this.btnOutputLayer.BackColor = System.Drawing.Color.White;
            this.btnOutputLayer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOutputLayer.FlatAppearance.BorderSize = 2;
            this.btnOutputLayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnOutputLayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnOutputLayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutputLayer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOutputLayer.ForeColor = System.Drawing.Color.Black;
            this.btnOutputLayer.Location = new System.Drawing.Point(361, 75);
            this.btnOutputLayer.Name = "btnOutputLayer";
            this.btnOutputLayer.Size = new System.Drawing.Size(49, 21);
            this.btnOutputLayer.TabIndex = 17;
            this.btnOutputLayer.Text = "...";
            this.btnOutputLayer.UseVisualStyleBackColor = false;
            this.btnOutputLayer.Click += new System.EventHandler(this.btnOutputLayer_Click);
            // 
            // txtOutputLayer
            // 
            this.txtOutputLayer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutputLayer.Location = new System.Drawing.Point(86, 75);
            this.txtOutputLayer.Name = "txtOutputLayer";
            this.txtOutputLayer.Size = new System.Drawing.Size(269, 23);
            this.txtOutputLayer.TabIndex = 16;
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBufferDistance.Location = new System.Drawing.Point(86, 43);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(269, 23);
            this.txtBufferDistance.TabIndex = 15;
            this.txtBufferDistance.Text = "1.0";
            // 
            // cmbLayerName
            // 
            this.cmbLayerName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLayerName.FormattingEnabled = true;
            this.cmbLayerName.Location = new System.Drawing.Point(86, 12);
            this.cmbLayerName.Name = "cmbLayerName";
            this.cmbLayerName.Size = new System.Drawing.Size(324, 22);
            this.cmbLayerName.TabIndex = 14;
            // 
            // labOutputLayer
            // 
            this.labOutputLayer.AutoSize = true;
            this.labOutputLayer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOutputLayer.Location = new System.Drawing.Point(17, 78);
            this.labOutputLayer.Name = "labOutputLayer";
            this.labOutputLayer.Size = new System.Drawing.Size(63, 14);
            this.labOutputLayer.TabIndex = 13;
            this.labOutputLayer.Text = "输出图层";
            // 
            // labMapUnit
            // 
            this.labMapUnit.AutoSize = true;
            this.labMapUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMapUnit.Location = new System.Drawing.Point(361, 46);
            this.labMapUnit.Name = "labMapUnit";
            this.labMapUnit.Size = new System.Drawing.Size(35, 14);
            this.labMapUnit.TabIndex = 12;
            this.labMapUnit.Text = "单位";
            // 
            // labBufferDistance
            // 
            this.labBufferDistance.AutoSize = true;
            this.labBufferDistance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBufferDistance.Location = new System.Drawing.Point(17, 46);
            this.labBufferDistance.Name = "labBufferDistance";
            this.labBufferDistance.Size = new System.Drawing.Size(63, 14);
            this.labBufferDistance.TabIndex = 11;
            this.labBufferDistance.Text = "缓冲半径";
            // 
            // labSelectLayer
            // 
            this.labSelectLayer.AutoSize = true;
            this.labSelectLayer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSelectLayer.Location = new System.Drawing.Point(17, 15);
            this.labSelectLayer.Name = "labSelectLayer";
            this.labSelectLayer.Size = new System.Drawing.Size(63, 14);
            this.labSelectLayer.TabIndex = 10;
            this.labSelectLayer.Text = "选择图层";
            // 
            // FormBufferAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBufferStart);
            this.Controls.Add(this.btnOutputLayer);
            this.Controls.Add(this.txtOutputLayer);
            this.Controls.Add(this.txtBufferDistance);
            this.Controls.Add(this.cmbLayerName);
            this.Controls.Add(this.labOutputLayer);
            this.Controls.Add(this.labMapUnit);
            this.Controls.Add(this.labBufferDistance);
            this.Controls.Add(this.labSelectLayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBufferAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缓冲区分析";
            this.Load += new System.EventHandler(this.BufferAnalysisForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBufferStart;
        private System.Windows.Forms.Button btnOutputLayer;
        private System.Windows.Forms.TextBox txtOutputLayer;
        private System.Windows.Forms.TextBox txtBufferDistance;
        private System.Windows.Forms.ComboBox cmbLayerName;
        private System.Windows.Forms.Label labOutputLayer;
        private System.Windows.Forms.Label labMapUnit;
        private System.Windows.Forms.Label labBufferDistance;
        private System.Windows.Forms.Label labSelectLayer;
    }
}