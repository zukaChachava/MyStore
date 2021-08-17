using MyStore.Domain.Models;
using MyStore.Repository;
using System.Windows.Forms;
using System.Data;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Exceptions;

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

        public static void LoadComboBoxID(ComboBox box, int id, bool enabled = false)
        {
            box.Items.Clear();
            box.Items.Add(id);
            box.SelectedIndex = 0;
            box.Enabled = enabled;
        }

        public static void LoadComboBoxID<TModel>(ComboBox box, TModel model, bool enabled = false) where TModel : BaseModel
        {
            box.Items.Clear();
            box.Items.Add(model);
            box.SelectedIndex = 0;
            box.Enabled = enabled;
        }

        public static TModel GetSelectedModel<TModel>(MainForm mainForm) where TModel : BaseModel
        {
            IListForm<TModel> listForm = null;
            Form activeChild = mainForm.ActiveMdiChild;

            if (activeChild == null || activeChild.GetType() != typeof(TModel))
                throw new ListFormException("Choose relevant window");

            listForm = activeChild as IListForm<TModel>;
            return listForm.GetSelectedModel();
        }

        public static void AbortCreatingWindow(Form form)
        {
            FormTools.ShowInfo("Ops", "You should choose relevant List Window");
            form.Close();
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
