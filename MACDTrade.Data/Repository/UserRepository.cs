using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserMaster GetUserByUserName(string username)
        {
            strSQL = "Select * FROM UserMaster WHERE UserName = @UserName;";
            dbHelper.AddParameter("@UserName", username);
            var dr = dbHelper.ExecuteReader(strSQL);
            return UIHelper.ConvertToObj<UserMaster>(dr);
        }
    }
}
