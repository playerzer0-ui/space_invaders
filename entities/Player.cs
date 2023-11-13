using CardCeption;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NodeTesting.models;

namespace space_invaders.entities
{
    public class Player
    {
        private Vector2 pos;
        private SpriteAnimation anim;
        private int speed = 200;

        public Player()
        {
            anim = new SpriteAnimation("player", 5, 4);
            pos = new Vector2(640, 630);
        }

        public Vector2 Pos { get => pos; set => pos = value; }
        public SpriteAnimation Anim { get => anim; set => anim = value; }

        public void Update(GameTime gt)
        {
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Right) && pos.X < 1216)
            {
                pos.X += speed * dt;
            }
            if (kState.IsKeyDown(Keys.Left) && pos.X > 64)
            {
                pos.X -= speed * dt;
            }

            anim.Position = pos;
            
            //anim.Update(gt);
        }

        public void Draw()
        {
            anim.Draw(Globals.spriteBatch);
        }

    }
}
