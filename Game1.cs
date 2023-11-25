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
            int x = 350;
            int y = 100;
            for (int i = 0; i < 16; i++)
            {
                if(i % 8 == 0 && i > 0)
                {
                    x = 350;
                    y += 60;
                }
                Alien.aliens.Add(new Alien(new Vector2(x, y)));
                x += 80;
            }
        }

        protected override void Update(GameTime gt)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //update the things
            for (int i = 0; i < Bullet.bullets.Count; i++)
            {
                Bullet.bullets[i].Update(gt);
            }
            for (int i = 0; i < Alien.aliens.Count; i++)
            {
                Alien.aliens[i].Update(gt);
			}

            //invert if hit border
            for(int i = 0; i < Alien.aliens.Count; i++)
            {
				if (Alien.aliens[i].Pos.X > 1080)
				{
                    Alien.canGoDown = true;
					Alien.aliens.ForEach(alien => { alien.Invert = true; });
				}
				if (Alien.aliens[i].Pos.X < 200)
				{
					Alien.canGoDown = true;
					Alien.aliens.ForEach(alien => { alien.Invert = false; });
				}
			}

            if (Alien.canGoDown)
            {
                Alien.aliens.ForEach(alien => { alien.Descend(gt); });
                Alien.canGoDown = false;
            }

            // TODO: Add your update logic here
            foreach (Bullet bullet in Bullet.bullets)
            {
                if (bullet.Pos.Y < 30)
                {
                    bullet.Collided = true;
                }
                foreach (Alien alien in Alien.aliens)
                {
                    if (bullet.Rect.Intersects(alien.Rect.Rect))
                    {
                        bullet.Collided = true;
                        alien.Die();
                    }
                    
                }
            }

            Bullet.bullets.RemoveAll(b => b.Collided);
            Alien.aliens.RemoveAll(a => a.Dead);
            
            player.Update(gt);
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
            for(int i = 0; i < Alien.aliens.Count; i++)
            {
                Alien.aliens[i].Draw();
            }
                player.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}