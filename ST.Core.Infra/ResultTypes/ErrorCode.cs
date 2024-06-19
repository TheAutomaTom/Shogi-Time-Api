﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Core.Infra.ResultTypes
{
	public enum ErrorCode
	{
		Unknown,
		Exception,

		Validation,

		ExpectedError,
		DoesNotExist,
		Connectivity,
		DistributedCacheError,

	}


}
