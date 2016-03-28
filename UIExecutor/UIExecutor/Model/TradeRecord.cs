using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIExecutor.Model
{
    public class TradeRecord : NotifyPropertyChangedBase
    {
        public TradeRecord(string pTradeID, string pQuantity, string pState, string pPrice, string pSymbol, string pSide)
        {
            TradeID = pTradeID;
            Quantity = pQuantity;
            State = pState;
            Price = pPrice;
            Symbol = pSymbol;
            Side = pSide;
        }

        private string _tradeID = "";
        private string _Quantity = "";
        private string _State = "";
        private string _Price = "";
        private string _symbol = "";
        private string _side = "";
        private string _execute = "";

        public string TradeID
        {
            get { return _tradeID; }
            set { _tradeID = value; OnPropertyChanged("TradeID"); }
        }

        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; OnPropertyChanged("Quantity"); }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; OnPropertyChanged("State"); }
        }

        public string Price
        {
            get { return _Price; }
            set { _Price = value; OnPropertyChanged("Price"); }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; OnPropertyChanged("Symbol"); }
        }

        public string Side
        {
            get { return _side; }
            set { _side = value; OnPropertyChanged("Side"); }
        }

        public string Execute
        {
            get { return _execute; }
            set { _execute = value; OnPropertyChanged("Execute"); }
        }
    }
}
