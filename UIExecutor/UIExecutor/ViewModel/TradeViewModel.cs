using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using UIExecutor.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using FIXApplication;

namespace UIExecutor.ViewModel
{
    class TradeViewModel
    {
        private QFApp _qfapp = null;

        private Object _messagesLock = new Object();
        public ObservableCollection<TradeRecord> Trades { get; set; }

        public TradeViewModel(QFApp app)
        {
            _qfapp = app;
            Trades = new ObservableCollection<TradeRecord>();

            //_qfapp.MessageEvent += new Action<QuickFix.Message, bool>(HandleMessage);
            _qfapp.Fix44QuoteRequestEvent += new Action<QuickFix.FIX44.QuoteRequest>(HandleQuoteRequest);
        }

        public void HandleMessage(QuickFix.Message msg, bool isIncoming)
        {
            try
            {
                if(isIncoming)
                {
                    // convert to trade record
                    //TradeRecord tr; // = new TradeRecord();
                    //SmartDispatcher.Invoke(new Action<TradeRecord>(PaintUpdate), tr);
                }

                //MessageRecord mr = new MessageRecord(msg, isIncoming);
                //SmartDispatcher.Invoke(new Action<MessageRecord>(AddMessage), mr);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }

        public void PaintUpdate(TradeRecord r)
        {
            try
            {
                Trades.Add(r);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }

        public void HandleQuoteRequest(QuickFix.FIX44.QuoteRequest msg)
        {
            try
            {
                string quoteRequestId = msg.QuoteReqID.Obj;
                //string status = FixEnumTranslator.Translate(msg.OrdStatus);

                Trace.WriteLine("OVM: Handling QuoteRequest: " + quoteRequestId);

                TradeRecord tr = new TradeRecord(quoteRequestId, "1", "New", "100.1", "CT10", "B");
                SmartDispatcher.Invoke(new Action<TradeRecord>(AddTrade), tr);
                /*
                lock (_ordersLock)
                {
                    foreach (OrderRecord r in Orders)
                    {
                        if (r.ClOrdID == clOrdId)
                        {
                            r.Status = status;
                            if (msg.IsSetLastPx())
                                r.Price = msg.LastPx.Obj;
                            if (msg.IsSetOrderID())
                                r.OrderID = msg.OrderID.Obj;

                            return;
                        }
                    }
                }
                */
                Trace.WriteLine("OVM: No order corresponds to QuoteRequestId: '" + quoteRequestId + "'");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }

        public void AddTrade(TradeRecord r)
        {
            try
            {
                Trades.Add(r);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }
    }
}
