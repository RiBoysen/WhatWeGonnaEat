using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace WhatWeGonnaEat.DataAcces
{
    public class WhatWeGonnaEatContext: DbContext
    {
        public WhatWeGonnaEatContext() : base()
        {
            Database.Log = s => Debug.WriteLine(s);
        }
    }
}
