using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Interfaces
{
    public interface IProviderForm
    {
        int Id { get; }

        string ProviderName { get; }

        string Phone { get; }

        string Email { get; }

        string Location { get; }
    }
}
