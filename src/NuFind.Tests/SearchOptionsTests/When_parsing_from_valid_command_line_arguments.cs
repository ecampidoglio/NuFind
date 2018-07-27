using FluentAssertions;
using Xunit;

namespace NuFind.Tests.SearchOptionsTests
{
    public class When_parsing_from_valid_command_line_arguments
    {
        [Fact]
        public void Should_parse_a_single_word_as_the_search_term_argument()
        {
            var result = SearchOptions.Parse(new[] {"word"});

            result.SearchTerm.Should().Be("word");
        }

        [Fact]
        public void Should_parse_multiple_words_as_the_search_term_argument()
        {
            var result = SearchOptions.Parse(new[] {"two words"});

            result.SearchTerm.Should().Be("two words");
        }

        [Theory]
        [InlineData("-p")]
        [InlineData("--prerelease")]
        public void Should_parse_the_prerelease_option(string option)
        {
            var result = SearchOptions.Parse(new[] {"word", option});

            result.IncludePreRelease.Should().BeTrue();
        }
    }
}
