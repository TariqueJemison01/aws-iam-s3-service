using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace Lab1_AWS_S3
{
    public class BucketOps
    {
        public async Task<CreateBucketResponse> CreateBucket(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true
            };

            var response = await Helper.s3Client.PutBucketAsync(putBucketRequest);

            return new CreateBucketResponse
            {
                BucketName = bucketName,
                RequestId = response.ResponseMetadata.RequestId
            };
        }

        public async Task<List<CreateBucketResponse>> GetBucketList(){
            ListBucketsResponse response = await Helper.s3Client.ListBucketsAsync();
            List<CreateBucketResponse> bucketList = new List<CreateBucketResponse>();

            foreach (S3Bucket bucket in response.Buckets)
            {
                bucketList.Add(new CreateBucketResponse
                {
                    BucketName = bucket.BucketName,
                    CreatedDate = bucket.CreationDate
                });
            }

            return bucketList;
        }

        public async Task<List<S3Object>> GetBucketObjects(string bucketName)
        {
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = bucketName
            };

            ListObjectsV2Response response = await Helper.s3Client.ListObjectsV2Async(request);

            return response.S3Objects;
        }

    }
}
