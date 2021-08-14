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
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class OrderAdd : AddForm<Order, OrderRepository>
    {
        protected OrderDetailsRepository _orderDetailsRepository;
        protected DataTable _table;
        protected List<OrderDetails> _orderDetails;

        public OrderAdd(AppDbContext context) : base(new OrderRepository(context))
        {
            InitializeComponent();
            _orderDetailsRepository = new OrderDetailsRepository(context);
            LoadProvider();
            LoadUser();
            _table = GenerateTable();
            _orderDetails = new List<OrderDetails>();
            gridView.ContextMenuStrip = productStrip;
        }

        protected void LoadProvider()
        {

        }

        protected void LoadUser()
        {
            userBox.Items.Add(new ComboBoxItem() { Id = LocalStorage.User.ID, Name = LocalStorage.User.Username });
            userBox.SelectedIndex = 0;
            userBox.Enabled = false;
        }

        protected override Order LoadModel()
        {
            return new Order()
            {
                
            };
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected DataTable GenerateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
            table.Columns.Add("Valid");

            return table;
        }

        protected void TableChanged()
        {
            gridView.DataSource = _table;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadOrderDetailId(int id)
        {
            foreach (OrderDetails item in _orderDetails)
                item.ID = id;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.DeleteSelectedRow(gridView);

            if(index >= 0)
                _orderDetails.RemoveAt(index);
        }
    }
}
