using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Util
{
    public class SoftMoveObject : HierarchyObject, IUpdatable
    {
        //private PID Xd = new PID(0.75f, 1.5f, 0.0075f);
        public float Speed = 1f;

        private PID Xd = new PID(0.25f, 1.25f, 0.005f);
        private PID Yd = new PID(0.25f, 1.25f, 0.005f);

        private HierarchyObject target;

        public float Order => 0f;

        public SoftMoveObject(HierarchyObject target)
        {
            this.target = target;
        }

        public void Update(GameTime time)
        {
            var lpos = target.Transform.GlobalPosition;
            var dpos = Transform.GlobalPosition - lpos;
            var vel = new Vector2(
                Xd.Update(dpos.X, time.ElapsedGameTime),
                Yd.Update(dpos.Y, time.ElapsedGameTime)) * Speed;

            target.Transform.GlobalPosition += vel;
        }

        public void Reset()
        {
            Xd.Reset();
            Yd.Reset();
        }
    }
}
