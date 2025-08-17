using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    public class Documents
    {
        public int code {  get; set; }
        public string message { get; set; }
        public List<Document> documents {  get; set; }
    }

    public class Document
    {
        public int code { get; set; }
        public string message { get; set; }

        public int id {  get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string description { get; set; }

        public int id_extra1 { get; set; }

        public int id_extra2 { get; set; }

        public string gpt { get; set; }

        public string gpt_cs { get; set; }

        public string gpt_ncs { get; set; }

        public int docType { get; set; }

        public List<Principle> principles { get; set; }
    }

    public class Principle
    {
        public int principle { get; set; }

        public int category_from { get; set; }

        public int category_to { get; set; }

    }
}
