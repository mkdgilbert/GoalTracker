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
    public class AssetService
    {
        private readonly string _userId;

        public AssetService(string userId)
        {
            _userId = userId;
        }
        public bool CreateAsset(AssetCreate model)
        {
            var entity =
                new Asset()
                {
                    Id = _userId,
                    HouseDebt = model.HouseDebt,
                    HouseAppraisal = model.HouseAppraisal,
                    AvailableCash = model.AvailableCash,
                    YearlyIncome = model.YearlyIncome,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AssetListItem> GetAssets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Assets
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new AssetListItem
                        {
                            AssetId = e.AssetId,                            
                            AvailableCash = e.AvailableCash,
                            YearlyIncome = e.YearlyIncome,
                        }
                        );
                return query.ToArray();
            }
        }

        public AssetDetail GetAssetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .Assets
                    .Single(e => e.AssetId == id && e.Id == _userId);
                return
                    new AssetDetail
                    {
                        AssetId = entity.AssetId,
                        HouseAppraisal = entity.HouseAppraisal,
                        HouseDebt = entity.HouseDebt,
                        AvailableCash = entity.AvailableCash,
                        YearlyIncome = entity.YearlyIncome,
                        TotalEquity = entity.TotalEquity,
                        TotalDebt = entity.TotalDebt,
                        TotalAssets = entity.TotalAssets,
                    };

            }
        }

        public bool UpdateAsset(AssetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assets
                    .Single(e => e.AssetId == model.AssetId && e.Id == _userId);

                entity.HouseDebt = model.HouseDebt;
                entity.HouseAppraisal = model.HouseAppraisal;
                entity.AvailableCash = model.AvailableCash;
                entity.YearlyIncome = model.YearlyIncome;
                entity.TotalDebt = model.TotalDebt;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAsset(int assetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assets
                    .Single(e => e.AssetId == assetId && e.Id == _userId);

                ctx.Assets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
