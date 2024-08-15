using UserLinkService.Models;
using UserLinkService.Repositories;
using UserLinkService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;
using UserLinkService.Data;

namespace UserLinkService.Tests
{
    public class UserLinkRepositoryTests
    {
        private readonly IUserLinkRepository _repository;
        private readonly ApplicationDbContext _context;


        public UserLinkRepositoryTests()
        {
            // Set up the in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UserLinksDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new UserLinkRepository(_context);
        }

        [Fact]
        public void GetUserLink_Should_Return_UserLink()
        {
            // Arrange
            var userLink = new UserLink
            {
                Id = 1,
                Link = "http://reddit.com",
                ShortenLink = "http://localhost:5249/api/1111"
            };
            _context.UserLinks.Add(userLink);
            _context.SaveChanges();

            // Act
            var result = _repository.GetUserLink(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("http://reddit.com", result.Link);
        }

        [Fact]
        public void GetAll_Should_Return_All_UserLinks()
        {
            // Arrange
            _context.UserLinks.AddRange(new List<UserLink>
    {
        new UserLink { Id = 2, Link = "http://facebook.com", ShortenLink = "http://localhost:5249/api/2222" },
        new UserLink { Id = 3, Link = "http://youtube.com", ShortenLink = "http://localhost:5249/api/3333" }
    });
            _context.SaveChanges();

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Update_Should_Modify_Existing_UserLink()
        {
            // Arrange
            var userLink = new UserLink
            {
                Id = 4,
                Link = "http://discord.com",
                ShortenLink = "http://localhost:5249/api/4444"
            };
            _context.UserLinks.Add(userLink);
            _context.SaveChanges();

            var updatedLink = new UserLink
            {
                Id = 4,
                Link = "http://myanimelist.net",
                ShortenLink = "http://localhost:5249/api/4444"
            };

            // Act
            var result = _repository.Update(4, updatedLink);

            // Assert
            Assert.True(result);
            var updatedUserLink = _context.UserLinks.Find(4);
            Assert.Equal("http://myanimelist.net", updatedUserLink.Link);
        }

        [Fact]
        public void Delete_Should_Remove_UserLink()
        {
            // Arrange
            var userLink = new UserLink
            {
                Id = 5,
                Link = "http://google.com",
                ShortenLink = "http://localhost:5249/api/5555"
            };
            _context.UserLinks.Add(userLink);
            _context.SaveChanges();

            // Act
            var result = _repository.Delete(5);

            // Assert
            Assert.True(result);
            Assert.Null(_context.UserLinks.Find(5));
        }

        [Fact]
        public void GenerateNewLink_Should_Create_ShortenedLink()
        {
            // Arrange
            var userLink = new UserLink
            {
                Id = 6,
                Link = "http://x.com"
            };

            var baseUrl = "http://localhost:5249/api/6666";

            // Act
            var result = _repository.GenerateNewLink(userLink, baseUrl);

            // Assert
            Assert.True(result);
            Assert.NotNull(userLink.ShortenLink);
            Assert.Contains(baseUrl, userLink.ShortenLink);
        }

        [Fact]
        public void GetUserLinkFromNewLink_Should_Return_Correct_UserLink()
        {
            // Arrange
            var userLink = new UserLink
            {
                Id = 7,
                Link = "http://twitch.tv",
                ShortenLink = "http://localhost:5249/api/7777"
            };
            _context.UserLinks.Add(userLink);
            _context.SaveChanges();

            // Act
            var result = _repository.GetUserLinkFromNewLink("http://localhost:5249/api/7777");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("http://twitch.tv", result.Link);
        }
    }
}

