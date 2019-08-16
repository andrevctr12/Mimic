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
		AppKit.NSButton configurationButton { get; set; }

		[Outlet]
		AppKit.NSMenu configurationMenu { get; set; }

		[Outlet]
		AppKit.NSView containerView { get; set; }

		[Action ("clickActionButton:")]
		partial void clickActionButton (Foundation.NSObject sender);

		[Action ("clickCloseButton:")]
		partial void clickCloseButton (Foundation.NSObject sender);

		[Action ("clickDiscordButton:")]
		partial void clickDiscordButton (Foundation.NSObject sender);

		[Action ("clickGithubButton:")]
		partial void clickGithubButton (Foundation.NSObject sender);

		[Action ("clickUpdateButton:")]
		partial void clickUpdateButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (configurationButton != null) {
				configurationButton.Dispose ();
				configurationButton = null;
			}

			if (configurationMenu != null) {
				configurationMenu.Dispose ();
				configurationMenu = null;
			}

			if (containerView != null) {
				containerView.Dispose ();
				containerView = null;
			}
		}
	}
}
