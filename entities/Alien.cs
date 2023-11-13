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
    public class Alien
    {
        private Vector2 pos;
        private SpriteAnimation[] anims = new SpriteAnimation[2];
        private SpriteAnimation anim;
        private CollisionRect rect;
        public static List<Alien> aliens = new List<Alien>();

        private int moveTimer = 1;
        private intmaxMoveTimer = 1;


        public CollisionRect Rect { get => rect; set => rect = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        public Alien(Vector2 pos) 
        {
            this.pos = pos;
            rect = new CollisionRect((int)pos.X, (int)pos.Y, 46, 25);
            anims[0] = new SpriteAnimation("alien1", 2, 2);
            anims[1] = new SpriteAnimation("alien_die", 2, 2);

            anim = anims[0];
        }

        public void Update(GameTime gt)
        {

            rect.UpdateRect((int)pos.X, (int)pos.Y);
            anim.Position = pos;
            anim.Update(gt);
        }

        public void Draw()
        {
            anim.Draw(Globals.spriteBatch);
        }

        public void Die()
        {
            anim = anims[1];
        }
    }
}
