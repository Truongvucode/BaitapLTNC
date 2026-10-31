using LibraryApp.BLL.DTOs;
using LibraryApp.BLL.Exceptions;
using LibraryApp.BLL.Services;
using LibraryApp.DAL.Enums;

namespace LibraryApp.UI.Forms
{
    public partial class FrmBookManagement : Form
    {
        private readonly IBookService _bookService;
        private readonly IBookCopyService _bookCopyService;
        private readonly ICategoryService _categoryService;

        private List<BookDto> _currentBooks = new();
        private List<BookCopyDto> _currentCopies = new();
        private BookDto? _selectedBook = null;
        private bool _isBindingBookInfo = false;

        public FrmBookManagement(
            IBookService bookService,
            IBookCopyService bookCopyService,
            ICategoryService categoryService)
        {
            _bookService = bookService;
            _bookCopyService = bookCopyService;
            _categoryService = categoryService;

            InitializeComponent();
            ConfigureDataGrids();
        }

        private void ConfigureDataGrids()
        {
            dgvBooks.AutoGenerateColumns = false;
            dgvCopies.AutoGenerateColumns = false;

            colPrice.DefaultCellStyle.Format = "#,##0 'đ'";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPublishYear.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCopyCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBookId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCopyId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCopyStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCopyCondition.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private async void FrmBookManagement_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                await LoadCategoriesAsync();
                await LoadBooksAsync();
                ResetBookForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = (await _categoryService.GetAllCategoriesAsync()).ToList();

            // Nạp cho tìm kiếm: thêm mục "-- Tất cả thể loại --"
            var searchCategories = new List<CategoryDto>
            {
                new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả thể loại --" }
            };
            searchCategories.AddRange(categories);
            cboSearchCategory.DataSource = searchCategories;
            cboSearchCategory.DisplayMember = "CategoryName";
            cboSearchCategory.ValueMember = "CategoryId";
            cboSearchCategory.SelectedIndex = 0;

            // Nạp cho Form thông tin đầu sách
            cboCategory.DataSource = categories.ToList();
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            if (categories.Any()) cboCategory.SelectedIndex = 0;
        }

        private async Task LoadBooksAsync(string? keyword = null, int? categoryId = null)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var books = await _bookService.SearchBooksAsync(keyword, categoryId);
                _currentBooks = books.ToList();
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = _currentBooks;

                lblStatus.Text = $"Đã tải {_currentBooks.Count} đầu sách lúc {DateTime.Now:HH:mm:ss}";

                if (_currentBooks.Count > 0)
                {
                    // Chọn sách đầu tiên nếu chưa chọn hoặc sách cũ không còn trong danh sách
                    int targetIndex = 0;
                    if (_selectedBook != null)
                    {
                        int foundIndex = _currentBooks.FindIndex(b => b.BookId == _selectedBook.BookId);
                        if (foundIndex >= 0) targetIndex = foundIndex;
                    }
                    dgvBooks.ClearSelection();
                    dgvBooks.Rows[targetIndex].Selected = true;
                    await SelectBookRowAsync(targetIndex);
                }
                else
                {
                    ResetBookForm();
                    _selectedBook = null;
                    _currentCopies.Clear();
                    dgvCopies.DataSource = null;
                    grpCopiesList.Text = "DANH SÁCH BẢN SAO";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task SelectBookRowAsync(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _currentBooks.Count) return;

            _selectedBook = _currentBooks[rowIndex];
            BindBookToForm(_selectedBook);
            await LoadCopiesForBookAsync(_selectedBook.BookId);
        }

