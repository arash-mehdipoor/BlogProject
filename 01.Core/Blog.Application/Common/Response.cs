using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common
{
    public class ResponseDto<T>
    {
        public ResponseDto(ApplicationServiceStatus status, string Message, T Data)
        {
            this.Status = status;
            this.Message = Message;
            this.Data = Data;
        }

        public T Data { get; private set; }
        public string Message { get; private set; }
         public ApplicationServiceStatus Status { get; set; }

    }


    public class ResponseDto
    {
        public ResponseDto(ApplicationServiceStatus status, string Message)
        {
            this.Status = status;
            this.Message = Message;
        }
        public string Message { get; private set; }
         public ApplicationServiceStatus Status { get; set; }

    }
}
