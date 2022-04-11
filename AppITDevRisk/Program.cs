using System;
using System.Collections.Generic;
using System.Globalization;

namespace AppITDevRisk
{
    class Program
    {

        public List<Trade> lstTrades = new List<Trade>();
        static void Main(string[] args)
        {
            string inpDate;
            string inpTimesTraders;
            DateTime dateTrade;
            int timesTraders;
            string inpValuesTraders;
            int i = 1;
            List<Trade> lstTraders = new List<Trade>();
            
            Execute execute = new Execute(new Trade());

            //Insert Trade date
            inpDate = Console.ReadLine();
            try
            {
                dateTrade = Convert.ToDateTime(execute.validDate(inpDate));
                try
                {
                    inpTimesTraders = Console.ReadLine();
                    timesTraders = Convert.ToInt32(inpTimesTraders);
                    // Insert trades
                    try
                    {
                        do
                        {
                            
                            inpValuesTraders = Console.ReadLine();
                            string[] tradevalues = inpValuesTraders.Split(' ');
                            Trade trade = new Trade();
                            trade.Value = Convert.ToDouble(tradevalues[0]);
                            trade.ClientSector = tradevalues[1];
                            trade.NextPaymentDate = Convert.ToDateTime(execute.validDate(tradevalues[2]));
                            lstTraders.Add(trade);
                            i++;
                        } while (i <= timesTraders);
                        
                        
                        Console.WriteLine(execute.verifyTradeCategory(lstTraders, timesTraders, dateTrade));

                    }
                    catch
                    {
                        Console.WriteLine("Please verify traders contents.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please insert an integer number.");
                }
            }
            catch
            {
                Console.WriteLine("Wrong type of date. Please insert date in format 'dd/mm/yyyy'.");
            }

        }
    }
}
