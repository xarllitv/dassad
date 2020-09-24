using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Resto.Front.Api.Data.Cheques;
using Resto.Front.Api.Data.Device;
using Resto.Front.Api.Data.Orders;
using Resto.Front.Api.Data.View;
using Resto.Front.Api.UI;
using Resto.Front.Api.Extensions;
using System.Runtime.Remoting;

namespace Resto.Front.Api.Dassad
{
    using static PluginContext;
    class TestPlugin : IFrontPlugin
    {
        
        private readonly Stack<IDisposable> subscriptions = new Stack<IDisposable>();
        public TestPlugin()
        {
            Log.Info("Initializing Plugin");
            subscriptions.Push(new TestP());
            Log.Info("Plugin started");
        }
        public void Dispose()
        {
            while (subscriptions.Any())
            {
                var subscription = subscriptions.Pop();
                try
                {
                    subscription.Dispose();
                }
                catch (RemotingException)
                {
                    // 
                }
            }
            Log.Info("plugin stopped");
        }
    }
}
