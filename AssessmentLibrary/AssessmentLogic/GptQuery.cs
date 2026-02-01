using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentLogic
{
    /// <summary>
    /// Class GptQuery
    /// Model of a query to be executed by GPT
    /// </summary>
    public class GptQuery
    {
        public int idCase {  get; set; }
        public int idNormative { get; set; }
        public int idLaw { get; set; }
        public int type { get; set; }

        public string apiKey { get; set; }
    }
}
