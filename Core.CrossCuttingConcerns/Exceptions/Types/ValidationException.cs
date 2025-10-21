﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException()
        : base()
    {
        Errors = [];
    }

    public ValidationException(string message)
        : base(message)
    {
        Errors = [];
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessages(errors))
    {
        
    }

    private static string BuildErrorMessages(IEnumerable<ValidationExceptionModel> errors)
    {
        var arr = errors.Select(x =>
            $"{Environment.NewLine} -- {x.Property} : {string.Join(Environment.NewLine, values: x.Errors)}"
        );
        return $"Validation Failed: {string.Join(string.Empty, arr)}";
    }

}

public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string> Errors { get; set; }

}