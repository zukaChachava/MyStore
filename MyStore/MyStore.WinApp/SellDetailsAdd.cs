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
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class SellDetailsAdd : Form, IModelForm<SellDetails>
    {
        protected SellDetailsRepository _repository;
        protected List<SellDetails> _sellDetails;

        public SellDetailsAdd(SellDetailsRepository repository, List<SellDetails> sellDetails)
        {
            InitializeComponent();
            maxQuantityTxt.Enabled = false;
            quantityTxt.Enabled = false;
            _repository = repository;
            _sellDetails = sellDetails;
            LoadProducts();
        }

        public SellDetails Model { get; protected set; }

        protected void LoadProducts()
        {
            // TODO: ToArray here :(
            productBox.Items.AddRange(_repository.GetProducts(LocalStorage.User).ToArray());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sellDetails.Contains(Model))
                    throw new Exception("Model already exists");
                _sellDetails.Add(Model);
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Product = productBox.SelectedItem as Product;
            quantityTxt.Enabled = true;
            maxQuantityTxt.Text = _repository.GetProductDetails(LocalStorage.User, Model.Product)
                .Sum(pd => pd.Quantity).ToString();
        }

        private void quantityTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Quantity = Convert.ToInt32(quantityTxt.Text);
        }

        private void discountTxt_TextChanged(object sender, EventArgs e)
        {
            Model.Discount = Convert.ToDecimal(discountTxt.Text);
        }
    }
}
