using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace JokeToKill
{
    public static class Constants
    {
        public const int CardCount = 4;
        public const float CardsPosY = -3f;
        public static readonly Vector2 CardsDrawOrigin = new Vector2(0f, -5f);
        public const float CamSize = 5;
        public static readonly Vector2 ScreenSize = new Vector2(JokeGame.ScreenWidth, JokeGame.ScreenHeight);

        public static readonly Vector2 MonsterFloorCenter = new Vector2(2.5f, -0.65f);

        public const float Aspect = JokeGame.ScreenWidth / (float)JokeGame.ScreenHeight;
        public static readonly Vector2 AspectVec = new Vector2(Aspect, 1f);
        public static readonly Vector2 Pixel = Vector2.One * (CamSize * 2f / JokeGame.ScreenHeight);
        
        public static readonly Vector2 CardSize = new Vector2(GetPart(CamSize * Aspect, CardCount, 0.1f), GetPart(CamSize, 3, 0f));

        public const float CardDrawOrder = 1f;

        public const int MinMonsterAspects = 2;
        public const int MaxMonsterAspects = 5;
        public const int CardAspects = 2;
        public const int MonsterCount = 3;

        private static float GetPart(float total, int count, float spacing)
        {
            return (total - spacing) / (count + spacing) - spacing;
        }
    }
}
