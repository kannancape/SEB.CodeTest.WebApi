using System.Collections.Generic;
using System.Text;

namespace CodeTest.Domain.ExceptionHandling
{
    public class ExceptionResponse
    {
        public ExceptionResponse()
        {
            Data = new Dictionary<string, object>();
        }
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine();
            builder.AppendLine(Message);
            foreach(var item in Data)
            {
                builder.AppendFormat("{0}: {1}", item.Key, item.Value);
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
