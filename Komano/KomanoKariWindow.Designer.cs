namespace TatehamaInterlocking.Komano
{
    partial class KomanoKariWindow
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
            button5 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(12, 148);
            button5.Name = "button5";
            button5.Size = new Size(50, 40);
            button5.TabIndex = 5;
            button5.Text = "→\r\n1RD5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 191);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 6;
            button1.Text = "→\r\n1RD0";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(289, 209);
            button2.Name = "button2";
            button2.Size = new Size(50, 40);
            button2.TabIndex = 8;
            button2.Text = "→\r\n5RB";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(289, 166);
            button3.Name = "button3";
            button3.Size = new Size(50, 40);
            button3.TabIndex = 7;
            button3.Text = "→\r\n5RA";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Lime;
            button4.Location = new Point(375, 38);
            button4.Name = "button4";
            button4.Size = new Size(50, 40);
            button4.TabIndex = 9;
            button4.Text = "→\r\n54R";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new Point(732, 41);
            button6.Name = "button6";
            button6.Size = new Size(50, 40);
            button6.TabIndex = 10;
            button6.Text = "→\r\n7R";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(733, 188);
            button7.Name = "button7";
            button7.Size = new Size(50, 40);
            button7.TabIndex = 11;
            button7.Text = "→\r\n8R";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(931, 259);
            button8.Name = "button8";
            button8.Size = new Size(50, 40);
            button8.TabIndex = 12;
            button8.Text = "←\r\n9LC";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(534, 256);
            button9.Name = "button9";
            button9.Size = new Size(50, 40);
            button9.TabIndex = 13;
            button9.Text = "←\r\n6L";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(147, 258);
            button10.Name = "button10";
            button10.Size = new Size(50, 40);
            button10.TabIndex = 14;
            button10.Text = "←\r\n2L";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(266, 93);
            button11.Name = "button11";
            button11.Size = new Size(50, 40);
            button11.TabIndex = 15;
            button11.Text = "←\r\n3L";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(470, 2);
            button12.Name = "button12";
            button12.Size = new Size(50, 40);
            button12.TabIndex = 16;
            button12.Text = "取消";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // KomanoKariWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.KomanoKari;
            ClientSize = new Size(1000, 348);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button5);
            Font = new Font("ＭＳ ゴシック", 12F);
            Name = "KomanoKariWindow";
            Text = "駒　野 | 仮操作盤 | 館浜電鉄　ダイヤ運転";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button button5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
    }
}