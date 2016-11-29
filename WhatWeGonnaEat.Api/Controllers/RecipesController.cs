using System.Threading.Tasks;
using System.Web.Http;

namespace WhatWeGonnaEat.Api.Controllers
{
    public class RecipesController : BaseController
    {
        public IHttpActionResult Get()
        {
            return Ok("This is a test");
        }
    }
}