        private void BindBookToForm(BookDto book)
        {
            _isBindingBookInfo = true;
            try
            {
                txtBookId.Text = book.BookId;
                txtBookId.ReadOnly = true; // Không cho sửa mã sách khi đang chọn sách cũ
                txtBookId.BackColor = Color.FromArgb(240, 240, 240);

                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtPublisher.Text = book.Publisher ?? string.Empty;
                cboCategory.SelectedValue = book.CategoryId;
                numPrice.Value = Math.Min(book.Price, numPrice.Maximum);
                numPublishYear.Value = book.PublishYear ?? DateTime.Now.Year;
                txtCopyCount.Text = book.CopyCount.ToString();

                btnAddBook.Enabled = false;
                btnUpdateBook.Enabled = true;
                btnDeleteBook.Enabled = true;
                btnBatchAddCopies.Enabled = true;
            }
            finally
            {
                _isBindingBookInfo = false;
            }
        }

        private void ResetBookForm()
        {
            _isBindingBookInfo = true;
            try
            {
                txtBookId.Text = string.Empty;
                txtBookId.ReadOnly = false;
                txtBookId.BackColor = Color.White;

                txtTitle.Text = string.Empty;
                txtAuthor.Text = string.Empty;
                txtPublisher.Text = string.Empty;
                if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
                numPrice.Value = 0;
                numPublishYear.Value = DateTime.Now.Year;
                txtCopyCount.Text = "0";

                btnAddBook.Enabled = true;
                btnUpdateBook.Enabled = false;
                btnDeleteBook.Enabled = false;
                btnBatchAddCopies.Enabled = false;

                _selectedBook = null;
                txtBookId.Focus();
            }
            finally
            {
                _isBindingBookInfo = false;
            }
        }

        private async Task LoadCopiesForBookAsync(string bookId)
        {
            try
            {
                var copies = await _bookCopyService.GetCopiesByBookIdAsync(bookId);
                _currentCopies = copies.ToList();

                dgvCopies.DataSource = null;
                dgvCopies.DataSource = _currentCopies;

                grpCopiesList.Text = $"DANH SÁCH BẢN SAO CỦA SÁCH {bookId} ({_currentCopies.Count} bản sao)";
                txtCopyCount.Text = _currentCopies.Count.ToString();

                // Cập nhật lại số bản sao trên dòng của sách đang chọn
                if (_selectedBook != null && _selectedBook.BookId == bookId)
                {
                    _selectedBook.CopyCount = _currentCopies.Count;
                    dgvBooks.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bản sao: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers - Tìm kiếm
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim();
            int? categoryId = null;
            if (cboSearchCategory.SelectedValue is int catId && catId > 0)
            {
                categoryId = catId;
            }

            await LoadBooksAsync(keyword, categoryId);
        }

        private async void btnRefreshSearch_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Text = string.Empty;
            cboSearchCategory.SelectedIndex = 0;
            await LoadBooksAsync();
        }

        private void txtSearchKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }
        #endregion

