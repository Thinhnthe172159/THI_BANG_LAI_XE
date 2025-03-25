using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class NotificationDao
    {
        private readonly ThiBangLaiXeContext _context;

        public NotificationDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }

        //add
        public void AddNotification(Notification notification)
        {
            //try
            //{
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            //}
            //catch (Exception)
            //{

            //}
        }


        //remove

        public void RemoveNotification(long id)
        {
            var notification = GetNotification(id);
            if (notification != null)
            {
                notification.IsRead = 1;
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
            }
        }


        //read
        public void readNofification(long id)
        {
            var notification = GetNotification(id);
            if (notification != null)
            {
                notification.IsRead = 1;
                _context.Notifications.Update(notification);
                _context.SaveChanges();
            }
        }

        public int CountMessageNotRead(long userId)
        {
            return _context.Notifications.Where(a => a.Receiver == userId && a.IsRead != 1).Count();
        }

        //get by id
        public Notification? GetNotification(long id) => _context.Notifications.FirstOrDefault(x => x.Id == id);

        // filter by many field
        public List<Notification> FilterNotification(string filter, long receiverId)
        {
            var list = _context.Notifications.Include(a => a.SenderNavigation).Include(a => a.ReceiverNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(a => a.Title.ToLower().Contains(filter.ToLower()) || a.SenderNavigation.FullName.ToLower().Contains(filter.ToLower()));
            }
            if (receiverId != 0)
            {
                list = list.Where(a => a.Receiver == receiverId);
            }
            return list.ToList();
        }

    }
}
