using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Domain.Common.Errors
{
    public static class Errors
    {
        public static class Deal
        {
            public static Error InvalidName => Error.Validation(
            code: "Deal.InvalidName",
            description: $"Name must be at least 15 " +
                $" characters long and at most 100 characters long.");

            public static Error InvalidDescription => Error.Validation(
            code: "Deal.InvalidDescription",
                description: $"Deal description must be at least50 " +
                    $" characters long and at most 200 characters long.");

            public static Error NotFound => Error.NotFound(
                code: "Deal.NotFound",
                description: "Deal not found");

            public static Error AlreadyExists => Error.Conflict(
             code: "Deal.AlreadyExists",
             description: "Deal Already exists");
        }
    }
}
