namespace LibraryApp.UI.Forms
{
    partial class FrmBookManagement
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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCopiesHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCopiesRowStyle = new DataGridViewCellStyle();

            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlSearch = new Panel();
            btnRefreshSearch = new Button();
            btnSearch = new Button();
            cboSearchCategory = new ComboBox();
            lblSearchCategory = new Label();
            txtSearchKeyword = new TextBox();
            lblSearchKeyword = new Label();
            pnlMain = new TableLayoutPanel();
            grpBookInfo = new GroupBox();
            btnBatchAddCopies = new Button();
            btnClear = new Button();
            btnDeleteBook = new Button();
            btnUpdateBook = new Button();
            btnAddBook = new Button();
            txtCopyCount = new TextBox();
            lblCopyCount = new Label();
            numPublishYear = new NumericUpDown();
            lblPublishYear = new Label();
            numPrice = new NumericUpDown();
            lblPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtPublisher = new TextBox();
            lblPublisher = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            lblBookTitle = new Label();
            txtBookId = new TextBox();
            lblBookId = new Label();
            splitRight = new SplitContainer();
            grpBooksList = new GroupBox();
            dgvBooks = new DataGridView();
            colBookId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colPublisher = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colPublishYear = new DataGridViewTextBoxColumn();
            colCopyCount = new DataGridViewTextBoxColumn();
            grpCopiesList = new GroupBox();
            pnlCopiesActions = new Panel();
            btnDeleteCopy = new Button();
            btnUpdateCopy = new Button();
            btnAddSingleCopy = new Button();
            lblCopyHint = new Label();
            dgvCopies = new DataGridView();
            colCopyId = new DataGridViewTextBoxColumn();
            colCopyStatus = new DataGridViewTextBoxColumn();
            colCopyCondition = new DataGridViewTextBoxColumn();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();

            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlMain.SuspendLayout();
            grpBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitRight).BeginInit();
            splitRight.Panel1.SuspendLayout();
            splitRight.Panel2.SuspendLayout();
            splitRight.SuspendLayout();
            grpBooksList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            grpCopiesList.SuspendLayout();
            pnlCopiesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCopies).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 44, 89);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1264, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 220, 245);
            lblSubtitle.Location = new Point(20, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(337, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Tra cứu, cập nhật thông tin đầu sách và quản lý bản sao";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(393, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ ĐẦU SÁCH VÀ BẢN SAO";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(235, 243, 252);
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(btnRefreshSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(cboSearchCategory);
            pnlSearch.Controls.Add(lblSearchCategory);
            pnlSearch.Controls.Add(txtSearchKeyword);
            pnlSearch.Controls.Add(lblSearchKeyword);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 70);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(12);
            pnlSearch.Size = new Size(1264, 55);
            pnlSearch.TabIndex = 1;
            // 
            // btnRefreshSearch
            // 
            btnRefreshSearch.BackColor = Color.White;
            btnRefreshSearch.Cursor = Cursors.Hand;
            btnRefreshSearch.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 220);
            btnRefreshSearch.FlatStyle = FlatStyle.Flat;
            btnRefreshSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshSearch.ForeColor = Color.FromArgb(50, 70, 90);
            btnRefreshSearch.Location = new Point(870, 10);
            btnRefreshSearch.Name = "btnRefreshSearch";
            btnRefreshSearch.Size = new Size(95, 32);
            btnRefreshSearch.TabIndex = 5;
            btnRefreshSearch.Text = "Làm mới";
            btnRefreshSearch.UseVisualStyleBackColor = false;
            btnRefreshSearch.Click += btnRefreshSearch_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(13, 110, 253);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(765, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(95, 32);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboSearchCategory
            // 
            cboSearchCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchCategory.Font = new Font("Segoe UI", 9.5F);
            cboSearchCategory.FormattingEnabled = true;
            cboSearchCategory.Location = new Point(530, 13);
            cboSearchCategory.Name = "cboSearchCategory";
            cboSearchCategory.Size = new Size(215, 24);
            cboSearchCategory.TabIndex = 3;
            // 
            // lblSearchCategory
            // 
            lblSearchCategory.AutoSize = true;
            lblSearchCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearchCategory.ForeColor = Color.FromArgb(30, 45, 65);
            lblSearchCategory.Location = new Point(455, 16);
            lblSearchCategory.Name = "lblSearchCategory";
            lblSearchCategory.Size = new Size(66, 17);
            lblSearchCategory.TabIndex = 2;
            lblSearchCategory.Text = "Thể loại:";
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Font = new Font("Segoe UI", 9.5F);
            txtSearchKeyword.Location = new Point(140, 13);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.PlaceholderText = "Mã sách, tên sách, tác giả...";
            txtSearchKeyword.Size = new Size(295, 24);
            txtSearchKeyword.TabIndex = 1;
            txtSearchKeyword.KeyDown += txtSearchKeyword_KeyDown;
            // 
            // lblSearchKeyword
            // 
            lblSearchKeyword.AutoSize = true;
            lblSearchKeyword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearchKeyword.ForeColor = Color.FromArgb(30, 45, 65);
            lblSearchKeyword.Location = new Point(16, 16);
            lblSearchKeyword.Name = "lblSearchKeyword";
            lblSearchKeyword.Size = new Size(116, 17);
            lblSearchKeyword.TabIndex = 0;
            lblSearchKeyword.Text = "Từ khóa tra cứu:";
            // 
            // pnlMain
            // 
            pnlMain.ColumnCount = 2;
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlMain.Controls.Add(grpBookInfo, 0, 0);
            pnlMain.Controls.Add(splitRight, 1, 0);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 125);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(8);
            pnlMain.RowCount = 1;
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlMain.Size = new Size(1264, 616);
            pnlMain.TabIndex = 2;
            // 
            // grpBookInfo
            // 
            grpBookInfo.BackColor = Color.White;
            grpBookInfo.Controls.Add(btnBatchAddCopies);
            grpBookInfo.Controls.Add(btnClear);
            grpBookInfo.Controls.Add(btnDeleteBook);
            grpBookInfo.Controls.Add(btnUpdateBook);
            grpBookInfo.Controls.Add(btnAddBook);
            grpBookInfo.Controls.Add(txtCopyCount);
            grpBookInfo.Controls.Add(lblCopyCount);
            grpBookInfo.Controls.Add(numPublishYear);
            grpBookInfo.Controls.Add(lblPublishYear);
            grpBookInfo.Controls.Add(numPrice);
            grpBookInfo.Controls.Add(lblPrice);
            grpBookInfo.Controls.Add(cboCategory);
            grpBookInfo.Controls.Add(lblCategory);
            grpBookInfo.Controls.Add(txtPublisher);
            grpBookInfo.Controls.Add(lblPublisher);
            grpBookInfo.Controls.Add(txtAuthor);
            grpBookInfo.Controls.Add(lblAuthor);
            grpBookInfo.Controls.Add(txtTitle);
            grpBookInfo.Controls.Add(lblBookTitle);
            grpBookInfo.Controls.Add(txtBookId);
            grpBookInfo.Controls.Add(lblBookId);
            grpBookInfo.Dock = DockStyle.Fill;
            grpBookInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBookInfo.ForeColor = Color.FromArgb(24, 76, 120);
            grpBookInfo.Location = new Point(11, 11);
            grpBookInfo.Name = "grpBookInfo";
            grpBookInfo.Padding = new Padding(12);
            grpBookInfo.Size = new Size(374, 594);
            grpBookInfo.TabIndex = 0;
            grpBookInfo.TabStop = false;
            grpBookInfo.Text = "THÔNG TIN ĐẦU SÁCH";
            // 
            // btnBatchAddCopies
            // 
            btnBatchAddCopies.BackColor = Color.FromArgb(13, 110, 253);
            btnBatchAddCopies.Cursor = Cursors.Hand;
            btnBatchAddCopies.FlatAppearance.BorderSize = 0;
            btnBatchAddCopies.FlatStyle = FlatStyle.Flat;
            btnBatchAddCopies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBatchAddCopies.ForeColor = Color.White;
            btnBatchAddCopies.Location = new Point(15, 475);
            btnBatchAddCopies.Name = "btnBatchAddCopies";
            btnBatchAddCopies.Size = new Size(342, 42);
            btnBatchAddCopies.TabIndex = 20;
            btnBatchAddCopies.Text = "NHẬP BỔ SUNG BẢN SAO";
            btnBatchAddCopies.UseVisualStyleBackColor = false;
            btnBatchAddCopies.Click += btnBatchAddCopies_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(248, 249, 250);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(60, 60, 60);
            btnClear.Location = new Point(190, 420);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(167, 36);
            btnClear.TabIndex = 19;
            btnClear.Text = "Làm trống";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteBook.Cursor = Cursors.Hand;
            btnDeleteBook.FlatAppearance.BorderSize = 0;
            btnDeleteBook.FlatStyle = FlatStyle.Flat;
            btnDeleteBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteBook.ForeColor = Color.White;
            btnDeleteBook.Location = new Point(15, 420);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(167, 36);
            btnDeleteBook.TabIndex = 18;
            btnDeleteBook.Text = "Xóa đầu sách";
            btnDeleteBook.UseVisualStyleBackColor = false;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.BackColor = Color.FromArgb(253, 126, 20);
            btnUpdateBook.Cursor = Cursors.Hand;
            btnUpdateBook.FlatAppearance.BorderSize = 0;
            btnUpdateBook.FlatStyle = FlatStyle.Flat;
            btnUpdateBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateBook.ForeColor = Color.White;
            btnUpdateBook.Location = new Point(190, 375);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(167, 36);
            btnUpdateBook.TabIndex = 17;
            btnUpdateBook.Text = "Lưu chỉnh sửa";
            btnUpdateBook.UseVisualStyleBackColor = false;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.FromArgb(40, 167, 69);
            btnAddBook.Cursor = Cursors.Hand;
            btnAddBook.FlatAppearance.BorderSize = 0;
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(15, 375);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(167, 36);
            btnAddBook.TabIndex = 16;
            btnAddBook.Text = "Thêm đầu sách";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // txtCopyCount
            // 
            txtCopyCount.BackColor = Color.FromArgb(235, 245, 255);
            txtCopyCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtCopyCount.ForeColor = Color.FromArgb(13, 110, 253);
            txtCopyCount.Location = new Point(125, 318);
            txtCopyCount.Name = "txtCopyCount";
            txtCopyCount.ReadOnly = true;
            txtCopyCount.Size = new Size(232, 25);
            txtCopyCount.TabIndex = 15;
            txtCopyCount.Text = "0";
            txtCopyCount.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCopyCount
            // 
            lblCopyCount.AutoSize = true;
            lblCopyCount.Font = new Font("Segoe UI", 9.5F);
            lblCopyCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblCopyCount.Location = new Point(15, 321);
            lblCopyCount.Name = "lblCopyCount";
            lblCopyCount.Size = new Size(74, 17);
            lblCopyCount.TabIndex = 14;
            lblCopyCount.Text = "Số bản sao:";
            // 
            // numPublishYear
            // 
            numPublishYear.Font = new Font("Segoe UI", 9.5F);
            numPublishYear.Location = new Point(125, 278);
            numPublishYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numPublishYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPublishYear.Name = "numPublishYear";
            numPublishYear.Size = new Size(232, 24);
            numPublishYear.TabIndex = 13;
            numPublishYear.TextAlign = HorizontalAlignment.Right;
            numPublishYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // lblPublishYear
            // 
            lblPublishYear.AutoSize = true;
            lblPublishYear.Font = new Font("Segoe UI", 9.5F);
            lblPublishYear.ForeColor = Color.FromArgb(50, 50, 50);
            lblPublishYear.Location = new Point(15, 280);
            lblPublishYear.Name = "lblPublishYear";
            lblPublishYear.Size = new Size(93, 17);
            lblPublishYear.TabIndex = 12;
            lblPublishYear.Text = "Năm xuất bản:";
            // 
            // numPrice
            // 
            numPrice.Font = new Font("Segoe UI", 9.5F);
            numPrice.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrice.Location = new Point(125, 238);
            numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(232, 24);
            numPrice.TabIndex = 11;
            numPrice.TextAlign = HorizontalAlignment.Right;
            numPrice.ThousandsSeparator = true;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9.5F);
            lblPrice.ForeColor = Color.FromArgb(50, 50, 50);
            lblPrice.Location = new Point(15, 240);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(61, 17);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Giá sách:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 9.5F);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(125, 198);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(232, 24);
            cboCategory.TabIndex = 9;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F);
            lblCategory.ForeColor = Color.FromArgb(50, 50, 50);
            lblCategory.Location = new Point(15, 201);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(82, 17);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Thể loại (*):";
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 9.5F);
            txtPublisher.Location = new Point(125, 158);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(232, 24);
            txtPublisher.TabIndex = 7;
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Font = new Font("Segoe UI", 9.5F);
            lblPublisher.ForeColor = Color.FromArgb(50, 50, 50);
            lblPublisher.Location = new Point(15, 161);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(89, 17);
            lblPublisher.TabIndex = 6;
            lblPublisher.Text = "Nhà xuất bản:";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9.5F);
            txtAuthor.Location = new Point(125, 118);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(232, 24);
            txtAuthor.TabIndex = 5;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 9.5F);
            lblAuthor.ForeColor = Color.FromArgb(50, 50, 50);
            lblAuthor.Location = new Point(15, 121);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(76, 17);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Tác giả (*):";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9.5F);
            txtTitle.Location = new Point(125, 78);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(232, 24);
            txtTitle.TabIndex = 3;
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 9.5F);
            lblBookTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblBookTitle.Location = new Point(15, 81);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(106, 17);
            lblBookTitle.TabIndex = 2;
            lblBookTitle.Text = "Tên đầu sách (*):";
            // 
            // txtBookId
            // 
            txtBookId.Font = new Font("Segoe UI", 9.5F);
            txtBookId.Location = new Point(125, 38);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(232, 24);
            txtBookId.TabIndex = 1;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new Font("Segoe UI", 9.5F);
            lblBookId.ForeColor = Color.FromArgb(50, 50, 50);
            lblBookId.Location = new Point(15, 41);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(84, 17);
            lblBookId.TabIndex = 0;
            lblBookId.Text = "Mã sách (*):";
            // 
            // splitRight
            // 
            splitRight.Dock = DockStyle.Fill;
            splitRight.Location = new Point(391, 11);
            splitRight.Name = "splitRight";
            splitRight.Orientation = Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            splitRight.Panel1.Controls.Add(grpBooksList);
            // 
            // splitRight.Panel2
            // 
            splitRight.Panel2.Controls.Add(grpCopiesList);
            splitRight.Size = new Size(862, 594);
            splitRight.SplitterDistance = 320;
            splitRight.SplitterWidth = 6;
            splitRight.TabIndex = 1;
            // 
            // grpBooksList
            // 
            grpBooksList.BackColor = Color.White;
            grpBooksList.Controls.Add(dgvBooks);
            grpBooksList.Dock = DockStyle.Fill;
            grpBooksList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBooksList.ForeColor = Color.FromArgb(24, 76, 120);
            grpBooksList.Location = new Point(0, 0);
            grpBooksList.Name = "grpBooksList";
            grpBooksList.Padding = new Padding(8);
            grpBooksList.Size = new Size(862, 320);
            grpBooksList.TabIndex = 0;
            grpBooksList.TabStop = false;
            grpBooksList.Text = "DANH SÁCH ĐẦU SÁCH";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(240, 244, 250);
            dgvHeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(30, 45, 65);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(240, 244, 250);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(30, 45, 65);
            dgvBooks.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvBooks.ColumnHeadersHeight = 32;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] {
                colBookId,
                colTitle,
                colCategory,
                colAuthor,
                colPublisher,
                colPrice,
                colPublishYear,
                colCopyCount
            });
            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.White;
            dgvRowStyle.Font = new Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvRowStyle.SelectionForeColor = Color.FromArgb(15, 44, 89);
            dgvBooks.DefaultCellStyle = dgvRowStyle;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.Location = new Point(8, 26);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowTemplate.Height = 28;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(846, 286);
            dgvBooks.TabIndex = 0;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // colBookId
            // 
            colBookId.DataPropertyName = "BookId";
            colBookId.FillWeight = 55F;
            colBookId.HeaderText = "Mã sách";
            colBookId.Name = "colBookId";
            colBookId.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.DataPropertyName = "Title";
            colTitle.FillWeight = 130F;
            colTitle.HeaderText = "Tên đầu sách";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "CategoryName";
            colCategory.FillWeight = 75F;
            colCategory.HeaderText = "Thể loại";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.DataPropertyName = "Author";
            colAuthor.FillWeight = 90F;
            colAuthor.HeaderText = "Tác giả";
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colPublisher
            // 
            colPublisher.DataPropertyName = "Publisher";
            colPublisher.FillWeight = 85F;
            colPublisher.HeaderText = "Nhà xuất bản";
            colPublisher.Name = "colPublisher";
            colPublisher.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.FillWeight = 65F;
            colPrice.HeaderText = "Giá sách";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colPublishYear
            // 
            colPublishYear.DataPropertyName = "PublishYear";
            colPublishYear.FillWeight = 50F;
            colPublishYear.HeaderText = "Năm XB";
            colPublishYear.Name = "colPublishYear";
            colPublishYear.ReadOnly = true;
            // 
            // colCopyCount
            // 
            colCopyCount.DataPropertyName = "CopyCount";
            colCopyCount.FillWeight = 50F;
            colCopyCount.HeaderText = "Số bản sao";
            colCopyCount.Name = "colCopyCount";
            colCopyCount.ReadOnly = true;
            // 
            // grpCopiesList
            // 
            grpCopiesList.BackColor = Color.White;
            grpCopiesList.Controls.Add(dgvCopies);
            grpCopiesList.Controls.Add(pnlCopiesActions);
            grpCopiesList.Controls.Add(lblCopyHint);
            grpCopiesList.Dock = DockStyle.Fill;
            grpCopiesList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpCopiesList.ForeColor = Color.FromArgb(24, 76, 120);
            grpCopiesList.Location = new Point(0, 0);
            grpCopiesList.Name = "grpCopiesList";
            grpCopiesList.Padding = new Padding(8);
            grpCopiesList.Size = new Size(862, 268);
            grpCopiesList.TabIndex = 0;
            grpCopiesList.TabStop = false;
            grpCopiesList.Text = "DANH SÁCH BẢN SAO";
            // 
            // pnlCopiesActions
            // 
            pnlCopiesActions.Controls.Add(btnDeleteCopy);
            pnlCopiesActions.Controls.Add(btnUpdateCopy);
            pnlCopiesActions.Controls.Add(btnAddSingleCopy);
            pnlCopiesActions.Dock = DockStyle.Bottom;
            pnlCopiesActions.Location = new Point(8, 222);
            pnlCopiesActions.Name = "pnlCopiesActions";
            pnlCopiesActions.Size = new Size(846, 38);
            pnlCopiesActions.TabIndex = 2;
            // 
            // btnDeleteCopy
            // 
            btnDeleteCopy.BackColor = Color.White;
            btnDeleteCopy.Cursor = Cursors.Hand;
            btnDeleteCopy.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);
            btnDeleteCopy.FlatStyle = FlatStyle.Flat;
            btnDeleteCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteCopy.ForeColor = Color.FromArgb(220, 53, 69);
            btnDeleteCopy.Location = new Point(310, 3);
            btnDeleteCopy.Name = "btnDeleteCopy";
            btnDeleteCopy.Size = new Size(130, 32);
            btnDeleteCopy.TabIndex = 2;
            btnDeleteCopy.Text = "Xóa bản sao";
            btnDeleteCopy.UseVisualStyleBackColor = false;
            btnDeleteCopy.Click += btnDeleteCopy_Click;
            // 
            // btnUpdateCopy
            // 
            btnUpdateCopy.BackColor = Color.White;
            btnUpdateCopy.Cursor = Cursors.Hand;
            btnUpdateCopy.FlatAppearance.BorderColor = Color.FromArgb(108, 117, 125);
            btnUpdateCopy.FlatStyle = FlatStyle.Flat;
            btnUpdateCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateCopy.ForeColor = Color.FromArgb(73, 80, 87);
            btnUpdateCopy.Location = new Point(165, 3);
            btnUpdateCopy.Name = "btnUpdateCopy";
            btnUpdateCopy.Size = new Size(130, 32);
            btnUpdateCopy.TabIndex = 1;
            btnUpdateCopy.Text = "Cập nhật bản sao";
            btnUpdateCopy.UseVisualStyleBackColor = false;
            btnUpdateCopy.Click += btnUpdateCopy_Click;
            // 
            // btnAddSingleCopy
            // 
            btnAddSingleCopy.BackColor = Color.White;
            btnAddSingleCopy.Cursor = Cursors.Hand;
            btnAddSingleCopy.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnAddSingleCopy.FlatStyle = FlatStyle.Flat;
            btnAddSingleCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddSingleCopy.ForeColor = Color.FromArgb(40, 167, 69);
            btnAddSingleCopy.Location = new Point(0, 3);
            btnAddSingleCopy.Name = "btnAddSingleCopy";
            btnAddSingleCopy.Size = new Size(150, 32);
            btnAddSingleCopy.TabIndex = 0;
            btnAddSingleCopy.Text = "+ Nhập thêm bản sao";
            btnAddSingleCopy.UseVisualStyleBackColor = false;
            btnAddSingleCopy.Click += btnAddSingleCopy_Click;
            // 
            // lblCopyHint
            // 
            lblCopyHint.AutoSize = true;
            lblCopyHint.Dock = DockStyle.Top;
            lblCopyHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblCopyHint.ForeColor = Color.FromArgb(120, 120, 120);
            lblCopyHint.Location = new Point(8, 26);
            lblCopyHint.Name = "lblCopyHint";
            lblCopyHint.Padding = new Padding(0, 0, 0, 4);
            lblCopyHint.Size = new Size(337, 19);
            lblCopyHint.TabIndex = 0;
            lblCopyHint.Text = "Chọn một bản sao để cập nhật trạng thái, tình trạng hoặc xóa.";
            // 
            // dgvCopies
            // 
            dgvCopies.AllowUserToAddRows = false;
            dgvCopies.AllowUserToDeleteRows = false;
            dgvCopies.AllowUserToResizeRows = false;
            dgvCopies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCopies.BackgroundColor = Color.White;
            dgvCopies.BorderStyle = BorderStyle.None;
            dgvCopies.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCopiesHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCopiesHeaderStyle.BackColor = Color.FromArgb(240, 244, 250);
            dgvCopiesHeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCopiesHeaderStyle.ForeColor = Color.FromArgb(30, 45, 65);
            dgvCopiesHeaderStyle.SelectionBackColor = Color.FromArgb(240, 244, 250);
            dgvCopiesHeaderStyle.SelectionForeColor = Color.FromArgb(30, 45, 65);
            dgvCopies.ColumnHeadersDefaultCellStyle = dgvCopiesHeaderStyle;
            dgvCopies.ColumnHeadersHeight = 30;
            dgvCopies.Columns.AddRange(new DataGridViewColumn[] {
                colCopyId,
                colCopyStatus,
                colCopyCondition
            });
            dgvCopiesRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCopiesRowStyle.BackColor = Color.White;
            dgvCopiesRowStyle.Font = new Font("Segoe UI", 9F);
            dgvCopiesRowStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvCopiesRowStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvCopiesRowStyle.SelectionForeColor = Color.FromArgb(15, 44, 89);
            dgvCopies.DefaultCellStyle = dgvCopiesRowStyle;
            dgvCopies.Dock = DockStyle.Fill;
            dgvCopies.EnableHeadersVisualStyles = false;
            dgvCopies.Location = new Point(8, 45);
            dgvCopies.MultiSelect = false;
            dgvCopies.Name = "dgvCopies";
            dgvCopies.ReadOnly = true;
            dgvCopies.RowHeadersVisible = false;
            dgvCopies.RowTemplate.Height = 26;
            dgvCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCopies.Size = new Size(846, 177);
            dgvCopies.TabIndex = 1;
            // 
            // colCopyId
            // 
            colCopyId.DataPropertyName = "CopyId";
            colCopyId.FillWeight = 100F;
            colCopyId.HeaderText = "Mã bản sao";
            colCopyId.Name = "colCopyId";
            colCopyId.ReadOnly = true;
            // 
            // colCopyStatus
            // 
            colCopyStatus.DataPropertyName = "StatusDisplay";
            colCopyStatus.FillWeight = 100F;
            colCopyStatus.HeaderText = "Trạng thái";
            colCopyStatus.Name = "colCopyStatus";
            colCopyStatus.ReadOnly = true;
            // 
            // colCopyCondition
            // 
            colCopyCondition.DataPropertyName = "PhysicalConditionDisplay";
            colCopyCondition.FillWeight = 100F;
            colCopyCondition.HeaderText = "Tình trạng vật lý";
            colCopyCondition.Name = "colCopyCondition";
            colCopyCondition.ReadOnly = true;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(235, 243, 252);
            statusStrip.Items.AddRange(new ToolStripItem[] {
                lblStatus
            });
            statusStrip.Location = new Point(0, 741);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1264, 22);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(30, 45, 65);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(118, 17);
            lblStatus.Text = "Sẵn sàng hoạt động";
            // 
            // FrmBookManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 252);
            ClientSize = new Size(1264, 763);
            Controls.Add(pnlMain);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1100, 700);
            Name = "FrmBookManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đầu sách và bản sao";
            Load += FrmBookManagement_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlMain.ResumeLayout(false);
            grpBookInfo.ResumeLayout(false);
            grpBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            splitRight.Panel1.ResumeLayout(false);
            splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitRight).EndInit();
            splitRight.ResumeLayout(false);
            grpBooksList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            grpCopiesList.ResumeLayout(false);
            grpCopiesList.PerformLayout();
            pnlCopiesActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCopies).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlSearch;
        private Label lblSearchKeyword;
        private TextBox txtSearchKeyword;
        private Label lblSearchCategory;
        private ComboBox cboSearchCategory;
        private Button btnSearch;
        private Button btnRefreshSearch;
        private TableLayoutPanel pnlMain;
        private GroupBox grpBookInfo;
        private Label lblBookId;
        private TextBox txtBookId;
        private Label lblBookTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblPublisher;
        private TextBox txtPublisher;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblPublishYear;
        private NumericUpDown numPublishYear;
        private Label lblCopyCount;
        private TextBox txtCopyCount;
        private Button btnAddBook;
        private Button btnUpdateBook;
        private Button btnDeleteBook;
        private Button btnClear;
        private Button btnBatchAddCopies;
        private SplitContainer splitRight;
        private GroupBox grpBooksList;
        private DataGridView dgvBooks;
        private DataGridViewTextBoxColumn colBookId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colPublisher;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colPublishYear;
        private DataGridViewTextBoxColumn colCopyCount;
        private GroupBox grpCopiesList;
        private Label lblCopyHint;
        private DataGridView dgvCopies;
        private DataGridViewTextBoxColumn colCopyId;
        private DataGridViewTextBoxColumn colCopyStatus;
        private DataGridViewTextBoxColumn colCopyCondition;
        private Panel pnlCopiesActions;
        private Button btnAddSingleCopy;
        private Button btnUpdateCopy;
        private Button btnDeleteCopy;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
    }
}
