using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Test
{
    public interface IDynamicObject
    {
        void Create(Object param);
        Object GetInnerObject();
        bool IsValidate();
        void Release();
    }
}
