using CardCeption;
using Microsoft.Xna.Framework;
using NodeTesting.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_invaders.entities
{
    public class Bullet
    {
        private Vector2 pos;
        private int speed = 600;
        public static List<Bullet> bullets = new List<Bullet>();
        private SpriteAnimation anim;
        private CollisionRect rect;

        public Vector2 Pos { get => pos; set => pos = value; }
        public CollisionRect Rect { get => rect; set => rect = value; }

        public Bullet(Vector2 pos)
        {
            rect = new CollisionRect((int)pos.X, (int)pos.Y, 4, 20);
            anim = new SpriteAnimation("bullet", 2, 4);
            this.pos = pos;
        }

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            pos.Y -= speed * dt;

            rect.UpdateRect((int)pos.X, (int)pos.Y);
            anim.Position = pos;
            anim.Update(gt);
        }

        public void Draw()
        {
            anim.Draw(Globals.spriteBatch);
        }
    }
}
