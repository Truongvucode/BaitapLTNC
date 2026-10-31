using LibraryApp.DAL.Enums;

namespace LibraryApp.UI.Forms
{
    public partial class FrmUpdateCopy : Form
    {
        public CopyStatus SelectedStatus { get; private set; }
        public PhysicalCondition SelectedCondition { get; private set; }

        public FrmUpdateCopy(string copyId, CopyStatus currentStatus, PhysicalCondition currentCondition)
        {
            InitializeComponent();

            lblCopyInfo.Text = $"Mã bản sao: {copyId}";
            SelectedStatus = currentStatus;
            SelectedCondition = currentCondition;

            // Nạp danh sách trạng thái
            var statuses = new[]
            {
                new { Value = CopyStatus.Available, Text = "Sẵn sàng" },
                new { Value = CopyStatus.Borrowed, Text = "Đang mượn" },
                new { Value = CopyStatus.Lost, Text = "Mất" },
                new { Value = CopyStatus.Maintenance, Text = "Bảo trì" }
            };

            cboStatus.DataSource = statuses;
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "Value";
            cboStatus.SelectedValue = currentStatus;

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
            cboCondition.SelectedValue = currentCondition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboStatus.SelectedValue is CopyStatus st)
            {
                SelectedStatus = st;
            }

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
