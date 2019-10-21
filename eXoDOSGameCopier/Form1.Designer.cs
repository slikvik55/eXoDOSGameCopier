namespace eXoDOSGameCopier
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.btnSelectRoot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtXMLtoWrite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectDest = new System.Windows.Forms.Button();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtRoot
            // 
            this.txtRoot.Location = new System.Drawing.Point(24, 48);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Size = new System.Drawing.Size(319, 20);
            this.txtRoot.TabIndex = 0;
            // 
            // btnSelectRoot
            // 
            this.btnSelectRoot.Location = new System.Drawing.Point(358, 32);
            this.btnSelectRoot.Name = "btnSelectRoot";
            this.btnSelectRoot.Size = new System.Drawing.Size(109, 36);
            this.btnSelectRoot.TabIndex = 1;
            this.btnSelectRoot.Text = "Select Root eXoDOS";
            this.btnSelectRoot.UseVisualStyleBackColor = true;
            this.btnSelectRoot.Click += new System.EventHandler(this.btnSelectRoot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root of Extracted eXoDOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder with selected zipped games in.";
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(24, 96);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(319, 20);
            this.txtDest.TabIndex = 4;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(240, 148);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(103, 40);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run!!";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // txtXMLtoWrite
            // 
            this.txtXMLtoWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXMLtoWrite.Location = new System.Drawing.Point(30, 216);
            this.txtXMLtoWrite.Multiline = true;
            this.txtXMLtoWrite.Name = "txtXMLtoWrite";
            this.txtXMLtoWrite.Size = new System.Drawing.Size(522, 414);
            this.txtXMLtoWrite.TabIndex = 6;
            this.txtXMLtoWrite.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "New XML file";
            // 
            // btnSelectDest
            // 
            this.btnSelectDest.Location = new System.Drawing.Point(358, 80);
            this.btnSelectDest.Name = "btnSelectDest";
            this.btnSelectDest.Size = new System.Drawing.Size(109, 36);
            this.btnSelectDest.TabIndex = 12;
            this.btnSelectDest.Text = "Select Destination Folder";
            this.btnSelectDest.UseVisualStyleBackColor = true;
            this.btnSelectDest.Click += new System.EventHandler(this.btnSelectDest_Click);
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(157, 161);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(77, 17);
            this.chkTestMode.TabIndex = 13;
            this.chkTestMode.Text = "Test Mode";
            this.chkTestMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 642);
            this.Controls.Add(this.chkTestMode);
            this.Controls.Add(this.btnSelectDest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXMLtoWrite);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectRoot);
            this.Controls.Add(this.txtRoot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Button btnSelectRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtXMLtoWrite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectDest;
        private System.Windows.Forms.CheckBox chkTestMode;
    }
}

