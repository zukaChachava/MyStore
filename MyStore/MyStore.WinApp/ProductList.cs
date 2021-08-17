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
    public partial class ProductList : ListForm<Product, ProductRepository>
    {
        public ProductList(AppDbContext context) : base(new ProductRepository(context))
        {
            InitializeComponent();
            AddPermission = 17;
            EditPermission = 27;
            DeletePermission = 37;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuProductAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuProductEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuProductDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
