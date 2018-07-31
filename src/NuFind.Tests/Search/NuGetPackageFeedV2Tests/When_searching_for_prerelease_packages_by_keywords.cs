using FluentAssertions;
using NuFind.Search;
using Xunit;

namespace NuFind.Tests.Search.NuGetPackageFeedV2Tests
{
    public class When_searching_for_prerelease_packages_by_keywords
    {
        [Fact(Skip = "The prerelease filter is ignored by the V2 API")]
        public void Should_return_at_least_one_prerelease_version_of_a_package()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp", includePreRelease: true);

            result.Should().Contain(package => package.IsPreRelease);
        }
    }
}
