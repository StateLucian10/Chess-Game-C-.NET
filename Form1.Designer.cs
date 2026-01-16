namespace JocDeSah
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            iesireToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            p = new PictureBox();
            panel2 = new Panel();
            panel1 = new Panel();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)p).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem4, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(873, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, iesireToolStripMenuItem });
            toolStripMenuItem1.Image = (Image)resources.GetObject("toolStripMenuItem1.Image");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(82, 24);
            toolStripMenuItem1.Text = "&Game";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(224, 26);
            toolStripMenuItem5.Text = "Restart";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // iesireToolStripMenuItem
            // 
            iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            iesireToolStripMenuItem.ShortcutKeys = Keys.F10;
            iesireToolStripMenuItem.ShowShortcutKeys = false;
            iesireToolStripMenuItem.Size = new Size(224, 26);
            iesireToolStripMenuItem.Text = "Exit";
            iesireToolStripMenuItem.Click += iesireToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(60, 24);
            toolStripMenuItem4.Text = "Menu";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(55, 24);
            toolStripMenuItem2.Text = "&Help";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // p
            // 
            p.Location = new Point(21, 55);
            p.Name = "p";
            p.Size = new Size(840, 600);
            p.TabIndex = 1;
            p.TabStop = false;
            p.Click += p_Click;
            p.Paint += p_Paint;
            p.MouseDown += p_MouseDown;
            p.MouseMove += p_MouseMove;
            p.MouseUp += p_MouseUp;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(p);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(873, 702);
            panel2.TabIndex = 2;
            panel2.Paint += panel1_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(876, 702);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(311, 346);
            button2.Name = "button2";
            button2.Size = new Size(228, 64);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sylfaen", 64.2000046F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(127, 80);
            label1.Name = "label1";
            label1.Size = new Size(620, 141);
            label1.TabIndex = 1;
            label1.Text = "Chess Game";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Tomato;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(311, 244);
            button1.Name = "button1";
            button1.Size = new Size(228, 56);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.KeyDown += button1_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(651, 55);
            label2.Name = "label2";
            label2.Size = new Size(65, 24);
            label2.TabIndex = 3;
            label2.Text = "White";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 703);
            Controls.Add(menuStrip1);
            Controls.Add(panel2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)p).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem iesireToolStripMenuItem;
        private PictureBox p;
        private ToolStripMenuItem toolStripMenuItem2;
        private Panel panel2;
        private Panel panel1;
        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
    }
}
