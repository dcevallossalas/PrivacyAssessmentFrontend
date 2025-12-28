using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }

        public int id { get; set; }
        public string text { get; set; }
    }
}
