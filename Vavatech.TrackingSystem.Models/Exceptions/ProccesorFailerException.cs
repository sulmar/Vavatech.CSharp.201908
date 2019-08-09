using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models.Exceptions
{
    public class OperationException : ApplicationException
    {
        public Operation Operation { get; set; }
        public OperationException(Operation operation, string message) 
            : base(message)
        {
            this.Operation = operation;
        }
    }
}
