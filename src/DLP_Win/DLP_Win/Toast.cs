using Microsoft.Toolkit.Uwp.Notifications;

namespace DLP_Win
{
	internal class Toast
	{
		/// <summary>
		/// Erstelle eine Windows Benachrichtigung
		/// </summary>
		/// <param name="title">Titel der Benachrichtigung</param>
		/// <param name="message">Text</param>
		public static void ToastMessage(string title, string message)
		{
			// Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
			// Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater
			ToastContentBuilder t = new ToastContentBuilder()
				.AddArgument("action", "viewConveration")
				.AddArgument("conversationID", 5000)
				.AddText(title)
				.AddText(message);
			//.Show();

			t.AddButton(new ToastButton().SetContent("Schliessen").SetDismissActivation());
			t.SetToastDuration(ToastDuration.Long);
			t.Show();
		}


	}
}
