using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_AWS_S3
{
    public class CreateBucketResponse
    {
        public string RequestId { get; set; }
        public string BucketName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
