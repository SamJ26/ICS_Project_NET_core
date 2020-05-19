using System;
using System.Diagnostics;

namespace FilmManagment.GUI.Services.WebService
{
	public class OpenWebPageService : IOpenWebPageService
	{
		public bool OpenUri(string uri)
		{
			if (!IsValidUri(uri))
				return false;
			Process.Start(new ProcessStartInfo(uri) { UseShellExecute = true });
			return true;
		}

		private bool IsValidUri(string uri)
		{
			if (!Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute))
				return false;
			Uri tempUri;
			if (!Uri.TryCreate(uri, UriKind.Absolute, out tempUri))
				return false;
			return tempUri.Scheme == Uri.UriSchemeHttp || tempUri.Scheme == Uri.UriSchemeHttps;
		}
	}
}
