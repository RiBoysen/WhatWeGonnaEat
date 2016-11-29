using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WhatWeGonnaEat.Common.Exceptions;

namespace WhatWeGonnaEat.Api.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// Tries the specified operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        protected async Task<IHttpActionResult> Try<T>(Func<Task<T>> function)
        {
            return await this.TryRaw(async () =>
            {
                var content = await function();
                var response = this.Ok(content);
                //AddPaginationHeader(content as IPaginatedEnumerable);
                return response;
            });
        }

        /// <summary>
        /// Tries the specified operation.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        protected async Task<IHttpActionResult> Try(Func<Task> function)
        {
            return await this.TryRaw(async () =>
            {
                await function();
                return this.StatusCode(HttpStatusCode.NoContent);
            });
        }

        /// <summary>
        /// Tries the execute a create function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        protected async Task<IHttpActionResult> TryCreate<T>(Func<Task<T>> function)
        {
            return await this.TryRaw(async () =>
            {
                var content = await function();
                return this.Content(HttpStatusCode.Created, content);
            });
        }

        /// <summary>
        /// Tries the to excute the function raw.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>
        protected async Task<IHttpActionResult> TryRaw(Func<Task<IHttpActionResult>> function)
        {
            try
            {
                return await function();
            }
            catch (BaseApiException ex)
            {
                return this.Content((HttpStatusCode)ex.StatusCode, new
                {
                    ex.Message,
                    ex.StatusCode
                });
            }
            catch (Exception e)
            {
                return this.Content(
                    HttpStatusCode.InternalServerError,
                    new
                    {
                        Message = "An unknown error occurred on the server.",
                        ExceptionMessage = e.Message,
                        ExceptionInnerMessage = e.InnerException?.Message
                    });
            }
        }

        /// <summary>
        /// Gets the authorized member.
        /// </summary>
        /// <param name="authRepository"></param>
        /// <returns></returns>
        //protected async Task<PersonAuthDto> GetAuthorizedMember(IAuthenticationRepository authRepository)
        //{
        //    var token = this.Request.Headers.Authorization.Parameter;
        //    var personAuthDto = await authRepository.VerifyToken(token);
        //    return personAuthDto;
        //}
    }
}
