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
    public class GoalService
    {
        private readonly string _userId;

        public GoalService(string userId)
        {
            _userId = userId;
        }
        public bool CreateGoal(GoalCreate model)
        {
            var entity =
                new Goal()
                {
                    Id = _userId,
                    GoalCost = model.GoalCost,
                    //FinanceOption = model.FinanceOption,
                    //OutOfPocketOption = model.OutOfPocketOption,
                    GoalName = model.GoalName,
                    GoalType = model.GoalType,
                    InterestRate = model.InterestRate,
                    NumberOfYears = model.NumberOfYears,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Goals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GoalListItem> GetGoals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Goals
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new GoalListItem
                        {
                            GoalId = e.GoalId,
                            GoalCost = e.GoalCost,
                            //FinanceOption = e.FinanceOption,
                            //OutOfPocketOption = e.OutOfPocketOption,
                            GoalName = e.GoalName,
                            GoalType = e.GoalType,  
                            NumberOfYears = e.NumberOfYears,
                        }
                        );
                return query.ToArray();
            }
        }

        public GoalDetail GetGoalById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .Goals
                    .Single(e => e.GoalId == id && e.Id == _userId);
                return
                    new GoalDetail
                    {
                        GoalId = entity.GoalId,
                        GoalCost = entity.GoalCost,
                        //FinanceOption = entity.FinanceOption,
                        //OutOfPocketOption = entity.OutOfPocketOption,
                        GoalName = entity.GoalName,
                        GoalType = entity.GoalType,
                        NumberOfYears = entity.NumberOfYears,
                        InterestRate = entity.InterestRate,
                        TotalAmount = entity.TotalAmount,
                        CompoundInterest = entity.CompoundInterest,
                    };

            }
        }

        public bool UpdateGoal(GoalEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Goals
                    .Single(e => e.GoalId == model.GoalId && e.Id == _userId);

                entity.GoalCost = model.GoalCost;
                //entity.FinanceOption = model.FinanceOption;
                //entity.OutOfPocketOption = model.OutOfPocketOption;
                entity.GoalName = model.GoalName;
                entity.GoalType = model.GoalType;
                entity.NumberOfYears = model.NumberOfYears;
                entity.InterestRate = model.InterestRate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGoal(int goalId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Goals
                    .Single(e => e.GoalId == goalId && e.Id == _userId);

                ctx.Goals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
