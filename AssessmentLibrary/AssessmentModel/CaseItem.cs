using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentModel
{
    public class CaseItem
    {
        public int id { get; set; }

        public int id_normative { get; set; }

        public int id_law { get; set; }

        public string name { get; set; }

        public string alias { get; set; }

        public string alias_normative { get; set; }

        public string alias_law { get; set; }

        public string description { get; set; }

        public int version { get; set; }

        public int version_cs { get; set; }

        public int version_ncs { get; set; }

        public List<int> subcases { get; set; }

        public override string ToString()
        {
            if (id > 0)
            {
                return name + " (" + alias + ") " + "(" + alias_normative + "-" + alias_law + ")";
            }
            else
            {
                if (id_normative > 0)
                {
                    return name + " (" + alias + ") (Normative)";
                }
                else
                {
                    return name + " (" + alias + ") (Compund case)";
                }
            }
        }
    }
}
