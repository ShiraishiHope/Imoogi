namespace Imoogi
{
    partial class Imoogi
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.textScore = new System.Windows.Forms.Label();
            this.textPoint = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Black;
            this.picCanvas.Location = new System.Drawing.Point(13, 13);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(580, 680);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // textScore
            // 
            this.textScore.AutoSize = true;
            this.textScore.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
            this.textScore.Location = new System.Drawing.Point(599, 81);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(51, 18);
            this.textScore.TabIndex = 2;
            this.textScore.Text = "Score:";
            // 
            // textPoint
            // 
            this.textPoint.AutoSize = true;
            this.textPoint.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
            this.textPoint.Location = new System.Drawing.Point(644, 81);
            this.textPoint.Name = "textPoint";
            this.textPoint.Size = new System.Drawing.Size(16, 18);
            this.textPoint.TabIndex = 2;
            this.textPoint.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(278, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "End Text";
            // 
            // Imoogi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 725);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPoint);
            this.Controls.Add(this.textScore);
            this.Controls.Add(this.picCanvas);
            this.Name = "Imoogi";
            this.Text = "Imoogi";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label textScore;
        private System.Windows.Forms.Label textPoint;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
    }
}

