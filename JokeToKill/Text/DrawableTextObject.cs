using Custom2d_Engine.Rendering;
using Custom2d_Engine.Scenes.Drawable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Text
{
    public class DrawableTextObject : SpecialRenderedObject
    {
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        private static SpriteBatch spriteBatch;

        public DrawableTextObject(RenderPipeline pipeline, Color color, float drawOrder) : base(pipeline, color, drawOrder)
        {
            SetQueueBehaviour(RenderPasses.Final, QueueBehaviour.CustomDraw);
            spriteBatch ??= new SpriteBatch(pipeline.Graphics);
        }

        protected override void RenderFinal(Texture2D sceneLights)
        {
            spriteBatch.Begin();
            var lines = Text.Split("\n");

            var pos = Pipeline.CurrentState.CurrentProjection.TransformPoint(Transform.GlobalPosition);
            pos = (pos + Vector2.One) * 0.5f;
            pos.Y = 1 - pos.Y;
            pos *= Constants.ScreenSize;

            for (int i=0; i<lines.Length; i++)
            {
                spriteBatch.DrawString(Font, lines[i], pos, Color);
                pos.Y += Font.LineSpacing;
            }
            spriteBatch.End();
        }
    }
}
