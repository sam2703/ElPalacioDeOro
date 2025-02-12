﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace ElPalacio.Domain.Helpers
{
    public static class FieldsFilter
    {
        public static Func<T, T> DynamicSelectGenerator<T>(string Fields = "")
        {
            string[] EntityFields;
            if (Fields == "")
                EntityFields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
            else
                EntityFields = Fields.Split(',');

            var xParameter = Expression.Parameter(typeof(T), "o");
            var xNew = Expression.New(typeof(T));
            var bindings = EntityFields.Select(o => o.Trim())
                .Select(o =>
                {
                    var mi = typeof(T).GetProperty(o);
                    var xOriginal = Expression.Property(xParameter, mi);

                    return Expression.Bind(mi, xOriginal);
                }
            );

            var xInit = Expression.MemberInit(xNew, bindings);
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            return lambda.Compile();
        }
    }
}
