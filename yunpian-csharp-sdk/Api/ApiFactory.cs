namespace Yunpian.Sdk.Api
{
    public class ApiFactory
    {
        private readonly YunpianClient _clnt;

        public ApiFactory(YunpianClient clnt)
        {
            _clnt = clnt;
        }

        public T Api<T>(string name) where T : YunpianApi
        {
            YunpianApi api = null;
            switch (name)
            {
                case ShortUrlApi.ApiName:
                    api = new ShortUrlApi();
                    break;
                case SignApi.ApiName:
                    api = new SignApi();
                    break;
                case SmsApi.ApiName:
                    api = new SmsApi();
                    break;
                case TplApi.ApiName:
                    api = new TplApi();
                    break;
                case UserApi.ApiName:
                    api = new UserApi();
                    break;
                case VideoSmsApi.ApiName:
                    api = new VideoSmsApi();
                    break;
                case VoiceApi.ApiName:
                    api = new VoiceApi();
                    break;
            }

            api?.Init(_clnt);

            return api as T;
        }
    }
}