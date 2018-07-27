using System;
using FluentAssertions;
using NuFind.Extensions;
using Xunit;

namespace NuFind.Tests.SearchOptionsTests
{
    public class When_parsing_from_invalid_command_line_arguments
    {
        [Theory]
        [InlineData("-xyz")]
        [InlineData("--unknown")]
        public void Should_throw_an_argument_exception(
            string option)
        {
            Action act = () => new[] {option}.ParseSearchOptions();

            act.Should().Throw<ArgumentException>();
        }
    }
}
