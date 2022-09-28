namespace Analyzer
{
    partial class ctlAnalyzer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFile = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.picBoxResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(98, 23);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "&File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(98, 52);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(589, 313);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // picBoxResult
            // 
            this.picBoxResult.Location = new System.Drawing.Point(98, 383);
            this.picBoxResult.Name = "picBoxResult";
            this.picBoxResult.Size = new System.Drawing.Size(589, 395);
            this.picBoxResult.TabIndex = 2;
            this.picBoxResult.TabStop = false;
            // 
            // ctlAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxResult);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnFile);
            this.Name = "ctlAnalyzer";
            this.Size = new System.Drawing.Size(1441, 893);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxResult)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.PictureBox picBoxResult;
    }
}
