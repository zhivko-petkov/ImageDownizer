namespace ImageDownsizer
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
            browse_btn = new Button();
            browsed_file_textBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            percentage_combo_box = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            compress_button = new Button();
            conseq_radioBtn = new RadioButton();
            parallel_radioBtn = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            duration_label = new Label();
            label7 = new Label();
            consequentialBtn2 = new RadioButton();
            save_file_textBox = new TextBox();
            saveAsBtn = new Button();
            label8 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            resizedImagePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)resizedImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // browse_btn
            // 
            browse_btn.BackColor = Color.LightGray;
            browse_btn.FlatStyle = FlatStyle.Flat;
            browse_btn.Location = new Point(487, 187);
            browse_btn.Name = "browse_btn";
            browse_btn.Size = new Size(102, 27);
            browse_btn.TabIndex = 0;
            browse_btn.Text = "Browse";
            browse_btn.UseVisualStyleBackColor = false;
            browse_btn.Click += browse_btn_Click;
            // 
            // browsed_file_textBox
            // 
            browsed_file_textBox.BackColor = Color.MintCream;
            browsed_file_textBox.BorderStyle = BorderStyle.FixedSingle;
            browsed_file_textBox.Location = new Point(78, 187);
            browsed_file_textBox.Name = "browsed_file_textBox";
            browsed_file_textBox.Size = new Size(392, 27);
            browsed_file_textBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(179, 21);
            label1.Name = "label1";
            label1.Size = new Size(466, 48);
            label1.TabIndex = 2;
            label1.Text = "IMAGE DOWNSIZER";
            // 
            // percentage_combo_box
            // 
            percentage_combo_box.BackColor = Color.FromArgb(255, 255, 192);
            percentage_combo_box.FormattingEnabled = true;
            percentage_combo_box.Location = new Point(82, 363);
            percentage_combo_box.Name = "percentage_combo_box";
            percentage_combo_box.Size = new Size(87, 28);
            percentage_combo_box.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 340);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 4;
            label2.Text = "% of downsizing";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 165);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 5;
            label3.Text = "Selected file";
            // 
            // compress_button
            // 
            compress_button.BackColor = Color.LightGreen;
            compress_button.FlatStyle = FlatStyle.Flat;
            compress_button.Location = new Point(196, 363);
            compress_button.Name = "compress_button";
            compress_button.Size = new Size(106, 28);
            compress_button.TabIndex = 6;
            compress_button.Text = "Compress";
            compress_button.UseVisualStyleBackColor = false;
            compress_button.Click += compress_button_Click;
            // 
            // conseq_radioBtn
            // 
            conseq_radioBtn.AutoSize = true;
            conseq_radioBtn.Location = new Point(101, 131);
            conseq_radioBtn.Name = "conseq_radioBtn";
            conseq_radioBtn.Size = new Size(124, 24);
            conseq_radioBtn.TabIndex = 7;
            conseq_radioBtn.TabStop = true;
            conseq_radioBtn.Text = "Consequential";
            conseq_radioBtn.UseVisualStyleBackColor = true;
            // 
            // parallel_radioBtn
            // 
            parallel_radioBtn.AutoSize = true;
            parallel_radioBtn.Location = new Point(247, 131);
            parallel_radioBtn.Name = "parallel_radioBtn";
            parallel_radioBtn.Size = new Size(78, 24);
            parallel_radioBtn.TabIndex = 8;
            parallel_radioBtn.TabStop = true;
            parallel_radioBtn.Text = "Parallel";
            parallel_radioBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 363);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(0, 20);
            label4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 108);
            label5.Name = "label5";
            label5.Size = new Size(186, 20);
            label5.TabIndex = 11;
            label5.Text = "Selected type of algorithm";
            // 
            // duration_label
            // 
            duration_label.AutoSize = true;
            duration_label.Location = new Point(76, 406);
            duration_label.Name = "duration_label";
            duration_label.Size = new Size(116, 20);
            duration_label.TabIndex = 14;
            duration_label.Text = "Processing time:";
            duration_label.UseMnemonic = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label7.Location = new Point(82, 266);
            label7.Name = "label7";
            label7.Size = new Size(0, 17);
            label7.TabIndex = 16;
            // 
            // consequentialBtn2
            // 
            consequentialBtn2.AutoSize = true;
            consequentialBtn2.Location = new Point(345, 131);
            consequentialBtn2.Name = "consequentialBtn2";
            consequentialBtn2.Size = new Size(136, 24);
            consequentialBtn2.TabIndex = 17;
            consequentialBtn2.TabStop = true;
            consequentialBtn2.Text = "Consequential 2";
            consequentialBtn2.UseVisualStyleBackColor = true;
            // 
            // save_file_textBox
            // 
            save_file_textBox.BackColor = Color.AliceBlue;
            save_file_textBox.BorderStyle = BorderStyle.FixedSingle;
            save_file_textBox.Location = new Point(77, 262);
            save_file_textBox.Name = "save_file_textBox";
            save_file_textBox.Size = new Size(388, 27);
            save_file_textBox.TabIndex = 18;
            // 
            // saveAsBtn
            // 
            saveAsBtn.BackColor = Color.LightGray;
            saveAsBtn.FlatStyle = FlatStyle.Flat;
            saveAsBtn.Location = new Point(485, 262);
            saveAsBtn.Name = "saveAsBtn";
            saveAsBtn.Size = new Size(102, 29);
            saveAsBtn.TabIndex = 19;
            saveAsBtn.Text = "Save As";
            saveAsBtn.UseVisualStyleBackColor = false;
            saveAsBtn.Click += saveAsBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(81, 239);
            label8.Name = "label8";
            label8.Size = new Size(129, 20);
            label8.TabIndex = 20;
            label8.Text = "Selected directory";
            // 
            // resizedImagePictureBox
            // 
            resizedImagePictureBox.Location = new Point(76, 460);
            resizedImagePictureBox.Name = "resizedImagePictureBox";
            resizedImagePictureBox.Size = new Size(692, 402);
            resizedImagePictureBox.TabIndex = 21;
            resizedImagePictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(844, 939);
            Controls.Add(resizedImagePictureBox);
            Controls.Add(label8);
            Controls.Add(saveAsBtn);
            Controls.Add(save_file_textBox);
            Controls.Add(consequentialBtn2);
            Controls.Add(label7);
            Controls.Add(duration_label);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(parallel_radioBtn);
            Controls.Add(conseq_radioBtn);
            Controls.Add(compress_button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(percentage_combo_box);
            Controls.Add(label1);
            Controls.Add(browsed_file_textBox);
            Controls.Add(browse_btn);
            Name = "Form1";
            Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)resizedImagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button browse_btn;
        private TextBox browsed_file_textBox;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private ComboBox percentage_combo_box;
        private Label label2;
        private Label label3;
        private Button compress_button;
        private RadioButton conseq_radioBtn;
        private RadioButton parallel_radioBtn;
        private ProgressBar progressBar1;
        private Label label4;
        private Label label5;
        private Button cancel_btn;
        private Label duration_label;
        private Label label7;
        private RadioButton consequentialBtn2;
        private TextBox save_file_textBox;
        private Button saveAsBtn;
        private Label label8;
        private SaveFileDialog saveFileDialog1;
        private PictureBox resizedImagePictureBox;
    }
}
