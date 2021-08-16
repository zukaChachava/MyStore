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
using MyStore.Repository.Context;
using MyStore.Repository;
using MyStore.WinApp.BaseForms;

namespace MyStore.WinApp
{
    public partial class EmployeeList : ListForm<Employee, EmployeeRepository>
    {
        public EmployeeList(AppDbContext context) : base(new EmployeeRepository(context))
        {
            InitializeComponent();
            AddPermission = 11;
            EditPermission = 21;
            DeletePermission = 31;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuEmployeeAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuEmployeeEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuEmployeeDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
