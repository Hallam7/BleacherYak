﻿using System;
using System.Collections.Generic;
using System.Linq;
using BleacherYak.AuthHelpers;

using Foundation;
using UIKit;


namespace BleacherYak.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //CardsViewRenderer.Preserve();

            LoadApplication(new App());


            global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();
            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            // Convert NSUrl to Uri
            var uri = new Uri(url.AbsoluteString);

            // Load redirectUrl page
            AuthenticationState.Authenticator.OnPageLoading(uri);

            return true;
        }
    }
}
