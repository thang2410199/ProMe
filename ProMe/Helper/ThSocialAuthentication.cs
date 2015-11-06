using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMe.Helper
{
    public class ThSocialAuthentication
    {
        public delegate void AuthenFailedEventHandler();
        public event AuthenFailedEventHandler AuthenFailed;

        public delegate void AuthenSuccessedEventHandler(string accessToken);
        public event AuthenSuccessedEventHandler AuthenSuccessed;

        string FBClientID = "";
        string WPAppID = "";
        public void InitFacebook(string clientId, string appId)
        {
            FBClientID = clientId;
            WPAppID = appId;
        }

        public async Task AuthenFacebook()
        {
            App.OnProtocolActivated += App_OnProtocolActivated;
            try
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(("fbconnect://authorize?client_id=" + FBClientID + "&scope=public_profile,email,publish_actions,user_friends&redirect_uri=msft-" + this.WPAppID + "%3a%2f%2fauthorize")));
            }
            catch
            {
                App.OnProtocolActivated -= App_OnProtocolActivated;
                if (AuthenFailed != null)
                    AuthenFailed.Invoke();
            }
        }

        void App_OnProtocolActivated(App sender, string FBtoken)
        {
            App.OnProtocolActivated -= App_OnProtocolActivated;

            if (AuthenSuccessed != null)
                AuthenSuccessed.Invoke(FBtoken);

        }

        public void RaiseAuthenFail()
        {
            if (AuthenFailed != null)
                AuthenFailed.Invoke();
        }
    }
}
