using MyStore.Domain.Models;
using MyStore.Repository;
using System.Windows.Forms;
using System.Data;
using MyStore.WinApp.Interfaces;

namespace MyStore.WinApp.Tools
{
    public static class FormTools
    {
        public static void ShowError(string header, string text)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string header, string text)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static Employee ReadInputModel(IEmployeeForm form) 
        {
            return new Employee()
            {
                ID = form.Id,
                Firstname = form.FirstName,
                Lastname = form.LastName,
                PersonalID = form.PersonalId,
                Phone = form.Phone,
                Email = form.Email,
                HomeAddress = form.HomeAddress,
                StartJob = form.StartJob
            };
        }

        public static User ReadInputModel(IUserForm form)
        {
            return new User()
            {
                ID = form.Id,
                Username = form.Username,
                Password = form.Password
            };
        }

        public static Category ReadInputModel(ICategoryForm form)
        {
            return new Category()
            {
                ID = form.Id,
                Name = form.CategoryName
            };
        }

        public static Product ReadInputModel(IProductForm form)
        {
            return new Product()
            {
                ID = form.Id,
                CategoryID = form.CategoryId,
                Name = form.ProductionName,
                Price = form.Price
            };
        }

        public static Provider ReadInputModel(IProviderForm form)
        {
            return new Provider()
            {
                ID = form.Id,
                Name = form.ProviderName,
                Phone = form.Phone,
                Email = form.Email,
                Location = form.Location
            };
        }

        public static void LoadRelatedData(ProductRepository repository, ComboBox comboBox)
        {
            //foreach (DataRow row in repository.GetRelatedData()[0].Rows)
            //    comboBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });
        }

        public static void LoadRelatedData(UserRepository repository, ComboBox comboBox)
        {
            //foreach (DataRow row in repository.GetRelatedData()[0].Rows)
            //    comboBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = $"{row["Firstname"]} {row["Lastname"]}" });
        }

        public static int DeleteSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count == 0 || gridView.Rows.Count == 0)
            {
                FormTools.ShowInfo("Ops", "Choose row to delete");
                return -1;
            }

            int row = gridView.SelectedRows[0].Index;
            gridView.Rows.RemoveAt(row);
            return row;
        }
    }
}
