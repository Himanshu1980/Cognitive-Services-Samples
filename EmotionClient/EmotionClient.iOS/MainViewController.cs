using EmotionClient.Shared;
using Foundation;
using System;
using UIKit;

namespace EmotionClient.iOS
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController (IntPtr handle) : base (handle)
        {
           
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            TakePhoto.TouchUpInside += TakePhotoButton_TouchUpInside;
        }

        private void TakePhotoButton_TouchUpInside(object sender, EventArgs e)
        {
            TakePhoto.Enabled = false;
            UIImagePickerController picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.Camera;
            picker.FinishedPickingMedia += async (o, ev) => {
                ThePhoto.Image = ev.OriginalImage;
                DetailsText.Text = "Processing...";
                ((UIImagePickerController)o).DismissViewController(true, null);
                using (var stream = ev.OriginalImage.AsJPEG(.5f).AsStream())
                {
                    try
                    {
                        float happyValue = await Core.GetAverageHappinessScore(stream);
                        DetailsText.Text = Core.GetHappinessMessage(happyValue);
                    }
                    catch (Exception ex)
                    {
                        DetailsText.Text = ex.Message;
                    }
                    TakePhoto.Enabled = true;
                }
            };
            PresentModalViewController(picker, true);
        }
    }
}