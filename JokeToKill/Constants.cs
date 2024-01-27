using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace JokeToKill
{
    public static class Constants
    {
        public const int CardCount = 15;
        public const float CardsPosY = -3f;
        public const float CamSize = 5;
        public static readonly Vector2 ScreenSize = new Vector2(JokeGame.ScreenWidth, JokeGame.ScreenHeight);

        public const float Aspect = JokeGame.ScreenWidth / (float)JokeGame.ScreenHeight;
        public static readonly Vector2 AspectVec = new Vector2(Aspect, 1f);
        public static readonly Vector2 Pixel = Vector2.One * (CamSize * 2f / JokeGame.ScreenHeight);
        
        public static readonly Vector2 CardSize = new Vector2(GetPart(CamSize * Aspect, CardCount, 0.1f), GetPart(CamSize, 3, 0f));

        public const float CardDrawOrder = 0f;

        private static float GetPart(float total, int count, float spacing)
        {
            return (total - spacing) / (count + spacing) - spacing;
        }
    }
}
