using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Publishers;
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// ����� ������ ��� ������������ ����������� ������ ��������
    /// </summary>
    [TestFixture]
    public class PublisherHandlerTests
    {
        private readonly IPublisherHandler _publisherHandler;
        private Guid _createPublisherId;

        public PublisherHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _publisherHandler = _services.GetService<IPublisherHandler>();
        }

        /// <summary>
        /// ������ �������� ��������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddPublisher()
        {
            // Arrange
            var modifiedPublisher = new PublisherModifyModel
            {
                Name = "�������� �����",
                BooksIds = new List<Guid>
                {
                    Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"),
                    Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC")
                }
            };
            var publisher = new PublisherViewModel
            {
                Name = "�������� �����",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"),
                        Name = "��� ����� �����",
                        Price = 330.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("6B6F819C-2A9D-4EF9-92DD-55F69097F36C"),
                                Name = "���� ����� ������"
                            }
                        }
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                        Name = "���, � �������",
                        Price = 605.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
                            }
                        }
                    },
                }
            };
            // Act
            var result = await _publisherHandler.AddAsync(modifiedPublisher);
            _createPublisherId = result.Id;
            publisher.Id = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(publisher);
        }

        /// <summary>
        /// ������ �������� ��������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdatePublisher()
        {
            // Arrange
            var modifiedPublisher = new PublisherModifyModel
            {
                Id = _createPublisherId,
                Name = "�������� �������",
                BooksIds = new List<Guid>
                {
                    Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD")
                }
            };
            var publisher = new PublisherViewModel
            {
                Id = _createPublisherId,
                Name = "�������� �������",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD"),
                        Name = "����� ��� ����������",
                        Price = 220.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
                            }
                        }
                    }
                }
            };
            // Act
            var result = await _publisherHandler.UpdateAsync(modifiedPublisher);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(publisher);
        }

        /// <summary>
        /// ������ ������� ��������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldDeletePublisher()
        {
            // Arrange
            var baseResponse = new BaseResponse();
            // Act
            var result = await _publisherHandler.DeleteAsync(_createPublisherId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(baseResponse);
        }

        /// <summary>
        /// ������ �������� ��������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetPublisher()
        {
            // Arrange
            var publisherId = Guid.Parse("B9AF4688-E273-4676-A92A-656023A2D216");
            var publisher = new PublisherViewModel
            {
                Id = publisherId,
                Name = "����� �������",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"),
                        Name = "1984",
                        Price = 203.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("6B6F819C-2A9D-4EF9-92DD-55F69097F36C"),
                                Name = "���� ����� ������"
                            }
                        }
                    }
                }
            };
            // Act
            var result = await _publisherHandler.GetAsync(publisherId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(publisher);
        }

        /// <summary>
        /// ������ �������� ���������� 3 ��������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAndSkipPublishers()
        {
            // Act
            var resultWithTaked = await _publisherHandler.GetAsync(3, 0);
            var resultWithSkipped = await _publisherHandler.GetAsync(3, 3);
            // Assert
            resultWithTaked.PreviewPublishers.Should().NotBeNull();
            resultWithTaked.PreviewPublishers.Count.Should().Be(3);

            resultWithSkipped.PreviewPublishers.Should().NotBeNull();
            resultWithSkipped.PreviewPublishers.Count.Should().Be(3);

            resultWithTaked.PreviewPublishers.Should()
                .NotBeEquivalentTo(resultWithSkipped.PreviewPublishers);
        }

        /// <summary>
        /// ������ ����� ��������� �� ������������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchPublishersByName()
        {
            // Act
            var result = await _publisherHandler.SearchByNameAsync("��", 1, 1);
            // Assert
            result.PreviewPublishers.Should().NotBeNull();
            result.PreviewPublishers.Count.Should().Be(1);
            result.Count.Should().Be(2);
        }
    }
}