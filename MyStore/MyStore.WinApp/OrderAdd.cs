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
using MyStore.WinApp.BaseForms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class OrderAdd : AddForm<Order, OrderRepository>
    {
        protected OrderDetailsRepository _orderDetailsRepository;
        protected BindingList<OrderDetails> _orderDetails;

        public OrderAdd(AppDbContext context) : base(new OrderRepository(context))
        {
            InitializeComponent();
            _orderDetailsRepository = new OrderDetailsRepository(context);
            _orderDetails = new BindingList<OrderDetails>();
            gridView.ContextMenuStrip = productStrip;
            gridView.DataSource = _orderDetails;
            LoadProviders();
            LoadUser();
        }

        protected void LoadProviders()
        {
            // TODO: ToArray is not good option here :(
            providerBox.Items.AddRange(_repository.GetProviders(LocalStorage.User).ToArray());
        }

        protected void LoadUser()
        {
            userBox.Items.Add(LocalStorage.User);
            userBox.SelectedIndex = 0;
            userBox.Enabled = false;
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            var orderDetailsWindow = new OrderDetailsAdd(_orderDetailsRepository, _orderDetails);
            orderDetailsWindow.ShowDialog();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //TODO : Remove next line
            dateBox_ValueChanged(sender, e);
            
            try
            {
                _repository.BeginTransaction();
                _repository.Add(LocalStorage.User, Model);
                GenerateOrderDetailsID(_orderDetails);
                _orderDetailsRepository.AddMany(LocalStorage.User, _orderDetails);
                _repository.CommitTransaction();
                Close();
            }
            catch (Exception ex)
            {
                if(_repository.TransactionOpended)
                    _repository.RollbackTransaction();
                Model.ID = 0;
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        protected void GenerateOrderDetailsID(IEnumerable<OrderDetails> orderDetails)
        {
            foreach (OrderDetails orderDetail in orderDetails)
            {
                orderDetail.ID = Model.ID;
                orderDetail.ProvideDate = dateBox.Value;
            } 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.GetSelectedIndex(gridView);

            if(index >= 0)
                _orderDetails.RemoveAt(index);
        }

        private void providerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.ProviderID = (providerBox.SelectedItem as Provider).ID;
        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.UserID = (userBox.SelectedItem as User).ID;
        }

        private void dateBox_ValueChanged(object sender, EventArgs e)
        {
            Model.OrderDate = DateTime.Now;
            Model.RequiredDate = dateBox.Value;
        }
    }
}
