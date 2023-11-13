using BasicCameraTutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NodeTesting.models;
using space_invaders.entities;
using System;

namespace space_invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private Canvas canvas;

        private Player player;
        private Alien alien;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.Content = Content;
            Globals.spriteBatch = _spriteBatch;
            Globals.graphics = _graphics;

            // TODO: use this.Content to load your game content here
            //canvas = new Canvas(_graphics.GraphicsDevice, 1280, 720);
            player = new Player();
            alien = new Alien(new Vector2(500, 500));
        }

        protected override void Update(GameTime gt)
        {
            int index = Bullet.bullets.Count;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for(int i = 0; i < index; i++)
            {
                if (alien.Rect.Intersects(Bullet.bullets[i].Rect.Rect))
                {
                    alien.Die();
                    Bullet.bullets.RemoveAt(i);
                    index--;
                }
                else if (Bullet.bullets[i].Pos.Y < 30)
                {
                    Bullet.bullets.RemoveAt(i);
                    index--;
                }
                else
                {
                    Bullet.bullets[i].Update(gt);
                }
            }

            

            player.Update(gt);
            alien.Update(gt);
            base.Update(gt);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < Bullet.bullets.Count; i++)
            {
                Bullet.bullets[i].Draw();
            }
            alien.Draw();
                player.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}