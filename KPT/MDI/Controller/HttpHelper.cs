using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
	static class HttpHelper
	{
		static public HttpWebResponse GetHttpWebResponse(HttpWebRequest request)
		{
			HttpWebResponse response = null;
			try
			{
				request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)";

				response = (HttpWebResponse)request.GetResponse();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
			return response;
		}
	}
}
