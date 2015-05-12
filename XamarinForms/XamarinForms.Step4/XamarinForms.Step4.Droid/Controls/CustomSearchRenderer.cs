using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Marvelpedia.XamarinForms.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinForms.Step4.Controls;

[assembly: ExportRenderer(typeof(CustomSearch), typeof(CustomSearchRenderer))]
namespace Marvelpedia.XamarinForms.Droid.Controls
{
    public class CustomSearchRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                int identifier = Control.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
                EditText textView = (Control.FindViewById(identifier)) as EditText;

                textView.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(10) } );
            }
        }
    }
}