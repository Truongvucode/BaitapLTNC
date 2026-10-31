namespace LibraryApp.UI.Forms
{
    partial class FrmUpdateCopy
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
            panelHeader = new Panel();
            lblHeaderTitle = new Label();
            lblCopyInfo = new Label();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblCondition = new Label();
            cboCondition = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            panelHeader.Size = new Size(440, 55);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(16, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(203, 21);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "CẬP NHẬT BẢN SAO SÁCH";
            // 
            // lblCopyInfo
            // 
            lblCopyInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCopyInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblCopyInfo.Location = new Point(20, 70);
            lblCopyInfo.Name = "lblCopyInfo";
            lblCopyInfo.Size = new Size(400, 30);
            lblCopyInfo.TabIndex = 1;
            lblCopyInfo.Text = "Mã bản sao: B001.001";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.Location = new Point(20, 115);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(93, 17);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái (*):";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(145, 112);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(265, 25);
            cboStatus.TabIndex = 3;
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Font = new Font("Segoe UI", 9.5F);
            lblCondition.Location = new Point(20, 162);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(118, 17);
            lblCondition.TabIndex = 4;
            lblCondition.Text = "Tình trạng vật lý (*):";
            // 
            // cboCondition
            // 
            cboCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCondition.Font = new Font("Segoe UI", 10F);
            cboCondition.FormattingEnabled = true;
            cboCondition.Location = new Point(145, 159);
            cboCondition.Name = "cboCondition";
            cboCondition.Size = new Size(265, 25);
            cboCondition.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(13, 110, 253);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(190, 215);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 36);
            btnSave.TabIndex = 6;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F);
            btnCancel.ForeColor = Color.FromArgb(33, 37, 41);
            btnCancel.Location = new Point(305, 215);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmUpdateCopy
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            CancelButton = btnCancel;
            ClientSize = new Size(440, 275);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboCondition);
            Controls.Add(lblCondition);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblCopyInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUpdateCopy";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập nhật bản sao";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblCopyInfo;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblCondition;
        private ComboBox cboCondition;
        private Button btnSave;
        private Button btnCancel;
    }
}
