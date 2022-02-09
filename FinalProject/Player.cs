using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class Player : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 firstPosition;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 FirstPosition { get => firstPosition; set => firstPosition = value; }

        public Player(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2((Shared.stage.X - tex.Width) / 2, 
                Shared.stage.Y - tex.Height);
            firstPosition = position;
            this.speed = new Vector2(2, 2);
        }



        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                position.X -= speed.X;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position.X += speed.X;
                if (position.X > Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position.Y -= speed.Y;
                if (position.Y < Shared.stage.Y/3 )
                {
                    position.Y = Shared.stage.Y / 3 ;
                   
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position.Y += speed.Y;
                if (position.Y > Shared.stage.Y - tex.Height)
                {
                    position.Y = Shared.stage.Y - tex.Height;

                }
            }

            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}
