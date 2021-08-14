﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class CategoryEdit : EditForm<Category, CategoryRepository>, ICategoryForm
    {
        public CategoryEdit(AppDbContext context) : base (new CategoryRepository(context))
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

        public string CategoryName
        {
            get
            {
                return categoryTxt.Text;
            }
        }

        protected override Category ReadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(CategoryList))
                Abort();

            //Category model = _repository.Get(listForm.GetSelectedId());
            //LoadModel(model);

            void LoadModel(Category model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.ID });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                categoryTxt.Text = model.Name;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
