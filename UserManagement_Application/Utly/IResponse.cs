﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_Application.Utly
{
    public interface IResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public bool IsSuccess { get; set; }


    }

    public interface IResponse<out T>:IResponse
    {
        T Data { get; }
    }

}
