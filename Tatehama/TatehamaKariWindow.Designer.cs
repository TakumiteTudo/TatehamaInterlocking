﻿namespace TatehamaInterlocking.Tatehama
{
    partial class TatehamaKariWindow
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(688, 105);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 0;
            button1.Text = "←\r\n5LA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(688, 145);
            button2.Name = "button2";
            button2.Size = new Size(50, 40);
            button2.TabIndex = 1;
            button2.Text = "←\r\n5LB";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(689, 185);
            button3.Name = "button3";
            button3.Size = new Size(50, 40);
            button3.TabIndex = 2;
            button3.Text = "←\r\n5LC";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(689, 225);
            button4.Name = "button4";
            button4.Size = new Size(50, 40);
            button4.TabIndex = 3;
            button4.Text = "←\r\n5LD";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(297, 39);
            button5.Name = "button5";
            button5.Size = new Size(50, 40);
            button5.TabIndex = 4;
            button5.Text = "→\r\n1R";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(297, 110);
            button6.Name = "button6";
            button6.Size = new Size(50, 40);
            button6.TabIndex = 5;
            button6.Text = "→\r\n2R";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(297, 168);
            button7.Name = "button7";
            button7.Size = new Size(50, 40);
            button7.TabIndex = 6;
            button7.Text = "→\r\n3R";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(297, 222);
            button8.Name = "button8";
            button8.Size = new Size(50, 40);
            button8.TabIndex = 7;
            button8.Text = "→\r\n4R";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(392, 12);
            button9.Name = "button9";
            button9.Size = new Size(50, 40);
            button9.TabIndex = 8;
            button9.Text = "取消";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // TatehamaKariWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.Tatehama_a;
            ClientSize = new Size(1000, 321);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("ＭＳ ゴシック", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TatehamaKariWindow";
            Text = "館　浜 | 仮操作盤 | 館浜電鉄　ダイヤ運転";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}