using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    /// <summary>
    /// Class Cases
    /// Model of a list of cases
    /// </summary>
    public class Cases
    {
        public int code {  get; set; }
        public string message { get; set; }
        public List<CaseItem> cases {  get; set; }
    }
}
