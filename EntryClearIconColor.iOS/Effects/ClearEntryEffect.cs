using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(EntryClearIconColor.iOS.Effects.ClearEntryEffect), "ClearEntryEffect")]
namespace EntryClearIconColor.iOS.Effects
{
    public class ClearEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            if (Control is UITextField textField)
            {
                //Enable the clear icon
                textField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                //Get hold of the clear icon inside the text field
                UIButton clearButton = textField.ValueForKey(new Foundation.NSString("clearButton")) as UIButton;
                //Set the desired color
                clearButton.TintColor = UIColor.Red;
                UIImage clearImage = UIImage.GetSystemImage("xmark.circle.fill");
                //Override the regular image with the colored one
                clearButton.SetImage(clearImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
            }
        }
    }
}