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
    public class UpdateChartDataRedisTask : IInvocable
    {
        private readonly DBRepository _dBRepository;
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        public UpdateChartDataRedisTask(DBRepository dBRepository, IMemoryCacheRepository memoryCacheRepository)
        {
            _dBRepository = dBRepository;
            _memoryCacheRepository = memoryCacheRepository;
        }
        public Task Invoke()
        {
            var result = _dBRepository.GetAll<Room>().ToArray().GroupBy(x => x.City)
            .Select(x => new
            {
                City = x.Key,
                RoomCount = x.Count(),
            })
            .OrderByDescending(x => x.RoomCount).Take(10)
            .Select((x, index) => new ChartDataModel
            {
                Ranking = index + 1,
                Area = x.City,
                Ratio = x.RoomCount / (float)(_dBRepository.GetAll<Room>().Count())
            });

            _memoryCacheRepository.Set<IEnumerable<ChartDataModel>>("Aircnc.ChartData", result);

            return Task.CompletedTask;
        }
    }
}
