using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }

        private Texture2D startTex;

        private SpriteBatch spriteBatch;

        string[] menuItem = {"Start Game",
                             "Help",
                             "Credit",
                             "Quit"};
        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g._spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("fonts/regularFont");
            SpriteFont hilightFont = g.Content.Load<SpriteFont>("fonts/hilightFont");

            Menu = new MenuComponent(game , spriteBatch,regularFont,hilightFont,menuItem);
            this.Components.Add(Menu);


            startTex = g.Content.Load<Texture2D>("images/menuPicture");
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(startTex, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
