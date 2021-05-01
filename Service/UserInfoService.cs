using Data;
using GoalTracker.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserInfoService
    {
        private readonly string _userId;

        public UserInfoService(string userId)
        {
            _userId = userId;
        }
        public bool CreateUserInfo(UserInfoCreate model)
        {
            var entity =
                new UserInfo()
                {
                    Id = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserInfoListItem> GetUserInfo()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .UserInfos
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new UserInfoListItem
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                        }
                        );
                return query.ToArray();
            }
        }

        public UserInfoDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .UserInfos
                    .Single(e => e.Id == _userId);
                return
                    new UserInfoDetail
                    {
                        FirstName = entity.LastName,
                        LastName = entity.LastName,
                    };

            }
        }

        public bool UpdateUserInfo(UserInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserInfos
                    .Single(e => e.UserInfoId == model.UserInfoId && e.Id == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
