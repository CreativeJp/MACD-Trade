using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class StockStatus
    {
        public int StockStatusId { get; set; }
        public int? StockId { get; set; }
        public int? StatusId { get; set; }
        public decimal? LastHistogram { get; set; }
        public bool? IsActive { get; set; }
    }
}
