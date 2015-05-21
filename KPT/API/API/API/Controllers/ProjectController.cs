using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.DataTransferObjects;
using API.Exceptions;
using API.Repositories;

namespace API.Controllers
{
    public class ProjectController : ApiController
    {
		[HttpGet]
		public HttpResponseMessage Get()
		{
			try
			{
				return Request.CreateResponse(HttpStatusCode.OK, ProjectRepository.ReadAll());

			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpGet]
		public HttpResponseMessage Get(int id)
		{
			try
			{
				var res = ProjectRepository.Read(id);
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
		public HttpResponseMessage Post(ProjectDto dto)
		{
			try
			{
				if (dto != null)
				{
					ProjectRepository.Create(dto);
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			catch(DbEntityValidationException e)
			{
				var err = e.EntityValidationErrors.SelectMany(dbEntityValidationResult => dbEntityValidationResult.ValidationErrors).Aggregate("", (current, dbValidationError) => current + (" " + dbValidationError.ErrorMessage));
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Validation failed. Errors:" + err);
			}
			catch (Exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}

		[HttpPut]
		public HttpResponseMessage Put(ProjectDto dto)
		{
			try
			{
				if (dto != null)
				{
					ProjectRepository.Update(dto);
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
				ProjectRepository.Delete(id);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (ElementNotFoundException e)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Generic error happened.");
			}
		}
    }
}
