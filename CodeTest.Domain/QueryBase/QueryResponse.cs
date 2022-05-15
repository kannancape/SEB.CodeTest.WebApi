using System;
using CodeTest.Domain.ExceptionHandling;

namespace CodeTest.Domain.QueryBase
{
    public class QueryResponse
    {
        public object Result { get; set; }

        public ExceptionResponse ErrorDetails { get; set; }
    }
}

