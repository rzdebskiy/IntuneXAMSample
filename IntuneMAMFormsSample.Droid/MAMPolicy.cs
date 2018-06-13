//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="MAMPolicy.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using IntuneMAMFormsSample.Droid;
using Microsoft.Intune.Mam.Client.Identity;
using Xamarin.Forms;

[assembly: Dependency(typeof(MAMPolicy))]
namespace IntuneMAMFormsSample.Droid
{
    public class MAMPolicy : IMAMPolicy
    {
        public MAMPolicy()
        {
        }

        public bool IsSaveToLocalAllowed()
        {
            return MAMPolicyManager.GetPolicy(Forms.Context).IsSaveToPersonalAllowed;
        }
    }
}