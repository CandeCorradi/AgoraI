namespace Desktop.Views
{
    partial class SplashView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashView));
            pictureBox1 = new PictureBox();
            ProgressBar = new ProgressBar();
            Timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(117, 11);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(16, 176);
            ProgressBar.Margin = new Padding(2, 2, 2, 2);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(469, 20);
            ProgressBar.TabIndex = 1;
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Tick += timer_Tick;
            // 
            // SplashView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(502, 203);
            Controls.Add(ProgressBar);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 2, 2, 2);
            Name = "SplashView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ProgressBar ProgressBar;
        private System.Windows.Forms.Timer Timer;
    }
}