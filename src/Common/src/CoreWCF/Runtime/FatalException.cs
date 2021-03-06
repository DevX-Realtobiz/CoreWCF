﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.Contracts;

namespace CoreWCF.Runtime
{
    // TODO: This is in internals so probably needs to go away
    internal class FatalException : Exception //SystemException
    {
        public FatalException()
        {
        }
        public FatalException(string message) : base(message)
        {
        }

        public FatalException(string message, Exception innerException) : base(message, innerException)
        {
            // This can't throw something like ArgumentException because that would be worse than
            // throwing the fatal exception that was requested.
            Contract.Assert(innerException == null || !Fx.IsFatal(innerException), "FatalException can't be used to wrap fatal exceptions.");
        }

        //protected FatalException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}