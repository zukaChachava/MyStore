using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class EmployeeDelete : DeleteForm<Employee, EmployeeRepository>, IEmployeeForm
    {
        public EmployeeDelete(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public int Id
        {
            get
            {
                return (idBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public string FirstName => default;

        public string LastName => default;

        public string PersonalId => default;

        public string Phone => default;

        public string Email => default;

        public string HomeAddress => default;

        public DateTime? StartJob => default;

        protected override Employee LoadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(EmployeeList))
                Abort();

            idBox.Items.Add(new ComboBoxItem() { Id = (int)listForm.GetSelectedId()["Id"] });
            idBox.SelectedIndex = 0;
            idBox.Enabled = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
