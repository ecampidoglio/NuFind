using FluentAssertions;
using NuFind.Search;
using Xunit;

namespace NuFind.Tests.Search.NuGetPackageFeedV2Tests
{
    public class When_searching_for_packages_by_keywords
    {
        [Fact]
        public void Should_return_at_least_one_package()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().NotBeEmpty().And.NotContainNulls();
        }

        [Fact]
        public void Should_return_at_least_one_package_whose_id_contains_the_keyword()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().Contain(package => package.Id.Contains("Microsoft.CSharp"));
        }

        [Fact]
        public void Should_only_return_packages_whose_authors_contain_the_keyword()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft");

            result.Should().OnlyContain(package => package.Authors.Contains("Microsoft"));
        }

        [Fact]
        public void Should_include_the_description_in_the_returned_packages()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().OnlyContain(package => package.Description != null);
        }

        [Fact]
        public void Should_include_the_version_in_the_returned_packages()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().OnlyContain(package => package.Version != null);
        }

        [Fact]
        public void Should_include_the_icon_url_in_the_returned_packages()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().OnlyContain(package => package.IconUrl != null);
        }

        [Fact]
        public void Should_include_the_gallery_url_in_the_returned_packages()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().OnlyContain(package => package.GalleryUrl != null);
        }

        [Fact]
        public void Should_not_return_any_prerelease_versions_of_the_packages()
        {
            var sut = new NuGetPackageFeedV2();

            var result = sut.FindPackages("Microsoft.CSharp");

            result.Should().NotContain(package => package.IsPreRelease);
        }
    }
}
