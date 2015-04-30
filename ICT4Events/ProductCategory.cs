using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    class ProductCategory
    {
        //fields 

        private int id_productCat;
        private string productnaamCat;

        public string ProductnaamCat { get { return productnaamCat; } set { productnaamCat = value; } }
        public int Id_productCat { get { return id_productCat; } set { id_productCat = value; } }

        public ProductCategory(int id_productCat, string productnaamCat)
        {
            this.id_productCat = id_productCat;
            this.productnaamCat = productnaamCat;
        }

        
        public override string ToString()
        {
            return productnaamCat;
        }
    }
}
