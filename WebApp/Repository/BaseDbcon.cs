using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class BaseDbcon: IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool _bool)
        {
            if (_bool)
            {
                GC.SuppressFinalize(this);
                GC.Collect();
            }
        }
    }
}