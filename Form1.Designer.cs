namespace Robinhood_API
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BtnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lablAccountNumber = new System.Windows.Forms.Label();
            this.lablStaus = new System.Windows.Forms.Label();
            this.lablBuyingPower = new System.Windows.Forms.Label();
            this.chartprice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPrice = new System.Windows.Forms.Label();
            this.priceTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartprice)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(1200, 678);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(156, 41);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Fluent Icons", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "WELCOME TO CRYPTO WATCHING";
            // 
            // lablAccountNumber
            // 
            this.lablAccountNumber.AutoSize = true;
            this.lablAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablAccountNumber.Location = new System.Drawing.Point(714, 53);
            this.lablAccountNumber.Name = "lablAccountNumber";
            this.lablAccountNumber.Size = new System.Drawing.Size(128, 20);
            this.lablAccountNumber.TabIndex = 4;
            this.lablAccountNumber.Text = "Account Number";
            // 
            // lablStaus
            // 
            this.lablStaus.AutoSize = true;
            this.lablStaus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablStaus.Location = new System.Drawing.Point(809, 73);
            this.lablStaus.Name = "lablStaus";
            this.lablStaus.Size = new System.Drawing.Size(44, 16);
            this.lablStaus.TabIndex = 5;
            this.lablStaus.Text = "Status";
            // 
            // lablBuyingPower
            // 
            this.lablBuyingPower.AutoSize = true;
            this.lablBuyingPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablBuyingPower.Location = new System.Drawing.Point(390, 99);
            this.lablBuyingPower.Name = "lablBuyingPower";
            this.lablBuyingPower.Size = new System.Drawing.Size(193, 31);
            this.lablBuyingPower.TabIndex = 6;
            this.lablBuyingPower.Text = "Buying Power";
            // 
            // chartprice
            // 
            this.chartprice.BackColor = System.Drawing.Color.Gray;
            this.chartprice.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.chartprice.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartprice.Legends.Add(legend1);
            this.chartprice.Location = new System.Drawing.Point(15, 196);
            this.chartprice.Name = "chartprice";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "ChartPrice";
            this.chartprice.Series.Add(series1);
            this.chartprice.Size = new System.Drawing.Size(1341, 476);
            this.chartprice.TabIndex = 8;
            this.chartprice.Text = "chart1";
            this.chartprice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartprice_MouseMove);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(236, 138);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(57, 55);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "P";
            // 
            // priceTimer
            // 
            this.priceTimer.Tick += new System.EventHandler(this.priceTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 55);
            this.label2.TabIndex = 10;
            this.label2.Text = "BITCOIN:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1368, 731);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.chartprice);
            this.Controls.Add(this.lablBuyingPower);
            this.Controls.Add(this.lablStaus);
            this.Controls.Add(this.lablAccountNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartprice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lablAccountNumber;
        private System.Windows.Forms.Label lablStaus;
        private System.Windows.Forms.Label lablBuyingPower;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartprice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Timer priceTimer;
        private System.Windows.Forms.Label label2;
    }
}

