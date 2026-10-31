namespace LibraryApp.UI.Forms
{
    partial class FrmAddCopies
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBookInfo = new Label();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblCondition = new Label();
            cboCondition = new ComboBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            panelHeader = new Panel();
            lblHeaderTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(24, 76, 120);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(464, 55);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(16, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(244, 21);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "NHẬP BỔ SUNG BẢN SAO SÁCH";
            // 
            // lblBookInfo
            // 
            lblBookInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBookInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblBookInfo.Location = new Point(20, 70);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(424, 40);
            lblBookInfo.TabIndex = 1;
            lblBookInfo.Text = "Đầu sách: B001 - Mắt Biếc";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.5F);
            lblQuantity.Location = new Point(20, 125);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(137, 17);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số lượng bản sao (*):";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(175, 123);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 25);
            numQuantity.TabIndex = 3;
            numQuantity.TextAlign = HorizontalAlignment.Right;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Font = new Font("Segoe UI", 9.5F);
            lblCondition.Location = new Point(20, 168);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(149, 17);
            lblCondition.TabIndex = 4;
            lblCondition.Text = "Tình trạng vật lý ban đầu:";
            // 
            // cboCondition
            // 
            cboCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCondition.Font = new Font("Segoe UI", 10F);
            cboCondition.FormattingEnabled = true;
            cboCondition.Location = new Point(175, 165);
            cboCondition.Name = "cboCondition";
            cboCondition.Size = new Size(269, 25);
            cboCondition.TabIndex = 5;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(40, 167, 69);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(215, 220);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(110, 36);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F);
            btnCancel.ForeColor = Color.FromArgb(33, 37, 41);
            btnCancel.Location = new Point(334, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmAddCopies
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            CancelButton = btnCancel;
            ClientSize = new Size(464, 275);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(cboCondition);
            Controls.Add(lblCondition);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(lblBookInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAddCopies";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập bổ sung bản sao";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblBookInfo;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblCondition;
        private ComboBox cboCondition;
        private Button btnConfirm;
        private Button btnCancel;
    }
}
