//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="TestApplicationActivity.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.App.Assist;
using Android.Net;
using Android.Util;

namespace IntuneMAMFormsSample.Droid
{
    /// <summary>
    /// This application shows that the MAM Remapper targets work with the FormsApplicationActivity as well.
    /// Beyond that, this activity doesn't do anything or have an affiliated UI.
    /// </summary>
    [Activity(Label = "IntuneMAMFormsSample", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class TestApplicationActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        const string TAG = "MainActivity";

        protected override void OnMAMCreate(Bundle bundle)
        {
            Log.Info(TAG, "OnMAMCreate");
            base.OnMAMCreate(bundle);

            Log.Info(TAG, "Got content " + Intent.GetStringExtra("content"));
        }

        protected override void OnMAMActivityResult(int i, Result j, Intent intent)
        {
            Log.Info(TAG, "OnMAMActivityResult");
            base.OnMAMActivityResult(i, j, intent);
        }

        protected override void OnMAMDestroy()
        {
            Log.Info(TAG, "OnMAMDestroy");
            base.OnMAMDestroy();
        }

        protected override void OnMAMPause()
        {
            Log.Info(TAG, "OnMAMPause");
            base.OnMAMPause();
        }

        protected override void OnMAMResume()
        {
            Log.Info(TAG, "OnMAMResume");
            base.OnMAMResume();
        }

        public override void OnMAMNewIntent(Intent intent)
        {
            Log.Info(TAG, "OnMAMNewIntent");
            base.OnMAMNewIntent(intent);
        }

        public override void OnMAMPostCreate(Bundle p0)
        {
            Log.Info(TAG, "OnMAMPostCreate");
            base.OnMAMPostCreate(p0);
        }

        public override void OnMAMPostResume()
        {
            Log.Info(TAG, "OnMAMPostResume");
            base.OnMAMPostResume();
        }

        public override void OnMAMProvideAssistContent(AssistContent p0)
        {
            Log.Info(TAG, "OnMAMProvideAssistContent");
            base.OnMAMProvideAssistContent(p0);
        }

        public override void OnMAMSaveInstanceState(Bundle p0)
        {
            Log.Info(TAG, "OnMAMSaveInstanceState");
            base.OnMAMSaveInstanceState(p0);
        }

        public override void OnMAMStateNotSaved()
        {
            Log.Info(TAG, "OnMAMStateNotSaved");
            base.OnMAMStateNotSaved();
        }

        public override bool OnMAMPrepareOptionsMenu(IMenu p0)
        {
            Log.Info(TAG, "OnMAMPrepareOptionsMenu");
            return base.OnMAMPrepareOptionsMenu(p0);
        }

        public override bool OnMAMSearchRequested(SearchEvent p0)
        {
            Log.Info(TAG, "OnMAMSearchRequested");
            return base.OnMAMSearchRequested(p0);
        }

        public override Uri OnMAMProvideReferrer()
        {
            Log.Info(TAG, "OnMAMProvideReferrer");
            return base.OnMAMProvideReferrer();
        }
    }
}