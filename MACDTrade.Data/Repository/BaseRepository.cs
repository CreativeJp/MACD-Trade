using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class BaseRepository
    {
        private DBHelper _dbHelper;

        private string _strSQL;

        public string strSQL { get { return _strSQL; } set { _strSQL = value; } }
        public DBHelper dbHelper
        {
            get
            {
                if (_dbHelper == null)
                {
                    _dbHelper = new DBHelper();
                }
                return _dbHelper;
            }
            set { _dbHelper = value; }
        }
    }
}
