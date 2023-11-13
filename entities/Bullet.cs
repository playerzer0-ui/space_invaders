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
        private int speed = 200;
        public static List<Bullet> bullets;
        private SpriteAnimation anim;

        public Bullet(Vector2 pos)
        {
            bullets = new List<Bullet>();
            anim = new SpriteAnimation("bullet", 2, 4);
            this.pos = pos;
        }

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            pos.Y -= speed * dt;

            anim.Position = pos;
            anim.Update(gt);
        }

        public void Draw()
        {
            anim.Draw(Globals.spriteBatch);
        }
    }
}
