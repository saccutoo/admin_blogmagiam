using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class Response
    {
        public Response(StatusCode code, string message)
        {
            StatusCode = code;
            Message = message;
        }
        public Response(string message)
        {
            Message = message;
        }
        public Response()
        {
        }
        public StatusCode StatusCode { get; set; } = StatusCode.Success;
        public string Message { get; set; } = "Thành công";
        public decimal TotalCount { get; set; } = 0;
        public decimal TotalPage { get; set; } = 0;
        public decimal TotalRecord { get; set; } = 0;
        public Dictionary<string, object> OutData { get; set; } = new Dictionary<string, object>();
    }

    public class ResponseObject<T> : Response
    {
        public ResponseObject()
        {

        }
        public ResponseObject(T data)
        {
            Data = data;
        }
        public ResponseObject(T data, decimal totalCount, decimal totalPage)
        {
            Data = data;
            TotalCount = totalCount;
            TotalPage = totalPage;
        }
        public ResponseObject(T data, decimal totalCount, decimal totalPage, decimal totalRecord)
        {
            Data = data;
            TotalCount = totalCount;
            TotalPage = totalPage;
            TotalRecord = totalRecord;
        }
        public ResponseObject(T data, string message)
        {
            Data = data;
            Message = message;
        }
        public ResponseObject(T data, string message, StatusCode code)
        {
            StatusCode = code;
            Data = data;
            Message = message;
        }
        public ResponseObject(T data, string message, StatusCode code, decimal totalCount, decimal totalPage)
        {
            StatusCode = code;
            Data = data;
            Message = message;
            TotalPage = totalPage;
            TotalCount = totalCount;
        }
        public ResponseObject(T data, string message, StatusCode code, decimal totalCount, decimal totalPage, decimal totalRecord)
        {
            StatusCode = code;
            Data = data;
            Message = message;
            TotalPage = totalPage;
            TotalCount = totalCount;
            TotalRecord = totalRecord;
        }
        public T Data { get; set; }
    }
}
