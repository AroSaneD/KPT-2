using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.DataTransferObjects;
using API.Exceptions;
using API.Repositories;

namespace API.Controllers
{
    public class CommitController : ApiController
    {
		[HttpGet]
		public HttpResponseMessage Get()
		{
			try
			{
				return Request.CreateResponse(HttpStatusCode.OK, CommitRepository.ReadAll());

			}
			catch (Exception exc)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpGet]
		public HttpResponseMessage Get(int id)
		{
			try
			{
				var res = CommitRepository.Read(id);
				return Request.CreateResponse(HttpStatusCode.OK, res);
			}
			catch (ElementNotFoundException e)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpPost]
		public HttpResponseMessage Post(CommitDto dto)
		{
			try
			{
				if (dto != null)
				{
					CommitRepository.Create(dto);
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpPut]
		public HttpResponseMessage Put(CommitDto dto)
		{
			try
			{
				if (dto != null)
				{
					CommitRepository.Update(dto);
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			catch (ElementNotFoundException e)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			try
			{
				CommitRepository.Delete(id);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (ElementNotFoundException e)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}
    }
}
