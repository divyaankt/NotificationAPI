using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationAPI.Models
{
    public class NotificationDBContext : DbContext
    {
        public NotificationDBContext(DbContextOptions<NotificationDBContext> options) : base(options)
        {

        }

        public DbSet<NotificationMessage> Notifications { get; set; }
    }
}
