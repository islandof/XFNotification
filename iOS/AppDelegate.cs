using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XFNotification.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			//localNotification 
			if (options != null) {
				if (options.ContainsKey (UIApplication.LaunchOptionsLocalNotificationKey)) {
					var localNotification = options [UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
					if (localNotification != null) {
						new UIAlertView (localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show ();
						UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
					}
				}

			}
			// register for remote notifications
			if (Convert.ToInt16 (UIDevice.CurrentDevice.SystemVersion.Split ('.') [0].ToString ()) < 8) {
					
				//remote
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
			} else {
				//local
				UIUserNotificationType localnotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
				var userNoticationSettings = UIUserNotificationSettings.GetSettingsForTypes (localnotificationTypes, new NSSet (new string[] { }));
				UIApplication.SharedApplication.RegisterUserNotificationSettings (userNoticationSettings);
				//remote
				UIUserNotificationType notificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
				var settings = UIUserNotificationSettings.GetSettingsForTypes (notificationTypes, new NSSet (new string[] { }));
				UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications ();
			}

			return base.FinishedLaunching (app, options);
		}

		public override void ReceivedLocalNotification (UIApplication application, UILocalNotification notification)
		{

			new UIAlertView (notification.AlertAction, notification.AlertBody, null, "OK", null).Show ();

			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
		}
	}
}

