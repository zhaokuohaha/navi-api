using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Fcz.Navi.Api.Models.Extensions
{
	public class FakeHttpException : Exception
	{
		public HttpStatusCode StatusCode { get; set; }

		public FakeHttpException(HttpStatusCode staus) : this(staus, null) { }

		public FakeHttpException(HttpStatusCode status, string message)  : this(status, message, null) { }
		
		public FakeHttpException(HttpStatusCode status, string message, Exception innerException) : base (message, innerException)
		{
			StatusCode = status;
		}
	}
}
