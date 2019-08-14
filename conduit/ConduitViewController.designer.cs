// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Conduit
{
	[Register ("ConduitViewController")]
	partial class ConduitViewController
	{
		[Outlet]
		AppKit.NSView containerView { get; set; }

		[Action ("clickDiscordButton:")]
		partial void clickDiscordButton (Foundation.NSObject sender);

		[Action ("clickGithubButton:")]
		partial void clickGithubButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (containerView != null) {
				containerView.Dispose ();
				containerView = null;
			}
		}
	}
}
