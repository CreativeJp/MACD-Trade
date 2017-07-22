using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MACDTrade.Data
{
    public class StockRepository : BaseRepository, IStockRepository
    {
        public List<StockMaster> ListStocks()
        {
            strSQL = @"SELECT 
                             SM.*
	                        ,SS.StockStatusId
	                        ,SS.LastHistogram
                        FROM StockMaster SM
                        LEFT JOIN  StockStatus SS ON SM.StockId = SS.StockId
                        LEFT JOIN SectorMaster Sec ON SM.SectorId = Sec.SectorId
                        WHERE SM.IsActive = 1 ";
            var dr = dbHelper.GetDataTable(strSQL);
            return UIHelper.ConvertToObjList<StockMaster>(dr);
        }
    }
}
