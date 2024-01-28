using Custom2d_Engine.Rendering;
using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Scenes.Events;
using Custom2d_Engine.Scenes.Factory;
using Custom2d_Engine.Ticking;
using Custom2d_Engine.Util;
using JokeToKill.Combat;
using JokeToKill.Text;
using Microsoft.Xna.Framework;
using System;

namespace JokeToKill.Cards
{
    public class CardObject : HierarchyObject, IUpdatable
    {
        public Card CurrentCard
        {
            get => currentCard;
            set
            {
                SetCard(value);
            }
        }

        public float Fade { get; set; } = 1f;

        public float Order => 0f;

        private Card currentCard;

        private DrawableObject background;
        private DrawableObject descBG;
        private DrawableTextObject desc;
        private DrawableObject foreground;
        private DrawableObject[] aspects;

        public CardObject(RenderPipeline pipeline, float drawOrder)
        {
            var cardSize = Sprites.GetSpriteSize(Sprites.CardBG);
            background = this.CreateDrawableChild(Sprites.CardBG, color: Color.White, drawOrder: drawOrder, localScale: cardSize);
            foreground = this.CreateDrawableChild(Sprite.Unlit, color: Color.PaleGoldenrod, drawOrder: drawOrder + 0.01f, 
                localScale: cardSize * new Vector2(0.9f, 0.45f), 
                localPosition: new Vector2(0f, cardSize.Y / 2f));
            
            /*descBG = this.CreateDrawableChild(Sprite.Unlit, color: Color.Gray, drawOrder: drawOrder + 0.01f,
                localScale: cardSize * new Vector2(0.9f, 0.45f),
                localPosition: new Vector2(0f, -cardSize.Y / 2f));*/

            desc = new DrawableTextObject(pipeline, Color.White, drawOrder + 0.02f);
            desc.Font = Sprites.CardFont;
            desc.Transform.LocalPosition = new Vector2(-0.9f, 0.8f);
            desc.Parent = this;

            aspects = new DrawableObject[3];
            var offset = new Vector2(0f, -cardSize.Y / 5);

            for (int i = 0; i < 3; i++)
            {
                aspects[i] = this.CreateDrawableChild(Sprite.Empty, 
                    localPosition: new Vector2(-cardSize.X, cardSize.Y) + offset * (i * 2f + 2f), 
                    localScale: new Vector2(1f));
            }

            SetDrawOrder(drawOrder);
            SetCard(null);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            /*var time = new Reference<float>();
            this.AddAccurateRepeatingAction(() =>
            {
                time.Value += MathHelper.Tau / 360f;
                //desc.Color = new Color((MathF.Cos(time) + 1f) / 2f, (MathF.Sin(time) + 1f) / 2f, 0f);
                Fade = (MathF.Sin(time) + 1) * 0.5f;
            }, 1f / 60f);*/
        }

        private void SetCard(Card card)
        {
            if (card != null)
            {
                desc.Text = card.description;
                foreground.Sprite = card.sprite;
                SetAspects(card.aspects);
            }
            else
            {
                desc.Text = "";
                foreground.Sprite = Sprite.Empty;
                ClearAspects();
            }  
            this.currentCard = card;
        }

        private void ClearAspects()
        {
            SetAspect(0, Aspects.NULL);
            SetAspect(1, Aspects.NULL);
            SetAspect(2, Aspects.NULL);
        }

        private void SetAspect(int i, Aspect aspect)
        {
            aspects[i].Sprite = aspect.Icon;
            aspects[i].Color = aspect.Tint;
            aspects[i].Transform.LocalScale = Sprites.GetSpriteSize(aspect.Icon);
        }

        private void SetAspects(Aspect[] aspects)
        {
            for (int i = 0; i < this.aspects.Length; i++)
            {
                if (i < aspects.Length)
                {
                    SetAspect(i, aspects[i]);
                }
                else
                {
                    SetAspect(i, Aspects.NULL);
                }
            }
        }

        public void SetDrawOrder(float drawOrder)
        {
            background.DrawOrder = drawOrder;
            foreground.DrawOrder = drawOrder;// + 0.01f;
            //descBG.DrawOrder = drawOrder;// + 0.01f;
            desc.DrawOrder = drawOrder;// + 0.02f;
            foreach (var aspect in aspects)
            {
                aspect.DrawOrder = drawOrder;// + 0.01f;
            }
        }

        public void Update(GameTime time)
        {
            background.Color = Color.White * Fade;
            //descBG.Color = Color.Gray * Fade;
            foreground.Color = Color.White * Fade;
            desc.Color = new Color(0xff101010) * Fade;
            if (currentCard != null)
            {
                for (int i = 0; i < currentCard.aspects.Length; i++)
                {
                    if (i > 2)
                    {
                        break;
                    }
                    aspects[i].Color = currentCard.aspects[i].Tint * Fade;
                }
            }
        }
    }
}
