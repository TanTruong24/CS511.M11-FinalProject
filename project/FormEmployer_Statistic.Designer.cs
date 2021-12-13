
namespace project
{
    partial class FormEmployer_Statistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployer_Statistic));
            this.FormEmp_Char = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtGv_showResult = new System.Windows.Forms.DataGridView();
            this.FormEmp_dt_StartDay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormEmp_dt_EndDay = new System.Windows.Forms.DateTimePicker();
            this.FormEmp_bt_Result = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FormEmp_cbox_ChooseStatistic = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormEmp_Char)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGv_showResult)).BeginInit();
            this.SuspendLayout();
            // 
            // FormEmp_Char
            // 
            chartArea1.Name = "ChartArea1";
            this.FormEmp_Char.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.FormEmp_Char.Legends.Add(legend1);
            this.FormEmp_Char.Location = new System.Drawing.Point(421, 175);
            this.FormEmp_Char.Name = "FormEmp_Char";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Lượt xem";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Lượt ứng tuyển";
            this.FormEmp_Char.Series.Add(series1);
            this.FormEmp_Char.Series.Add(series2);
            this.FormEmp_Char.Size = new System.Drawing.Size(499, 263);
            this.FormEmp_Char.TabIndex = 0;
            this.FormEmp_Char.Text = "chart1";
            // 
            // dtGv_showResult
            // 
            this.dtGv_showResult.BackgroundColor = System.Drawing.Color.White;
            this.dtGv_showResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGv_showResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGv_showResult.Location = new System.Drawing.Point(12, 12);
            this.dtGv_showResult.Name = "dtGv_showResult";
            this.dtGv_showResult.Size = new System.Drawing.Size(403, 426);
            this.dtGv_showResult.TabIndex = 1;
            // 
            // FormEmp_dt_StartDay
            // 
            this.FormEmp_dt_StartDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FormEmp_dt_StartDay.Location = new System.Drawing.Point(576, 13);
            this.FormEmp_dt_StartDay.Name = "FormEmp_dt_StartDay";
            this.FormEmp_dt_StartDay.Size = new System.Drawing.Size(184, 20);
            this.FormEmp_dt_StartDay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày kết thúc:";
            // 
            // FormEmp_dt_EndDay
            // 
            this.FormEmp_dt_EndDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FormEmp_dt_EndDay.Location = new System.Drawing.Point(576, 53);
            this.FormEmp_dt_EndDay.Name = "FormEmp_dt_EndDay";
            this.FormEmp_dt_EndDay.Size = new System.Drawing.Size(184, 20);
            this.FormEmp_dt_EndDay.TabIndex = 2;
            // 
            // FormEmp_bt_Result
            // 
            this.FormEmp_bt_Result.Location = new System.Drawing.Point(562, 143);
            this.FormEmp_bt_Result.Name = "FormEmp_bt_Result";
            this.FormEmp_bt_Result.Size = new System.Drawing.Size(126, 26);
            this.FormEmp_bt_Result.TabIndex = 4;
            this.FormEmp_bt_Result.Text = "Kết quả";
            this.FormEmp_bt_Result.UseVisualStyleBackColor = true;
            this.FormEmp_bt_Result.Click += new System.EventHandler(this.FormEmp_bt_Result_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(436, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thống kê:";
            // 
            // FormEmp_cbox_ChooseStatistic
            // 
            this.FormEmp_cbox_ChooseStatistic.FormattingEnabled = true;
            this.FormEmp_cbox_ChooseStatistic.Items.AddRange(new object[] {
            "Lượt xem",
            "Lượt ứng tuyển"});
            this.FormEmp_cbox_ChooseStatistic.Location = new System.Drawing.Point(576, 95);
            this.FormEmp_cbox_ChooseStatistic.Name = "FormEmp_cbox_ChooseStatistic";
            this.FormEmp_cbox_ChooseStatistic.Size = new System.Drawing.Size(184, 21);
            this.FormEmp_cbox_ChooseStatistic.TabIndex = 6;
            // 
            // FormEmployer_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.FormEmp_cbox_ChooseStatistic);
            this.Controls.Add(this.FormEmp_bt_Result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormEmp_dt_EndDay);
            this.Controls.Add(this.FormEmp_dt_StartDay);
            this.Controls.Add(this.dtGv_showResult);
            this.Controls.Add(this.FormEmp_Char);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEmployer_Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT Jobs - Thống Kê";
            ((System.ComponentModel.ISupportInitialize)(this.FormEmp_Char)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGv_showResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FormEmp_Char;
        private System.Windows.Forms.DataGridView dtGv_showResult;
        private System.Windows.Forms.DateTimePicker FormEmp_dt_StartDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FormEmp_dt_EndDay;
        private System.Windows.Forms.Button FormEmp_bt_Result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FormEmp_cbox_ChooseStatistic;
    }
}