        #region Event Handlers - Danh sách sách & Chọn dòng
        private async void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBindingBookInfo) return;
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int index = dgvBooks.SelectedRows[0].Index;
                await SelectBookRowAsync(index);
            }
        }

        #endregion

        #region Event Handlers - Quản lý đầu sách (Thêm, Sửa, Xóa, Làm trống)
        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                var bookDto = new BookDto
                {
                    BookId = txtBookId.Text.Trim().ToUpper(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text.Trim(),
                    Price = numPrice.Value,
                    PublishYear = (int)numPublishYear.Value,
                    CategoryId = cboCategory.SelectedValue is int cId ? cId : 0
                };

                Cursor = Cursors.WaitCursor;
                var createdBook = await _bookService.AddBookAsync(bookDto);
                MessageBox.Show($"Thêm đầu sách '{createdBook.Title}' (Mã: {createdBook.BookId}) thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedBook = createdBook;
                await LoadBooksAsync();
            }
            catch (BusinessException bEx)
            {
                MessageBox.Show(bEx.Message, "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đầu sách: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn một đầu sách từ danh sách để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var bookDto = new BookDto
                {
                    BookId = _selectedBook.BookId,
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text.Trim(),
                    Price = numPrice.Value,
                    PublishYear = (int)numPublishYear.Value,
                    CategoryId = cboCategory.SelectedValue is int cId ? cId : 0
                };

                Cursor = Cursors.WaitCursor;
                await _bookService.UpdateBookAsync(bookDto);
                MessageBox.Show("Cập nhật thông tin đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadBooksAsync();
            }
            catch (BusinessException bEx)
            {
                MessageBox.Show(bEx.Message, "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đầu sách: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn một đầu sách từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đầu sách '{_selectedBook.Title}' (Mã: {_selectedBook.BookId})?\nLưu ý: Mọi bản sao chưa mượn cũng sẽ bị xóa vĩnh viễn!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                await _bookService.DeleteBookAsync(_selectedBook.BookId);
                MessageBox.Show("Đã xóa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedBook = null;
                ResetBookForm();
                await LoadBooksAsync();
            }
            catch (BusinessException bEx)
            {
                MessageBox.Show(bEx.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đầu sách: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetBookForm();
            dgvBooks.ClearSelection();
            _currentCopies.Clear();
            dgvCopies.DataSource = null;
            grpCopiesList.Text = "DANH SÁCH BẢN SAO";
        }
        #endregion

        #region Event Handlers - Quản lý bản sao (Nhập bổ sung, Nhập thêm 1, Cập nhật, Xóa)
        private async void btnBatchAddCopies_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn một đầu sách trước khi nhập bổ sung bản sao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new FrmAddCopies(_selectedBook.BookId, _selectedBook.Title);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var addedCopies = await _bookCopyService.AddCopiesAsync(_selectedBook.BookId, dlg.Quantity, dlg.SelectedCondition);
                    MessageBox.Show($"Đã nhập bổ sung thành công {addedCopies.Count()} bản sao cho sách '{_selectedBook.Title}'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadCopiesForBookAsync(_selectedBook.BookId);
                }
                catch (BusinessException bEx)
                {
                    MessageBox.Show(bEx.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi nhập bản sao: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private async void btnAddSingleCopy_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn một đầu sách trước khi thêm bản sao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                var copy = await _bookCopyService.AddSingleCopyAsync(_selectedBook.BookId, PhysicalCondition.Good);
                MessageBox.Show($"Đã tạo mới bản sao '{copy.CopyId}' (Tình trạng: Tốt, Trạng thái: Sẵn sàng)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadCopiesForBookAsync(_selectedBook.BookId);
            }
            catch (BusinessException bEx)
            {
                MessageBox.Show(bEx.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm bản sao: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnUpdateCopy_Click(object sender, EventArgs e)
        {
            if (dgvCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản sao từ bảng bên dưới để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCopy = (BookCopyDto)dgvCopies.SelectedRows[0].DataBoundItem;
            if (selectedCopy == null) return;

            using var dlg = new FrmUpdateCopy(selectedCopy.CopyId, selectedCopy.Status, selectedCopy.PhysicalCondition);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    await _bookCopyService.UpdateCopyAsync(selectedCopy.CopyId, dlg.SelectedStatus, dlg.SelectedCondition);
                    MessageBox.Show($"Cập nhật bản sao '{selectedCopy.CopyId}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (_selectedBook != null)
                    {
                        await LoadCopiesForBookAsync(_selectedBook.BookId);
                    }
                }
                catch (BusinessException bEx)
                {
                    MessageBox.Show(bEx.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật bản sao: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private async void btnDeleteCopy_Click(object sender, EventArgs e)
        {
            if (dgvCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản sao để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCopy = (BookCopyDto)dgvCopies.SelectedRows[0].DataBoundItem;
            if (selectedCopy == null) return;

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bản sao '{selectedCopy.CopyId}'?",
                "Xác nhận xóa bản sao",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                await _bookCopyService.DeleteCopyAsync(selectedCopy.CopyId);
                MessageBox.Show($"Đã xóa bản sao '{selectedCopy.CopyId}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_selectedBook != null)
                {
                    await LoadCopiesForBookAsync(_selectedBook.BookId);
                }
            }
            catch (BusinessException bEx)
            {
                MessageBox.Show(bEx.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bản sao: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}
