using Microsoft.EntityFrameworkCore;
using MyFriendsAPP.Models;

namespace MyFriendsAPP.Data
{
    public class MvcFriendContext : DbContext
    {
        public MvcFriendContext(DbContextOptions<MvcFriendContext> options)
            : base(options)
        {
        }

        public DbSet<Friend> Friend { get; set; }
    }
}
