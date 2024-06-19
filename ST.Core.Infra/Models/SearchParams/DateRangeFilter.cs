﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Core.Infra.Models.SearchParams
{
  public class DateRangeFilter
  {
    public DateRangeFilter(DateTime? from, DateTime? until)
    {
      From = from ?? DateTime.MinValue;
      Until = until ?? DateTime.MaxValue;
    }
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
  }
}
