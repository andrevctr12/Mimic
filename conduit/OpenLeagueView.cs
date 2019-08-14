using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Conduit
{
    public partial class OpenLeagueView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public OpenLeagueView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
