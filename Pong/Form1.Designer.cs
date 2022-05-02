namespace Pong
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
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.p1scorelabel = new System.Windows.Forms.Label();
            this.p2scorelabel = new System.Windows.Forms.Label();
            this.winlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 1;
            this.gametimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // p1scorelabel
            // 
            this.p1scorelabel.BackColor = System.Drawing.Color.Transparent;
            this.p1scorelabel.Font = new System.Drawing.Font("Bebas Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1scorelabel.ForeColor = System.Drawing.Color.White;
            this.p1scorelabel.Location = new System.Drawing.Point(200, 9);
            this.p1scorelabel.Name = "p1scorelabel";
            this.p1scorelabel.Size = new System.Drawing.Size(100, 23);
            this.p1scorelabel.TabIndex = 1;
            this.p1scorelabel.Text = "0";
            this.p1scorelabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p2scorelabel
            // 
            this.p2scorelabel.BackColor = System.Drawing.Color.Transparent;
            this.p2scorelabel.Font = new System.Drawing.Font("Bebas Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2scorelabel.ForeColor = System.Drawing.Color.White;
            this.p2scorelabel.Location = new System.Drawing.Point(282, 9);
            this.p2scorelabel.Name = "p2scorelabel";
            this.p2scorelabel.Size = new System.Drawing.Size(100, 23);
            this.p2scorelabel.TabIndex = 2;
            this.p2scorelabel.Text = "0";
            this.p2scorelabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // winlabel
            // 
            this.winlabel.BackColor = System.Drawing.Color.Transparent;
            this.winlabel.Font = new System.Drawing.Font("Bebas Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winlabel.ForeColor = System.Drawing.Color.White;
            this.winlabel.Location = new System.Drawing.Point(245, 353);
            this.winlabel.Name = "winlabel";
            this.winlabel.Size = new System.Drawing.Size(100, 23);
            this.winlabel.TabIndex = 3;
            this.winlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.winlabel);
            this.Controls.Add(this.p2scorelabel);
            this.Controls.Add(this.p1scorelabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fair Hockey";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Label p1scorelabel;
        private System.Windows.Forms.Label p2scorelabel;
        private System.Windows.Forms.Label winlabel;
    }
}

