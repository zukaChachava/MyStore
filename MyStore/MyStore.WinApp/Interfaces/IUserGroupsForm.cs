using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Interfaces
{
    public interface IUserGroupsForm
    {
        int Id { get; }

        bool Admin { get; }

        bool Cashier { get; }

        bool Manager { get; }

        bool SupplyManager { get; }
    }
}
