using System;

namespace ApplicationServices.CalcLog
{
    public interface ICalcLogService
    {
        void Log(DateTime dtLog, int selfPositionX, int selfPositionY, int friendPositionX, int friendPositionY, double calcResult);
    }
}
