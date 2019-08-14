using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using QRCoder;
using System.Diagnostics;
using System.IO;

namespace Conduit
{
    public partial class ConduitViewController : AppKit.NSViewController
    {
        #region Constructors

        private App _appinstance;
        public Action onStateChange;

        // Called when created from unmanaged code
        public ConduitViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
            _appinstance = new App(this);
            onStateChange += changeContainerView;
        }

        #endregion

        //strongly typed view accessor
        public new ConduitView View
        {
            get
            {
                return (ConduitView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
        }

        private void changeContainerView()
        {
            //containerView.Subviews = QRCodeViewController.freshController().View.;
        }

        static public ConduitViewController freshController()
        {
            var storyboard = NSStoryboard.FromName("Main", null);

            return storyboard.InstantiateControllerWithIdentifier("ConduitViewController") as ConduitViewController;
            
        }

        partial void clickDiscordButton(NSObject sender)
        {
            Process.Start("https://discord.gg/bfxdsRC");
        }

        partial void clickGithubButton(NSObject sender)
        {
            Process.Start("https://github.com/molenzwiebel/mimic");
        }

        partial void clickCloseButton(NSObject sender)
        {
            App.close();
        }

    }
}
