using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Interpreters;
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// ����� ������ ��� ������������ ����������� ������ ����������
    /// </summary>
    [TestFixture]
    public class InterpreterHandlerTests
    {
        private readonly IInterpreterHandler _interpreterHandler;
        private Guid _createIntepreterId;

        public InterpreterHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _interpreterHandler = _services.GetService<IInterpreterHandler>();
        }

        /// <summary>
        /// ������ �������� �����������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddInterpreter()
        {
            // Arrange
            var modifiedInterpreter = new InterpreterModifyModel
            {
                Name = "����� ������������",
                Age = 22,
                Description = "�� �������� ������ ����� ������������? ������ ���",
                BooksIds = new List<Guid> 
                {
                    Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"),
                    Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B")
                }
            };
            var interpreter = new InterpreterViewModel
            {
                Name = "����� ������������",
                Age = 22,
                Description = "�� �������� ������ ����� ������������? ������ ���",
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
                                Name = "���� ����� ������",
                            }
                        }
                    },
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
                                Name = "������ �� ����-��������",
                            }
                        }
                    }
                }
            };
            // Act
            var result = await _interpreterHandler.AddAsync(modifiedInterpreter);
            _createIntepreterId = result.Id;
            interpreter.Id = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(interpreter);
        }

        /// <summary>
        /// ������ �������� �����������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdateInterpreter()
        {
            // Arrange
            var modifiedInterpreter = new InterpreterModifyModel
            {
                Id = _createIntepreterId,
                Name = "����� �������������",
                Age = 32,
                Description = "�� �������� ������ ����� �������������? ������ ��� ����� ������������ �������",
                BooksIds = new List<Guid> { Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25") }
            };
            var interpreter = new InterpreterViewModel
            {
                Id = _createIntepreterId,
                Name = "����� �������������",
                Age = 32,
                Description = "�� �������� ������ ����� �������������? ������ ��� ����� ������������ �������",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"),
                        Name = "�������",
                        Price = 250.00M,
                        Authors = new List<AuthorShortModel>
                        {
                            new AuthorShortModel
                            {
                                Id = Guid.Parse("6BE1A08C-550C-447F-BB67-D1E1F5275DBF"),
                                Name = "��� ������ ��������",
                            }
                        }
                    }
                }
            };
            // Act
            var result = await _interpreterHandler.UpdateAsync(modifiedInterpreter);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(interpreter);
        }

        /// <summary>
        /// ������ ������� �����������
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldDeleteInterpreter()
        {
            // Arrange
            var baseResponse = new BaseResponse();
            // Act
            var result = await _interpreterHandler.DeleteAsync(_createIntepreterId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(baseResponse);
        }

        /// <summary>
        /// ������ �������� �����������
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetInterpreter()
        {
            // Arrange
            var guid = Guid.Parse("FEC297D0-8287-42F3-81BD-311AE1B0C6C6");
            var interpreter = new InterpreterViewModel
            {
                Id = guid,
                Name = "������� ������",
                Age = 75,
                Description = "��������� �������� ������, ��� ������ �� ������� ���������" +
                " �������� (����� � 1976 ����) ������ ��� ����, ����� ��������� ����" +
                " ����������; ��, �������, ��-���� ��������� �������.",
                Books = new List<BookPreviewModel> 
                { 
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
                      }
                }
            };
            // Act
            var result = await _interpreterHandler.GetAsync(guid);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(interpreter);
        }
    }
}