using System;
namespace BleacherYak.AppConstant
{
    public class Constants
    {
		public static string AppName = "OAuthNativeFlow";

		// OAuth
		// For Google login, configure at https://console.developers.google.com/
		public static string iOSClientId = "758862578489-n1orntf5e5vstl64t9pmsd14ief2pud2.apps.googleusercontent.com";
		public static string AndroidClientId = "758862578489-9ucrp91a5l9jl6oa7a7d3qcr4kbrajv1.apps.googleusercontent.com";

		// These values do not need changing
		public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
		public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		public static string iOSRedirectUrl = "com.googleusercontent.apps.758862578489-n1orntf5e5vstl64t9pmsd14ief2pud2:/oauth2redirect";
		public static string AndroidRedirectUrl = "com.googleusercontent.apps.758862578489-9ucrp91a5l9jl6oa7a7d3qcr4kbrajv1:/oauth2redirect";

	}
}
