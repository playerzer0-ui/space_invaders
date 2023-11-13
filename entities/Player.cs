using CardCeption;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NodeTesting.models;
using System.Threading;

namespace space_invaders.entities
{
    public class Player
    {
        private Vector2 pos;
        private SpriteAnimation anim;
        private int speed = 200;
        private float shootTimer = 0;
        private float maxShootTimer = 1;
        private CollisionRect rect;

        public Player()
        {
            rect = new CollisionRect((int)pos.X, (int)pos.Y, 60, 10);
            anim = new SpriteAnimation("player", 5, 4);
            pos = new Vector2(640, 630);
        }

        public Vector2 Pos { get => pos; set => pos = value; }
        public SpriteAnimation Anim { get => anim; set => anim = value; }

        public void Update(GameTime gt)
        {
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;

            ShootBullet(gt, kState);

            if (kState.IsKeyDown(Keys.Right) && pos.X < 1216)
            {
                pos.X += speed * dt;
            }
            if (kState.IsKeyDown(Keys.Left) && pos.X > 64)
            {
                pos.X -= speed * dt;
            }
            

            //oState = kState;
            anim.Position = pos;
            rect.UpdateRect((int)pos.X, (int)pos.Y);
            rect.SetOffsetExtra(0, 5);
            //anim.Update(gt);
        }

        public void ShootBullet(GameTime gt, KeyboardState kState)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;

            shootTimer -= dt;
            if(shootTimer < 0)
            {
                if (kState.IsKeyDown(Keys.Space))
                {
                    Bullet.bullets.Add(new Bullet(new Vector2(pos.X, pos.Y - 20)));
                    shootTimer = maxShootTimer;
                }
            }
        }

        public void Draw()
        {
            anim.Draw(Globals.spriteBatch);
            rect.DrawRect(new Color(255, 0, 0, 128));
        }

    }
}
