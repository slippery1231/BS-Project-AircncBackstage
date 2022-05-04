using Aircnc_BackStage.Models;
using Aircnc_BackStage.Models.DataModels;
using Aircnc_BackStage.Repositories.Interface;
using AircncFrontStage.Repositories;
using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Common.Coraval
{
    public class UpdatePieDataRedisTask : IInvocable
    {
        private readonly DBRepository _dBRepository;
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        public UpdatePieDataRedisTask(DBRepository dBRepository, IMemoryCacheRepository memoryCacheRepository)
        {
            _dBRepository = dBRepository;
            _memoryCacheRepository = memoryCacheRepository;
        }
        public Task Invoke()
        {
           var result = _dBRepository.GetAll<Order>().ToArray().GroupBy(x => x.City)
             .Select(x => new
             {
                 City = x.Key,
                 Total = x.Sum(y => y.OriginalPrice),
             })
             .OrderByDescending(x => x.Total).Take(5)
              .Select((x, index) => new PieDataModel
              {
                  Ranking = index + 1,
                  Area = x.City,
                  Ratio = (float)x.Total / (float)(_dBRepository.GetAll<Order>().Sum(y => y.OriginalPrice))
              });
            _memoryCacheRepository.Set<IEnumerable<PieDataModel>>("Aircnc.PieData", result);
            return Task.CompletedTask;
        }
    }
}
