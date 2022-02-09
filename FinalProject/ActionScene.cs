using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace FinalProject
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D texBG;

        private Player player;
        private Accident accident;

        private Car car1;
        private Car car2;
        private Car car3;
        private Car car4;

        private string[] carsLtoR = { "car3", "car4", "car7", "car8", "car12" };
        private string[] carsRtoL = { "car1", "car2", "car5", "car9", "car10", "car11" };

        Vector2 position1;
        Vector2 position2;
        Vector2 position3;
        Vector2 position4;

        Texture2D texCar1;
        Texture2D texCar2;
        Texture2D texCar3;
        Texture2D texCar4;

        Vector2 speed1;
        Vector2 speed2;
        Vector2 speed3;
        Vector2 speed4;

        int minSpeed = 5;
        int maxSpeed = 18;

        Random r = new Random();

        Game1 g;
        Score score;
        Score winMessage;
        Score LoseMessage;
        Score lives;

        SpriteFont font;
        SpriteFont fontScore;

        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;

            this.texBG = g.Content.Load<Texture2D>("images/Background");

            speed1 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            texCar1 = g.Content.Load<Texture2D>($"images/{carsRtoL[new Random().Next(0, carsRtoL.Length - 1)]}");
            position1 = new Vector2((Shared.stage.X + texCar1.Width), (350));
            car1 = new Car(game, spriteBatch, texCar1, position1, speed1);
            this.Components.Add(car1);


            speed2 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            texCar2 = g.Content.Load<Texture2D>($"images/{carsRtoL[new Random().Next(0, carsRtoL.Length - 1)]}");
            position2 = new Vector2((Shared.stage.X + texCar2.Width), (390));
            car2 = new Car(game, spriteBatch, texCar2, position2, speed2);
            this.Components.Add(car2);


            speed3 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            texCar3 = g.Content.Load<Texture2D>($"images/{carsLtoR[new Random().Next(0, carsRtoL.Length - 1)]}");
            position3 = new Vector2((0 - texCar3.Width), (220));
            car3 = new Car(game, spriteBatch, texCar3, position3, -speed3);
            this.Components.Add(car3);


            speed4 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            texCar4 = g.Content.Load<Texture2D>($"images/{carsLtoR[new Random().Next(0, carsRtoL.Length - 1)]}");
            position4 = new Vector2((0 - texCar4.Width), (263));
            car4 = new Car(game, spriteBatch, texCar4, position4, -speed4);
            this.Components.Add(car4);


            Texture2D texPlayer = g.Content.Load<Texture2D>("images/player");
            player = new Player(game, spriteBatch, texPlayer);
            this.Components.Add(player);

            SoundEffect hitSound = g.Content.Load<SoundEffect>("audio/losingbell");

            font = g.Content.Load<SpriteFont>("fonts/hilightFont");
            fontScore = g.Content.Load<SpriteFont>("fonts/messageFont");

            string loseMessage = "";
            this.LoseMessage = new Score(game, spriteBatch, font, loseMessage, Vector2.Zero, Color.Red);
            this.Components.Add(this.LoseMessage);

            string live = "Lives: " + "3";
            lives = new Score(game, spriteBatch, fontScore, live, new Vector2(690, 10), Color.DimGray);
            this.Components.Add(lives);

            Texture2D tex = game.Content.Load<Texture2D>("images/ghosts");
            accident = new Accident(game, spriteBatch, tex, Vector2.Zero, 3);
            this.Components.Add(accident);

            CollisionManager cm1 = new CollisionManager(game, car1, player, hitSound, accident, LoseMessage, lives);
            this.Components.Add(cm1);
            CollisionManager cm2 = new CollisionManager(game, car2, player, hitSound, accident, LoseMessage, lives);
            this.Components.Add(cm2);
            CollisionManager cm3 = new CollisionManager(game, car3, player, hitSound, accident, LoseMessage, lives);
            this.Components.Add(cm3);
            CollisionManager cm4 = new CollisionManager(game, car4, player, hitSound, accident, LoseMessage, lives);
            this.Components.Add(cm4);


            string message = "SCORE:"+ 0 ;
            score = new Score(game, spriteBatch , font, message, new Vector2(20, 10), Color.DimGray);
            this.Components.Add(score);


            string winMessage = "";
            this.winMessage = new Score(game, spriteBatch, font, winMessage, Vector2.Zero, Color.DarkBlue);
            this.Components.Add(this.winMessage);          
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texBG, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


        public override void Update(GameTime gameTime)
        {

            if (car1.Position.X < 0 - car1.Tex.Width)
            {
                car1.Position = position1;
                car1.Tex = g.Content.Load<Texture2D>($"images/{carsRtoL[new Random().Next(0, carsRtoL.Length - 1)]}");
                speed1 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            }
            if (car2.Position.X < 0 - texCar2.Width)
            {
                car2.Position = position2;
                car2.Tex = g.Content.Load<Texture2D>($"images/{carsRtoL[new Random().Next(0, carsRtoL.Length - 1)]}");
                speed2 = new Vector2(r.Next(minSpeed, maxSpeed), 0);
            }

            if (car3.Position.X > Shared.stage.X)
            {
                car3.Position = position3;
                car3.Tex = g.Content.Load<Texture2D>($"images/{carsLtoR[new Random().Next(0, carsRtoL.Length - 1)]}");
                car3.Speed = -(new Vector2(r.Next(minSpeed, maxSpeed), 0));
            }
            if (car4.Position.X > Shared.stage.X)
            {
                car4.Position = position4;
                car4.Tex = g.Content.Load<Texture2D>($"images/{carsLtoR[new Random().Next(0, carsRtoL.Length - 1)]}");
                car4.Speed = -(new Vector2(r.Next(minSpeed, maxSpeed), 0));
            }


            if (player.Position.Y <= 390 && player.Position.Y > 325)
                score.Message = "SCORE: " + 500 ;

           else if (player.Position.Y <= 325 && player.Position.Y > 260)
            score.Message = "SCORE: " + 1000 ;

           else if (player.Position.Y <= 260 && player.Position.Y > 200)
                score.Message = "SCORE: " + 1500 ;

            else if (player.Position.Y <= 200)
            {
                score.Message = "SCORE: " + 3000 ;
                player.Enabled = false;

                winMessage.Position = new Vector2(250, 120);
                winMessage.Message = "           WINNER \n You have scored 3000 \n\n To play again press Esc" ;

            }


           
            if(CollisionManager.Life != 0)
            {
                KeyboardState k = Keyboard.GetState();
                if (k.IsKeyDown(Keys.Enter))
                {
                    LoseMessage.Message = "";
                    player.Enabled = true;
                }
            }

            base.Update(gameTime);
        }
    }
}
