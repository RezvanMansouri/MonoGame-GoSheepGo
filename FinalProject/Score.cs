using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        //protected
        protected string message;
        private SpriteFont font;
        //protected
        protected Vector2 position;
        private Color color;

        public Score(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            string message,
            Vector2 position,
            Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message;
            this.position = position;
            this.color = color;
        }

        public string Message { get => message; set => message = value; }
        public Vector2 Position { get => position; set => position = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
          
            base.Update(gameTime);

        }
    }
}
