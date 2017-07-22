using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    interface IUserRepository
    {
        UserMaster GetUserByUserName(string username);
    }
}
