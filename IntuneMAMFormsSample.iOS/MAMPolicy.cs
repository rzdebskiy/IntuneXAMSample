//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="MAMPolicy.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using Microsoft.Intune.MAM;
using IntuneMAMFormsSample.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(MAMPolicy))]
namespace IntuneMAMFormsSample.iOS
{
    public class MAMPolicy : IMAMPolicy
    {
        public MAMPolicy()
        {
        }

        public bool IsSaveToLocalAllowed()
        {
           return IntuneMAMPolicyManager.Instance.Policy.IsSaveToAllowedForLocation(IntuneMAMSaveLocation.LocalDrive, IntuneMAMPolicyManager.Instance.PrimaryUser);
        }
    }
}
