using AppKit;
using Foundation;

namespace Conduit
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        NSStatusItem statusItem;
        NSPopover popover = new NSPopover();
        EventMonitor eventMonitor;

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            NSImage statusImage = NSImage.ImageNamed("StatusBarButtonImage");
            statusImage.Size = new CoreGraphics.CGSize(16.0, 16.0);

            this.statusItem = NSStatusBar.SystemStatusBar.CreateStatusItem(NSStatusItemLength.Square);
            this.statusItem.Image = statusImage;
            this.statusItem.HighlightMode = true;
            this.statusItem.Enabled = true;
            //this.statusItem.Menu = this.statusMenu;
            this.statusItem.Action = new ObjCRuntime.Selector("togglePopover:");

            //statusItem = NSStatusBar.SystemStatusBar.CreateStatusItem(NSStatusItemLength.Square);
            //var button = statusItem.Button;
            //if (button != null) {
            //    button.Image = NSImage.ImageNamed("StatusBarButtonImage");
            //    button.Image.Size = new CoreGraphics.CGSize(16.0, 16.0);
            //    statusItem.HighlightMode = true;
            //    button.Image.Template = true;
            //    button.Action = new ObjCRuntime.Selector("togglePopover:");
            //}

            //NSImage* statusImage = [NSImage imageNamed: NSImageNameActionTemplate];
            //statusImage.size = NSMakeSize(18.0, 18.0);
            //self.statusItem = [[NSStatusBar systemStatusBar] statusItemWithLength: NSSquareStatusItemLength];
            //self.statusItem.image = statusImage;
            //self.statusItem.highlightMode = YES;
            //self.statusItem.enabled = YES;
            //self.statusItem.menu = self.statusMenu;

            popover.ContentViewController = ConduitViewController.freshController();
            this.showPopover(this);

            //TODO: Event monitor not yet working


            //GlobalEventHandler eventHandler = new GlobalEventHandler((theEvent) =>
            //{
            //    var strongSelf = this;
            //    if (strongSelf.popover.Shown)
            //    {
            //        strongSelf.closePopover(theEvent);
            //    }
            //});
            //NSEventMask[] masks = { NSEventMask.LeftMouseDown, NSEventMask.RightMouseDown };
            //eventMonitor = new EventMonitor(masks, eventHandler);

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        [Action("togglePopover:")]public void togglePopover(NSObject sender)
        {
            if (popover.Shown)
                closePopover(sender);
            else
                showPopover(sender);

        }

        public void closePopover(NSObject sender)
        {
            popover.PerformClose(sender);
            //eventMonitor.stop();
        }

        public void showPopover(NSObject sender)
        {
            var button = statusItem.Button;
            popover.Show(
                relativePositioningRect: button.Bounds,
                positioningView: button,
                preferredEdge: NSRectEdge.MinYEdge);
//            eventMonitor.start();
        }

    }
}
