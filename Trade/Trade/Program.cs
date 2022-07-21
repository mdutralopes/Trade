using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    class Program
    {
        static DateTime ConvertDate(string dateString)
        {
            string dateStr = dateString.Substring(3, 2) + "/" + dateString.Substring(0, 2) + "/" +
                             dateString.Substring(6, 4);

            return Convert.ToDateTime(dateStr); ;
        }

        static void Main(string[] args)
        {
            List <Trade> Trades = new List<Trade>();
            List <string> Lines = new List<string>();
            IRiskCategory Risk;
            DateTime dateRef;
            int numTrades = 0;
            string[] lineValues;

            // reading input
            dateRef = ConvertDate(Console.ReadLine());
            numTrades = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < numTrades; i++ )
            {
                Lines.Add(Console.ReadLine());
            }
            
            // creating trades 
            foreach(string line in Lines)
            {
                lineValues = line.Split(' ');
                double Value = Convert.ToDouble(lineValues[0]);
                string ClientSector = lineValues[1];
                DateTime NextPaymentDate = ConvertDate(lineValues[2]);
                Risk = new RiskCategory(Value, ClientSector, NextPaymentDate, dateRef);
                Trades.Add(new Trade(Value, ClientSector, NextPaymentDate, Risk));              
            }

            // printing risks categories
            foreach(Trade trade in Trades)
            {
               Console.WriteLine(trade.riskTrade);
            }

            Console.ReadLine();
        }
    }
}
