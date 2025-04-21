using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {

        //Get all product

        Task<IEnumerable<ProductResultDto>> GetAllProductAsync();

        //Get product By Id

        Task<ProductResultDto?> GetProductByIdAsync(int id);

        //Get ALL Brands
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        //Get All Types
        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();

    }
}
