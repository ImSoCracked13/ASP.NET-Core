﻿using UserLinkService.Data;
using UserLinkService.Models;
using UserLinkService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UserLinkService.Repositories
{
    public class UserLinkRepository : IUserLinkRepository
    {
        private readonly ApplicationDbContext _context;

        public UserLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(UserLink userlink)
        {
            try
            {
                _context.UserLinks.Add(userlink);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var userlink = _context.UserLinks.Find(id);
                if (userlink == null) return false;

                _context.UserLinks.Remove(userlink);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UserLink> GetAll()
        {
            return _context.UserLinks.ToList();
        }

        public UserLink GetUserLink(int id)
        {
            return _context.UserLinks.Find(id);
        }

        public bool Update(int id, UserLink userlink)
        {
            try
            {
                var existingUserLink = GetUserLink(id);
                if (existingUserLink == null) return false;

                existingUserLink.Link = userlink.Link;
                existingUserLink.ShortenLink = userlink.ShortenLink;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(UserLink userLink, string baseUrl)
        {
            try
            {
                _context.UserLinks.Add(userLink);
                GenerateNewLink(userLink, baseUrl);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GenerateNewLink(UserLink userLink, string baseUrl)
        {
            try
            {
                string newLink;
                do
                {
                    var rnd = new Random();
                    var num = rnd.Next(1000, 9999);
                    newLink = $"{baseUrl}/{num}";
                } while (_context.UserLinks.Any(d => d.ShortenLink == newLink));

                userLink.ShortenLink = newLink;
                _context.UserLinks.Add(userLink);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }





        public UserLink GetUserLinkFromNewLink(string newuserlink)
        {
            return _context.UserLinks.FirstOrDefault(d => d.ShortenLink == newuserlink);
        }
    }
}

