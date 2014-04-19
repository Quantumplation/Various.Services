﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Razor;
using Microsoft.AspNet.SignalR;
using RazorEngine;
using Website.Models;
using Website.ViewModels.Web;

namespace Website.Hubs
{
    public class QuotesHub : Hub
    {
        private static Lazy<IHubContext> _context = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<QuotesHub>());

        private const string ViewName = "Quotes/_Quote";
        private static readonly string ViewPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views", ViewName + ".cshtml");

        public static void NewQuote(Quote q)
        {
            var quoteVM = new QuoteViewModel(q);
            var rawPage = File.ReadAllText(ViewPath);
            var page = Razor.Parse(rawPage, quoteVM);
            _context.Value.Clients.All.newQuote(page);
        }
    }
}