namespace LINE_Backup_Restore.form
{
    partial class backup_aplit
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OFSBox = new System.Windows.Forms.TextBox();
            this.SFOButton = new System.Windows.Forms.Button();
            this.SFDBox = new System.Windows.Forms.TextBox();
            this.SAButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dateFileListBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.convartButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.OFSBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SFOButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SFDBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SAButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OFSBox
            // 
            this.OFSBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OFSBox.Location = new System.Drawing.Point(3, 3);
            this.OFSBox.Name = "OFSBox";
            this.OFSBox.Size = new System.Drawing.Size(795, 19);
            this.OFSBox.TabIndex = 0;
            // 
            // SFOButton
            // 
            this.SFOButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFOButton.Location = new System.Drawing.Point(804, 3);
            this.SFOButton.Name = "SFOButton";
            this.SFOButton.Size = new System.Drawing.Size(94, 24);
            this.SFOButton.TabIndex = 1;
            this.SFOButton.Text = "ソースファイル";
            this.SFOButton.UseVisualStyleBackColor = true;
            this.SFOButton.Click += new System.EventHandler(this.SFOButton_Click);
            // 
            // SFDBox
            // 
            this.SFDBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFDBox.Location = new System.Drawing.Point(3, 33);
            this.SFDBox.Name = "SFDBox";
            this.SFDBox.Size = new System.Drawing.Size(795, 19);
            this.SFDBox.TabIndex = 2;
            // 
            // SAButton
            // 
            this.SAButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SAButton.Location = new System.Drawing.Point(804, 33);
            this.SAButton.Name = "SAButton";
            this.SAButton.Size = new System.Drawing.Size(94, 24);
            this.SAButton.TabIndex = 3;
            this.SAButton.Text = "保存場所";
            this.SAButton.UseVisualStyleBackColor = true;
            this.SAButton.Click += new System.EventHandler(this.SAButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateFileListBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(907, 594);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dateFileListBox
            // 
            this.dateFileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFileListBox.FormattingEnabled = true;
            this.dateFileListBox.Location = new System.Drawing.Point(3, 66);
            this.dateFileListBox.Name = "dateFileListBox";
            this.dateFileListBox.Size = new System.Drawing.Size(901, 472);
            this.dateFileListBox.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Controls.Add(this.convartButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 544);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(901, 47);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // convartButton
            // 
            this.convartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convartButton.Location = new System.Drawing.Point(804, 3);
            this.convartButton.Name = "convartButton";
            this.convartButton.Size = new System.Drawing.Size(94, 41);
            this.convartButton.TabIndex = 0;
            this.convartButton.Text = "変換";
            this.convartButton.UseVisualStyleBackColor = true;
            this.convartButton.Click += new System.EventHandler(this.convartButton_Click);
            // 
            // backup_aplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "backup_aplit";
            this.Size = new System.Drawing.Size(907, 594);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox OFSBox;
        private System.Windows.Forms.Button SFOButton;
        private System.Windows.Forms.TextBox SFDBox;
        private System.Windows.Forms.Button SAButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckedListBox dateFileListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button convartButton;
    }
}
