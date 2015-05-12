using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamarinForms.Step4.Controls;
using XamarinForms.Step4.WinPhone.Controls;

[assembly: ExportRenderer(typeof(CustomSearch), typeof(CustomSearchRenderer))]
namespace XamarinForms.Step4.WinPhone.Controls
{
    public class CustomSearchRenderer: SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.MaxLength = 10;
            }
        }
    }
}
