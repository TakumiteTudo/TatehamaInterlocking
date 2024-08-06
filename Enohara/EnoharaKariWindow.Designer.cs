namespace TatehamaInterlocking.Enohara
{
    partial class EnoharaKariWindow
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
            button12 = new Button();
            button11 = new Button();
            button4 = new Button();
            button1 = new Button();
            button3 = new Button();
            button5 = new Button();
            button2 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button12
            // 
            button12.Location = new Point(455, 13);
            button12.Name = "button12";
            button12.Size = new Size(50, 40);
            button12.TabIndex = 19;
            button12.Text = "取消";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Location = new Point(682, 131);
            button11.Name = "button11";
            button11.Size = new Size(50, 40);
            button11.TabIndex = 18;
            button11.Text = "←\r\n4L";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button4
            // 
            button4.Location = new Point(495, 125);
            button4.Name = "button4";
            button4.Size = new Size(50, 40);
            button4.TabIndex = 17;
            button4.Text = "→\r\n2R";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(681, 74);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 20;
            button1.Text = "←\r\n3L";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(843, 197);
            button3.Name = "button3";
            button3.Size = new Size(50, 40);
            button3.TabIndex = 21;
            button3.Text = "←\r\n5LE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(843, 238);
            button5.Name = "button5";
            button5.Size = new Size(50, 40);
            button5.TabIndex = 22;
            button5.Text = "←\r\n5LD";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Location = new Point(70, 171);
            button2.Name = "button2";
            button2.Size = new Size(50, 40);
            button2.TabIndex = 17;
            button2.Text = "→\r\n1RA";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button6
            // 
            button6.Location = new Point(70, 130);
            button6.Name = "button6";
            button6.Size = new Size(50, 40);
            button6.TabIndex = 17;
            button6.Text = "→\r\n1RB";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(70, 89);
            button7.Name = "button7";
            button7.Size = new Size(50, 40);
            button7.TabIndex = 17;
            button7.Text = "→\r\n1RC";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // EnoharaKariWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.EnoharaKari;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1000, 296);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button4);
            DoubleBuffered = true;
            Font = new Font("ＭＳ ゴシック", 12F);
            Name = "EnoharaKariWindow";
            Text = "江ノ原検 | 仮操作盤 | 館浜電鉄　ダイヤ運転";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button button12;
        private Button button11;
        private Button button4;
        private Button button1;
        private Button button3;
        private Button button5;
        private Button button2;
        private Button button6;
        private Button button7;
    }
}