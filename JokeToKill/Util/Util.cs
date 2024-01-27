using Custom2d_Engine.Scenes;
using Microsoft.Xna.Framework;

namespace JokeToKill.Util
{
    public static class Util
    {
        public static Vector2 ScreenToWorld(this Camera camera, Point screenPos)
        {
            var posNorm = new Vector2(screenPos.X, screenPos.Y) / Constants.ScreenSize;
            posNorm = posNorm * 2f - Vector2.One;
            posNorm.Y = -posNorm.Y;
            var worldPos = camera.ProjectionMatrix.Inverse().TransformPoint(posNorm);
            return worldPos;
        }
    }
}
