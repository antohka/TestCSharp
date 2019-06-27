namespace Text_Editor
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFileDB = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameFromDB = new System.Windows.Forms.ToolStripTextBox();
            this.saveFileDB = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameDB = new System.Windows.Forms.ToolStripTextBox();
            this.clearAllClick = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldText
            // 
            this.fieldText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fieldText.Location = new System.Drawing.Point(0, 27);
            this.fieldText.Name = "fieldText";
            this.fieldText.Size = new System.Drawing.Size(873, 429);
            this.fieldText.TabIndex = 0;
            this.fieldText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearAllClick});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile,
            this.selectFileDB,
            this.saveFileDB});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(310, 22);
            this.openFile.Text = "Open";
            // 
            // saveFile
            // 
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(310, 22);
            this.saveFile.Text = "Save";
            // 
            // selectFileDB
            // 
            this.selectFileDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameFromDB});
            this.selectFileDB.Name = "selectFileDB";
            this.selectFileDB.Size = new System.Drawing.Size(321, 22);
            this.selectFileDB.Text = "Select a file from DB (enter a file name to right)";
            // 
            // fileNameFromDB
            // 
            this.fileNameFromDB.BackColor = System.Drawing.SystemColors.HotTrack;
            this.fileNameFromDB.Name = "fileNameFromDB";
            this.fileNameFromDB.Size = new System.Drawing.Size(100, 23);
            // 
            // saveFileDB
            // 
            this.saveFileDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameDB});
            this.saveFileDB.Name = "saveFileDB";
            this.saveFileDB.Size = new System.Drawing.Size(310, 22);
            this.saveFileDB.Text = "Save the file to DB (enter a file name to right)";
            // 
            // fileNameDB
            // 
            this.fileNameDB.BackColor = System.Drawing.SystemColors.HotTrack;
            this.fileNameDB.Name = "fileNameDB";
            this.fileNameDB.Size = new System.Drawing.Size(100, 23);
            // 
            // clearAllClick
            // 
            this.clearAllClick.Name = "clearAllClick";
            this.clearAllClick.Size = new System.Drawing.Size(61, 20);
            this.clearAllClick.Text = "Clear all";
            this.clearAllClick.Click += new System.EventHandler(this.ClearAllClick);
            // 
            // fontSize
            // 
            this.fontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSize.Location = new System.Drawing.Point(804, 4);
            this.fontSize.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.fontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(57, 20);
            this.fontSize.TabIndex = 2;
            this.fontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(752, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "font size";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontSize);
            this.Controls.Add(this.fieldText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form";
            this.Text = "Text Editor ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox fieldText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem clearAllClick;
        private System.Windows.Forms.NumericUpDown fontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem selectFileDB;
        private System.Windows.Forms.ToolStripMenuItem saveFileDB;
        private System.Windows.Forms.ToolStripTextBox fileNameDB;
        private System.Windows.Forms.ToolStripTextBox fileNameFromDB;
    }
}

