using System;
using FluentAssertions;
using Xunit;

namespace NuFind.Tests.Scenarios
{
    public class When_invoking_the_program_with_a_search_term
    {
        [Fact]
        public void Should_return_an_exit_status_to_indicate_success()
        {
            // Redirects stdout to /dev/null to hide the results
            // since they're not relevant to the scenario
            Console.SetOut(new NullWriter());

            var result = Program.Main(new[] { "example" });

            result.Should().Be(0);
        }
    }
}
