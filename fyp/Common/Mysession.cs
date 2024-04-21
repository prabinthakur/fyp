using Newtonsoft.Json;

namespace fyp.Common
{
    public class Mysession
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public Mysession(IHttpContextAccessor httpContext)
        {
            
            _httpContextAccessor = httpContext;

        }


        public int  JobId
        {
            get
            {
                return _httpContextAccessor.HttpContext?.Session.GetInt32("JobId")??0;

            }
            set { 

                _httpContextAccessor.HttpContext?.Session.SetInt32("JobId",(value));
            }

        }



        private string Serialize(object? value)
        {
            return JsonConvert.SerializeObject(value);

        }
    }
}
