using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
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

        [NotMapped]
        public int StockStatusId { get; set; }
        public decimal LastHistogram { get; set; }
    }
}
