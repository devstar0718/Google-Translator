namespace GoogleTranslator
{
    partial class GoogleTranslator
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.buttonSelectSrc = new System.Windows.Forms.Button();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTranslate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.textBoxDst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSelectDst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source File:";
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.Location = new System.Drawing.Point(129, 20);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.ReadOnly = true;
            this.textBoxSrc.Size = new System.Drawing.Size(577, 29);
            this.textBoxSrc.TabIndex = 1;
            // 
            // buttonSelectSrc
            // 
            this.buttonSelectSrc.Location = new System.Drawing.Point(712, 20);
            this.buttonSelectSrc.Name = "buttonSelectSrc";
            this.buttonSelectSrc.Size = new System.Drawing.Size(36, 30);
            this.buttonSelectSrc.TabIndex = 2;
            this.buttonSelectSrc.Text = "...";
            this.buttonSelectSrc.UseVisualStyleBackColor = true;
            this.buttonSelectSrc.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.FormattingEnabled = true;
            this.comboBoxLang.Location = new System.Drawing.Point(183, 63);
            this.comboBoxLang.Name = "comboBoxLang";
            this.comboBoxLang.Size = new System.Drawing.Size(417, 32);
            this.comboBoxLang.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Language:";
            // 
            // buttonTranslate
            // 
            this.buttonTranslate.Location = new System.Drawing.Point(623, 62);
            this.buttonTranslate.Name = "buttonTranslate";
            this.buttonTranslate.Size = new System.Drawing.Size(125, 32);
            this.buttonTranslate.TabIndex = 5;
            this.buttonTranslate.Text = "Translate";
            this.buttonTranslate.UseVisualStyleBackColor = true;
            this.buttonTranslate.Click += new System.EventHandler(this.buttonTranslate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 161);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(736, 22);
            this.progressBar1.TabIndex = 6;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(12, 206);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(736, 388);
            this.listBoxLog.TabIndex = 7;
            // 
            // textBoxDst
            // 
            this.textBoxDst.Location = new System.Drawing.Point(129, 115);
            this.textBoxDst.Name = "textBoxDst";
            this.textBoxDst.ReadOnly = true;
            this.textBoxDst.Size = new System.Drawing.Size(577, 29);
            this.textBoxDst.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Target File:";
            // 
            // buttonSelectDst
            // 
            this.buttonSelectDst.Location = new System.Drawing.Point(712, 115);
            this.buttonSelectDst.Name = "buttonSelectDst";
            this.buttonSelectDst.Size = new System.Drawing.Size(36, 30);
            this.buttonSelectDst.TabIndex = 10;
            this.buttonSelectDst.Text = "...";
            this.buttonSelectDst.UseVisualStyleBackColor = true;
            this.buttonSelectDst.Click += new System.EventHandler(this.buttonSelectDst_Click);
            // 
            // GoogleTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 661);
            this.Controls.Add(this.buttonSelectDst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDst);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonTranslate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLang);
            this.Controls.Add(this.buttonSelectSrc);
            this.Controls.Add(this.textBoxSrc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GoogleTranslator";
            this.Text = "Google Translator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.Button buttonSelectSrc;
        private System.Windows.Forms.ComboBox comboBoxLang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTranslate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TextBox textBoxDst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSelectDst;
    }
}

