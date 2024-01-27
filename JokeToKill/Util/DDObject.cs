using Custom2d_Engine.Input;
using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Events;
using Microsoft.Xna.Framework;
using System;

namespace JokeToKill.Util
{
    public class DDObject : HierarchyObject
    {
        private Camera camera;
        public HierarchyObject AttachedObject { get; private set; }

        private bool HadParent;

        public DDObject(InputManager input, Camera camera)
        {
            input.CursorPosition.Performed += (inp) => Move(inp.GetCurrentValue<Point>());
            this.camera = camera;
        }

        private void Move(Point screenPos)
        {
            Transform.GlobalPosition = camera.ScreenToWorld(screenPos);
        }

        public void Attach(HierarchyObject obj)
        {
            if (AttachedObject != null)
            {
                throw new Exception("Already Attached");
            }
            if (obj.Parent != Parent && !obj.IsRootInHierarcy)
            {
                throw new Exception("Invalid Object");
            }
            var pos = obj.Transform.LocalPosition;
            var thisPos = Transform.LocalPosition;

            HadParent = obj.Parent != null;
            this.AttachedObject = obj;
            obj.Parent = this;
            var localPos = pos - thisPos;
            obj.Transform.LocalPosition = localPos;
        }

        public HierarchyObject Detach()
        {
            if (AttachedObject == null)
            {
                throw new Exception("Nothing To Detach");
            }
            var pos = Transform.LocalPosition;
            AttachedObject.Transform.LocalPosition += pos;
            if (!HadParent || Parent == null)
            {
                AttachedObject.Parent = null;
                CurrentHierarchy.AddObject(AttachedObject);
            }
            else
            {
                AttachedObject.Parent = Parent;
            }

            var obj = AttachedObject;
            AttachedObject = null;
            return obj;
        }
    }
}
