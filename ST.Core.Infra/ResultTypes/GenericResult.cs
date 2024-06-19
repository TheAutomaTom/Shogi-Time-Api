﻿using FluentValidation.Results;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Infra.ResultTypes
{
	public class Result<T> : Result
	{
		public T? Data { get; set; } = default;

		// TODO: Think about how a non-generic Result is missing a detail about
		//        how a call may have been successful but the request was invalid.
		//      It seems like every request is at least Result<bool>,
		//        but then the data delivered may be more complicated like GetCrusRequest, which has pagination info.

		public string DataType { get; set; }

		public Result() { }

		public Result(T data)
		{
			Data = data;

			DataType = data != null
				? data!.GetType().Name
				: string.Empty;
		}

		public Result(Exception ex) : base(ex)
		{
			Data = default;
		}

		public Result(IEnumerable<ValidationFailure> validationErrors) : base(validationErrors)
		{
			Data = default;
		}

		public Result(IEnumerable<ExpectedError> errors) : base(errors)
		{
			Data = default;
		}

		public Result(IEnumerable<HandledError> errors) : base(errors)
		{
			Data = default;
		}

		public Result(ExpectedError error) : base(error)
		{
			Data = default;
		}

		public static Result<T> Ok(T data) => new Result<T>(data);
		public static Result<T> Fail() => new(new ExpectedError(ErrorCode.Unknown));
		public static new Result<T> Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
		public static new Result<T> Fail(IEnumerable<ExpectedError> errors) => new(errors);
		public static new Result<T> Fail(IEnumerable<HandledError> errors) => new(errors);
		public static new Result<T> Fail(ExpectedError error) => new(error);
		public static new Result<T> Fail(Exception ex) => new(ex);


	}
}
