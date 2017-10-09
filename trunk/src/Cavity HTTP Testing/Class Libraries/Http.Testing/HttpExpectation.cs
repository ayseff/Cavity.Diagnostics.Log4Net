﻿namespace Cavity
{
    using System;
    using System.Net;
    using Cavity.Net;

    public class HttpExpectation : IHttpExpectation
    {
        public HttpExchange Exchange { get; set; }

        public static HttpWebResponse GetResponse(HttpRequest request,
                                                  CookieContainer cookies)
        {
            try
            {
#if NET20
                return (HttpWebResponse)HttpRequestExtensionMethods.ToWebRequest(request, cookies).GetResponse();
#else
                return (HttpWebResponse)request.ToWebRequest(cookies).GetResponse();
#endif
            }
            catch (WebException exception)
            {
                return (HttpWebResponse)exception.Response;
            }
        }

        public bool Verify(CookieContainer cookies)
        {
            if (null == cookies)
            {
                throw new ArgumentNullException("cookies");
            }

            if (null == Exchange)
            {
                throw new InvalidOperationException();
            }

            if (null == Exchange.Response)
            {
                throw new InvalidOperationException();
            }

            using (var response = GetResponse(Exchange.Request, cookies))
            {
                cookies = new CookieContainer();
                foreach (Cookie cookie in response.Cookies)
                {
                    cookies.Add(cookie);
                }

                if (Exchange.Response.Line.Code != (int)response.StatusCode ||
                    Exchange.Response.Line.Reason != response.StatusDescription)
                {
                    var message = "\"{0} {1}\" was expected, but \"{2} {3}\" was actually recieved.".FormatWith(Exchange.Response.Line.Code,
                                                                                                                Exchange.Response.Line.Reason,
                                                                                                                (int)response.StatusCode,
                                                                                                                response.StatusDescription);
                    throw new HttpTestException(message);
                }

                foreach (var header in Exchange.Response.Headers)
                {
                    if (response.Headers[header.Name] ==
                        header.Value)
                    {
                        continue;
                    }

                    var message = "\"{0}\" was expected, but \"{1}: {2}\" was actually recieved.".FormatWith(header,
                                                                                                             header.Name,
                                                                                                             response.Headers[header.Name]);
                    throw new HttpTestException(message);
                }
            }

            return true;
        }
    }
}