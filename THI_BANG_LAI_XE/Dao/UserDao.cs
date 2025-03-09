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
        public IPagedList<User> GetUserList(int page = 1, int pageSize = 10)
        {
            // using x page list
            return _context.Users.ToPagedList(page, pageSize);
        }


        //Get user by id
        public async Task<User?> GetUserByIdAsync(long UserId)
        {
            return await _context.Users.FirstOrDefaultAsync(us => us.UserId == UserId);
        }

        //Update user
        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var userToUpdate = await GetUserByIdAsync(user.UserId);
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
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //Delete user
        public async void DeleteUserAsync(long UserId)
        {
            {
                try
                {
                    var userToDelete = await GetUserByIdAsync(UserId);
                    if (userToDelete != null)
                    {
                        _context.Users.Remove(userToDelete);
                        await _context.SaveChangesAsync();
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