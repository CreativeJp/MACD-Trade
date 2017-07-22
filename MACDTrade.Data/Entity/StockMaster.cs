using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data.Entity
{
    public class StockMaster
    {
        public int StockId { get; set; }
        public string StockSymbol { get; set; }
        public string CompanyName { get; set; }
        public int? SectorId { get; set; }
        public string GglUrl { get; set; }
        public string MacdUrl { get; set; }
        public bool? IsActive { get; set; }
    }
}
