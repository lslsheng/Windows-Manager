using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KWManager.util
{
    class KWTimer
    {
        long lastTime = 0;
        long timeSpan = 0;

        public void reset(long interval)
        {
            timeSpan = interval;
            lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public bool poll() 
        {
            return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - lastTime) >　timeSpan;
        }
    }
}
