using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_210042111
{
    public static class EventBus
    {
        private static readonly List<Action<IEvent>> handlers = new List<Action<IEvent>>();

        public static void Subscribe(Action<IEvent> handler)
        {
            handlers.Add(handler);
        }

        public static void Publish(IEvent eventMessage)
        {
            foreach (var handler in handlers)
            {
                handler(eventMessage);
            }
        }
    }
}
