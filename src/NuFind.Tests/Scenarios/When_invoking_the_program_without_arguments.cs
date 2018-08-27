using FluentAssertions;
using Xunit;

namespace NuFind.Tests.Scenarios
{
    public class When_invoking_the_program_without_arguments
    {
        [Fact]
        public void Should_return_an_exit_status_to_indicate_usage_error()
        {
            var result = Program.Main(new string[0]);

            result.Should().Be(2);
        }
    }
}
