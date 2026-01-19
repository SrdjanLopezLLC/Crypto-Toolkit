namespace Decrypter_By_SL_LLC
{
    partial class Decrypter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Decrypter));
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtMain = new System.Windows.Forms.RichTextBox();
            this.imgArrow = new System.Windows.Forms.PictureBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.cmbAlg = new System.Windows.Forms.ComboBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtIVInput = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblVInput = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnVerifySha = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewForm = new System.Windows.Forms.Button();
            this.cmbEncMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.btnClearMain = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(310, 219);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(184, 40);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtMain
            // 
            this.txtMain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMain.Location = new System.Drawing.Point(12, 12);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(482, 54);
            this.txtMain.TabIndex = 3;
            this.txtMain.Text = "";
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
            // 
            // imgArrow
            // 
            this.imgArrow.BackColor = System.Drawing.Color.Transparent;
            this.imgArrow.Image = ((System.Drawing.Image)(resources.GetObject("imgArrow.Image")));
            this.imgArrow.Location = new System.Drawing.Point(12, 72);
            this.imgArrow.Name = "imgArrow";
            this.imgArrow.Size = new System.Drawing.Size(108, 71);
            this.imgArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgArrow.TabIndex = 5;
            this.imgArrow.TabStop = false;
            this.imgArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgArrow.Click += new System.EventHandler(this.imgArrow_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(12, 219);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(184, 40);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 149);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(482, 54);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.Text = "";
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // cmbAlg
            // 
            this.cmbAlg.FormattingEnabled = true;
            this.cmbAlg.Location = new System.Drawing.Point(373, 72);
            this.cmbAlg.Name = "cmbAlg";
            this.cmbAlg.Size = new System.Drawing.Size(121, 21);
            this.cmbAlg.TabIndex = 8;
            this.cmbAlg.SelectedIndexChanged += new System.EventHandler(this.cmbAlg_SelectedIndexChanged);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(126, 123);
            this.txtKey.MaxLength = 32767999;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(145, 20);
            this.txtKey.TabIndex = 9;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // txtIVInput
            // 
            this.txtIVInput.Location = new System.Drawing.Point(349, 123);
            this.txtIVInput.MaxLength = 32767999;
            this.txtIVInput.Name = "txtIVInput";
            this.txtIVInput.Size = new System.Drawing.Size(145, 20);
            this.txtIVInput.TabIndex = 10;
            this.txtIVInput.TextChanged += new System.EventHandler(this.txtIVInput_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.Color.Transparent;
            this.lblKey.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.ForeColor = System.Drawing.Color.White;
            this.lblKey.Location = new System.Drawing.Point(169, 107);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(51, 13);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "For Key";
            // 
            // lblVInput
            // 
            this.lblVInput.AutoSize = true;
            this.lblVInput.BackColor = System.Drawing.Color.Transparent;
            this.lblVInput.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVInput.ForeColor = System.Drawing.Color.White;
            this.lblVInput.Location = new System.Drawing.Point(396, 107);
            this.lblVInput.Name = "lblVInput";
            this.lblVInput.Size = new System.Drawing.Size(42, 13);
            this.lblVInput.TabIndex = 12;
            this.lblVInput.Text = "For IV";
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(202, 219);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(102, 40);
            this.btnVerify.TabIndex = 13;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(126, 72);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(102, 21);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "Browse :)";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnVerifySha
            // 
            this.btnVerifySha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifySha.Location = new System.Drawing.Point(254, 72);
            this.btnVerifySha.Name = "btnVerifySha";
            this.btnVerifySha.Size = new System.Drawing.Size(102, 21);
            this.btnVerifySha.TabIndex = 15;
            this.btnVerifySha.Text = "SHA + MD5";
            this.btnVerifySha.UseVisualStyleBackColor = true;
            this.btnVerifySha.Click += new System.EventHandler(this.btnVerifySha_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Location = new System.Drawing.Point(12, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 10);
            this.panel1.TabIndex = 16;
            // 
            // btnNewForm
            // 
            this.btnNewForm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewForm.Location = new System.Drawing.Point(172, 281);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(184, 40);
            this.btnNewForm.TabIndex = 17;
            this.btnNewForm.Text = "For ECDiffieHellman";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // cmbEncMode
            // 
            this.cmbEncMode.FormattingEnabled = true;
            this.cmbEncMode.Location = new System.Drawing.Point(37, 295);
            this.cmbEncMode.Name = "cmbEncMode";
            this.cmbEncMode.Size = new System.Drawing.Size(102, 21);
            this.cmbEncMode.TabIndex = 18;
            this.cmbEncMode.SelectedIndexChanged += new System.EventHandler(this.cmbEncMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "AES Encryption Modes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(373, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "AES Output Format";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(377, 295);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(102, 21);
            this.cmbOutputFormat.TabIndex = 21;
            // 
            // btnClearMain
            // 
            this.btnClearMain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMain.Location = new System.Drawing.Point(277, 122);
            this.btnClearMain.Name = "btnClearMain";
            this.btnClearMain.Size = new System.Drawing.Size(66, 21);
            this.btnClearMain.TabIndex = 22;
            this.btnClearMain.Text = "Clear";
            this.btnClearMain.UseVisualStyleBackColor = true;
            this.btnClearMain.Click += new System.EventHandler(this.btnClearMain_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(254, 97);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(102, 21);
            this.btnClearAll.TabIndex = 23;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // Decrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(506, 328);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearMain);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEncMode);
            this.Controls.Add(this.btnNewForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVerifySha);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.lblVInput);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtIVInput);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.cmbAlg);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.imgArrow);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.btnDecrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Decrypter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Decrypter By SL LLC";
            this.Load += new System.EventHandler(this.Decrypter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.RichTextBox txtMain;
        private System.Windows.Forms.PictureBox imgArrow;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ComboBox cmbAlg;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtIVInput;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblVInput;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnVerifySha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewForm;
        private System.Windows.Forms.ComboBox cmbEncMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Button btnClearMain;
        private System.Windows.Forms.Button btnClearAll;
    }
}

