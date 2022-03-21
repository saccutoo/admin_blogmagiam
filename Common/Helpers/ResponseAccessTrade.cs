﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ResponseAccessTrade<T>
    {

        public ResponseAccessTrade()
        {
        }

        public ResponseAccessTrade(List<T> datas, StatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Data = datas;
        }

        public List<T> Data { get; set; }
        public StatusCode StatusCode { get; set; } = StatusCode.Success;
        public string Message { get; set; } = "Thành công";
        public long Count { get; set; }
    }
}
