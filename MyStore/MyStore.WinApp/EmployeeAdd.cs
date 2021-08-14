using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class EmployeeAdd : AddForm<Employee, EmployeeRepository>, IEmployeeForm
    {
        public EmployeeAdd(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return default;
            }
        }

        public string FirstName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        public string LastName
        {
            get
            {
                return lastnameTxt.Text;
            }
        }

        public string PersonalId
        {
            get
            {
                return personalTxt.Text;
            }
        }

        public string Phone
        {
            get
            {
                return phoneTxt.Text;
            }
        }

        public string Email
        {
            get
            {
                return emailTxt.Text;
            }
        }

        public string HomeAddress
        {
            get
            {
                return addressTxt.Text;
            }
        }

        public DateTime? StartJob
        {
            get
            {
                return Convert.ToDateTime(dateBox.Text);
            }
        }

        protected override Employee LoadModel() => FormTools.ReadInputModel(this);

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
