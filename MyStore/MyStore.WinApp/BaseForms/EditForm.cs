using MyStore.WinApp.Exceptions;
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
    public abstract partial class EditForm<TModel, TRepo> : Form, IModelForm<TModel>
    {
        protected TRepo _repository;

        public TModel Model { get; protected set; }

        public EditForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected virtual void GetSelectedModel()
        {
            try
            {
                Model = FormTools.GetSelectedModel<TModel>(Owner as MainForm);
            }
            catch (ListFormException ex)
            {
                FormTools.ShowInfo("Ops", ex.Message);
                Close();
                Dispose();
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Critical Error", ex.Message);

            }
        }

        protected virtual void Edit()
        {
            _repository.Update(LocalStorage.User, Model);
            if (Model == LocalStorage.User)
                Application.Restart();
        }

        protected abstract void LoadSelectedModel();

        private void EditForm_Load(object sender, EventArgs e)
        {
            GetSelectedModel();
            if (IsDisposed)
                return;
            LoadSelectedModel();
        }
    }
}
