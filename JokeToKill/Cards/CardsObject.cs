﻿using Custom2d_Engine.Input;
using Custom2d_Engine.Rendering;
using Custom2d_Engine.Scenes;
using JokeToKill.Combat;
using JokeToKill.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Cards
{
    public class CardsObject : HierarchyObject
    {
        private CardObject[] cards = new CardObject[Constants.CardCount];
        private SoftMoveObject[] cardMovers = new SoftMoveObject[Constants.CardCount];
        private DDObject dragger;
        private Camera camera;
        private InputManager inputManager;
        private int currentIdx = -1;
        private Deck deck = new Deck(Cards.AllCards, 2);

        public CardsObject(InputManager inputManager, Camera camera, RenderPipeline pipeline) 
        {
            this.camera = camera;
            this.inputManager = inputManager;
            dragger = new DDObject(inputManager, camera);
            dragger.Parent = this;

            for (int i=0; i<Constants.CardCount; i++)
            {
                cards[i] = new CardObject(pipeline, Constants.CardDrawOrder);
                cards[i].Parent = this;
                cardMovers[i] = new SoftMoveObject(cards[i]);
                cardMovers[i].Parent = this;
                cardMovers[i].Speed = 0.5f;
            }

            var click = inputManager.GetMouse(MouseButton.Left);
            click.Started += (_) => OnClick();
            click.Canceled += (_) => OnUnclick();

            var rc = inputManager.GetMouse(MouseButton.Right);
            rc.Started += (_) => ResetPositions(true);

            ResetPositions(true);
            DrawHand();
        }

        protected virtual Card GetNextCard()
        {
            return deck.Get();
        }

        public void DrawHand()
        {
            for (int i = 0; i < cards.Length; i++) 
            {
                DrawCard(i);
            }
        }

        private void DrawCard(int i)
        {
            cards[i].CurrentCard = GetNextCard();
        }

        private void ResetPositions(bool animateDraw)
        {
            for (int i = 0; i < cards.Length; i++) 
            {
                ResetPosition(i, animateDraw);
            }
        }

        private void ResetPosition(int i, bool animateDraw)
        {
            var count = Constants.CardCount;
            var viewSize = Constants.CamSize * 2f;

            var space = viewSize / count;

            var pos = (i + 0.5f) * space - Constants.CamSize;

            if (dragger.AttachedObject != null)
            {
                dragger.Detach();
            }

            if (animateDraw)
            {
                cards[i].Transform.GlobalPosition = new Vector2(pos, Constants.CardsDrawOrigin.Y);
                cardMovers[i].Reset();
            }

            cardMovers[i].Transform.GlobalPosition = new Vector2(pos, Constants.CardsPosY);
            //cards[i].SetDrawOrder(Constants.CardDrawOrder);
        }

        public void OnClick()
        {
            var pos = camera.ScreenToWorld(inputManager.CursorPosition.GetCurrentValue<Point>());

            if (MathF.Abs(pos.X) > Constants.CamSize)
            {
                return;
            }

            if(pos.Y > Constants.CardsPosY + Sprites.GetSpriteSize(Sprites.CardBG).Y / 2f)
            {
                return;
            }

            var zone = pos.X * (Constants.CardCount / Constants.CamSize) / 2f;

            int idx;
            if((Constants.CardCount & 1) == 0)
            {
                idx = (int)MathF.Floor(zone) + Constants.CardCount / 2;
            }
            else
            {
                idx = (int)MathF.Round(zone) + Constants.CardCount / 2;
            }

            //cards[idx].SetDrawOrder(Constants.CardDrawOrder + 1f);
            dragger.Attach(cardMovers[idx]);
            cardMovers[idx].Transform.LocalPosition = Vector2.Zero;
            currentIdx = idx;
        }

        public void OnUnclick()
        {
            if (currentIdx < 0)
            {
                return;
            }
            var card = cards[currentIdx];
            if (card.Transform.GlobalPosition.Y < -1f)
            {
                ResetPosition(currentIdx, false);
            }
            else
            {
                Console.Out.WriteLine("Played a card");
                CombatManager.HandleCardPlayed(card.CurrentCard);
                DrawCard(currentIdx);
                ResetPosition(currentIdx, true);
            }

            currentIdx = -1;
        }
    }
}
