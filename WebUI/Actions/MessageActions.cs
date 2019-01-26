﻿using RealtimeDatabase.Models.Actions;
using RealtimeDatabase.Websocket;
using System.Threading.Tasks;

namespace WebUI.Actions
{
    public class MessageActions : ActionHandlerBase
    {
        private readonly RealtimeMessageSender MessageSender;

        public MessageActions(RealtimeMessageSender messageSender)
        {
            MessageSender = messageSender;
        }

        public void Publish(string message)
        {
            MessageSender.Send(message);
        }

        public void SendToAdmin(string message)
        {
            MessageSender.Send(c => c.HttpContext.User.IsInRole("admin"), message);
        }
    }
}
