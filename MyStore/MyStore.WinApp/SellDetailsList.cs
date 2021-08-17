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
    public partial class SellDetailsList : ListForm<SellDetails, SellDetailsRepository>
    {
        protected int _sellId;

        public SellDetailsList(int sellId, AppDbContext context) : base(new SellDetailsRepository(context))
        {
            InitializeComponent();
            _sellId = sellId;
            Text = "Sell Details List";
        }

        public override void RefreshData()
        {
            //Table = _repository.GetSellDetailsById(_sellId);
        }
    }
}
