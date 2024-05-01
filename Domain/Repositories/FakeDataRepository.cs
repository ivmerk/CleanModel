using System;
using System.Collections.Generic;
using CleanModel.Domain.Dto;
using Bogus;

namespace CleanModel.Domain.Repositories; 


    public class FakeDataRepository(AppDbContext dbContext)
{
        private readonly AppDbContext _dbContext = dbContext;
      
        public List<ProductDto> GenerateFakeProducts(int count)
        {
            var faker = new Faker<ProductDto>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Category, GenerateFakeCategories)
                .RuleFor(p => p.DimensionsAndWeights, f => new List<int> { f.Random.Int(1, 100) })
                .RuleFor(p => p.Article, f => f.Random.AlphaNumeric(10))
                .RuleFor(p => p.Marking, f => f.Random.AlphaNumeric(5))
                .RuleFor(p => p.IsAdult, f => f.Random.Bool())
                .RuleFor(p => p.IsHandmade, f => f.Random.Bool())
                .RuleFor(p => p.IsAvailable, f => f.Random.Bool())
                .RuleFor(p => p.Materials, f => GenerateFakeMaterials(f))
                .RuleFor(p => p.PhotoAndVideos, f => GenerateFakePhotoAndVideos(f))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Price, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.IsDiscount, f => f.Random.Bool())
                .RuleFor(p => p.Discount, f => f.Random.Int(1, 50));

          var result = faker.Generate(count);
          var resultList = result.ToList();
            return result;

        }

        public void SeedDatabase(int count)
        {
            _dbContext.Products.AddRange(GenerateFakeProducts(count));
            _dbContext.SaveChanges();
        }

        private CategoryDto GenerateFakeCategories(Faker faker)
        {
            var categoryFaker = new Faker<CategoryDto>()
                .RuleFor(c => c.Name, (f, c)  => f.Commerce.Department());

            return categoryFaker.Generate(faker.Random.Int(1, 5)).ToList()[0];
        }
        private List<MaterialDto> GenerateFakeMaterials(Faker faker)
        {
            var materialFaker = new Faker<MaterialDto>()
                .RuleFor(m => m.Name, f => f.Commerce.ProductMaterial());

            return materialFaker.Generate(faker.Random.Int(1, 5));
        }

        private List<PhotoAndVideoDto> GenerateFakePhotoAndVideos(Faker faker)
        {
            var photoAndVideoFaker = new Faker<PhotoAndVideoDto>()
                .RuleFor(pv => pv.Url, f => f.Internet.Url())
                .RuleFor(pv => pv.MediaType, f => f.PickRandom<MediaType>());

            return photoAndVideoFaker.Generate(faker.Random.Int(1, 5));
        }
    }



