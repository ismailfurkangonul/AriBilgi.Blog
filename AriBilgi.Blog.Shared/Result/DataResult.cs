using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Shared.Result
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }

        public int Status { get; }

        public string Exception { get; }

        public List<string> Message { get; }

        public DataResult(int status, T data, List<string> message, Exception exception)
        {
            Data = data;
            Status = status;
            Message = message;
            Exception = exception.Message;
        }
        public DataResult(int status, T data, List<string> message)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}
