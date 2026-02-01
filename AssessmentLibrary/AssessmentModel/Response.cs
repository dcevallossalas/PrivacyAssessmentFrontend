using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    /// <summary>
    /// Class Response
    /// Model of a Response from the backend component
    /// </summary>
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }

        public int id { get; set; }
        public string text { get; set; }
    }
}
