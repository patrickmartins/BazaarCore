using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Specifications.Ad;
using System;

namespace PM.BazaarCore.Application.Extensions
{
    public static class SpecificationAdQueryBuilder
    {

        public static ISpecificationQuery<Ad> MaxPrice(double maxPrice)
        {
            return new MaxPrice(maxPrice);
        }

        public static ISpecificationQuery<Ad> MinPrice(double minPrice)
        {
            return new MinPrice(minPrice);
        }

        public static ISpecificationQuery<Ad> WithKeywordInTitle(string keyword)
        {
            return new WithKeywordInTitle(keyword);
        }

        public static ISpecificationQuery<Ad> WithCategory(Guid[] idCategories)
        {
            return new WithCategory(idCategories);
        }

        public static ISpecificationQuery<Ad> MaxPrice(this ISpecificationQuery<Ad> specification, double maxPrice)
        {
            return specification.And(MaxPrice(maxPrice));
        }

        public static ISpecificationQuery<Ad> MinPrice(this ISpecificationQuery<Ad> specification, double minPrice)
        {
            return specification.And(MinPrice(minPrice));
        }

        public static ISpecificationQuery<Ad> WithKeywordInTitle(this ISpecificationQuery<Ad> specification, string keyword)
        {
            return specification.And(WithKeywordInTitle(keyword));
        }

        public static ISpecificationQuery<Ad> WithCategory(this ISpecificationQuery<Ad> specification, Guid[] idCategories)
        {
            return specification.And(WithCategory(idCategories));
        }
    }
}
