using System;
using ApplicationServices.CalcLog;
using RepositoriesService.CalcLog;

namespace Application.CalcLog
{
    public class CalcLogService : ICalcLogService
    {
        ICalcLogRepository _calcLogRepository;

        public CalcLogService(ICalcLogRepository calcLogRepository)
        {
            _calcLogRepository = calcLogRepository;
        }

        public void Log(DateTime dtLog, int selfPositionX, int selfPositionY, int friendPositionX, int friendPositionY, double calcResult)
        {
            _calcLogRepository.Log(dtLog, selfPositionX, selfPositionY, friendPositionX, friendPositionY, calcResult);
        }
    }
}
