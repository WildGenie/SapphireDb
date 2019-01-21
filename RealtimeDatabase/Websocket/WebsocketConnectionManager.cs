﻿using RealtimeDatabase.Websocket.Models;
using System.Collections.Concurrent;
using System.Linq;

namespace RealtimeDatabase.Websocket
{
    public class WebsocketConnectionManager
    {
        public ConcurrentBag<WebsocketConnection> connections;

        public WebsocketConnectionManager()
        {
            connections = new ConcurrentBag<WebsocketConnection>();
        }

        public void AddConnection(WebsocketConnection connection)
        {
            connections.Add(connection);
        }

        public void RemoveConnection(WebsocketConnection connection)
        {
            connections = new ConcurrentBag<WebsocketConnection>(connections.Where(c => c.Id != connection.Id));
        }
    }
}
