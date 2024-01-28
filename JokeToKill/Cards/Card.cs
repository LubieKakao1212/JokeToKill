﻿using Custom2d_Engine.FMOD_Audio;
using Custom2d_Engine.Rendering.Sprites;
using JokeToKill.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Cards
{
    public class Card
    {
        public Aspect[] aspects;
        public string description;
        public Sprite sprite;
        public FSound voice;

        public Card(string description, Sprite sprite, FSound voice, params Aspect[] aspects)
        {
            this.aspects = aspects;
            this.description = description;
            this.sprite = sprite;
            this.voice = voice;
        }
    }
}
