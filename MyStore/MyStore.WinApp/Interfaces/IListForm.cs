using System;
using System.Data;
using System.Collections.Generic;
using MyStore.Domain.Models;

namespace MyStore.WinApp.Interfaces
{
	public interface IListForm<TModel> where TModel : BaseModel
	{
		TModel GetSelectedModel();

		int GetSelectedRowIndex();
	}
}
