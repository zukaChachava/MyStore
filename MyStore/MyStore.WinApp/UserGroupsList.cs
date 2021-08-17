using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyStore.Repository;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.WinApp.BaseForms;

namespace MyStore.WinApp
{
    public partial class UserGroupsList : ListForm<User, UserRepository>
    {
        public UserGroupsList(AppDbContext context)  : base(new UserRepository(context))
        {
            InitializeComponent();
            AddPermission = 10;
            EditPermission = 20;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuUserGroupAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuUserGroupEdit_Click;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }
    }
}
