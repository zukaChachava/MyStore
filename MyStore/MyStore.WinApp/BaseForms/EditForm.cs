using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStore.WinApp.BaseForms
{
    public abstract partial class EditForm<TModel, TRepo> : Form
    {
        protected TRepo _repository;

        public EditForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected virtual TModel GetSelectedModel()
        {
            IListForm<TModel> listForm = null;
            Form activeChild = (Owner as MainForm).ActiveMdiChild;

            if (activeChild == null || activeChild.GetType() != typeof(TModel))
            {
                Abort();
                return null;
            }

            listForm = activeChild as IListForm<TModel>;
            return listForm.GetSelectedModel();
        }

        protected virtual void Edit()
        {
            TModel model = ReadModel();
            _repository.Update(LocalStorage.User, model);
            if (model == LocalStorage.User)
                Application.Restart();
        }

        protected virtual void Abort()
        {
            FormTools.ShowInfo("Ops", "You should choose relevant List Window");
            Close();
        }

        protected abstract TModel ReadModel();

        protected abstract void LoadSelectedModel();

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadSelectedModel();
        }
    }
}
