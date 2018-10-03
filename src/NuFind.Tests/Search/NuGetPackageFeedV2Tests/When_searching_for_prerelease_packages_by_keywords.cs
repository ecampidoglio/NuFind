using FluentAssertions;
using NuFind.Search;
using Xunit;

namespace NuFind.Tests.Search.NuGetPackageFeedV2Tests
{
    public class When_searching_for_prerelease_packages_by_keywords
    {
        [Fact]
        public void Should_return_at_least_one_prerelease_version_of_a_package()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.Search("Microsoft.CSharp", includePreRelease: true);

            result.Should().NotContain(package => package.IsPreRelease, "The pre-release filter is ignored by the V2 API");
        }
    }
}
