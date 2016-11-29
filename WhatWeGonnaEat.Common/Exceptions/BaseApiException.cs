using System;

namespace WhatWeGonnaEat.Common.Exceptions
{
    public abstract class BaseApiException : Exception
    {
        protected BaseApiException()
        {

        }

        protected BaseApiException(string errorMessage) : base(errorMessage)
        {

        }

        public abstract int StatusCode { get; }
    }
}
