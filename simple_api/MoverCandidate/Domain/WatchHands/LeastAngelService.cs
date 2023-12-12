using System;

namespace MoverCandidate.Domain.WatchHands
{
    public class LeastAngelService
    {
        public double FindLeastAngel(DateTime time)
        {
            double hours = 360.0 / 12.0 * (time.Hour % 12);
            double minutes = 360.0 / 60.0 * time.Minute;
            double seconds = 360.0 / 60.0 * time.Second;

            return Math.Min(
                Math.Min(
                    GetAngel(hours, minutes),
                    GetAngel(hours, seconds)),
                GetAngel(minutes, seconds));
        }

        private double GetAngel(double angle1, double angle2)
        {
            double angle = Math.Abs(angle1 - angle2);
            return Math.Min(angle, 360.0 - angle);
        }

    }
}
