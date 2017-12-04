using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace QuanLyThueXe.Hubs
{
    public class CounterHub: Hub
    {
        static long counter = 0;
        public override System.Threading.Tasks.Task OnConnected()
        {
            counter = counter + 1;
            Clients.All.updatecounter(counter);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            counter = counter - 1;
            Clients.All.updatecounter(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}