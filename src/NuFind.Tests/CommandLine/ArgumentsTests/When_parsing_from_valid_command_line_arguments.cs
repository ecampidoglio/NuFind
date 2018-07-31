using FluentAssertions;
using NuFind.CommandLine;
using Xunit;

namespace NuFind.Tests.CommandLine.ArgumentsTests
{
    public class When_parsing_from_valid_command_line_arguments
    {
        [Fact]
        public void Should_parse_a_single_word_as_the_search_term_argument()
        {
            var result = Arguments.Parse(new[] {"word"});

            result.SearchTerm.Should().Be("word");
        }

        [Fact]
        public void Should_parse_multiple_words_as_the_search_term_argument()
        {
            var result = Arguments.Parse(new[] {"two words"});

            result.SearchTerm.Should().Be("two words");
        }

        [Theory]
        [InlineData("-p")]
        [InlineData("--prerelease")]
        public void Should_parse_the_prerelease_option(string option)
        {
            var result = Arguments.Parse(new[] {"word", option});

            result.IncludePreRelease.Should().BeTrue();
        }
    }
}
