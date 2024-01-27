using Custom2d_Engine.Input;
using Custom2d_Engine.Math;
using Custom2d_Engine.Rendering;
using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Rendering.Sprites.Atlas;
using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Scenes.Drawable.Lights;
using Custom2d_Engine.Scenes.Events;
using Custom2d_Engine.Ticking;
using Custom2d_Engine.TMX;
using Custom2d_Engine.Util;
using JokeToKill.Cards;
using JokeToKill.Combat;
using JokeToKill.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using nkast.Aether.Physics2D.Dynamics;
using System;
using System.Collections.Generic;

namespace JokeToKill
{
    public class JokeGame : Game
    {
        public const int ScreenWidth = 1024;
        public const int ScreenHeight = 768;

        private RenderPipeline RenderPipeline;
        private SpriteAtlas<Color> SpriteAtlas;
        private Hierarchy MainHierarchy;
        private TickManager TickManager;
        private Camera Camera;
        private World PhysicsWorld;
        private InputManager InputManager;

        public JokeGame()
        {
            var _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            InitSystems();
            
            LoadSprites();
            
            InitPhysics();
            InitHierarchy();
        }

        private void InitSystems()
        {
            Effects.Init(Content);
            Effects.Default.CurrentTechnique = Effects.Default.Techniques["Lit"];
            RenderPipeline = new RenderPipeline();
            RenderPipeline.Init(GraphicsDevice, ScreenWidth, ScreenHeight);
            TickManager = new TickManager();
            InputManager = new InputManager(Window);
        }

        private void LoadSprites()
        {
            SpriteAtlas = new SpriteAtlas<Color>(GraphicsDevice, 2048, 2);
            SpriteAtlas.SetBaseColor(0, Color.Black);
            SpriteAtlas.SetBaseColor(1, new Color(128, 255, 128));
            var Loader = new SpriteAtlasLoader<Color>(Content, SpriteAtlas, "albedo", "normal", "emit");

            // Load Sprites Here
            Sprites.Init(Content, Loader);
            Aspects.Init();
            Cards.Cards.Init();

            LoadTMX(Loader);

            SpriteAtlas.Compact();
            var textures = SpriteAtlas.AtlasTextures;
            RenderPipeline.SetLitAtlases(textures[0], textures[1], textures[2]);
        }

        private void LoadTMX(SpriteAtlasLoader<Color> SALoader)
        {
            var Loader = new TMXLoader<Color>(Content, SALoader);

            //Load TMX Maps here
        }

        private void InitPhysics()
        {
            PhysicsWorld = new World();

            //Do init here
        }

        private void InitHierarchy()
        {
            MainHierarchy = new Hierarchy(TickManager);
            Camera = new Camera();
            Camera.ViewSize = 5f;
            Camera.AspectRatio = ScreenWidth / (float)ScreenHeight;
            
            MainHierarchy.AddObject(Camera);

            MainHierarchy.AddObject(new GlobalLight(RenderPipeline, Color.White, 0f)
            {
                Intensity = 1f,
                LightHeight = 0f
            });

            var cards = new CardsObject(InputManager, Camera, RenderPipeline);
            cards.DrawHand();
            MainHierarchy.AddObject(cards);

            var minotaur = new DrawableObject(Color.White, 0f);
            minotaur.Transform.GlobalPosition = new Vector2(3f, 3f);
            minotaur.Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 2f;
            MainHierarchy.AddObject(minotaur);
            minotaur.AnimateUnsynced(Sprites.MonsterMinotaur, 0.1f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.UpdateState();

            MainHierarchy.BeginUpdate();
            foreach (var upd in MainHierarchy.OrderedInstancesOf<IUpdatable>())
            {
                upd.Update(gameTime);
            }
            MainHierarchy.EndUpdate();

            TickManager.Forward(gameTime.ElapsedGameTime);
            PhysicsWorld.Step(gameTime.ElapsedGameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            RenderPipeline.RenderScene(MainHierarchy, Camera, Color.DarkGray);

            base.Draw(gameTime);
        }
    }
}
