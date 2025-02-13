using System;

namespace ElPalacio.Domain.Entities
{
    public class Base
    {
        public virtual DateTime? CreatedAt { get; set; }

        public virtual DateTime? UpdatedAt { get; set; }
    }
}