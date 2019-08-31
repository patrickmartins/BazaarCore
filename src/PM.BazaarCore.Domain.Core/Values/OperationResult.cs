using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values.Common;
using System.Collections.Generic;

namespace PM.BazaarCore.Domain.Core.Values
{
    public class OperationResult : Result
    {
        public OperationResult(params Error[] errors) : base(errors) { }
        public OperationResult(List<Error> errors) : base(errors) { }
    }

    public class OperationResult<TEntity> : OperationResult where TEntity : class
    {
        public OperationResult(params Error[] errors) : base(errors) { }
        public OperationResult(List<Error> errors) : base(errors) { }
        public OperationResult(TEntity value)
        {
            Value = value;
        }

        public TEntity Value { get; private set; }

        public void SetValue(TEntity value)
        {
            Value = value;
        }
    }
}