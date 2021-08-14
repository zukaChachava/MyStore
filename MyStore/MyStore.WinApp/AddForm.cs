﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStore.WinApp.LocalData;

namespace MyStore.WinApp
{
    public abstract partial class AddForm<TModel, TRepo> : Form 
    {
        protected TRepo _repository;

        public AddForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        protected abstract TModel LoadModel();

        public virtual void Add()
        {
            _repository.Add(LocalStorage.User, LoadModel());
        }
    }
}
