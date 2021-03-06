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
using MyStore.WinApp.LocalData;

namespace MyStore.WinApp
{
    public partial class OrderDetailsList : ListForm<OrderDetails, OrderDetailsRepository>
    {
        private int _orderId;

        public OrderDetailsList(int orderId, AppDbContext context) : base(new OrderDetailsRepository(context))
        {
            InitializeComponent();
            _orderId = orderId;
        }

        public override void RefreshData()
        {
            Data = _repository.Select(LocalStorage.User);
        }
    }
}
