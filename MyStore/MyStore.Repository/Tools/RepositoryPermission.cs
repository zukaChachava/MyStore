using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repository.Tools
{
    public class RepositoryPermission
    {
        private int? _select, _add, _update, _delete;

        public int Select
        {
            get
            {
                if (_select == null)
                    throw new NullReferenceException("select code is null");

                return _select ?? 0;
            }
            set
            {
                _select = value;
            }
        }
        public int Add
        {
            get
            {
                if (_add == null)
                    _add = Select + 10;
                return _add ?? 0;
            }
            set
            {
                _add = value;
            }
        }
        public int Update
        {
            get
            {
                if (_update == null)
                    _update = Select + 20;
                return _update ?? 0;
            }
            set
            {
                _update = value;
            }
        }
        public int Delete
        {
            get
            {
                if (_delete == null)
                    _delete = Select + 30;
                return _delete ?? 0;
            }
        }
    }
}
