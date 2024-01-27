using Custom2d_Engine.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Util
{
    public class PID
    {
        private float P, I, D;
        private float value;
        private float integral;
        private float last;

        public PID(float proportional, float integral, float differential)
        {
            this.P = proportional;
            this.I = integral;
            this.D = differential;
        }

        public float Update(float error, TimeSpan dt)
        {
            integral += error * (float)dt.TotalSeconds;
            var derivative = 0f;
            if (dt > TimeSpan.Zero)
            {
                derivative = (last - error) / (float)dt.TotalSeconds;
            }
            value = P * error + I * integral + D * derivative;
            return value;
        }

        public void Reset(float value, float integral = 0f)
        {
            this.value = value;
            this.integral = integral;
        }
    }
}
