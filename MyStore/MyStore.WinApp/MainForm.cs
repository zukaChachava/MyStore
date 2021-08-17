using MyStore.Domain.Models;
using MyStore.Repository.Interfaces;
using MyStore.Repository.Context;
using System;
using System.Windows.Forms;
using MyStore.WinApp.Tools;
using MyStore.WinApp.Interfaces;
using FormExtensions;
using MyStore.WinApp.LocalData;
using System.Linq;
using MyStore.WinApp.BaseForms;

namespace MyStore.WinApp
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        #region Properties

        public string StatusStripText
        {
            get
            {
                return toolStripStatusLabel.Text;
            }
            set
            {
                toolStripStatusLabel.Text = value;
            }
        }

        public AppDbContext Context
        {
            get
            {
                return _context;
            }
        }

        #endregion

        #region WindowsAppearence

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            while (MdiChildren.Length > 0)
                MdiChildren[0].Close();
        }

        #endregion

        #region About&Help

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        #endregion

        #region Lists

        private void OpenChildForm<TModel, TRepo>(ListForm<TModel, TRepo> listForm) where TModel : BaseModel, new() where TRepo : IRepository<TModel>
        {
            if (WindowExists(listForm))
            {
                FormTools.ShowInfo("Ops", "Window is already opend");
                return;
            }

            listForm.MdiParent = this;
            listForm.Show();
        }

        private void mnuEmployeesList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeList(_context));
        }

        private void mnuUsersList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserList(_context));
        }

        private void mnuUserGroupsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserGroupsList(_context));
        }

        private void mnuCategoriesList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryList(_context));
        }

        private void mnuProductsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductList(_context));
        }

        private void mnuProductDetailsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductDetailsList(_context));
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderList(_context));
        }

        private void mnuSellList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SellList(_context));
        }

        private void mnuProviderList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProviderList(_context));
        }

        private bool WindowExists<TModel, TRepo>(ListForm<TModel, TRepo> listForm) where TModel : BaseModel, new() where TRepo : IRepository<TModel>
        {
            for (int i = 0; i < MdiChildren.Length; i++)
                if (MdiChildren[i].GetType() == listForm.GetType())
                    return true;

            return false;
        }

        #endregion
        
        #region Add

        private void CallAddDialog<TModel, TRepo>(AddForm<TModel, TRepo> addForm) where TModel : BaseModel, new() where TRepo : IRepository<TModel>
        {
            addForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new EmployeeAdd(_context));
        }

        public void mnuUserAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new UserAdd(_context));
        }

        public void mnuUserGroupAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new UserGroupAdd(_context));
        }

        public void mnuCategoryAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new CategoryAdd(_context));
        }

        public void mnuProductAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new ProductAdd(_context));
        }

        public void mnuProviderAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new ProviderAdd(_context));
        }

        public void mnuOrderAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new OrderAdd(_context));
        }

        public void mnuSellAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new SellAdd(_context));
        }

        #endregion

        #region Edit

        private void CallEditDialog<TModel, TRepo>(EditForm<TModel, TRepo> editForm) where TModel : BaseModel, new() where TRepo : IRepository<TModel>
        {
            editForm.Owner = this;
            editForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new EmployeeEdit(_context));
        }

        public void mnuUserEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new UserEdit(_context));
        }

        public void mnuUserGroupEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new UserGroupEdit(_context));
        }

        public void mnuCategoryEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new CategoryEdit(_context));
        }

        public void mnuProductEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new ProductEdit(_context));
        }

        public void mnuProviderEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new ProviderEdit(_context));
        }

        #endregion

        #region Delete

        private void CallDeleteDialog<TModel, TRepo>(DeleteForm<TModel, TRepo> deleteForm) where TModel : BaseModel, new() where TRepo : IRepository<TModel>
        {
            deleteForm.Owner = this;
            deleteForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeDelete_Click(object sender, EventArgs e)
        {
            CallDeleteDialog(new EmployeeDelete(_context));
        }

        public void mnuUserDelete_Click(object sender, EventArgs e)
        {
            CallDeleteDialog(new UserDelete(_context));
        }

        public void mnuCategoryDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void mnuProductDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void mnuProviderDelete_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ToolStripFunctions

        private void GlobalAdd_Click(object sender, EventArgs e)
        {
            IListFormFuncs form = (IListFormFuncs)ActiveMdiChild;
            if (form == null)
            {
                FormTools.ShowInfo("Ops", "First you should open list window !");
                return;
            }

            form.AddFunction(sender, e);
        }

        #endregion

        #region User Logging

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogInForm logIn = new LogInForm(_context);
            logIn.Owner = this;
            logIn.ShowDialog();
            if (!logIn.Valid)
                Close();
            else
                this.RenderControlsByPermission(LocalStorage.Permissions.Select(x => Convert.ToInt16(x)), ',');
        }

        private void logOutLbl_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        #endregion

        #region Tools

        private void RefreshList()
        {
            foreach (IRefresher form in MdiChildren)
                form.RefreshData();
        }

        #endregion
    }
}
