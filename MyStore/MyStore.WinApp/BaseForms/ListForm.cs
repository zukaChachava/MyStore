using FormExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.LocalData;
using System.Linq;

namespace MyStore.WinApp.BaseForms
{
    public abstract partial class ListForm<TModel, TRepo> : Form, IListForm<TModel>, IListFormFuncs, IRefresher
    {
        protected IEnumerable<TModel> _data;
        protected TRepo _repository;

        public ListForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            AddPermission = DeletePermission = EditPermission = 100;
        }

        public IEnumerable<TModel> Data
        {
            get
            {
                return _data;
            }
            protected set
            {
                _data = value;
                //TODO: I don't like ToList() func here, but I haven't found better solution :(
                dataGridView.DataSource = _data.ToList();
                dataGridView.Columns["ID"].Visible = false;
            }
        }

        protected DataGridView GridView
        {
            get
            {
                return dataGridView;
            }
        }

        public int AddPermission
        {
            get
            {
                return (int)contextMnuAdd.Tag;
            }
            protected set
            {
                contextMnuAdd.Tag = value;
            }
        }

        public int EditPermission
        {
            get
            {
                return (int)contextMnuEdit.Tag;
            }
            protected set
            {
                contextMnuEdit.Tag = value;
            }
        }

        public int DeletePermission
        {
            get
            {
                return (int)contextMnuDelete.Tag;
            }
            protected set
            {
                contextMnuDelete.Tag = value;
            }
        }

        public virtual IDictionary<string, object> GetSelectedId()
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            int rowNum = dataGridView.SelectedRows[0].Index;
            values.Add("Id", dataGridView.Rows[rowNum].Cells["Id"].Value);

            return values;
        }

        public virtual void RefreshData()
        {
            Data = _repository.Select(LocalStorage.User);
        }

        public Action<object, EventArgs> AddFunction { get; set; }

        public Action<object, EventArgs> EditFunction { get; set; }

        public Action<object, EventArgs> DeleteFunction { get; set; }

        protected virtual void ListForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip.RenderToolStripByPermission(LocalStorage.Permissions.Select(x => (short)x), '\t');
            RefreshData();
        }

        private void contextMnuAdd_Click(object sender, EventArgs e)
        {
            AddFunction(sender, e);
        }

        private void contextMnuEdit_Click(object sender, EventArgs e)
        {
            EditFunction(sender, e);
        }

        private void contextMnuDelete_Click(object sender, EventArgs e)
        {
            DeleteFunction(sender, e);
        }

        public int GetSelectedRowIndex()
        {
            throw new NotImplementedException();
        }

        public TModel GetSelectedModel()
        {
            return Data.ElementAt(GridView.SelectedRows[0].Index);
        }
    }
}
