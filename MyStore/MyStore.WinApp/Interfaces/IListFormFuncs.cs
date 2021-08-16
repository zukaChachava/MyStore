using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Interfaces
{
    public interface IListFormFuncs
    {
        Action<object, EventArgs> AddFunction { get; set; }

        Action<object, EventArgs> EditFunction { get; set; }

        Action<object, EventArgs> DeleteFunction { get; set; }
    }
}
