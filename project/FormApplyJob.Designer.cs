
namespace project
{
    partial class FormApplyJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApplyJob));
            this.panel1 = new System.Windows.Forms.Panel();
            this.FormApply_rtb_Describe = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FormApply_tb_FileName = new System.Windows.Forms.TextBox();
            this.FormApply_bt_SendCV = new System.Windows.Forms.Button();
            this.FormApply_bt_ChooseFile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FormApply_tb_Email = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FormApply_tb_UserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormApply_Title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.FormApply_rtb_Describe);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.FormApply_tb_FileName);
            this.panel1.Controls.Add(this.FormApply_bt_SendCV);
            this.panel1.Controls.Add(this.FormApply_bt_ChooseFile);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.FormApply_Title);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 426);
            this.panel1.TabIndex = 0;
            // 
            // FormApply_rtb_Describe
            // 
            this.FormApply_rtb_Describe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormApply_rtb_Describe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_rtb_Describe.Location = new System.Drawing.Point(36, 254);
            this.FormApply_rtb_Describe.Name = "FormApply_rtb_Describe";
            this.FormApply_rtb_Describe.Size = new System.Drawing.Size(705, 109);
            this.FormApply_rtb_Describe.TabIndex = 5;
            this.FormApply_rtb_Describe.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(163, 191);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(421, 18);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "We accept .pdf";
            // 
            // FormApply_tb_FileName
            // 
            this.FormApply_tb_FileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormApply_tb_FileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_tb_FileName.Location = new System.Drawing.Point(287, 160);
            this.FormApply_tb_FileName.Name = "FormApply_tb_FileName";
            this.FormApply_tb_FileName.Size = new System.Drawing.Size(421, 22);
            this.FormApply_tb_FileName.TabIndex = 2;
            this.FormApply_tb_FileName.Text = "No file chosen";
            // 
            // FormApply_bt_SendCV
            // 
            this.FormApply_bt_SendCV.BackColor = System.Drawing.Color.Red;
            this.FormApply_bt_SendCV.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_bt_SendCV.Location = new System.Drawing.Point(39, 370);
            this.FormApply_bt_SendCV.Name = "FormApply_bt_SendCV";
            this.FormApply_bt_SendCV.Size = new System.Drawing.Size(705, 44);
            this.FormApply_bt_SendCV.TabIndex = 4;
            this.FormApply_bt_SendCV.Text = "Send my CV";
            this.FormApply_bt_SendCV.UseVisualStyleBackColor = false;
            this.FormApply_bt_SendCV.Click += new System.EventHandler(this.FormApply_bt_SendCV_Click);
            // 
            // FormApply_bt_ChooseFile
            // 
            this.FormApply_bt_ChooseFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_bt_ChooseFile.Location = new System.Drawing.Point(163, 155);
            this.FormApply_bt_ChooseFile.Name = "FormApply_bt_ChooseFile";
            this.FormApply_bt_ChooseFile.Size = new System.Drawing.Size(118, 30);
            this.FormApply_bt_ChooseFile.TabIndex = 4;
            this.FormApply_bt_ChooseFile.Text = "Choose File";
            this.FormApply_bt_ChooseFile.UseVisualStyleBackColor = true;
            this.FormApply_bt_ChooseFile.Click += new System.EventHandler(this.FormApply_bt_ChooseFile_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.FormApply_tb_Email);
            this.panel3.Location = new System.Drawing.Point(163, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 33);
            this.panel3.TabIndex = 3;
            // 
            // FormApply_tb_Email
            // 
            this.FormApply_tb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormApply_tb_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_tb_Email.Location = new System.Drawing.Point(15, 4);
            this.FormApply_tb_Email.Name = "FormApply_tb_Email";
            this.FormApply_tb_Email.Size = new System.Drawing.Size(421, 22);
            this.FormApply_tb_Email.TabIndex = 2;
            this.FormApply_tb_Email.Text = "email";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.FormApply_tb_UserName);
            this.panel2.Location = new System.Drawing.Point(163, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 33);
            this.panel2.TabIndex = 3;
            // 
            // FormApply_tb_UserName
            // 
            this.FormApply_tb_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormApply_tb_UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_tb_UserName.Location = new System.Drawing.Point(15, 4);
            this.FormApply_tb_UserName.Name = "FormApply_tb_UserName";
            this.FormApply_tb_UserName.Size = new System.Drawing.Size(421, 22);
            this.FormApply_tb_UserName.TabIndex = 2;
            this.FormApply_tb_UserName.Text = "Full name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(565, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "What skills, work projects or achievements make you a strong candidate?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Your CV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your name:";
            // 
            // FormApply_Title
            // 
            this.FormApply_Title.AutoSize = true;
            this.FormApply_Title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormApply_Title.Location = new System.Drawing.Point(34, 6);
            this.FormApply_Title.Margin = new System.Windows.Forms.Padding(6);
            this.FormApply_Title.Name = "FormApply_Title";
            this.FormApply_Title.Size = new System.Drawing.Size(546, 30);
            this.FormApply_Title.TabIndex = 0;
            this.FormApply_Title.Text = "Senior Backend Developer (Java) at One Mount Group";
            // 
            // FormApplyJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormApplyJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Jobs - Ứng Tuyển Công Việc";
            this.Load += new System.EventHandler(this.FormApplyJob_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox FormApply_rtb_Describe;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox FormApply_tb_FileName;
        private System.Windows.Forms.Button FormApply_bt_SendCV;
        private System.Windows.Forms.Button FormApply_bt_ChooseFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FormApply_tb_UserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FormApply_Title;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox FormApply_tb_Email;
        private System.Windows.Forms.Label label1;
    }
}