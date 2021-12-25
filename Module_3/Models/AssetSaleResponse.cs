using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_3.Models
{
    public class AssetSaleResponse
    {
        public bool SaleStatus { get; set; }
        public int NetWorth { get; set; }

        public List<StockDetails> StockList { get; set; }
        public List<MutualFundDetails> MutualFundList { get; set; }
    }
}
