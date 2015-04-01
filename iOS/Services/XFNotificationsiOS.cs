using System;
using UIKit;
using Foundation;
using XFNotification.iOS;

[assembly:Xamarin.Forms.Dependency (typeof(XFNotificationsiOS))]
namespace XFNotification.iOS
{
	public class XFNotificationsiOS:IXFNotifications
	{
		public XFNotificationsiOS ()
		{
		}

		public void SendXFNotification (string title, string description, int iconID)
		{
			var notification = new UILocalNotification ();
//			notification.FireDate = DateTime.Now.AddSeconds (15);
//			notification.AlertTitle = title;
			notification.AlertAction = title;
			notification.AlertBody = description;
			notification.ApplicationIconBadgeNumber = 1;
			notification.SoundName = UILocalNotification.DefaultSoundName;
			UIApplication.SharedApplication.ScheduleLocalNotification (notification);
		}
	}
}

