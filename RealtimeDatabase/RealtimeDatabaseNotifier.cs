﻿using RealtimeDatabase.Models.Responses;
using RealtimeDatabase.Websocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealtimeDatabase
{
    public class RealtimeDatabaseNotifier
    {
        private readonly WebsocketChangeNotifier notifier;

        public RealtimeDatabaseNotifier(WebsocketChangeNotifier _notifier)
        {
            notifier = _notifier;
        }

        public async Task HandleChanges(List<ChangeResponse> changes)
        {
            await notifier.HandleChanges(changes);
        }
    }
}
