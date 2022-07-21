using Estudos.Aws.Bucket.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Aws.Bucket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : Controller
    {

        private readonly IBucketService _iBucketService;

        public TesteController(IBucketService iBucketService)
        {
            _iBucketService = iBucketService;
        }


        [HttpGet("/[controller]/[action]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _iBucketService.GetBucket());
        }

        [HttpPost("/[controller]/[action]")]
        public async Task<IActionResult> Post(IFormFile formFile)
        {
            return Ok(await _iBucketService.Insert(formFile));
        }

        [HttpDelete("/[controller]/[action]/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            return Ok(_iBucketService.Delete(key));
        }
    }
}
