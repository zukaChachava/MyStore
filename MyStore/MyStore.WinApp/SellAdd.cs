using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class SellAdd : AddForm<Sell, SellRepository>
    {
        protected SellDetailsRepository _sellDetailsRepository;
        protected DataTable _table;
        protected List<SellDetails> _sellDetails;

        public SellAdd(AppDbContext context) : base(new SellRepository(context))
        {
            InitializeComponent();
            _sellDetailsRepository = new SellDetailsRepository(context);
            _sellDetails = new List<SellDetails>();
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
                //var returnedValues = _repository.Insert(LocalStorage.UserId, LoadModel(), null, false);
                //LoadOrderDetailId(returnedValues.lastReturn);
                //_sellDetailsRepository.InsertMany(LocalStorage.UserId, _sellDetails, returnedValues.dbTransaction, true);
                //Close();
            }
            catch(ArgumentException ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count == 0 || gridView.Rows.Count == 0)
            {
                FormTools.ShowInfo("Ops", "Choose row to delete");
                return;
            }

            int row = gridView.SelectedRows[0].Index;
            //SellDetailsAdd orderDetailsAdd = new SellDetailsAdd(_sellDetailsRepository, _sellDetails[row]);
            //orderDetailsAdd.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.DeleteSelectedRow(gridView);

            if (index >= 0)
                _sellDetails.RemoveAt(index);
        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.User = userBox.SelectedItem as User;
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            Model.SellDate = datePicker.Value;
        }
    }
}
