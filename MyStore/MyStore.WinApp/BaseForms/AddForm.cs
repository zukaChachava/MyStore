using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;

namespace MyStore.WinApp.BaseForms
{
    public abstract partial class AddForm<TModel, TRepo> : Form, IModelForm<TModel>
    {
        protected TRepo _repository;

        public AddForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            Model = new TModel();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public TModel Model { get; private set; }

        public virtual void Add()
        {
            _repository.Add(LocalStorage.User, Model);
        }
    }
}
