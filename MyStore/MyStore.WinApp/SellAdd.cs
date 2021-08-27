using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class SellAdd : AddForm<Sell, SellRepository>
    {
        protected SellDetailsRepository _sellDetailsRepository;
        protected ProductDetailsRepository _productDetailsRepository;
        protected BindingList<SellDetails> _sellDetails;

        public SellAdd(AppDbContext context) : base(new SellRepository(context))
        {
            InitializeComponent();
            _sellDetailsRepository = new SellDetailsRepository(context);
            _sellDetails = new BindingList<SellDetails>();
            gridView.ContextMenuStrip = productStrip;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            var sellDetailsWindow = new SellDetailsAdd(_sellDetailsRepository, _sellDetails);
            sellDetailsWindow.ShowDialog();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _repository.BeginTransaction();
                _repository.Add(LocalStorage.User, Model);
                GenerateSellDetails();
                _sellDetailsRepository.AddMany(LocalStorage.User, _sellDetails);
                _productDetailsRepository.
                _repository.CommitTransaction();
                Close();
            }
            catch (Exception ex)
            {
                if (_repository.TransactionOpended)
                    _repository.RollbackTransaction();
                Model.ID = 0;
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        protected void GenerateSellDetails()
        {
            foreach (SellDetails selldetail in _sellDetails)
                selldetail.ID = Model.ID;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.GetSelectedIndex(gridView);

            if (index >= 0)
                _sellDetails.RemoveAt(index);
        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.UserID = (userBox.SelectedItem as User).ID;
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            Model.SellDate = datePicker.Value;
        }
    }
}
