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

namespace MyStore.WinApp.BaseForms
{
    public abstract partial class DeleteForm<TModel, TRepo> : Form
    {
        protected TRepo _repository;

        public DeleteForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected void Delete()
        {
            _repository.Delete(LocalStorage.User, LoadModel());
        }

        protected abstract TModel LoadModel();

        protected abstract void LoadSelectedModel();

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            LoadSelectedModel();
        }

        protected virtual void Abort()
        {
            FormTools.ShowInfo("Ops", "You should choose relevant List Window");
            Close();
        }
    }
}
