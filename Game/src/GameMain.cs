using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            // Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            // SwinGame.ShowSwinGameSplashScreen();


            Scene scene = new Scene();
            // Run the game loop
            while (SwinGame.WindowCloseRequested() == false)
            {
                SwinGame.ProcessEvents();           // Fetch the next batch of UI interaction
                SwinGame.ClearScreen(Color.White);  // Clear the screen

                scene.Update();
                
                SwinGame.RefreshScreen(60);         // Draw onto the screen
            }
        }
    }
}