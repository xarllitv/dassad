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

namespace Resto.Front.Api.Dassad
{
    using static PluginContext;
    public sealed class TestP : IDisposable
    {
        private readonly CompositeDisposable subscriptions;

        public TestP()
        {
            subscriptions = new CompositeDisposable
            {
                Integration.AddButton("кнопка созданная мною", Print)
            };
        }
        private static void Print(IViewManager viewManager, IReceiptPrinter receiptPrinter)
        {
            receiptPrinter.Print(new ReceiptSlip
            {
                Doc = new XElement(Tags.Doc, new XElement(Tags.Center, "Test"))
            });
        }
        public void Dispose()
        {
            Dispose();
        }
    }
}
