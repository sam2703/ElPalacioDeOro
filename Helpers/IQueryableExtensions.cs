﻿using ElPalacio.Domain.Filters;
using ElPalacio.Domain.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ElPalacio.Domain.Helpers
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Gets the paged data.
        /// </summary>
        /// <returns>The paged.</returns>
        /// <param name="query">Query.</param>
        /// <param name="queryParameter">Query parameter.</param>
        /// <param name="filter">Filter.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, QueryParameter queryParameter, IFilter filter) where T : class
        {
            int page = queryParameter.pageNumber;
            int pageSize = queryParameter.pageSize;
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize
            };

            var skip = (page - 1) * pageSize;

            if (!string.IsNullOrEmpty(queryParameter.Sort))
            {
                string sort = queryParameter.Sort.StartsWith("-") ? queryParameter.Sort.Substring(1) : queryParameter.Sort;
                var type = typeof(T);
                var propertyInfo = type.GetProperty(sort);
                if (propertyInfo != null)
                {
                    if (queryParameter.Sort.StartsWith("-"))
                        query = query.OrderByDescending(x => propertyInfo.GetValue(x, null));
                    else
                        query = query.OrderBy(x => propertyInfo.GetValue(x, null));
                }
            }

            query = query.ApplyFilters<T>(filter);
            query = query.ApplyFields<T>(queryParameter.Fields);

            if (queryParameter.AllowPaging)
            {
                result.Results = query.Skip(skip).Take(pageSize).ToList();
                var nextPage = page + 1;
                var tempSkip = (nextPage - 1) * pageSize;
                result.NextPage = (query.Skip(tempSkip).Take(pageSize).ToList().Count > 0) ? true : false;
                result.PreviousPage = (skip == 0 && result.Results.Count <= pageSize) ? false : true;
                // get total page rounding to smallest integer. For example: (0.1) = 1, (2.6) = 3, etc.
                result.TotalPages = (int)Math.Ceiling(query.Count() / (decimal)pageSize);
            }
            else
            {
                result.Results = query.ToList();
            }

            return result;
        }

        /// <summary>
        /// Applies the fields filter.
        /// </summary>
        /// <returns>The query with fields filter applied.</returns>
        /// <param name="query">Query.</param>
        /// <param name="fields">Fields.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IQueryable<T> ApplyFields<T>(this IQueryable<T> query, string fields = "") where T : class
        {
            if (fields != "")
            {
                var propsNames = typeof(T).GetProperties().Select(p => p.Name);
                var queryFields = fields.Split(",").ToList();

                var allowedFields = queryFields.Where(propsNames.Contains).ToArray();
                var allowefFieldsString = string.Join(",", allowedFields);

                query = query.Select(FieldsFilter.DynamicSelectGenerator<T>(allowefFieldsString)).AsQueryable();
            }

            return query;
        }

        /// <summary>
        /// Applies the filters filter.
        /// </summary>
        /// <returns>The query with filters applied.</returns>
        /// <param name="query">Query.</param>
        /// <param name="filter">Filter.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IFilter filter) where T : class
        {
            var reflectionFilterData = filter.GetType();
            var properties = reflectionFilterData.GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(filter);
                if (propValue == null)
                {
                    continue;
                }

                var methodName = "FilterBy" + prop.Name;

                MethodInfo methodInfo = reflectionFilterData.GetMethod(methodName);
                if (methodInfo != null)
                {
                    object[] parameters = new object[] { query };
                    query = (System.Linq.IQueryable<T>)methodInfo.Invoke(filter, parameters);
                }
                else
                {
                    //var defaultFilter = false; string.Format("{0} = \"{1}\"", prop.Name, propValue);
                    //query = query.Where(defaultFilter);

                    var parameter = Expression.Parameter(typeof(T), "entity");
                    var property = Expression.Property(parameter, prop.Name);
                    var constant = Expression.Constant(propValue);
                    var equal = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);

                    query = query.Where(lambda);
                }
            }

            return query;
        }
    }
}
