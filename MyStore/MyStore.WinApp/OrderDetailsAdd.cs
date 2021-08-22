using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using MyStore.WinApp.Tools;

namespace MyStore.WinApp
{
    public partial class OrderDetailsAdd : Form, IModelForm<OrderDetails>
    {
        protected readonly OrderDetailsRepository _repository;
        protected BindingList<OrderDetails> _orderDetails;
        protected Order _order;

        public OrderDetailsAdd(OrderDetailsRepository repository, BindingList<OrderDetails> orderDetails)
        {
            InitializeComponent();
            sellPriceTxt.Enabled = false;
            priceTxt.Enabled = false;
            _repository = repository;
            _orderDetails = orderDetails;
            LoadProducts();
            Model = new OrderDetails();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public OrderDetails Model { get; protected set; }

        protected void LoadProducts()
        {
            productBox.Items.AddRange(_repository.GetProducts(LocalStorage.User).ToArray());
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.ProductID = (productBox.SelectedItem as Product).ID;
            sellPriceTxt.Text = _repository.GetProductPrice(productBox.SelectedItem as Product).ToString();
            priceTxt.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // TODO: Remove Next line.
            validDate_ValueChanged(sender, e);
            try
            {
                if (_orderDetails.Contains(Model))
                    throw new Exception("Model already exists");
                _orderDetails.Add(Model);
                Close();
            }
            catch(Exception ex)
            {
               FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (priceTxt.Text == "")
                    return;
                Model.UnitPrice = Convert.ToDecimal(priceTxt.Text);
                if (Convert.ToDecimal(sellPriceTxt.Text) < Convert.ToDecimal(priceTxt.Text))
                    throw new Exception("Sell price is lower !");
            }
            catch(FormatException)
            {
                priceTxt.Text = "";
                FormTools.ShowInfo("Ops", "Wrong numeric format, Pleas write only numbers !");
            }
            catch(Exception ex)
            {
                priceTxt.Text = "";
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void quantityTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Model.Quantity = Convert.ToInt32(quantityTxt.Text);
            }
            catch (FormatException)
            {
                quantityTxt.Text = "";
                FormTools.ShowInfo("Ops", "Wrong numeric format, Pleas write only numbers !");
            }
            catch (Exception ex)
            {
                quantityTxt.Text = "";
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void validDate_ValueChanged(object sender, EventArgs e)
        {
            Model.Valid = validDate.Value;
        }
    }
}
