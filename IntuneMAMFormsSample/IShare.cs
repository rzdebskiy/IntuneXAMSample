//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="IShare.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using Xamarin.Forms;

namespace IntuneMAMFormsSample
{
    public interface IShare
    {
        void ShareString(string content);
        
        void ShareToFormsApplicationActivity(string content);
    }
}
