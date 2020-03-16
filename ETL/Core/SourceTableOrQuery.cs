﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Core
{
    abstract class SourceTableOrQuery
    {
        abstract public List<string> GetColumnsNames();
    }
}