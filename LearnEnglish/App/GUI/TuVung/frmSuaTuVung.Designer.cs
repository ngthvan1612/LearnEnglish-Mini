namespace LearnEnglish.App.GUI.TuVung
{
    partial class frmSuaTuVung
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTaiFile = new System.Windows.Forms.RadioButton();
            this.rbChonFile = new System.Windows.Forms.RadioButton();
            this.btnOpenSelectionFileDialog = new System.Windows.Forms.Button();
            this.tbSelectedPath = new System.Windows.Forms.TextBox();
            this.tbVie = new System.Windows.Forms.TextBox();
            this.tbEng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbTaiFile);
            this.groupBox1.Controls.Add(this.rbChonFile);
            this.groupBox1.Controls.Add(this.btnOpenSelectionFileDialog);
            this.groupBox1.Controls.Add(this.tbSelectedPath);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 139);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Âm thanh";
            // 
            // rbTaiFile
            // 
            this.rbTaiFile.AutoSize = true;
            this.rbTaiFile.Checked = true;
            this.rbTaiFile.Location = new System.Drawing.Point(28, 47);
            this.rbTaiFile.Name = "rbTaiFile";
            this.rbTaiFile.Size = new System.Drawing.Size(320, 27);
            this.rbTaiFile.TabIndex = 6;
            this.rbTaiFile.TabStop = true;
            this.rbTaiFile.Text = "Tải âm thanh online (google dịch)";
            this.rbTaiFile.UseVisualStyleBackColor = true;
            // 
            // rbChonFile
            // 
            this.rbChonFile.AutoSize = true;
            this.rbChonFile.Location = new System.Drawing.Point(28, 92);
            this.rbChonFile.Name = "rbChonFile";
            this.rbChonFile.Size = new System.Drawing.Size(107, 27);
            this.rbChonFile.TabIndex = 5;
            this.rbChonFile.Text = "Chọn file";
            this.rbChonFile.UseVisualStyleBackColor = true;
            // 
            // btnOpenSelectionFileDialog
            // 
            this.btnOpenSelectionFileDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSelectionFileDialog.Location = new System.Drawing.Point(531, 91);
            this.btnOpenSelectionFileDialog.Name = "btnOpenSelectionFileDialog";
            this.btnOpenSelectionFileDialog.Size = new System.Drawing.Size(57, 29);
            this.btnOpenSelectionFileDialog.TabIndex = 4;
            this.btnOpenSelectionFileDialog.Text = "...";
            this.btnOpenSelectionFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenSelectionFileDialog.Click += new System.EventHandler(this.btnOpenSelectionFileDialog_Click);
            // 
            // tbSelectedPath
            // 
            this.tbSelectedPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelectedPath.Location = new System.Drawing.Point(141, 91);
            this.tbSelectedPath.Name = "tbSelectedPath";
            this.tbSelectedPath.Size = new System.Drawing.Size(384, 30);
            this.tbSelectedPath.TabIndex = 3;
            // 
            // tbVie
            // 
            this.tbVie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVie.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbVie.Location = new System.Drawing.Point(112, 55);
            this.tbVie.Name = "tbVie";
            this.tbVie.Size = new System.Drawing.Size(504, 30);
            this.tbVie.TabIndex = 9;
            // 
            // tbEng
            // 
            this.tbEng.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEng.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbEng.Location = new System.Drawing.Point(112, 8);
            this.tbEng.Name = "tbEng";
            this.tbEng.Size = new System.Drawing.Size(504, 30);
            this.tbEng.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tiếng việt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tiếng anh";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLuu.Location = new System.Drawing.Point(266, 238);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(94, 33);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmSuaTuVung
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbVie);
            this.Controls.Add(this.tbEng);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.MaximizeBox = false;
            this.Name = "frmSuaTuVung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa từ vựng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbTaiFile;
        private RadioButton rbChonFile;
        private Button btnOpenSelectionFileDialog;
        private TextBox tbSelectedPath;
        private TextBox tbVie;
        private TextBox tbEng;
        private Label label2;
        private Label label1;
        private Button btnLuu;
    }
}