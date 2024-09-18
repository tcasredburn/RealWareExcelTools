using RealWare.Core.API;
using RealWare.Core.API.Connection;
using RealWareExcelTools.WinCore.Forms.Authentication;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Validation
{
    public class ConnectToRealWareValidator
    {
        public string RealWareLoginName { get; private set; }
        public string ApiToken { get; private set; }

        private readonly string _apiUrl;

        public enum LoginFormResult
        {
            CanceledByUser,
            TokenValid,
            TokenInvalid
        }

        public ConnectToRealWareValidator(string apiUrl, string token, string realWareLoginName) 
        {
            _apiUrl = apiUrl;
            ApiToken = token;
            RealWareLoginName = realWareLoginName;
        }

        public RealWareApiConnection GetRealWareApiConnection()
            => new RealWareApiConnection(_apiUrl, ApiToken);

        public bool Validate()
        {
            if(string.IsNullOrEmpty(_apiUrl))
            {
                Forms.ErrorMessage.ShowErrorMessage("API URL is required. Please go to settings and specify a valid url.", 
                    "Settings Incorrect");
                return false;
            }

            if (string.IsNullOrEmpty(ApiToken))
            {
                var result = showLoginFormLoop();
                if(result == LoginFormResult.CanceledByUser)
                    return false;
            }

            if(isTokenValid(_apiUrl, ApiToken))
                return true;

            var result2 = showLoginFormLoop();
            if (result2 == LoginFormResult.CanceledByUser)
                return false;
            else
                return true;
        }

        private LoginFormResult showLoginFormLoop()
        {
            string loginName = RealWareLoginName;
            string loginToken = ApiToken;

            var loginForm = new LoginToRealWareForm(new RealWareApi(GetRealWareApiConnection()));

            do
            {
                if (loginToken != string.Empty)
                {
                    if (isTokenValid(_apiUrl, loginToken))
                    {
                        RealWareLoginName = loginName;
                        ApiToken = loginToken;
                        return LoginFormResult.TokenValid;
                    }
                }

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    loginToken = loginForm.Token;
                    loginName = loginForm.Username;

                    if (isTokenValid(_apiUrl, loginToken))
                    {
                        RealWareLoginName = loginName;
                        ApiToken = loginToken;
                        return LoginFormResult.TokenValid;
                    }
                }
                else
                {
                    ApiToken = null;
                    return LoginFormResult.CanceledByUser;
                }
            }
            while (true);
        }

        private bool isTokenValid(string url, string token)
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(url);

            return Task.Run(async () => await RealWareApi.IsTokenValidAsync(client, url, token)).Result;
        }
    }
}
