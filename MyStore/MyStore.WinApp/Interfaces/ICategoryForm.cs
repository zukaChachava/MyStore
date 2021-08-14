using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Interfaces
{
    public interface ICategoryForm
    {
        int Id { get; }

        string CategoryName { get; }
    }
}
