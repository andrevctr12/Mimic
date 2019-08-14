using System;

namespace Conduit
{
    public class App
    {
        public static string APP_NAME = "Mimic Conduit";
        public static string VERSION = "2.2.0";

        public static string HUB_WS = "wss://rift.mimic.lol/conduit";
        public static string HUB = "https://rift.mimic.lol";

        private ConnectionManager manager;
        private String codeMenuItem;
        private ConduitViewController view;

        public App(ConduitViewController view)
        {
            this.view = view;
            manager = new ConnectionManager(this);
            Persistence.OnHubCodeChanged += UpdateCodeMenuItemText;
            UpdateCodeMenuItemText();
            
        }

        public void onStateChange()
        {
            view.onStateChange?.Invoke();
        }

        /**
         * Updates the code menu item with the current code, if it has changed.
         */
        private void UpdateCodeMenuItemText()
        {
            var code = Persistence.GetHubCode();
            if (code == null)
            {
                codeMenuItem = "Start League to generate an access code!";
                
            }
            else
            {
                codeMenuItem = "Access Code: " + code;
            }
            DebugLogger.Global.WriteMessage(codeMenuItem);
        }

        /**
         * Shows a simple notification with the specified text for 5 seconds.
         */
        public void ShowNotification(string text)
        {
            //icon.BalloonTipTitle = "Mimic Conduit";
            //icon.BalloonTipText = text;
            //icon.ShowBalloonTip(5000);

            DebugLogger.Global.WriteMessage($"Notification: " + text);
        }
    }
}
