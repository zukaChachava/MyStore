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

namespace MyStore.WinApp
{
    public partial class ProductDetailsList : ListForm<ProductDetails, ProductDetailsRepository>
    {
        public ProductDetailsList(AppDbContext context) : base(new ProductDetailsRepository(context))
        {
            InitializeComponent();
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = null;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }
    }
}
