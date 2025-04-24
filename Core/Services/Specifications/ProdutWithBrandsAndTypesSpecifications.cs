using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProdutWithBrandsAndTypesSpecifications : BaseSpecifications<Product, int>
    {
        public ProdutWithBrandsAndTypesSpecifications(int id): base(p => p.Id == id)
        {
            ApplyIncludes();
        }
        public ProdutWithBrandsAndTypesSpecifications(): base(null)
        {
            ApplyIncludes();
        }
        private void ApplyIncludes()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }




    }
}
