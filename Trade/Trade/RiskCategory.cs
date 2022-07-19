using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    class RiskCategory
    {
        private string[] riskArr = { "EXPIRED", "HIGHRISK", "MEDIUMRISK" };
        private enum riskCat { EXPIRED, HIGHRISK, MEDIUMRISK };
        private Trade _trade;
        private DateTime _DateRef;

        private bool IsExpired()
        {
            TimeSpan dateDiff = _DateRef - _trade.NextPaymentDate;
            return (dateDiff.Days > 30);
        }

        private bool IsHighRisk()
        {
            return ((_trade.Value > 1000000) & (_trade.ClientSector == "Private"));
        }
        
        private bool IsMediumRisk()
        {
            return ((_trade.Value > 1000000) & (_trade.ClientSector == "Public"));
        }

        private string calculateRiskCategory()
        {
            riskCat riskcat;

            // precedence #1
            if (IsExpired())
            {
                riskcat = riskCat.EXPIRED;
                return riskArr[(int)riskcat];
            }
            // precedence #2 
            else if (IsHighRisk())
            {
                riskcat = riskCat.HIGHRISK;
                return riskArr[(int)riskcat];
            }
            // precedence #3
            else if (IsMediumRisk())
            {
                riskcat = riskCat.MEDIUMRISK;
                return riskArr[(int)riskcat];
            }
            return "DEFAULT";
        }

        public RiskCategory (Trade trade, DateTime DateRef)
        {
            _trade = trade;
            _DateRef = DateRef;
        }  

        public string riskDescription
        {
            get { return this.calculateRiskCategory(); }    
        }

    }
} 
