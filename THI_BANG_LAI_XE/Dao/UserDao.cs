using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace THI_BANG_LAI_XE.Dao
{
    public class UserDao
    {
        private readonly ThiBangLaiXeContext _context;

        public UserDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }



        //Add user
        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //get userList 
        public IPagedList<User> GetUserPageList(int page = 1, int pageSize = 10)
        {
            // using x page list
            return _context.Users.ToPagedList(page, pageSize);
        }
        public List<User> GetUserList()
        {
            // using x page list
            return _context.Users.ToList();
        }


        //Get user by id
        public User? GetUserById(long UserId)
        {
            return _context.Users.FirstOrDefault(us => us.UserId == UserId);
        }

        //Update user
        public void UpdateUser(User user)
        {
            try
            {
                var userToUpdate = GetUserById(user.UserId);
                if (userToUpdate != null)
                {
                    userToUpdate.FullName = user.FullName;
                    userToUpdate.Email = user.Email;
                    userToUpdate.Password = user.Password;
                    userToUpdate.Role = user.Role;
                    userToUpdate.Class = user.Class;
                    userToUpdate.Phone = user.Phone;
                    userToUpdate.School = user.School;
                    _context.Users.Update(userToUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //Delete user
        public void DeleteUserAsync(long UserId)
        {
            {
                try
                {
                    var userToDelete = GetUserById(UserId);
                    if (userToDelete != null)
                    {
                        _context.Users.Remove(userToDelete);
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        public bool IsEmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}