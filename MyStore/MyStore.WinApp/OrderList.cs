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

namespace MyStore.WinApp
{
    public partial class OrderList : ListForm<Order, OrderRepository>
    {
        private readonly AppDbContext _context;

        public OrderList(AppDbContext context) : base(new OrderRepository(context))
        {
            InitializeComponent();
            AddPermission = 15;
            GridView.RowHeaderMouseDoubleClick += RowClick;
            _context = context;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuOrderAdd_Click;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }

        protected void RowClick(object sender, EventArgs e)
        {
            OrderDetailsList sellDetailsList = new OrderDetailsList((int)GetSelectedId()["Id"], _context);
            sellDetailsList.ShowDialog();
        }
    }
}
