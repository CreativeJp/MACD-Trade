using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class StatusMaster
    {
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
