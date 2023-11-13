using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NodeTesting.models
{
    public class CollisionRect
    {
        private Rectangle rect;
        private Texture2D pixel;
        private int offsetX;
        private int offsetY;

        public CollisionRect(int x, int y, int width, int height)
        {
            rect = new Rectangle(x, y, width, height);
            pixel = new Texture2D(Globals.graphics.GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            rect.Offset(-(width / 2), -(height / 2));
        }
        public Rectangle Rect { get => rect; set => rect = value; }

        /// <summary>
        /// check if the rectangle touches the other rectangle
        /// </summary>
        /// <param name="target">The target rectangle</param>
        /// <returns>true or false</returns>
        public bool Intersects(Rectangle target)
        {
            return rect.Intersects(target);
        }

        /// <summary>
        /// check if rectangle is in the rectangle
        /// </summary>
        /// <param name="target">The target rectangle</param>
        /// <returns>true or false</returns>
        public bool Contains(Rectangle target)
        {
            return rect.Contains(target);
        }

        /// <summary>
        /// check if mouse cursor is in the rectangle
        /// </summary>
        /// <param name="target">The target cursor</param>
        /// <returns>true or false</returns>
        public bool Contains(Point target)
        {
            return rect.Contains(target);
        }

        /// <summary>
        /// get rectangle position
        /// </summary>
        /// <returns>A Vector2.</returns>
        public Vector2 pos()
        {
            return new Vector2(rect.X, rect.Y);
        }

        /// <summary>
        /// Sets the offset extra.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void SetOffsetExtra(int x, int y)
        {
            offsetX = x;
            offsetY = y;
        }

        /// <summary>
        /// Updates the rect.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void UpdateRect(int x, int y)
        {
            rect.X = x;
            rect.Y = y;
            rect.Offset(-(rect.Width / 2) + offsetX, -(rect.Height / 2) + offsetY);
        }

        /// <summary>
        /// Draws the rect.
        /// </summary>
        /// <param name="color">The color.</param>
        public void DrawRect(Color color)
        {
            Globals.spriteBatch.Draw(pixel, rect, color);
        }
    }
}
