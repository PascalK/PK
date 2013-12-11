using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PK.Common
{
    public interface IEnumerated<TEnumerated, TValue>
        where TEnumerated : class, IEnumerated<TEnumerated, TValue>
    {
        TValue Value { get; }
    }
}
