using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using System;

namespace MyStore.WinApp
{
    public partial class EmployeeEdit : EditForm<Employee, EmployeeRepository>, IEmployeeForm
    {
        public EmployeeEdit(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return (idBox.SelectedItem as ComboBoxItem).Id;
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
                return adressTxt.Text;
            }
        }

        public DateTime? StartJob
        {
            get
            {
                return Convert.ToDateTime(dateBox.Text);
            }
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(Employee))
                Abort();

            //Employee model = _repository.Get(listForm.GetSelectedId());
            //LoadModel(model);

            void LoadModel(Employee model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.ID });
                nameTxt.Text = model.Firstname;
                lastnameTxt.Text = model.Lastname;
                personalTxt.Text = model.PersonalID;
                phoneTxt.Text = model.Phone;
                emailTxt.Text = model.Email;
                adressTxt.Text = model.HomeAddress;
                dateBox.Text = model.StartJob.ToString();
            }
        }

        protected override Employee ReadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
