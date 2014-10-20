using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace speed_trapper.Hubs
{
    [HubName("SpeedTrapperHub")]
    public class SpeedTrapperHub : Microsoft.AspNet.SignalR.Hub
    {
        public static int speed = 200;

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, speed);

            if (Convert.ToInt32(message) > speed)
            {

                Clients.Client(Context.ConnectionId).broadcastMessage(name, 1, message);
            }
            else { Clients.Client(Context.ConnectionId).broadcastMessage(name, 0, message); }
        }
        [HubMethodName("SetSpeed")]
        public void SetSpeed(int speed1)
        {

            speed = speed1;
        }
    }
}