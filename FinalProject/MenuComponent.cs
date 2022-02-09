using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FinalProject 
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, hilightFont;
        private string[] menuItems;

        public int SelectedIndex { get; set; }
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color hilightColor = Color.Red;

        private KeyboardState oldstate;
        public MenuComponent(Game game , 
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont hilightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.hilightFont = hilightFont;
            menuItems = menus;
            position = new Vector2(100, 70);
        }

    
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();
             for(int i=0; i<menuItems.Length; i++)
            {
                if(SelectedIndex==i)
                {
                    spriteBatch.DrawString(hilightFont, menuItems[i], tempPos, hilightColor);
                    tempPos.Y += hilightFont.LineSpacing; 
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(Keys.Down) && oldstate.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if(SelectedIndex==menuItems.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if(ks.IsKeyDown(Keys.Up) && oldstate.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if(SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Length - 1;
                }
            }
            oldstate = ks;
            base.Update(gameTime);
        }
    }
}
