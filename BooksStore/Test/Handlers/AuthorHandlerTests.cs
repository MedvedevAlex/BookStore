using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// ����� ������ ��� ������������ ����������� ������ �����
    /// </summary>
    [TestFixture]
    public class AuthorHandlerTests : GeneralSetUpExecution
    {
        private readonly IAuthorHandler _authorHandler;

        public AuthorHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _authorHandler = _services.GetService<IAuthorHandler>();
        }

        /// <summary>
        /// ������ �������� ������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldUpdateAuthor()
        {
            // Arrange
            var updatedAuthor = new AuthorModifyModel
            {
                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                Name = "������ �� ����-�������� �������",
                Age = 22,
                Description = "� ������ 1955 ����, � �������� �������������� ������ " +
                "�����-����, ����-�������� ������� ���� � ������ ���� ����� � ���� �������. " +
                "����� ������ ����� �� ������ ���� � ����� ������� ����� ����� �� �����",
                BooksIds = new List<Guid>
                {
                    Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                    Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD"),
                    Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"),
                }
            };
            var author = new AuthorViewModel
            {
                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                Name = "������ �� ����-�������� �������",
                Age = 22,
                Description = "� ������ 1955 ����, � �������� �������������� ������ " +
                "�����-����, ����-�������� ������� ���� � ������ ���� ����� � ���� �������. " +
                "����� ������ ����� �� ������ ���� � ����� ������� ����� ����� �� �����",
                Books = new List<BookPreviewModel> {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                        Name = "������ ��������� ����� (�������� �� 3 ����)",
                        Price = 792.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-�������� �������"
                            }
                        }
                    },
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
                                Name = "������ �� ����-�������� �������"
                            }
                        }
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"),
                        Name = "�������",
                        Price = 250.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-�������� �������"
                            }
                        }
                    },
                }
            };
            // Act
            var result = await _authorHandler.UpdateAsync(updatedAuthor);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(author);
        }

        /// <summary>
        /// ������ ������� ������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldDeleteAuthor()
        {
            // Arrange
            var guid = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7");
            var baseResponse = new BaseResponse();
            // Act
            var result = await _authorHandler.DeleteAsync(guid);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(baseResponse);
        }

        /// <summary>
        /// ������ �������� ������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldAddAuthor()
        {
            // Arrange
            var addedAuthor = new AuthorModifyModel
            {
                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                Name = "������ �� ����-��������",
                Age = 44,
                Description = "� ������ 1935 ����, � �������� �������������� ������ " +
                "�����-����, ����-�������� ������� ���� � ������ ���� ����� � ���� �������. " +
                "����� ������������� � ��������� ����� ����� ���������� ����������� ���� ����� " +
                "�� ������ ������������ ��������� ������, � ������� �������� ������� ��������� ���������.",
                BooksIds = new List<Guid>
                {
                    Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                    Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD"),
                    Guid.Parse("7C7EF3FC-B918-41D5-9E9D-E0549B0F42BC"),
                    Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                }
            };
            var author = new AuthorViewModel
            {
                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                Name = "������ �� ����-��������",
                Age = 44,
                Description = "� ������ 1935 ����, � �������� �������������� ������ " +
                "�����-����, ����-�������� ������� ���� � ������ ���� ����� � ���� �������. " +
                "����� ������������� � ��������� ����� ����� ���������� ����������� ���� ����� " +
                "�� ������ ������������ ��������� ������, � ������� �������� ������� ��������� ���������.",
                Books = new List<BookPreviewModel> {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                        Name = "������ ��������� ����� (�������� �� 3 ����)",
                        Price = 792.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
                            }
                        }
                    },
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
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7C7EF3FC-B918-41D5-9E9D-E0549B0F42BC"),
                        Name = "��� ��� �����������",
                        Price = 377.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
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
            var result = await _authorHandler.AddAsync(addedAuthor);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(author);
        }

        /// <summary>
        /// ������ �������� ������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAuthor()
        {
            // Arrange
            var author = new AuthorViewModel
            {
                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                Name = "������ �� ����-��������",
                Age = 44,
                Description = "� ������ 1935 ����, � �������� �������������� ������ " +
                "�����-����, ����-�������� ������� ���� � ������ ���� ����� � ���� �������. " +
                "����� ������������� � ��������� ����� ����� ���������� ����������� ���� ����� " +
                "�� ������ ������������ ��������� ������, � ������� �������� ������� ��������� ���������.",
                Books = new List<BookPreviewModel> {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                        Name = "������ ��������� ����� (�������� �� 3 ����)",
                        Price = 792.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
                            }
                        }
                    },
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
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7C7EF3FC-B918-41D5-9E9D-E0549B0F42BC"),
                        Name = "��� ��� �����������",
                        Price = 377.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                                Name = "������ �� ����-��������"
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
            var result = await _authorHandler.GetAsync(author.Id);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(author);
        }

        /// <summary>
        /// ������ �������� �������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAuthors()
        {
            // Act
            var resultWithTaked = await _authorHandler.GetAsync(3, 0);
            var resultWithSkipped = await _authorHandler.GetAsync(3, 3);
            // Assert
            resultWithTaked.PreviewAuthors.Should().NotBeNull();
            resultWithTaked.PreviewAuthors.Count.Should().Be(3);

            resultWithSkipped.PreviewAuthors.Should().NotBeNull();
            resultWithSkipped.PreviewAuthors.Count.Should().Be(3);

            resultWithTaked.PreviewAuthors.Should().NotBeEquivalentTo(resultWithSkipped.PreviewAuthors);
        }

        /// <summary>
        /// ������ ����� ������� �� �����
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAuthorsByName()
        {
            // Act
            var result = await _authorHandler.SearchByNameAsync("��", 1, 1);
            // Assert
            result.Should().NotBeNull();
            result.PreviewAuthors.Count.Should().Be(1);
            result.Count.Should().Be(2);
        }
    }
}