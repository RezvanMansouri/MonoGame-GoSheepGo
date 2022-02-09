using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace FinalProject
{
    public class CollisionManager : GameComponent
    {
        private Car car;
        private Player player;
        private SoundEffect hitSound;
        private Accident accident;
        private static int life;
        private Score lostMsg;
        private Score lives;


        public static int Life { get => life; set => life = value; }

        public CollisionManager(Game game,
            Car car,
            Player player,
            SoundEffect hitsound,
            Accident accident,
            Score msg,
            Score lives) : base(game)
        {
            this.car = car;
            this.player = player;
            this.hitSound = hitsound;
            this.accident = accident;
            life = Shared.life;
            this.lostMsg = msg;
            this.lives = lives;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle CarRect = car.getBounds();
            Rectangle playerRect = player.getBounds();

            if (CarRect.Intersects(playerRect))
            {
                accident.Position = player.Position;
                life= life -1;
                hitSound.Play();
                player.Position = player.FirstPosition;
                accident.restart();

                lives.Message = "Lives: " + life;
                lives.Position = new Vector2(690, 0);

                if (life == 0)
                {
                    player.Position = new Vector2(+10000, +10000);
                    player.Enabled = false;
                    MediaPlayer.Stop();
                    lostMsg.Message = "      You Have LOST! \n \nTo play again press Esc";
                    lostMsg.Position = new Vector2(250,170);
                }
                else
                {
                    player.Enabled = false;
                    lostMsg.Message = $"          Oh,NO! \n  You still have {life} life!\n\nTo continue press Enter";
                    lostMsg.Position = new Vector2(250, 170);
                }
            }
            base.Update(gameTime);
        }

    }
}

