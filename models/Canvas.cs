using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NodeTesting.models;
using System;

namespace BasicCameraTutorial;

public class Canvas
{
    private readonly RenderTarget2D _target;
    private readonly GraphicsDevice _graphicsDevice;
    private Rectangle _destinationRectangle;

    public Canvas(GraphicsDevice graphicsDevice, int width, int height)
    {
        _graphicsDevice = graphicsDevice;
        _target = new(_graphicsDevice, width, height);
    }

    /// <summary>
    /// Sets the destination rectangle.
    /// </summary>
    public void SetDestinationRectangle()
    {
        //gets the size of screen
        var screenSize = _graphicsDevice.PresentationParameters.Bounds;

        //this substract screen width width with target width
        float scaleX = (float)screenSize.Width / _target.Width;
        float scaleY = (float)screenSize.Height / _target.Height;
        float scale = Math.Min(scaleX, scaleY); //get the smaller one of the two
        //multiply with scale, now it can grow
        int newWidth = (int)(_target.Width * scale); 
        int newHeight = (int)(_target.Height * scale);
        //substract screen with new screen / 2
        int posX = (screenSize.Width - newWidth) / 2;
        int posY = (screenSize.Height - newHeight) / 2;

        _destinationRectangle = new Rectangle(posX, posY, newWidth, newHeight);
    }

    /// <summary>
    /// Activates the canvas, this should be paired with Draw() after SpriteBatch.End()
    /// </summary>
    public void Activate()
    {
        _graphicsDevice.SetRenderTarget(_target);
        _graphicsDevice.Clear(Color.DarkGray);
    }

    /// <summary>
    /// Draws the canvas to the screen
    /// </summary>
    /// <param name="spriteBatch">The spriteBatch class</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        _graphicsDevice.SetRenderTarget(null);
        _graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin();
        spriteBatch.Draw(_target, _destinationRectangle, Color.White);
        spriteBatch.End();
    }

    /// <summary>
    /// Sets the resolution.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public void SetResolution(int width, int height)
    {
        Globals.graphics.PreferredBackBufferWidth = width;
        Globals.graphics.PreferredBackBufferHeight = height;
        Globals.graphics.ApplyChanges();
        SetDestinationRectangle();
    }
}
