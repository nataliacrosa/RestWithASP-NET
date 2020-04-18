﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);
    }
}
