﻿using System;

namespace ElPalacio.Domain.Exceptions
{
    public class CodeException : Exception
    {
        public string Code
        {
            get;
            set;
        }

        protected CodeException() : base() { }
        protected CodeException(string message) : base(message) { }
        protected CodeException(string message, string code) : base(message)
        {
            Code = code;
        }
        protected CodeException(string message, System.Exception inner) : base(message, inner) { }
    }
}
