//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="MainPage.xaml.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IntuneMAMFormsSample
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();
            this.viewModel = this.BindingContext as MainPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.viewModel.InvalidUriOpened += this.HandleInvalidUriOpened;
            this.viewModel.ShareRequested += this.HandleShareRequested;
            this.viewModel.ShareToActivityRequested += this.HandeShareToFormsApplicationActivity;
            this.viewModel.SaveFinished += this.HandleSaveFinished;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.viewModel.InvalidUriOpened -= this.HandleInvalidUriOpened;
            this.viewModel.ShareRequested -= this.HandleShareRequested;
            this.viewModel.ShareToActivityRequested -= this.HandeShareToFormsApplicationActivity;
            this.viewModel.SaveFinished -= this.HandleSaveFinished;
        }

        private async void HandleInvalidUriOpened(object sender, string e)
        {
            await this.DisplayAlert("Invalid Url", string.Format("\"{0}\" is not an absolute uri.", e), "Ok");
        }

        private void HandleShareRequested(object sender, string e)
        {
            DependencyService.Get<IShare>().ShareString(e);
        }

        private void HandeShareToFormsApplicationActivity(object sender, string e)
        {
            DependencyService.Get<IShare>().ShareToFormsApplicationActivity(e);
        }

        private async void HandleSaveFinished(object sender, string[] e)
        {
            await this.DisplayAlert(e[0], e[1], "Ok");
        }
    }
}
