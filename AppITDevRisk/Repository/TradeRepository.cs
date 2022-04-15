using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppITDevRisk;


namespace AppITDevRisk.Repository
{
    public class TradeRepository
    {
        private ITrade _trade { get; set; }

        public TradeRepository(ITrade trade)
        {
            _trade = trade;
        }

        public Trade AddTrades(string pInpValues)
        {            
            List<Trade> lstTrade = new List<Trade>();
            string[] tradevalues = pInpValues.Split(' ');
            Execute exec = new Execute();
            _trade.Value = Convert.ToDouble(tradevalues[0]);
            _trade.ClientSector = tradevalues[1];
            _trade.NextPaymentDate = Convert.ToDateTime(exec.validDate(tradevalues[2]));
            return (Trade)_trade;
        }


        
    }
}
