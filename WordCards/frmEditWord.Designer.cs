namespace WordCards
{
    partial class frmEditWord
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
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtPhonogram = new System.Windows.Forms.TextBox();
            this.txtSoundPath = new System.Windows.Forms.TextBox();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(159, 103);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(100, 22);
            this.txtWord.TabIndex = 0;
            // 
            // txtPhonogram
            // 
            this.txtPhonogram.Location = new System.Drawing.Point(159, 157);
            this.txtPhonogram.Name = "txtPhonogram";
            this.txtPhonogram.Size = new System.Drawing.Size(100, 22);
            this.txtPhonogram.TabIndex = 1;
            // 
            // txtSoundPath
            // 
            this.txtSoundPath.Location = new System.Drawing.Point(336, 103);
            this.txtSoundPath.Name = "txtSoundPath";
            this.txtSoundPath.Size = new System.Drawing.Size(100, 22);
            this.txtSoundPath.TabIndex = 2;
            // 
            // txtExplain
            // 
            this.txtExplain.Location = new System.Drawing.Point(336, 157);
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(100, 22);
            this.txtExplain.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(503, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtExplain);
            this.Controls.Add(this.txtSoundPath);
            this.Controls.Add(this.txtPhonogram);
            this.Controls.Add(this.txtWord);
            this.Name = "frmEditWord";
            this.Text = "frmEditWord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtPhonogram;
        private System.Windows.Forms.TextBox txtSoundPath;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.Button btnSave;
    }
}