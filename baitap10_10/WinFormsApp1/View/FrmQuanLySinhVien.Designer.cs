namespace QuanLySinhVienWF.View
{
    partial class FrmQuanLySinhVien
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // === Khai báo controls ===
            components = new System.ComponentModel.Container();
            epValidation = new ErrorProvider(components);
            grpThongTin = new GroupBox();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblLopHoc = new Label();
            cboLopHoc = new ComboBox();
            lblDiem = new Label();
            txtDiem = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            pnlBoLoc = new Panel();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            lblFilterLop = new Label();
            cboFilterLop = new ComboBox();
            lblDiemTu = new Label();
            txtDiemTu = new TextBox();
            btnTimKiem = new Button();
            btnHienThiTatCa = new Button();

            grpDanhSach = new GroupBox();
            dgvSinhVien = new DataGridView();
            lblTongSo = new Label();

            ((System.ComponentModel.ISupportInitialize)epValidation).BeginInit();
            grpThongTin.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();

            // =====================================================
            // grpThongTin - GroupBox "Thông tin sinh viên"
            // =====================================================
            grpThongTin.Text = "Thông tin sinh viên";
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Size = new Size(1260, 210);
            grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            grpThongTin.Controls.AddRange(new Control[] {
                lblMaSV, txtMaSV, lblHoTen, txtHoTen,
                lblNgaySinh, dtpNgaySinh, lblGioiTinh, rdoNam, rdoNu,
                lblEmail, txtEmail, lblDienThoai, txtDienThoai,
                lblLopHoc, cboLopHoc, lblDiem, txtDiem,
                lblTrangThai, cboTrangThai,
                btnThem, btnSua, btnXoa, btnLamMoi
            });

            // --- Cột 1 ---
            lblMaSV.Text = "Mã SV:";
            lblMaSV.Location = new Point(20, 35);
            lblMaSV.Size = new Size(85, 25);
            lblMaSV.Font = new Font("Segoe UI", 9.5F);

            txtMaSV.Location = new Point(115, 32);
            txtMaSV.Size = new Size(160, 28);
            txtMaSV.Font = new Font("Segoe UI", 9.5F);
            txtMaSV.PlaceholderText = "SVxxxxx";
            txtMaSV.TabIndex = 0;

            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new Point(20, 72);
            lblNgaySinh.Size = new Size(85, 25);
            lblNgaySinh.Font = new Font("Segoe UI", 9.5F);

            dtpNgaySinh.Location = new Point(115, 69);
            dtpNgaySinh.Size = new Size(160, 28);
            dtpNgaySinh.Font = new Font("Segoe UI", 9.5F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = new DateTime(2003, 1, 1);
            dtpNgaySinh.TabIndex = 2;

            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(20, 109);
            lblEmail.Size = new Size(85, 25);
            lblEmail.Font = new Font("Segoe UI", 9.5F);

            txtEmail.Location = new Point(115, 106);
            txtEmail.Size = new Size(160, 28);
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.PlaceholderText = "abc@st.vju.ac.vn";
            txtEmail.TabIndex = 5;

            // --- Cột 2 ---
            lblHoTen.Text = "Họ tên:";
            lblHoTen.Location = new Point(310, 35);
            lblHoTen.Size = new Size(85, 25);
            lblHoTen.Font = new Font("Segoe UI", 9.5F);

            txtHoTen.Location = new Point(400, 32);
            txtHoTen.Size = new Size(190, 28);
            txtHoTen.Font = new Font("Segoe UI", 9.5F);
            txtHoTen.TabIndex = 1;

            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new Point(310, 72);
            lblGioiTinh.Size = new Size(85, 25);
            lblGioiTinh.Font = new Font("Segoe UI", 9.5F);

            rdoNam.Text = "Nam";
            rdoNam.Location = new Point(400, 70);
            rdoNam.Size = new Size(70, 28);
            rdoNam.Font = new Font("Segoe UI", 9.5F);
            rdoNam.Checked = true;
            rdoNam.TabIndex = 3;

            rdoNu.Text = "Nữ";
            rdoNu.Location = new Point(480, 70);
            rdoNu.Size = new Size(70, 28);
            rdoNu.Font = new Font("Segoe UI", 9.5F);
            rdoNu.TabIndex = 4;

            lblDienThoai.Text = "Điện thoại:";
            lblDienThoai.Location = new Point(310, 109);
            lblDienThoai.Size = new Size(85, 25);
            lblDienThoai.Font = new Font("Segoe UI", 9.5F);

            txtDienThoai.Location = new Point(400, 106);
            txtDienThoai.Size = new Size(190, 28);
            txtDienThoai.Font = new Font("Segoe UI", 9.5F);
            txtDienThoai.TabIndex = 6;

            // --- Cột 3 ---
            lblLopHoc.Text = "Lớp học:";
            lblLopHoc.Location = new Point(620, 35);
            lblLopHoc.Size = new Size(85, 25);
            lblLopHoc.Font = new Font("Segoe UI", 9.5F);

            cboLopHoc.Location = new Point(710, 32);
            cboLopHoc.Size = new Size(180, 28);
            cboLopHoc.Font = new Font("Segoe UI", 9.5F);
            cboLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopHoc.TabIndex = 7;

            lblDiem.Text = "Điểm:";
            lblDiem.Location = new Point(620, 72);
            lblDiem.Size = new Size(85, 25);
            lblDiem.Font = new Font("Segoe UI", 9.5F);

            txtDiem.Location = new Point(710, 69);
            txtDiem.Size = new Size(180, 28);
            txtDiem.Font = new Font("Segoe UI", 9.5F);
            txtDiem.TabIndex = 8;

            lblTrangThai.Text = "Trạng thái:";
            lblTrangThai.Location = new Point(620, 109);
            lblTrangThai.Size = new Size(85, 25);
            lblTrangThai.Font = new Font("Segoe UI", 9.5F);

            cboTrangThai.Location = new Point(710, 106);
            cboTrangThai.Size = new Size(180, 28);
            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Đang học", "Tạm dừng", "Đã tốt nghiệp" });
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.TabIndex = 9;

            // --- Buttons ---
            int btnY = 155;
            int btnW = 120;
            int btnH = 38;

            btnThem.Text = "&Thêm";
            btnThem.Location = new Point(620, btnY);
            btnThem.Size = new Size(btnW, btnH);
            btnThem.Font = new Font("Segoe UI", 9.5F);
            btnThem.BackColor = Color.FromArgb(46, 139, 87);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.TabIndex = 10;
            btnThem.Click += btnThem_Click;

            btnSua.Text = "&Sửa";
            btnSua.Location = new Point(755, btnY);
            btnSua.Size = new Size(btnW, btnH);
            btnSua.Font = new Font("Segoe UI", 9.5F);
            btnSua.BackColor = Color.FromArgb(30, 100, 190);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Enabled = false;
            btnSua.TabIndex = 11;
            btnSua.Click += btnSua_Click;

            btnXoa.Text = "&Xóa";
            btnXoa.Location = new Point(890, btnY);
            btnXoa.Size = new Size(btnW, btnH);
            btnXoa.Font = new Font("Segoe UI", 9.5F);
            btnXoa.BackColor = Color.FromArgb(200, 50, 50);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Enabled = false;
            btnXoa.TabIndex = 12;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Text = "&Làm mới";
            btnLamMoi.Location = new Point(1025, btnY);
            btnLamMoi.Size = new Size(btnW, btnH);
            btnLamMoi.Font = new Font("Segoe UI", 9.5F);
            btnLamMoi.BackColor = Color.FromArgb(100, 100, 100);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Click += btnLamMoi_Click;

            // =====================================================
            // pnlBoLoc - Panel "Bộ lọc"
            // =====================================================
            pnlBoLoc.Location = new Point(12, 228);
            pnlBoLoc.Size = new Size(1260, 52);
            pnlBoLoc.BorderStyle = BorderStyle.FixedSingle;
            pnlBoLoc.BackColor = Color.FromArgb(240, 245, 250);

            pnlBoLoc.Controls.AddRange(new Control[] {
                lblTuKhoa, txtTuKhoa, lblFilterLop, cboFilterLop,
                lblDiemTu, txtDiemTu, btnTimKiem, btnHienThiTatCa
            });

            lblTuKhoa.Text = "Từ khóa:";
            lblTuKhoa.Location = new Point(10, 14);
            lblTuKhoa.Size = new Size(70, 25);
            lblTuKhoa.Font = new Font("Segoe UI", 9.5F);

            txtTuKhoa.Location = new Point(85, 11);
            txtTuKhoa.Size = new Size(180, 28);
            txtTuKhoa.Font = new Font("Segoe UI", 9.5F);
            txtTuKhoa.PlaceholderText = "Mã SV / Họ tên / Email...";
            txtTuKhoa.TabIndex = 14;

            lblFilterLop.Text = "Lớp:";
            lblFilterLop.Location = new Point(285, 14);
            lblFilterLop.Size = new Size(40, 25);
            lblFilterLop.Font = new Font("Segoe UI", 9.5F);

            cboFilterLop.Location = new Point(330, 11);
            cboFilterLop.Size = new Size(180, 28);
            cboFilterLop.Font = new Font("Segoe UI", 9.5F);
            cboFilterLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterLop.TabIndex = 15;

            lblDiemTu.Text = "Điểm từ:";
            lblDiemTu.Location = new Point(530, 14);
            lblDiemTu.Size = new Size(70, 25);
            lblDiemTu.Font = new Font("Segoe UI", 9.5F);

            txtDiemTu.Location = new Point(605, 11);
            txtDiemTu.Size = new Size(80, 28);
            txtDiemTu.Font = new Font("Segoe UI", 9.5F);
            txtDiemTu.TabIndex = 16;

            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new Point(710, 8);
            btnTimKiem.Size = new Size(110, 35);
            btnTimKiem.Font = new Font("Segoe UI", 9.5F);
            btnTimKiem.BackColor = Color.FromArgb(30, 100, 190);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Click += btnTimKiem_Click;

            btnHienThiTatCa.Text = "Hiển thị tất cả";
            btnHienThiTatCa.Location = new Point(835, 8);
            btnHienThiTatCa.Size = new Size(130, 35);
            btnHienThiTatCa.Font = new Font("Segoe UI", 9.5F);
            btnHienThiTatCa.BackColor = Color.FromArgb(100, 100, 100);
            btnHienThiTatCa.ForeColor = Color.White;
            btnHienThiTatCa.FlatStyle = FlatStyle.Flat;
            btnHienThiTatCa.TabIndex = 18;
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;

            // =====================================================
            // grpDanhSach - GroupBox "Danh sách sinh viên"
            // =====================================================
            grpDanhSach.Text = "Danh sách sinh viên";
            grpDanhSach.Location = new Point(12, 288);
            grpDanhSach.Size = new Size(1260, 400);
            grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            grpDanhSach.Controls.Add(dgvSinhVien);
            grpDanhSach.Controls.Add(lblTongSo);

            dgvSinhVien.Location = new Point(10, 28);
            dgvSinhVien.Size = new Size(1240, 340);
            dgvSinhVien.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.RowHeadersWidth = 30;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.TabIndex = 19;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            lblTongSo.Text = "Tổng số: 0 sinh viên";
            lblTongSo.Location = new Point(10, 372);
            lblTongSo.Size = new Size(300, 25);
            lblTongSo.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTongSo.ForeColor = Color.DarkSlateGray;

            // =====================================================
            // Form chính
            // =====================================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 700);
            Controls.Add(grpThongTin);
            Controls.Add(pnlBoLoc);
            Controls.Add(grpDanhSach);
            Name = "FrmQuanLySinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ SINH VIÊN";
            Font = new Font("Segoe UI", 9.5F);
            Load += FrmQuanLySinhVien_Load;

            // =====================================================
            // epValidation - ErrorProvider
            // =====================================================
            epValidation.ContainerControl = this;
            epValidation.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)epValidation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // === ErrorProvider ===
        private ErrorProvider epValidation;

        // === Nhóm Thông tin ===
        private GroupBox grpThongTin;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblLopHoc;
        private ComboBox cboLopHoc;
        private Label lblDiem;
        private TextBox txtDiem;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        // === Nhóm Bộ lọc ===
        private Panel pnlBoLoc;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Label lblFilterLop;
        private ComboBox cboFilterLop;
        private Label lblDiemTu;
        private TextBox txtDiemTu;
        private Button btnTimKiem;
        private Button btnHienThiTatCa;

        // === Nhóm Danh sách ===
        private GroupBox grpDanhSach;
        private DataGridView dgvSinhVien;
        private Label lblTongSo;
    }
}
