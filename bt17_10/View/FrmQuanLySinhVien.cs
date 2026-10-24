using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QuanLySinhVienWF.Business;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.View
{
    public partial class FrmQuanLySinhVien : Form
    {
        private readonly SinhVienBLL _svBLL = new SinhVienBLL();
        private readonly LopHocBLL _lopBLL = new LopHocBLL();

        public FrmQuanLySinhVien()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            DangKySuKienValidation();
        }

        #region ========== ĐĂNG KÝ SỰ KIỆN VALIDATION & ERRORPROVIDER ==========

        /// <summary>
        /// Đăng ký các sự kiện Leave (kiểm tra khi chuyển ô) và TextChanged (tự động xóa lỗi khi gõ)
        /// </summary>
        private void DangKySuKienValidation()
        {
            // 1. Sự kiện Leave: Kiểm tra tính hợp lệ khi người dùng rời khỏi ô nhập liệu
            txtMaSV.Leave += txtMaSV_Leave;
            txtHoTen.Leave += txtHoTen_Leave;
            txtEmail.Leave += txtEmail_Leave;
            txtDienThoai.Leave += txtDienThoai_Leave;
            txtDiem.Leave += txtDiem_Leave;

            // 2. Sự kiện TextChanged: Tự động xóa dấu X đỏ ngay khi người dùng bắt đầu chỉnh sửa
            txtMaSV.TextChanged += TextBox_TextChanged;
            txtHoTen.TextChanged += TextBox_TextChanged;
            txtEmail.TextChanged += TextBox_TextChanged;
            txtDienThoai.TextChanged += TextBox_TextChanged;
            txtDiem.TextChanged += TextBox_TextChanged;
        }

        #endregion

        #region ========== FORM LOAD (Yêu cầu C) ==========

        private void FrmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboLopHoc();
                LoadComboFilterLop();
                LoadDanhSachSinhVien(_svBLL.GetAll());

                // Bật Thêm + Làm mới, tắt Sửa + Xóa (trạng thái mặc định)
                SetButtonState(isNewMode: true);

                // Focus vào txtMaSV
                txtMaSV.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo Form:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== CẤU HÌNH & NẠP DỮ LIỆU ==========

        /// <summary>
        /// Cấu hình các cột cho DataGridView.
        /// ĐẶC BIỆT: Luôn gán Name và DataPropertyName trùng khớp chính xác để tránh lỗi
        /// "Column named ... cannot be found" khi truy xuất dgvSinhVien.Rows[i].Cells["..."]
        /// </summary>
        private void SetupDataGridViewColumns()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();

            // Cột Mã SV
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaSV",
                DataPropertyName = "MaSV",
                HeaderText = "Mã SV",
                Width = 95
            });

            // Cột Họ và tên
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                DataPropertyName = "HoTen",
                HeaderText = "Họ và tên",
                Width = 170
            });

            // Cột Ngày sinh
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgaySinh",
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày sinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Cột Giới tính (lấy từ thuộc tính GioiTinhHienThi)
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioiTinhHienThi",
                DataPropertyName = "GioiTinhHienThi",
                HeaderText = "Giới tính",
                Width = 80
            });

            // Cột Email
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 180
            });

            // Cột Điện thoại
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DienThoai",
                DataPropertyName = "DienThoai",
                HeaderText = "Điện thoại",
                Width = 110
            });

            // Cột Điểm
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Diem",
                DataPropertyName = "Diem",
                HeaderText = "Điểm",
                Width = 65,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N1", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Cột Lớp
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaLop",
                DataPropertyName = "MaLop",
                HeaderText = "Lớp",
                Width = 85
            });

            // Cột Trạng thái
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Width = 110
            });
        }

        /// <summary>
        /// Nạp danh sách lớp học vào cboLopHoc (nhóm Thông tin)
        /// </summary>
        private void LoadComboLopHoc()
        {
            var dsLop = _lopBLL.GetAll();
            cboLopHoc.DataSource = new BindingSource(dsLop, null);
            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.ValueMember = "MaLop";
        }

        /// <summary>
        /// Nạp danh sách lớp học vào cboFilterLop (nhóm Bộ lọc), thêm item "Tất cả"
        /// </summary>
        private void LoadComboFilterLop()
        {
            var dsLop = new List<LopHoc> { new LopHoc("", "-- Tất cả --") };
            dsLop.AddRange(_lopBLL.GetAll());
            cboFilterLop.DataSource = new BindingSource(dsLop, null);
            cboFilterLop.DisplayMember = "TenLop";
            cboFilterLop.ValueMember = "MaLop";
            cboFilterLop.SelectedIndex = 0;
        }

        /// <summary>
        /// Hiển thị danh sách sinh viên lên DataGridView và cập nhật lblTongSo
        /// Binding trực tiếp List<SinhVien> để DataBoundItem trả về đúng đối tượng SinhVien
        /// </summary>
        private void LoadDanhSachSinhVien(List<SinhVien> danhSach)
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = danhSach;
            lblTongSo.Text = $"Tổng số: {danhSach.Count} sinh viên";
        }

        #endregion

        #region ========== XỬ LÝ ERRORPROVIDER (DẤU X ĐỎ) ==========

        /// <summary>
        /// Tự động xóa dấu X đỏ báo lỗi ngay khi người dùng bắt đầu gõ phím
        /// </summary>
        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            if (sender is Control control)
            {
                epValidation.SetError(control, "");
            }
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của trường Họ và tên
        /// </summary>
        private bool ValidateHoTen()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                epValidation.SetError(txtHoTen, "Họ và tên không được để trống!");
                return false;
            }
            epValidation.SetError(txtHoTen, "");
            return true;
        }

        /// <summary>
        /// Sự kiện Leave của txtHoTen: Báo lỗi nếu để trống
        /// </summary>
        private void txtHoTen_Leave(object? sender, EventArgs e)
        {
            ValidateHoTen();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của trường Email
        /// </summary>
        private bool ValidateEmail()
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                epValidation.SetError(txtEmail, "Email không được để trống!");
                return false;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                epValidation.SetError(txtEmail, "Email không đúng định dạng (VD: example@st.vju.ac.vn)!");
                return false;
            }
            epValidation.SetError(txtEmail, "");
            return true;
        }

        private void txtEmail_Leave(object? sender, EventArgs e)
        {
            ValidateEmail();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của trường Số điện thoại
        /// </summary>
        private bool ValidateDienThoai()
        {
            string phone = txtDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                epValidation.SetError(txtDienThoai, "Số điện thoại không được để trống!");
                return false;
            }
            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                epValidation.SetError(txtDienThoai, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!");
                return false;
            }
            epValidation.SetError(txtDienThoai, "");
            return true;
        }

        private void txtDienThoai_Leave(object? sender, EventArgs e)
        {
            ValidateDienThoai();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của trường Điểm
        /// </summary>
        private bool ValidateDiem()
        {
            string diemStr = txtDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(diemStr))
            {
                epValidation.SetError(txtDiem, "Điểm không được để trống!");
                return false;
            }
            if (!double.TryParse(diemStr, out double diem) || diem < 0.0 || diem > 10.0)
            {
                epValidation.SetError(txtDiem, "Điểm phải là số thực từ 0.0 đến 10.0!");
                return false;
            }
            epValidation.SetError(txtDiem, "");
            return true;
        }

        private void txtDiem_Leave(object? sender, EventArgs e)
        {
            ValidateDiem();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của trường Mã sinh viên
        /// </summary>
        private bool ValidateMaSV()
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV))
            {
                epValidation.SetError(txtMaSV, "Mã sinh viên không được để trống!");
                return false;
            }
            if (!Regex.IsMatch(maSV, @"^SV\d{5}$"))
            {
                epValidation.SetError(txtMaSV, "Mã sinh viên phải có định dạng SVxxxxx (ví dụ: SV00001)!");
                return false;
            }
            epValidation.SetError(txtMaSV, "");
            return true;
        }

        #endregion

        #region ========== KIỂM TRA MÃ SV - SỰ KIỆN LEAVE (Yêu cầu D) ==========

        /// <summary>
        /// Khi rời khỏi ô txtMaSV:
        /// - Kiểm tra định dạng qua ErrorProvider
        /// - Nếu MaSV ĐÃ TỒN TẠI: tự động hiển thị thông tin, disable Thêm, enable Sửa/Xóa
        /// - Nếu MaSV CHƯA TỒN TẠI: xóa trắng các control khác, enable Thêm, disable Sửa/Xóa
        /// </summary>
        private void txtMaSV_Leave(object? sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maSV))
                {
                    epValidation.SetError(txtMaSV, "Mã sinh viên không được để trống!");
                    return;
                }

                if (!Regex.IsMatch(maSV, @"^SV\d{5}$"))
                {
                    epValidation.SetError(txtMaSV, "Mã sinh viên phải có định dạng SVxxxxx (ví dụ: SV00001)!");
                    return;
                }

                epValidation.SetError(txtMaSV, "");

                var sv = _svBLL.GetById(maSV);
                if (sv != null)
                {
                    // ĐÃ TỒN TẠI -> Hiển thị thông tin lên form
                    epValidation.Clear();
                    HienThiThongTinSinhVien(sv);
                    SetButtonState(isNewMode: false); // Disable Thêm, Enable Sửa + Xóa
                }
                else
                {
                    // CHƯA TỒN TẠI -> Xóa trắng các control khác (giữ txtMaSV)
                    XoaTrangKhongMaSV();
                    SetButtonState(isNewMode: true); // Enable Thêm, Disable Sửa + Xóa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra mã SV:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== NÚT THÊM (Yêu cầu F) ==========

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation nhanh trước khi lưu
                bool hopLe = ValidateMaSV() & ValidateHoTen() & ValidateEmail() & ValidateDienThoai() & ValidateDiem();
                if (!hopLe)
                {
                    MessageBox.Show("Vui lòng sửa các lỗi nhập liệu được đánh dấu màu đỏ!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sv = LayThongTinTuForm();

                var (success, message) = _svBLL.Add(sv);
                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSinhVien(_svBLL.GetAll());
                    LamMoi();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi xác thực dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== NÚT SỬA (Yêu cầu F - Có xác nhận) ==========

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation trước khi sửa
                bool hopLe = ValidateMaSV() & ValidateHoTen() & ValidateEmail() & ValidateDienThoai() & ValidateDiem();
                if (!hopLe)
                {
                    MessageBox.Show("Vui lòng sửa các lỗi nhập liệu được đánh dấu màu đỏ!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận trước khi sửa
                var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn thực hiện thao tác này không?",
                    "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var sv = LayThongTinTuForm();

                var (success, message) = _svBLL.Update(sv);
                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSinhVien(_svBLL.GetAll());
                }
                else
                {
                    MessageBox.Show(message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sinh viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== NÚT XÓA (Yêu cầu F - Có xác nhận) ==========

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maSV))
                {
                    epValidation.SetError(txtMaSV, "Vui lòng nhập mã sinh viên cần xóa!");
                    MessageBox.Show("Vui lòng nhập mã sinh viên cần xóa!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận trước khi xóa
                var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn thực hiện thao tác này không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var (success, message) = _svBLL.Delete(maSV);
                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSinhVien(_svBLL.GetAll());
                    LamMoi();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sinh viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== NÚT LÀM MỚI (Yêu cầu G) ==========

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
                LoadDanhSachSinhVien(_svBLL.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa trắng toàn bộ form, tắt báo lỗi ErrorProvider, đặt lại trạng thái nút, focus về txtMaSV
        /// </summary>
        private void LamMoi()
        {
            // Tắt toàn bộ dấu lỗi ErrorProvider
            epValidation.Clear();

            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2003, 1, 1);
            rdoNam.Checked = true;
            txtEmail.Clear();
            txtDienThoai.Clear();
            if (cboLopHoc.Items.Count > 0) cboLopHoc.SelectedIndex = 0;
            txtDiem.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            // Xóa bộ lọc
            txtTuKhoa.Clear();
            if (cboFilterLop.Items.Count > 0) cboFilterLop.SelectedIndex = 0;
            txtDiemTu.Clear();

            SetButtonState(isNewMode: true);
            txtMaSV.Focus();
        }

        #endregion

        #region ========== BỘ LỌC & TÌM KIẾM ==========

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTuKhoa.Text.Trim();
                string maLop = cboFilterLop.SelectedValue?.ToString() ?? "";

                double? diemTu = null;
                if (!string.IsNullOrWhiteSpace(txtDiemTu.Text))
                {
                    if (double.TryParse(txtDiemTu.Text.Trim(), out double d))
                        diemTu = d;
                    else
                    {
                        MessageBox.Show("Điểm từ phải là số hợp lệ!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var ketQua = _svBLL.Search(
                    string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                    string.IsNullOrWhiteSpace(maLop) ? null : maLop,
                    diemTu);

                LoadDanhSachSinhVien(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                txtTuKhoa.Clear();
                if (cboFilterLop.Items.Count > 0) cboFilterLop.SelectedIndex = 0;
                txtDiemTu.Clear();
                LoadDanhSachSinhVien(_svBLL.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== SỬA LỖI CLICK DATAGRIDVIEW ==========

        /// <summary>
        /// Khi click vào 1 dòng trên DataGridView:
        /// - Luôn kiểm tra e.RowIndex >= 0 (tránh click Header cột có e.RowIndex < 0)
        /// - Ép kiểu trực tiếp từ đối tượng binding DataBoundItem thay vì gọi tên cột
        /// - Có phương án dự phòng lấy qua dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"]
        /// </summary>
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 1. Luôn kiểm tra điều kiện dòng hợp lệ (bấm vào tiêu đề cột RowIndex = -1)
                if (e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

                // 2. Ép kiểu trực tiếp từ đối tượng binding DataBoundItem (Khuyên dùng)
                var sv = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVien;

                // 3. Phương án dự phòng: nếu DataBoundItem null, lấy qua ô Cells["MaSV"]
                if (sv == null)
                {
                    var cell = dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"];
                    string maSV = cell?.Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(maSV))
                    {
                        sv = _svBLL.GetById(maSV);
                    }
                }

                if (sv != null)
                {
                    // Tắt dấu đỏ báo lỗi cũ nếu có
                    epValidation.Clear();

                    HienThiThongTinSinhVien(sv);
                    SetButtonState(isNewMode: false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng trên danh sách:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ========== HÀM HỖ TRỢ ==========

        /// <summary>
        /// Đổ thông tin 1 SinhVien lên các control nhập liệu
        /// </summary>
        private void HienThiThongTinSinhVien(SinhVien sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;

            if (sv.NgaySinh >= dtpNgaySinh.MinDate && sv.NgaySinh <= dtpNgaySinh.MaxDate)
                dtpNgaySinh.Value = sv.NgaySinh;

            rdoNam.Checked = sv.GioiTinh;
            rdoNu.Checked = !sv.GioiTinh;

            txtEmail.Text = sv.Email;
            txtDienThoai.Text = sv.DienThoai;

            // Chọn lớp trong combobox
            cboLopHoc.SelectedValue = sv.MaLop;

            txtDiem.Text = sv.Diem.ToString("N1");

            // Chọn trạng thái
            int idx = cboTrangThai.Items.IndexOf(sv.TrangThai);
            cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
        }

        /// <summary>
        /// Thu thập dữ liệu từ form thành đối tượng SinhVien
        /// </summary>
        private SinhVien LayThongTinTuForm()
        {
            double diem = 0.0;
            if (!string.IsNullOrWhiteSpace(txtDiem.Text))
                double.TryParse(txtDiem.Text.Trim(), out diem);

            return new SinhVien
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdoNam.Checked,
                Email = txtEmail.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Diem = diem,
                MaLop = cboLopHoc.SelectedValue?.ToString()?.Trim() ?? "",
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };
        }

        /// <summary>
        /// Xóa trắng các control nhập liệu NGOẠI TRỪ txtMaSV
        /// </summary>
        private void XoaTrangKhongMaSV()
        {
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2003, 1, 1);
            rdoNam.Checked = true;
            txtEmail.Clear();
            txtDienThoai.Clear();
            if (cboLopHoc.Items.Count > 0) cboLopHoc.SelectedIndex = 0;
            txtDiem.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        /// <summary>
        /// Đặt trạng thái Enable/Disable cho các nút
        /// isNewMode = true: Thêm mode (Enable Thêm + Làm mới, Disable Sửa + Xóa)
        /// isNewMode = false: Edit mode (Disable Thêm, Enable Sửa + Xóa + Làm mới)
        /// </summary>
        private void SetButtonState(bool isNewMode)
        {
            btnThem.Enabled = isNewMode;
            btnSua.Enabled = !isNewMode;
            btnXoa.Enabled = !isNewMode;
            btnLamMoi.Enabled = true; // luôn bật
        }

        #endregion
    }
}
