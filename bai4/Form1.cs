using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace bai5._4
{
    public partial class Form1 : Form
    {
        // Lớp nhân viên: NodePath là đường dẫn node mà nhân viên thuộc về
        class Employee
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public DateTime StartDate { get; set; }
            public string NodePath { get; set; }
        }

        private readonly List<Employee> _employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImages();
            LoadSampleEmployees();
            BuildTree();
            SetupListView();
            SetupViewCombo();

            tvDepartments.SelectedNode = tvDepartments.Nodes[0];
        }

        // ---------- ImageList ----------
        private void LoadImages()
        {
            // Dùng icon hệ thống cho nhanh; có thể thay bằng ảnh của bạn
            foreach (var il in new[] { imgSmall, imgLarge })
            {
                il.Images.Add("company", SystemIcons.Shield);
                il.Images.Add("dept", SystemIcons.Information);
                il.Images.Add("group", SystemIcons.Question);
                il.Images.Add("emp", SystemIcons.Application);
            }
            tvDepartments.ImageList = imgSmall;
            lsvEmployees.SmallImageList = imgSmall;
            lsvEmployees.LargeImageList = imgLarge;
        }

        // ---------- Dữ liệu mẫu ----------
        private void LoadSampleEmployees()
        {
            string c = "Công ty ABC";
            _employees.AddRange(new[]
            {
                new Employee{Id="NV001",Name="Nguyễn Văn An", Position="Trưởng phòng",StartDate=new DateTime(2018,3,1), NodePath=$@"{c}\Phòng IT"},
                new Employee{Id="NV002",Name="Trần Thị Bình",  Position="Lập trình viên",StartDate=new DateTime(2020,6,15),NodePath=$@"{c}\Phòng IT\Nhóm Backend"},
                new Employee{Id="NV003",Name="Lê Hoàng Cường", Position="Lập trình viên",StartDate=new DateTime(2021,9,1), NodePath=$@"{c}\Phòng IT\Nhóm Backend"},
                new Employee{Id="NV004",Name="Phạm Minh Dũng",Position="Thiết kế UI",    StartDate=new DateTime(2022,1,10),NodePath=$@"{c}\Phòng IT\Nhóm Frontend"},
                new Employee{Id="NV005",Name="Võ Thu Hà",      Position="Trưởng phòng",StartDate=new DateTime(2017,5,20),NodePath=$@"{c}\Phòng Nhân sự"},
                new Employee{Id="NV006",Name="Đặng Quốc Khánh",Position="Chuyên viên",  StartDate=new DateTime(2023,2,1), NodePath=$@"{c}\Phòng Nhân sự\Nhóm Tuyển dụng"},
                new Employee{Id="NV007",Name="Bùi Ngọc Lan",   Position="Kế toán trưởng",StartDate=new DateTime(2016,8,8),NodePath=$@"{c}\Phòng Kế toán"},
            });
        }

        // ---------- 1. Xây cây ----------
        private void BuildTree()
        {
            tvDepartments.Nodes.Clear();

            var root = CreateNode("Công ty ABC", "company");

            var it = CreateNode("Phòng IT", "dept");
            it.Nodes.Add(CreateNode("Nhóm Backend", "group"));
            it.Nodes.Add(CreateNode("Nhóm Frontend", "group"));

            var hr = CreateNode("Phòng Nhân sự", "dept");
            hr.Nodes.Add(CreateNode("Nhóm Tuyển dụng", "group"));

            var acc = CreateNode("Phòng Kế toán", "dept");

            root.Nodes.AddRange(new[] { it, hr, acc });
            tvDepartments.Nodes.Add(root);
            root.Expand();
        }

        private TreeNode CreateNode(string text, string imageKey)
        {
            return new TreeNode(text)
            {
                ImageKey = imageKey,
                SelectedImageKey = imageKey
            };
        }

        // ---------- 3. Cột cho Details ----------
        private void SetupListView()
        {
            lsvEmployees.View = View.Details;
            lsvEmployees.Columns.Clear();
            lsvEmployees.Columns.Add("Mã NV", 80);
            lsvEmployees.Columns.Add("Họ Tên", 180);
            lsvEmployees.Columns.Add("Chức vụ", 140);
            lsvEmployees.Columns.Add("Ngày vào làm", 110);
        }

        private void SetupViewCombo()
        {
            cboView.Items.AddRange(new object[] { "Details", "SmallIcon", "LargeIcon", "List", "Tile" });
            cboView.SelectedIndex = 0;
        }

        // ---------- 2. Click node -> lọc nhân viên ----------
        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.FullPath;

            // Nhân viên thuộc node này hoặc bất kỳ node con nào
            var list = _employees.Where(x =>
                x.NodePath == path || x.NodePath.StartsWith(path + @"\"));

            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();
            foreach (var emp in list)
            {
                var item = new ListViewItem(emp.Id) { ImageKey = "emp" };
                item.SubItems.Add(emp.Name);
                item.SubItems.Add(emp.Position);
                item.SubItems.Add(emp.StartDate.ToString("dd/MM/yyyy"));
                lsvEmployees.Items.Add(item);
            }
            lsvEmployees.EndUpdate();
        }

        // ---------- Đổi chế độ xem ----------
        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(cboView.SelectedItem.ToString(), out View v))
                lsvEmployees.View = v;
        }
    }
}