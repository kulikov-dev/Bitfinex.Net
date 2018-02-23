﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitfinex.Net.Objects.SocketObjets;
using Newtonsoft.Json;

namespace Bitfinex.Net.Objects.SocketObjects2
{
    [SubscriptionChannel("ticker", typeof(BitfinexSocketTradingPairTick), false)]
    public class TickerSubscriptionRequest : SubscriptionRequest
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        private Action<BitfinexSocketTradingPairTick[]> handler;

        public TickerSubscriptionRequest(string symbol, Action<BitfinexSocketTradingPairTick[]> handler)
        {
            Symbol = symbol;
            this.handler = handler;
        }

        protected override string GetSubscriptionSubKey()
        {
            return Symbol;
        }

        protected override void Handle(object obj)
        {
            handler((BitfinexSocketTradingPairTick[]) obj);
        }
    }

    [SubscriptionChannel("ticker")]
    public class TickerSubscriptionResponse : SubscriptionResponse
    {
        public string Symbol { get; set; }

        protected override string GetSubsciptionSubKey()
        {
            return Symbol;
        }
    }
}
