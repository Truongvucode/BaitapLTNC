namespace WinFormsApp1
{
    partial class frmungdungquanlysv
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
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            numericUpDown1 = new NumericUpDown();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox8 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            textBox6 = new TextBox();
            label8 = new Label();
            textBox5 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            textBox4 = new TextBox();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            button5 = new Button();
            button6 = new Button();
            label13 = new Label();
            numericUpDown2 = new NumericUpDown();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox8);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1245, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quản lý sinh viên";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(684, 67);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 29);
            radioButton2.TabIndex = 25;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nữ";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(595, 69);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(75, 29);
            radioButton1.TabIndex = 24;
            radioButton1.TabStop = true;
            radioButton1.Text = "Nam";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Location = new Point(929, 67);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 31);
            numericUpDown1.TabIndex = 23;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button4
            // 
            button4.Location = new Point(1045, 158);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 22;
            button4.Text = "&Sửa";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(909, 160);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 21;
            button3.Text = "&Làm mới";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(766, 160);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 20;
            button2.Text = "&Xóa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(633, 158);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 19;
            button1.Text = "&Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox8.Location = new Point(929, 108);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(150, 31);
            textBox8.TabIndex = 18;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(824, 111);
            label10.Name = "label10";
            label10.Size = new Size(89, 25);
            label10.TabIndex = 17;
            label10.Text = "Trạng thái";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(824, 69);
            label9.Name = "label9";
            label9.Size = new Size(54, 25);
            label9.TabIndex = 15;
            label9.Text = "Điểm";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox6.Location = new Point(929, 24);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(150, 31);
            textBox6.TabIndex = 14;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(824, 27);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 13;
            label8.Text = "Lớp học";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(595, 108);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(480, 108);
            label7.Name = "label7";
            label7.Size = new Size(93, 25);
            label7.TabIndex = 11;
            label7.Text = "Điện thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(480, 66);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 9;
            label6.Text = "Giới tính";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(595, 27);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(480, 27);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 7;
            label5.Text = "Họ tên";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(138, 64);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 31);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.Value = new DateTime(2026, 10, 3, 0, 0, 0, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 64);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 5;
            label4.Text = "Ngày sinh";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 108);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(138, 102);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "abc@st.vju.ac.vn";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 64);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 27);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 0;
            label1.Text = "MSV";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(numericUpDown2);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(3, 202);
            panel1.Name = "panel1";
            panel1.Size = new Size(1236, 70);
            panel1.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(105, 18);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(203, 31);
            textBox4.TabIndex = 27;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 21);
            label11.Name = "label11";
            label11.Size = new Size(76, 25);
            label11.TabIndex = 26;
            label11.Text = "Từ khóa";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(436, 15);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(122, 31);
            textBox7.TabIndex = 29;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(385, 18);
            label12.Name = "label12";
            label12.Size = new Size(42, 25);
            label12.TabIndex = 28;
            label12.Text = "Lớp";
            label12.Click += this.label12_Click;
            // 
            // button5
            // 
            button5.Location = new Point(909, 16);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 26;
            button5.Text = "&Xóa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(1045, 13);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 26;
            button6.Text = "&Sửa";
            button6.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(633, 22);
            label13.Name = "label13";
            label13.Size = new Size(76, 25);
            label13.TabIndex = 26;
            label13.Text = "Điểm từ";
            label13.Click += label13_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Location = new Point(728, 15);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(116, 31);
            numericUpDown2.TabIndex = 26;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(3, 278);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1236, 432);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sinh viên";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1221, 396);
            dataGridView1.TabIndex = 0;
            // 
            // frmungdungquanlysv
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 707);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "frmungdungquanlysv";
            Text = "Ứng dụng quản lý sinh viên";
            Load += frmungdungquanlysv_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox8;
        private Label label10;
        private Label label9;
        private TextBox textBox6;
        private Label label8;
        private TextBox textBox5;
        private Label label7;
        private Label label6;
        private TextBox textBox3;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel panel1;
        private TextBox textBox4;
        private Label label11;
        private TextBox textBox7;
        private Label label12;
        private Label label13;
        private Button button6;
        private Button button5;
        private NumericUpDown numericUpDown2;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
    }
}