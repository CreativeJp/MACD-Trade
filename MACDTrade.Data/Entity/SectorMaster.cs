using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class SectorMaster
    {
        public int SectorId { get; set; }
        public string Sector { get; set; }
        public bool? IsActive { get; set; }
    }
}
