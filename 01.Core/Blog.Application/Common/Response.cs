using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Common
{
    public class ResponseDto<T>
    {
        public ResponseDto(bool IsSuccess, string Message, T Data)
        {
            this.IsSuccess = IsSuccess;
            this.Message = Message;
            this.Data = Data;
        }

        public T Data { get; private set; }
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }

    }


    public class ResponseDto
    {
        public ResponseDto(bool IsSuccess, string Message)
        {
            this.IsSuccess = IsSuccess;
            this.Message = Message;
        }
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }

    }
}
