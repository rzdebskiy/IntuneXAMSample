//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="Share.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using Foundation;
using CoreGraphics;
using UIKit;
using IntuneMAMFormsSample.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace IntuneMAMFormsSample.iOS
{
    public class Share : IShare
    {
        public Share()
        {
        }

        public void ShareString(string content)
        {
            var avc = new UIActivityViewController(new NSObject[] { new NSString(content) }, null);
            var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }

            if (avc.PopoverPresentationController != null)
            {
                var frame = UIScreen.MainScreen.Bounds;
                frame.Height /= 2;
                avc.PopoverPresentationController.SourceView = topController.View;
                avc.PopoverPresentationController.SourceRect = frame;
                avc.PopoverPresentationController.PermittedArrowDirections = UIPopoverArrowDirection.Unknown;
            }

            topController.PresentViewController(avc, true, null);
        }

        public void ShareToFormsApplicationActivity(string content)
        {
            // not implemented in iOS
        }
    }
}
