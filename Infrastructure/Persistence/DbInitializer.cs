using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;

        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {

            try
            {
                //Create Data base If  it doesnot Exists && Apply To Any Pending Migrations
                if (_context.Database.GetPendingMigrations().Any())
                {
                    await _context.Database.MigrateAsync();
                }

                // Data Sending

                //Seeding productTypes from JsonFiles

                if (!_context.ProductTypes.Any())
                {

                    //1. Read All DATA From types Json File as string 

                    var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");

                    //2. TransForm String To C# Objects [list<ProductTypes>]
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    //3.Add List <ProductTypes> To Database
                    if (types is not null && types.Any())
                    {
                        await _context.ProductTypes.AddRangeAsync(types);
                        await _context.SaveChangesAsync();

                    }

                }

                //Seeding productBrands from JsonFiles


                if (!_context.ProductBrands.Any())
                {

                    //1. Read All DATA From types Json File as string 

                    var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\brands.json");

                    //2. TransForm String To C# Objects [list<ProductBrand>]
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    //3.Add List <ProductBrands> To Database
                    if (brands is not null && brands.Any())
                    {
                        await _context.ProductBrands.AddRangeAsync(brands);
                        await _context.SaveChangesAsync();

                    }

                }


                //Seeding products from JsonFiles

                if (!_context.Products.Any())
                {

                    //1. Read All DATA From products Json File as string 

                    var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\Products.json");

                    //2. TransForm String To C# Objects [list<Products>]
                    var Products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    //3.Add List <Products> To Database
                    if (Products is not null && Products.Any())
                    {
                        await _context.Products.AddRangeAsync(Products);
                        await _context.SaveChangesAsync();

                    }

                }
            }
            catch (Exception)
            { 
                throw;
            }

        }

    } 
}

  


