//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="MainPageViewModel.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntuneMAMFormsSample
{
    public class MainPageViewModel : PropertyNotifyBase
    {
        public MainPageViewModel()
        {
            this.PlaceholderUrl = "https://www.microsoft.com/";
            this.OpenCommand = new Command(this.ParseUriAndOpen);
            this.ShareCommand = new Command(
                () => this.FireEvent(this.ShareRequested, "Test Content Sharing from Intune Sample App"));
            this.SaveCommand = new Command(this.Save);
            this.ShareToActivityCommand = new Command(
                () => this.FireEvent(this.ShareToActivityRequested, "Opening FormsApplicationActivity"));
        }

        public event EventHandler<string> InvalidUriOpened;
        public event EventHandler<string> ShareRequested;
        public event EventHandler<string> ShareToActivityRequested;
        public event EventHandler<string[]> SaveFinished;

        public Command OpenCommand
        {
            get;
            private set;
        }

        public Command ShareCommand
        {
            get;
            private set;
        }

        public Command ShareToActivityCommand
        {
            get;
            private set;
        }

        public Command SaveCommand
        {
            get;
            private set;
        }

        public string PlaceholderUrl
        {
            get { return this.GetProperty<string>(); }
            private set { this.SetProperty<string>(value); }
        }

        public string Url
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        private void ParseUriAndOpen()
        {
            Uri uri;
            if (string.IsNullOrEmpty(this.Url))
            {
                Device.OpenUri(new Uri(this.PlaceholderUrl));
            }
            else if (Uri.TryCreate(this.Url, UriKind.Absolute, out uri))
            {
                Device.OpenUri(uri);
            }
            else
            {
                this.FireEvent(this.InvalidUriOpened, this.Url);
            }
        }

        private void Save()
        {
            // App to enforce Save-As (optional)
            if (!DependencyService.Get<IMAMPolicy>().IsSaveToLocalAllowed())
            {
                this.FireEvent(this.SaveFinished, new[] { "Blocked", "Blocked from writing to personal location" });
                return;
            }

            var fileName = "intune-test.txt";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);

            try
            {
                File.WriteAllText(path, "Test Save to Personal");
                this.FireEvent(this.SaveFinished, new[] { "Succeeded", "Wrote to " + fileName });
            }
            catch (Exception)
            {
                this.FireEvent(this.SaveFinished, new[] { "Failed", "Failed to write to " + fileName });
            }
        }

        private void FireEvent<T>(EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
