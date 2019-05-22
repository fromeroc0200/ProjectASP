using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Data.Model
{
    public class ProcessResult<T> : IProcessResult<T> where T : class
    {
        public T Content { get; set; }
        public bool HasError { get; set; }
        public string ErrorDescription { get; set; }
        
    }

    public class ProcessResult : ProcessResult<object> { }
}