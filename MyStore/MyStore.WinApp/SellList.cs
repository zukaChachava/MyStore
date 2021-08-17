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
    public partial class SellList : ListForm<Sell, SellRepository>
    {
        private readonly AppDbContext _context;
        SellDetailsRepository _sellDetailsRepository;

        public SellList(AppDbContext context) : base(new SellRepository(context))
        {
            InitializeComponent();
            AddPermission = 18;
            _sellDetailsRepository = new SellDetailsRepository(context);
            GridView.RowHeaderMouseDoubleClick += RowClick;
            _context = context;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuSellAdd_Click;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }

        protected void RowClick(object sender, EventArgs e)
        {
            SellDetailsList sellDetailsList = new SellDetailsList((int)GetSelectedId()["Id"], _context);
            sellDetailsList.ShowDialog();
        }
    }
}
