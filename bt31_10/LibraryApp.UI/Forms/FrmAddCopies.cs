using LibraryApp.DAL.Enums;

namespace LibraryApp.UI.Forms
{
    public partial class FrmAddCopies : Form
    {
        public int Quantity { get; private set; } = 1;
        public PhysicalCondition SelectedCondition { get; private set; } = PhysicalCondition.Good;

        public FrmAddCopies(string bookId, string bookTitle)
        {
            InitializeComponent();
            lblBookInfo.Text = $"Đầu sách: [{bookId}] - {bookTitle}";

            // Nạp danh sách tình trạng vật lý
            var conditions = new[]
            {
                new { Value = PhysicalCondition.New, Text = "Mới" },
                new { Value = PhysicalCondition.Good, Text = "Tốt" },
                new { Value = PhysicalCondition.Worn, Text = "Cũ" },
                new { Value = PhysicalCondition.Damaged, Text = "Hỏng" }
            };

            cboCondition.DataSource = conditions;
            cboCondition.DisplayMember = "Text";
            cboCondition.ValueMember = "Value";
            cboCondition.SelectedIndex = 1; // Mặc định là Tốt
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Quantity = (int)numQuantity.Value;
            if (cboCondition.SelectedValue is PhysicalCondition cond)
            {
                SelectedCondition = cond;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
