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
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Exceptions;

namespace MyStore.WinApp.BaseForms
{
    public abstract partial class DeleteForm<TModel, TRepo> : Form, IModelForm<TModel>
    {
        protected TRepo _repository;

        public TModel Model { get; protected set; }

        public DeleteForm(TRepo repository)
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
                Close();
                Dispose();
            }
        }

        protected void Delete()
        {
            _repository.Delete(LocalStorage.User, Model);
        }

        protected abstract void LoadSelectedModel();

        protected virtual void Abort()
        {
            FormTools.ShowInfo("Ops", "You should choose relevant List Window");
            Close();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            GetSelectedModel();
            if (IsDisposed)
                return;
            LoadSelectedModel();
        }
    }
}
