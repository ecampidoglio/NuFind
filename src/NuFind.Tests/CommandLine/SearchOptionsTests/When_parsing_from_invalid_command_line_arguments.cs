using System;
using FluentAssertions;
using NuFind.CommandLine;
using Xunit;

namespace NuFind.Tests.CommandLine.SearchOptionsTests
{
    public class When_parsing_from_invalid_command_line_arguments
    {
        [Theory]
        [InlineData("-xyz")]
        [InlineData("--unknown")]
        public void Should_throw_an_argument_exception(
            string option)
        {
            Action act = () => SearchOptions.Parse(new[] {option});

            act.Should().Throw<ArgumentException>();
        }
    }
}
