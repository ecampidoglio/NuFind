using AutoFixture.Xunit2;
using FluentAssertions;
using NuFind.Output;
using NuFind.Search;
using Xunit;

namespace NuFind.Tests.Output.AlfredJsonFormatTests
{
    public class When_formatting_package_metadata_for_alfred
    {
        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_id_as_title(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"title\":\"{package.Id}\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_description_as_subtitle(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"subtitle\":\"{package.Description}\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_msbuild_package_reference_as_argument(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result
                .Should()
                .Contain($"\"arg\":\"<PackageReference Include=\\\"{package.Id}\\\" Version=\\\"{package.Version}\\\" />\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_msbuild_package_reference_as_the_text_to_copy(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result
                .Should()
                .Contain($"\"copy\":\"<PackageReference Include=\\\"{package.Id}\\\" Version=\\\"{package.Version}\\\" />\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_id_for_autocomplete(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"autocomplete\":\"{package.Id}\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_gallery_url_for_quicklook(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"quicklookurl\":\"{package.GalleryUrl}\"");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_gallery_url_as_command_argument(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"cmd\":{{\"valid\":true,\"arg\":\"{package.GalleryUrl}\",\"subtitle\":\"Go to {package.GalleryUrl}\"}}");
        }

        [Theory, InlineAutoData]
        public void Should_return_a_string_containing_the_package_version_and_authors_and_download_count_as_option_argument(
            PackageMetadata package,
            AlfredJsonFormat sut)
        {
            var result = sut.Render(new[] { package });

            result.Should().Contain($"\"alt\":{{\"valid\":true,\"arg\":\"{package.Version} • {package.Authors} • {package.DownloadCount} downloads\",\"subtitle\":\"{package.Version} • {package.Authors} • {package.DownloadCount} downloads\"}}");
        }
    }
}
