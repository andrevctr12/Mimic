using AppKit;

namespace Conduit
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            //NSApplication.SharedApplication.MainMenu = new NSMenu();
            NSApplication.Init();
            //NSApplication.SharedApplication.Delegate = new AppDelegate();
            NSApplication.Main(args);
        }
    }
}
