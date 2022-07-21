using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estudos.Aws.Bucket.Interface
{
    public interface IBucketService
    {
        Task<IEnumerable<object>> GetBucket();

        bool Delete(string key);

        Task<bool> Insert(IFormFile formFile);
    }
}
