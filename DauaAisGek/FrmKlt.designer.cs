namespace DauaAisGek
{
    partial class FrmKlt
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIinBeg = new System.Windows.Forms.TextBox();
            this.ButWrt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtIinEnd = new System.Windows.Forms.TextBox();
            this.DatBeg = new System.Windows.Forms.DateTimePicker();
            this.DatEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Начало (год)";
            // 
            // TxtIinBeg
            // 
            this.TxtIinBeg.Location = new System.Drawing.Point(143, 42);
            this.TxtIinBeg.Name = "TxtIinBeg";
            this.TxtIinBeg.Size = new System.Drawing.Size(124, 20);
            this.TxtIinBeg.TabIndex = 4;
            // 
            // ButWrt
            // 
            this.ButWrt.Location = new System.Drawing.Point(98, 131);
            this.ButWrt.Name = "ButWrt";
            this.ButWrt.Size = new System.Drawing.Size(209, 34);
            this.ButWrt.TabIndex = 8;
            this.ButWrt.Text = "Записать";
            this.ButWrt.UseVisualStyleBackColor = true;
            this.ButWrt.Click += new System.EventHandler(this.ButWrt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Укажите период:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TxtIinEnd
            // 
            this.TxtIinEnd.Location = new System.Drawing.Point(277, 42);
            this.TxtIinEnd.Name = "TxtIinEnd";
            this.TxtIinEnd.Size = new System.Drawing.Size(110, 20);
            this.TxtIinEnd.TabIndex = 23;
            // 
            // DatBeg
            // 
            this.DatBeg.Location = new System.Drawing.Point(143, 71);
            this.DatBeg.Name = "DatBeg";
            this.DatBeg.Size = new System.Drawing.Size(124, 20);
            this.DatBeg.TabIndex = 25;
            this.DatBeg.ValueChanged += new System.EventHandler(this.DatBeg_ValueChanged);
            // 
            // DatEnd
            // 
            this.DatEnd.Location = new System.Drawing.Point(277, 71);
            this.DatEnd.Name = "DatEnd";
            this.DatEnd.Size = new System.Drawing.Size(110, 20);
            this.DatEnd.TabIndex = 26;
            // 
            // FrmKlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 181);
            this.Controls.Add(this.DatEnd);
            this.Controls.Add(this.DatBeg);
            this.Controls.Add(this.TxtIinEnd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ButWrt);
            this.Controls.Add(this.TxtIinBeg);
            this.Controls.Add(this.label2);
            this.Name = "FrmKlt";
            this.Text = "FrmKlt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButWrt;
        public System.Windows.Forms.TextBox TxtIinBeg;
        public System.Windows.Forms.TextBox TxtIinEnd;
        public System.Windows.Forms.DateTimePicker DatBeg;
        public System.Windows.Forms.DateTimePicker DatEnd;
    }
}