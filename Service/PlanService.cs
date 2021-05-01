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
    public class PlanService
    {
        private readonly string _userId;

        public PlanService(string userId)
        {
            _userId = userId;
        }
        public bool CreatePlan(PlanCreate model)
        {
            var entity =
                new PlanOfAction()
                {
                    Id = _userId,
                    AssetId = model.AssetId,
                    GoalId = model.GoalId,
                    PlanName = model.PlanName,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlanOfActions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlanListItem> GetPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PlanOfActions
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new PlanListItem
                        {
                            PlanId = e.PlanId,
                            PlanName = e.PlanName,
                        }
                        );
                return query.ToArray();
            }
        }

        public PlanDetail GetPlanById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .PlanOfActions
                    .Single(e => e.PlanId == id && e.Id == _userId);
                return
                    new PlanDetail
                    {
                        PlanId = entity.PlanId,
                        GoalId = entity.GoalId,
                        PlanName = entity.PlanName,
                        Essentials = entity.Essentials,
                        Discretionary = entity.Discretionary,
                        YearlySaving = entity.YearlySaving,
                        MonthlySaving = entity.MonthlySaving,
                        Considerations = entity.Considerations,
                        RiskRatio = entity.RiskRatio,
                    };

            }
        }

        public bool UpdatePlan(PlanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PlanOfActions
                    .Single(e => e.PlanId == model.PlanId && e.Id == _userId);

                entity.PlanName = model.PlanName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlan(int planId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PlanOfActions
                    .Single(e => e.PlanId == planId && e.Id == _userId);

                ctx.PlanOfActions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
