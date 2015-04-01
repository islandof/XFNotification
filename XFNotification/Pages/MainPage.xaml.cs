using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFNotification
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private void NotificationClicked (object sender, EventArgs e)
		{
			DependencyService.Get<IXFNotifications> ().SendXFNotification ("title", "description ", 0);
		}
	}
}

