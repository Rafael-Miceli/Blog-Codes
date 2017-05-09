using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WcfSignalRWinformPush.SignalHubs;

[assembly: OwinStartup(typeof(WcfServiceWithSignalR.Startup))]

namespace WcfServiceWithSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AppDomain.CurrentDomain.Load(typeof(MyHub).Assembly.FullName);
            app.MapSignalR();
        }
    }
}
