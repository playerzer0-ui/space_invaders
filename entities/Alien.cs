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

        private bool invert = false;
        private bool collided = false;
        private bool dead = false;

        public static bool canGoDown = false;
        public static List<Alien> aliens = new List<Alien>();

        private float moveTimer = 0.5f;
        private float maxMoveTimer = 0.5f;

        private float downTimer = 0.5f;
        private float maxDownTimer = 0.5f;

        private float dieTimer = 1f;
        private float maxDieTimer = 1f;


        public CollisionRect Rect { get => rect; set => rect = value; }
        public Vector2 Pos { get => pos; set => pos = value; }

        public bool Collided { get => collided; set => collided = value; }
        public bool Dead { get => dead; set => dead = value; }
        public bool Invert { get => invert; set => invert = value; }

        public Alien(Vector2 pos) 
        {
            this.pos = pos;
            rect = new CollisionRect((int)pos.X, (int)pos.Y, 46, 25);
            anims[0] = new SpriteAnimation("alien1", 2, 2);
            anims[1] = new SpriteAnimation("alien_die", 2, 2);

            anim = anims[0];
        }

        public void Descend(GameTime gt)
        {
			float dt = (float)gt.ElapsedGameTime.TotalSeconds;

            downTimer -= dt;

            if(downTimer < 0)
            {
                pos.Y += 60;
                downTimer = maxDownTimer;
                canGoDown = false;
            }
		}

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;

            if (collided)
            {
                rect.SetOffsetExtra(-200, -200);

                dieTimer -= dt;
                if (dieTimer < 0)
                {
                    dead = true;
                    dieTimer = maxDieTimer;
                }
            }
            else
            {
                if (!canGoDown)
                {
					moveTimer -= dt;

					if (moveTimer < 0)
					{
						if (invert)
						{
							pos.X -= 20;

						}
						else
						{
							pos.X += 20;

						}
						moveTimer = maxMoveTimer;
					}
				}
			}

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
            if (!collided)
            {
                collided = true;
                anim = anims[1];
            }
        }
    }
}
