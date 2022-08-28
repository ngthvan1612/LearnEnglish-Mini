namespace LearnEnglish.App.GUI.Hoc
{
    partial class frmHoc
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
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbQuestionContent = new System.Windows.Forms.Label();
            this.lb01 = new System.Windows.Forms.Label();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lbStatus.Location = new System.Drawing.Point(12, 9);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(168, 33);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Câu hỏi ?/?";
            // 
            // lbQuestionContent
            // 
            this.lbQuestionContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbQuestionContent.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbQuestionContent.Location = new System.Drawing.Point(12, 56);
            this.lbQuestionContent.Name = "lbQuestionContent";
            this.lbQuestionContent.Size = new System.Drawing.Size(905, 395);
            this.lbQuestionContent.TabIndex = 1;
            this.lbQuestionContent.Text = "Haha";
            this.lbQuestionContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb01
            // 
            this.lb01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb01.AutoSize = true;
            this.lb01.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb01.Location = new System.Drawing.Point(12, 471);
            this.lb01.Name = "lb01";
            this.lb01.Size = new System.Drawing.Size(102, 33);
            this.lb01.TabIndex = 2;
            this.lb01.Text = "Trả lời";
            // 
            // tbAnswer
            // 
            this.tbAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnswer.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbAnswer.Location = new System.Drawing.Point(120, 468);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(797, 39);
            this.tbAnswer.TabIndex = 3;
            this.tbAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAnswer_KeyDown);
            this.tbAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAnswer_KeyPress);
            this.tbAnswer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbAnswer_PreviewKeyDown);
            // 
            // frmHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 519);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.lb01);
            this.Controls.Add(this.lbQuestionContent);
            this.Controls.Add(this.lbStatus);
            this.MaximizeBox = false;
            this.Name = "frmHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Học";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbStatus;
        private Label lbQuestionContent;
        private Label lb01;
        private TextBox tbAnswer;
    }
}