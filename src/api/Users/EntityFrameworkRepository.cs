using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Users
{
    public class EntityFrameworkRepository : Repository
    {
        private readonly Conduit.Sql.AppDbContext context;
        public EntityFrameworkRepository(Conduit.Sql.AppDbContext context)
        {
            this.context = context;
        }
        // public override Task<IEnumerable<User>> find()
        // {
        //     return Task.FromResult<IEnumerable<User>>(context.Users.Select(this.mapToUser).ToList());
        // }

        public override async Task<User> findOne(string id)
        {
            var dbUser = await context.Users.FindAsync(id);
            if (dbUser != null)
            {
                return this.mapToUser(dbUser);
            }
            else
            {
                throw new Exception("not-found");
            }

        }

        // public override Task<string> insertOne(User User)
        // {
        //     if (User.username != null)
        //     {
        //         var existingUser = context.Users.Where(dbUser => dbUser.username == User.username).Count();

        //         if (existingUser == 0)
        //         {
        //             var dbUser = this.mapToDbUser(User);
        //             context.Users.Add(dbUser);
        //             try
        //             {
        //                 context.SaveChanges();
        //             }
        //             catch (Exception e)
        //             {
        //                 throw e;
        //             }

        //             return Task.FromResult<string>(User.username);
        //         }
        //         else
        //         {
        //             throw new Exception("conflict");

        //         }
        //     }
        //     else
        //     {
        //         throw new Exception("bad-request");
        //     }
        // }


        // public override Task updateOne(User User)
        // {
        //     if (User.username != null)
        //     {
        //         var existingUser = context.Users.Find(User.username);
        //         if (existingUser != null)
        //         {
        //             context.Users.Update(this.mapToDbUser(User));
        //             try
        //             {
        //                 context.SaveChanges();
        //             }
        //             catch (Exception e)
        //             {
        //                 throw e;
        //             }

        //             return Task.FromResult<string>(User.username);
        //         }
        //         else
        //         {
        //             throw new Exception("conflict");

        //         }
        //     }
        //     else
        //     {
        //         throw new Exception("bad-request");
        //     }
        // }

        // public override Task deleteOne(string id)
        // {
        //     var existingUser = this.context.Users.Find(id);
        //     if (existingUser != null)
        //     {
        //         this.context.Users.Remove(existingUser);
        //         try
        //         {
        //             context.SaveChanges();
        //         }
        //         catch (Exception e)
        //         {
        //             throw e;
        //         }
        //         return Task.FromResult("");
        //     }
        //     else
        //     {
        //         throw new Exception("not-found");

        //     }

        // }


        private User mapToUser(Conduit.Sql.User dbUser)
        {
            return new User()
            {
                username = dbUser.username,
                bio = dbUser.bio,
                email = dbUser.email,
                image = dbUser.image,
            };
        }

        private Sql.User mapToDbUser(User User)
        {
            return new Sql.User()
            {
                username = User.username,
                bio = User.bio,
                email = User.email,
                image = User.image,

            };
        }

    }
}