using System;

namespace XFNotification
{
	public interface IXFNotifications
	{
		void SendXFNotification (string title, string description, int iconID);
	}
}

