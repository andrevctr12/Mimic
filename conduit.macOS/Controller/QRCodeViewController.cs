using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using QRCoder;

namespace Conduit
{
    public partial class QRCodeViewController : AppKit.NSViewController
    {
        private String hubCode;

        #region Constructors

        // Called when created from unmanaged code
        public QRCodeViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new QRCodeView View
        {
            get
            {
                return (QRCodeView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            hubCode = Persistence.GetHubCode();
            if (hubCode != null)
                renderCode();
            //else
                
     
            
        }

        static public QRCodeViewController freshController()
        {
            var storyboard = NSStoryboard.FromName("Main", null);

            return storyboard.InstantiateControllerWithIdentifier("QRCodeViewController") as QRCodeViewController;

        }


        public void renderCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://remote.mimic.lol/" + hubCode, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);


            //    ConnectionQR.Source = qrCode.GetGraphic(20);
            //    ConnectionQR.Visibility = Visibility.Visible;

            //    CodeLabel.Content = Persistence.GetHubCode();
            //    CodeLabel.Visibility = Visibility.Visible;

            //    ConnectionSteps.Visibility = Visibility.Visible;
            //    NoCodeText.Visibility = Visibility.Hidden;

            NSData imageData = NSData.FromArray(qrCodeAsBitmapByteArr);
            QRCodeImage.Image = new NSImage(imageData);

            codeLabel.StringValue = hubCode;
            
        }
    }
}
