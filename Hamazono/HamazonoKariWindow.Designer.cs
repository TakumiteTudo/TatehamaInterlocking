namespace TatehamaInterlocking.Hamazono
{
    partial class HamazonoKariWindow
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
            button1 = new Button();
            button12 = new Button();
            button4 = new Button();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(251, 226);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 23;
            button1.Text = "←\r\n2L";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button12
            // 
            button12.Location = new Point(453, 14);
            button12.Margin = new Padding(4, 2, 4, 2);
            button12.Name = "button12";
            button12.Size = new Size(50, 40);
            button12.TabIndex = 22;
            button12.Text = "取消";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button4
            // 
            button4.Location = new Point(516, 134);
            button4.Margin = new Padding(4, 2, 4, 2);
            button4.Name = "button4";
            button4.Size = new Size(50, 40);
            button4.TabIndex = 21;
            button4.Text = "→\r\n3R";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(821, 224);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(50, 40);
            button2.TabIndex = 24;
            button2.Text = "←\r\n5L";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(166, 132);
            button3.Margin = new Padding(4, 2, 4, 2);
            button3.Name = "button3";
            button3.Size = new Size(50, 40);
            button3.TabIndex = 25;
            button3.Text = "→\r1R";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Lime;
            button5.Location = new Point(464, 134);
            button5.Margin = new Padding(4, 2, 4, 2);
            button5.Name = "button5";
            button5.Size = new Size(50, 40);
            button5.TabIndex = 26;
            button5.Text = "→\r\n11R";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Lime;
            button6.Location = new Point(818, 134);
            button6.Margin = new Padding(4, 2, 4, 2);
            button6.Name = "button6";
            button6.Size = new Size(50, 40);
            button6.TabIndex = 27;
            button6.Text = "←\r\n12L";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Gold;
            label1.Font = new Font("ＭＳ ゴシック", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(586, 72);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(310, 48);
            label1.TabIndex = 28;
            label1.Text = "★入換進路TID表示非対応★\r\n進路自体は取れます。";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // HamazonoKariWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.HamazonoKari;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1000, 350);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button12);
            Controls.Add(button4);
            Cursor = Cursors.Cross;
            Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(4, 2, 4, 2);
            Name = "HamazonoKariWindow";
            Text = "浜　園 | 仮操作盤 | 館浜電鉄　ダイヤ運転";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button12;
        private Button button4;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button button6;
        private Label label1;
    }
}