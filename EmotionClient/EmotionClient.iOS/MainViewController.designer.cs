// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace EmotionClient.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DetailsText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TakePhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ThePhoto { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DetailsText != null) {
                DetailsText.Dispose ();
                DetailsText = null;
            }

            if (TakePhoto != null) {
                TakePhoto.Dispose ();
                TakePhoto = null;
            }

            if (ThePhoto != null) {
                ThePhoto.Dispose ();
                ThePhoto = null;
            }
        }
    }
}