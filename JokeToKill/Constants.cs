using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace JokeToKill
{
    public static class Constants
    {
        public const int CardCount = 4;
        public const float CamSize = 5;
        public static readonly Vector2 ScreenSize = new Vector2(JokeGame.ScreenWidth, JokeGame.ScreenHeight);

        public const float Aspect = JokeGame.ScreenWidth / (float)JokeGame.ScreenHeight;
        public static readonly Vector2 AspectVec = new Vector2(1f, Aspect);      
        public static readonly Vector2 Pixel = Vector2.One * (CamSize / JokeGame.ScreenWidth);
            
        public static readonly Vector2 CardSize = new Vector2(GetPart(CamSize * Aspect, CardCount, 0.1f), GetPart(CamSize, 3, 0f));


        private static float GetPart(float total, int count, float spacing)
        {
            return (total - spacing) / (count + spacing) - spacing;
        }
    }
}
