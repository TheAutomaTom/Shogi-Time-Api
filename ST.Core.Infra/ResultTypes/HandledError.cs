using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Infra.ResultTypes
{
	public class HandledError
	{
		public ErrorCode Type { get; set; }
		public object Value { get; set; }

		public HandledError(Exception ex)
		{
			Type = ErrorCode.Exception;
			Value = ex;
		}
		public HandledError(ValidationFailure vf)
		{
			Type = ErrorCode.Validation;
			Value = vf;
		}
		public HandledError(ExpectedError ee)
		{
			Type = ErrorCode.ExpectedError;
			Value = ee;
		}

	}
}
