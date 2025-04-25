using Domain.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithCountSpecifications : BaseSpecifications<Product , int>
    {

        public ProductWithCountSpecifications(ProductSpecificationsParameters specParams) : 
            
            base(
                 p =>
                  (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search.ToLower())) &&
                 (!specParams.BrandId.HasValue || p.BrandId == specParams.BrandId) &&
                 (!specParams.TypeId.HasValue || p.TypeId == specParams.TypeId)

                ) 
        { 
        
        
        
        }



    }
}
