using System;
using AppKit;

namespace Conduit
{
    public class EventMonitor
    {
        private Foundation.NSObject[] monitor;
        private NSEventMask[] mask;
        private GlobalEventHandler handler;

        public EventMonitor(NSEventMask[] mask, GlobalEventHandler handler)
        {
            this.mask = mask;
            this.handler = handler;
        }

        public void start()
        {
            for(int i = 0; i < mask.Length; i++)
            {
                monitor[i] = new Foundation.NSObject();
                monitor[i] = NSEvent.AddGlobalMonitorForEventsMatchingMask(mask[i], handler);
            }
            
        }

        public void stop()
        {
            for (int i = 0; i < mask.Length; i++)
            {
                if (monitor[i] != null)
                {
                    NSEvent.RemoveMonitor(monitor[i]);
                    monitor[i] = null;
                }
            }
        }
    }
}
