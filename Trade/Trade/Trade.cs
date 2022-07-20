using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    class Trade : ITrade
    {
        private double _Value;
        private string _ClientSector;
        private DateTime _NextPaymentDate;
        private IRiskCategory _risk;
        
        public Trade (double Value, string ClientSector, DateTime NextPaymentDate, RiskCategory risk)
        {
            _Value = Value;
            _ClientSector = ClientSector;
            _NextPaymentDate = NextPaymentDate;
            _risk = risk;
        }

        public double Value
        {
            get { return this._Value; }
        }    
             
        public string ClientSector
        {
            get { return this._ClientSector; }
        }

        public DateTime NextPaymentDate
        {
            get { return this._NextPaymentDate; }
        }
       
        public string riskTrade
        {
            get { return _risk.riskDescription; }
        }
    }
}
