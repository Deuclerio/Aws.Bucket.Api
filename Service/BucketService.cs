using Amazon.S3;
using Amazon.S3.Model;
using Estudos.Aws.Bucket.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Estudos.Aws.Bucket.Service
{
    public class BucketService : IBucketService
    {
        IAmazonS3 S3Client { get; set; }

        public const string NameBucket = "";

        public BucketService(IAmazonS3 s3Client)
        {
            S3Client = s3Client;
        }

        public bool Delete(string key)
        {
            try
            {
                var result = S3Client.DeleteObjectAsync(NameBucket, key);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<object>> GetBucket()
        {
            var result = await S3Client.ListObjectsAsync(NameBucket);

            var resultado = result.S3Objects.Select(x => new { Name = x.Key, Type = x.Key.Split(".")[1].ToString(), Modificao = x.LastModified }).ToList();

            return resultado;

        }

        public async Task<bool> Insert(IFormFile formFile)
        {
            try
            {
                var key = formFile.FileName;

                using (var stream = formFile.OpenReadStream())
                {

                    PutObjectRequest putRequest = new PutObjectRequest
                    {
                        BucketName = NameBucket,
                        Key = key,
                        ContentType = formFile.ContentType,
                        InputStream = stream,
                        AutoCloseStream = true
                    };

                    var result = await S3Client.PutObjectAsync(putRequest);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
