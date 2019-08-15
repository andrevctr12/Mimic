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
	[Register ("QRCodeViewController")]
	partial class QRCodeViewController
	{
		[Outlet]
		AppKit.NSTextField codeLabel { get; set; }

		[Outlet]
		AppKit.NSImageView QRCodeImage { get; set; }

		[Action ("setQRCodeImage:")]
		partial void setQRCodeImage (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (codeLabel != null) {
				codeLabel.Dispose ();
				codeLabel = null;
			}

			if (QRCodeImage != null) {
				QRCodeImage.Dispose ();
				QRCodeImage = null;
			}
		}
	}
}
