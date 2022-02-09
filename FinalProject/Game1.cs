using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace FinalProject
{

    //Only one responsibility which is taking care of all the scenes and manage them
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Song song;


        //declare all scence
        private StartScene startScene;
        private HelpScene helpScence;
        private ActionScene actionScene;
        private CreditScene creditScene;

        private void hideAllScene()
        {
            foreach (GameScene item in Components)
            {
                item.hide();
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth,
              _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            startScene.show();
            this.

            helpScence = new HelpScene(this);
            this.Components.Add(helpScence);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);
            this.song = Content.Load<Song>("audio/backgroundsong");

            creditScene = new CreditScene(this);
            this.Components.Add(creditScene);

        }

        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    //hide all scene
                    //go to actionScene
                    hideAllScene();
                    actionScene = new ActionScene(this);
                    this.Components.Add(actionScene);
                    actionScene.show();

                    MediaPlayer.Play(song);
                    MediaPlayer.IsRepeating = true;

                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScene();
                    helpScence.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScene();
                    creditScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (helpScence.Enabled || actionScene.Enabled || creditScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScene();
                    startScene.show();
                    MediaPlayer.Stop();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
