using System;

namespace RepositoriesService.CalcLog
{
    public interface ICalcLogRepository
    {
        void Log(System.DateTime dtLog, int selfPositionX, int selfPositionY, int friendPositionX, int friendPositionY, double calcResult);
    }
}
