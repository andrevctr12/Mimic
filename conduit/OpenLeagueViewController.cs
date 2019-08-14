using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Diagnostics;

namespace Conduit
{
    public partial class OpenLeagueViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public OpenLeagueViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new OpenLeagueView View
        {
            get
            {
                return (OpenLeagueView)base.View;
            }
        }

        partial void openLeague(NSObject sender)
        {

            //task.LaunchPath = "/Applications/League of Legends.app";
            //task.Launch();
            if (NSWorkspace.SharedWorkspace.LaunchApplication("League of Legends"))
            {
                
            }
        }
    }
}
