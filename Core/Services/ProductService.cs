﻿using AutoMapper;
using Domain.Contracts;
using Domain.Model;
using Services.Abstractions;
using Services.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
        // public async Task<IEnumerable<ProductResultDto>> GetAllProductAsync(int? brandId, int? typeId , string? sort , int pageIndex = 1, int pagesize = 5)

        public async Task<PaginationResponse<ProductResultDto>> GetAllProductAsync(ProductSpecificationsParameters specParams)
        {
            var spec = new ProdutWithBrandsAndTypesSpecifications(specParams);

            //Get All products Throught productrepository
            var Products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(spec);

            var specCount = new ProductWithCountSpecifications (specParams);


           var count = await unitOfWork.GetRepository<Product , int>().CountAsync(specCount);

          //  var count = Products.Count();

            //Mapping IEnumerable <product> To IEnumerable<productResultDto> : Automapeer
           var result = mapper.Map<IEnumerable<ProductResultDto>>(Products);
           return new PaginationResponse<ProductResultDto>(specParams.PageIndex, specParams.PageSize, count ,result);
        }

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var spec = new ProdutWithBrandsAndTypesSpecifications(id);
            var Product = await unitOfWork.GetRepository<Product, int>().GetAsync(spec);
            if (Product is null) return null;

            var result = mapper.Map<ProductResultDto>(Product);
            return result;
        }

        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var result = mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return result;
            
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();

            var result = mapper.Map<IEnumerable<TypeResultDto>>(types);
            return result;
        }

    }
}
