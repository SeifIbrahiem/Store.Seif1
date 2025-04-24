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
        public ProdutWithBrandsAndTypesSpecifications(int? brandId, int? typeId) 
            : base(
                  p =>
                  (!brandId.HasValue || p.BrandId == brandId)
                  &&
                  (!typeId.HasValue || p.TypeId == typeId)   
                  )
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
