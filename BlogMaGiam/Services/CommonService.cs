using Common;
using Common.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public class CommonService<T>
    {
        private RestClient client = null;
        private RestRequest request = null;
        public CommonService()
        {
            //var session = HttpContext.Current.Session;
            //if (session["UserProfile"] != null)
            //{
            //    return session["UserProfile"] as IUserProfileSessionData;
            //}
            client = new RestClient(ConfigurationManager.AppSettings["URL_API"]);
            request = new RestRequest();
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Type", "application/json");
            try
            {
                request.AddHeader("Authorization", "Bearer " + CurrentUser.User.token);
                request.AddHeader("X-UserName", CurrentUser.User.user_name);

            }
            catch (Exception)
            {
                request.AddHeader("Authorization", "Bearer ");
                request.AddHeader("X-UserName", "");

            }

        }

        public ResponseObject<List<T>> GetListApi(string url)
        {
            ResponseObject<List<T>> res = new ResponseObject<List<T>>();
            request.Resource = url;
            request.Method = Method.GET;
            //request.RequestFormat = DataFormat.Json;
            //request.AddParameter("user", model);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = JsonConvert.DeserializeObject<ResponseObject<List<T>>>(response.Content);
            }
            return res;
        }

        public ResponseObject<T> GetApi(string url)
        {
            ResponseObject<T> res = new ResponseObject<T>();
            request.Resource = url;
            request.Method = Method.GET;
            //request.RequestFormat = DataFormat.Json;
            //request.AddParameter("user", model);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = JsonConvert.DeserializeObject<ResponseObject<T>>(response.Content);
            }
            return res;
        }

        public ResponseObject<T> PostApi(string url,object data)
        {
            ResponseObject<T> res = new ResponseObject<T>();
            request.Resource = url;
            request.Method = Method.POST;
            request.AddJsonBody(data);
            //request.RequestFormat = DataFormat.Json;
            //request.AddParameter("user", model);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = JsonConvert.DeserializeObject<ResponseObject<T>>(response.Content);
            }
            return res;
        }

        public ResponseObject<T> PutApi(string url, object data)
        {
            ResponseObject<T> res = new ResponseObject<T>();
            request.Resource = url;
            request.Method = Method.PUT;
            request.AddJsonBody(data);
            //request.RequestFormat = DataFormat.Json;
            //request.AddParameter("user", model);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = JsonConvert.DeserializeObject<ResponseObject<T>>(response.Content);
            }
            return res;
        }
     
    }
}