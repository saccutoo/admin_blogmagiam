using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMaGiam.Helpers
{
    public class NoCache : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            List<string> keys = new List<string>();
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();

            while (enumerator.MoveNext())
                keys.Add(enumerator.Key.ToString());

            for (int i = 0; i < keys.Count; i++)
                if (keys[i].IndexOf("LoggedInUsers") == -1)
                {
                    HttpRuntime.Cache.Remove(keys[i]);
                }
            base.OnResultExecuting(filterContext);
        }
    }
}