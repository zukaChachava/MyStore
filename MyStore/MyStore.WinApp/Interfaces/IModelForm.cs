using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.WinApp.Interfaces
{
    public interface IModelForm<TModel> where TModel : BaseModel
    {
        TModel Model { get; }
    }
}
