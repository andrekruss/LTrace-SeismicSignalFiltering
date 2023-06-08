namespace SeismicSignalFiltering.Views
{
    partial class FilteredSignalView
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
            this.txtLpfFreqCutoff = new System.Windows.Forms.TextBox();
            this.txtHpfFreqCutoff = new System.Windows.Forms.TextBox();
            this.lblLpfFreqCutoff = new System.Windows.Forms.Label();
            this.lblHpfFreqCutoff = new System.Windows.Forms.Label();
            this.waveChart = new ZedGraph.ZedGraphControl();
            this.trackBarLpfFreqCutoff = new System.Windows.Forms.TrackBar();
            this.trackBarHpfFreqCutoff = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLpfFreqCutoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHpfFreqCutoff)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLpfFreqCutoff
            // 
            this.txtLpfFreqCutoff.Location = new System.Drawing.Point(33, 69);
            this.txtLpfFreqCutoff.Name = "txtLpfFreqCutoff";
            this.txtLpfFreqCutoff.Size = new System.Drawing.Size(100, 20);
            this.txtLpfFreqCutoff.TabIndex = 0;
            // 
            // txtHpfFreqCutoff
            // 
            this.txtHpfFreqCutoff.Location = new System.Drawing.Point(33, 145);
            this.txtHpfFreqCutoff.Name = "txtHpfFreqCutoff";
            this.txtHpfFreqCutoff.Size = new System.Drawing.Size(100, 20);
            this.txtHpfFreqCutoff.TabIndex = 1;
            // 
            // lblLpfFreqCutoff
            // 
            this.lblLpfFreqCutoff.AutoSize = true;
            this.lblLpfFreqCutoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLpfFreqCutoff.Location = new System.Drawing.Point(30, 39);
            this.lblLpfFreqCutoff.Name = "lblLpfFreqCutoff";
            this.lblLpfFreqCutoff.Size = new System.Drawing.Size(221, 13);
            this.lblLpfFreqCutoff.TabIndex = 2;
            this.lblLpfFreqCutoff.Text = "Low Pass Filter Frequency Cutoff (Hz)";
            // 
            // lblHpfFreqCutoff
            // 
            this.lblHpfFreqCutoff.AutoSize = true;
            this.lblHpfFreqCutoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHpfFreqCutoff.Location = new System.Drawing.Point(30, 117);
            this.lblHpfFreqCutoff.Name = "lblHpfFreqCutoff";
            this.lblHpfFreqCutoff.Size = new System.Drawing.Size(224, 13);
            this.lblHpfFreqCutoff.TabIndex = 3;
            this.lblHpfFreqCutoff.Text = "High Pass Filter Frequency Cutoff (Hz)";
            // 
            // waveChart
            // 
            this.waveChart.BackColor = System.Drawing.Color.Silver;
            this.waveChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveChart.Location = new System.Drawing.Point(265, 39);
            this.waveChart.Name = "waveChart";
            this.waveChart.ScrollGrace = 0D;
            this.waveChart.ScrollMaxX = 0D;
            this.waveChart.ScrollMaxY = 0D;
            this.waveChart.ScrollMaxY2 = 0D;
            this.waveChart.ScrollMinX = 0D;
            this.waveChart.ScrollMinY = 0D;
            this.waveChart.ScrollMinY2 = 0D;
            this.waveChart.Size = new System.Drawing.Size(493, 480);
            this.waveChart.TabIndex = 4;
            this.waveChart.UseExtendedPrintDialog = true;
            // 
            // trackBarLpfFreqCutoff
            // 
            this.trackBarLpfFreqCutoff.Location = new System.Drawing.Point(145, 69);
            this.trackBarLpfFreqCutoff.Maximum = 100;
            this.trackBarLpfFreqCutoff.Name = "trackBarLpfFreqCutoff";
            this.trackBarLpfFreqCutoff.Size = new System.Drawing.Size(104, 45);
            this.trackBarLpfFreqCutoff.TabIndex = 5;
            // 
            // trackBarHpfFreqCutoff
            // 
            this.trackBarHpfFreqCutoff.Location = new System.Drawing.Point(145, 145);
            this.trackBarHpfFreqCutoff.Maximum = 100;
            this.trackBarHpfFreqCutoff.Name = "trackBarHpfFreqCutoff";
            this.trackBarHpfFreqCutoff.Size = new System.Drawing.Size(104, 45);
            this.trackBarHpfFreqCutoff.TabIndex = 6;
            // 
            // FilteredSignalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(878, 542);
            this.Controls.Add(this.trackBarHpfFreqCutoff);
            this.Controls.Add(this.trackBarLpfFreqCutoff);
            this.Controls.Add(this.waveChart);
            this.Controls.Add(this.lblHpfFreqCutoff);
            this.Controls.Add(this.lblLpfFreqCutoff);
            this.Controls.Add(this.txtHpfFreqCutoff);
            this.Controls.Add(this.txtLpfFreqCutoff);
            this.Name = "FilteredSignalView";
            this.Text = "Filtered Signal";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLpfFreqCutoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHpfFreqCutoff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLpfFreqCutoff;
        private System.Windows.Forms.TextBox txtHpfFreqCutoff;
        private System.Windows.Forms.Label lblLpfFreqCutoff;
        private System.Windows.Forms.Label lblHpfFreqCutoff;
        private ZedGraph.ZedGraphControl waveChart;
        private System.Windows.Forms.TrackBar trackBarLpfFreqCutoff;
        private System.Windows.Forms.TrackBar trackBarHpfFreqCutoff;
    }
}