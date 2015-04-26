using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    //Laurent de Vries
    public class Tag : ICategorieTag
    {
        //fields

        public string Name { get; set; }

        public Tag(string tag_name)
        {
            Name = tag_name;
        }


    }
}