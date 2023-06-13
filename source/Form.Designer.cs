namespace OpenTK_WinForms_Template
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            glParentPanel = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            bindingSource1 = new BindingSource(components);
            scoreLabel = new Label();
            highScoreLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // glParentPanel
            // 
            glParentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            glParentPanel.BackColor = Color.Black;
            glParentPanel.BorderStyle = BorderStyle.Fixed3D;
            glParentPanel.Location = new Point(12, 68);
            glParentPanel.Name = "glParentPanel";
            glParentPanel.Size = new Size(960, 881);
            glParentPanel.TabIndex = 1;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1;
            timer.Tick += OnTimerTick;
            // 
            // scoreLabel
            // 
            scoreLabel.BackColor = Color.Black;
            scoreLabel.BorderStyle = BorderStyle.Fixed3D;
            scoreLabel.Font = new Font("Unispace", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.ForeColor = Color.FromArgb(255, 255, 128);
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(494, 56);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Score: ";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // highScoreLabel
            // 
            highScoreLabel.BackColor = Color.Black;
            highScoreLabel.BorderStyle = BorderStyle.Fixed3D;
            highScoreLabel.Font = new Font("Unispace", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            highScoreLabel.ForeColor = Color.FromArgb(255, 255, 128);
            highScoreLabel.Location = new Point(512, 9);
            highScoreLabel.Name = "highScoreLabel";
            highScoreLabel.Size = new Size(460, 56);
            highScoreLabel.TabIndex = 2;
            highScoreLabel.Text = "High Score: ";
            highScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 961);
            Controls.Add(highScoreLabel);
            Controls.Add(scoreLabel);
            Controls.Add(glParentPanel);
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = "Box Runner";
            Load += OnFormLoad;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel glParentPanel;
        private System.Windows.Forms.Timer timer;
        private BindingSource bindingSource1;
        private Label scoreLabel;
        private Label highScoreLabel;
    }
}