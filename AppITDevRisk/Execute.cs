using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppITDevRisk
{
    class Execute
    {
        private ITrade _iTrade;
        public Execute(ITrade iTrade)
        {
            _iTrade = iTrade;
        }

        public DateTime validDate(string pDate)
        {
            DateTime dateTrade;
            CultureInfo Culture = new CultureInfo("en-US");
            dateTrade = Convert.ToDateTime(pDate, Culture);
            return dateTrade;
        }

        public string validTimesTrades(string pTimesTrades)
        {
            int timesTraders;
            timesTraders = Convert.ToInt32(pTimesTrades);
            return timesTraders.ToString();
        }

        public Trade insertTrade(string Values)
        {
            string[] tradevalues = Values.Split(' ');
            _iTrade.Value = Convert.ToDouble(tradevalues[0]);
            _iTrade.ClientSector = tradevalues[1];
            _iTrade.NextPaymentDate = Convert.ToDateTime(validDate(tradevalues[2]));
            return (Trade)_iTrade;
        }

        public string verifyTradeCategory(List<Trade> trade, int pNumTraders, DateTime pDate)
        {
            string sTradeCategory = "";
            int i = 1;
            do
            {
                if (trade[i - 1].NextPaymentDate < pDate.AddDays(30))
                {
                    sTradeCategory = sTradeCategory + "EXPIRED\n";
                }
                else if ((trade[i - 1].ClientSector == "Private") && (trade[i-1].Value > 1000000))
                {
                    sTradeCategory = sTradeCategory + "HIGHRISK\n";
                }
                else if ((trade[i - 1].ClientSector == "Public") && (trade[i-1].Value > 1000000))
                {
                    sTradeCategory = sTradeCategory + "MEDIUMRISK\n";
                }
                i++;
            } while (i <= pNumTraders);

            return sTradeCategory;
            
        }

    }
}
