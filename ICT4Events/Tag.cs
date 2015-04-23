using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    //Laurent de Vries
    class Tag
    {
        //fields
        string tag_name;

        public string Tag_name { get; set; }

        public Tag(string tag_name)
        {
            this.tag_name = tag_name;
        }
    }
}