using Amazon.S3;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Estudos.Aws.Bucket
{
    [ExcludeFromCodeCoverage]
    public class ConfigS3
    {
        public AmazonS3Client AmazonS3Client { get; }

        public ConfigS3(IConfiguration configuration)
        {
            AmazonS3Client = GetDynamoClient();
        }

        protected AmazonS3Client GetDynamoClient()
        {
            var (accessKey, secret) = ("", "");

            if (!string.IsNullOrEmpty(accessKey) && !string.IsNullOrEmpty(secret))
                return new AmazonS3Client(accessKey, secret, Amazon.RegionEndpoint.USEast1);

            return new AmazonS3Client();
        }
    }
}
