//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="Share.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using Android.App;
using Android.Content;
using IntuneMAMFormsSample.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace IntuneMAMFormsSample.Droid
{
    public class Share : IShare
    {
        public Share()
        {
        }

        public void ShareString(string content)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, content);

            var intentChooser = Intent.CreateChooser(intent, "Share via");
            ((Activity)Forms.Context).StartActivity(intentChooser);
        }

        public void ShareToFormsApplicationActivity(string content)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, content);

            var explicitIntent = new Intent(Forms.Context, typeof(TestApplicationActivity));
            explicitIntent.PutExtra("content", content);
            ((Activity)Forms.Context).StartActivity(explicitIntent);
        }
    }
}