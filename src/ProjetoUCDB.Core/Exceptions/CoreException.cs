using System;
using System.Collections.Generic;

namespace ProjetoUCDB.Core.Exceptions
{
    public class CoreException : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public CoreException()
        {
        }
        public CoreException(string message) : base(message)
        {
        }
        public CoreException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }
        public CoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
