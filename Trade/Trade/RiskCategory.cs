using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    class RiskCategory : IRiskCategory
    {
        private string[] riskArr = { "EXPIRED", "HIGHRISK", "MEDIUMRISK" };
        private enum riskCat { EXPIRED, HIGHRISK, MEDIUMRISK };
        private DateTime _NextPaymentDate;
        private string _ClientSector;
        private double _Value;
        private DateTime _DateRef;

        private bool IsExpired()
        {
            TimeSpan dateDiff = _DateRef - _NextPaymentDate;
            return (dateDiff.Days > 30);
        }

        private bool IsHighRisk()
        {
            return ((_Value > 1000000) & (_ClientSector == "Private"));
        }
        
        private bool IsMediumRisk()
        {
            return ((_Value > 1000000) & (_ClientSector == "Public"));
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

        public RiskCategory (double Value, string ClientSector, DateTime NextPaymentDate, DateTime DateRef)
        {
            _Value = Value;
            _ClientSector = ClientSector;
            _NextPaymentDate = NextPaymentDate;
            _DateRef = DateRef;
        }  

        public string riskDescription
        {
            get { return this.calculateRiskCategory(); }    
        }

    }
} 
