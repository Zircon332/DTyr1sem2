using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TopBar : UIObject
	{
		/// <summary>
		/// The health text.
		/// </summary>
        private UIText _healthText;
        /// <summary>
        /// The points text.
        /// </summary>
		private UIText _pointsText;
        /// <summary>
        /// The round text.
        /// </summary>
		private UIText _roundText;
        /// <summary>
        /// The background.
        /// </summary>
		private Color _background;


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.TopBar"/> class.
		/// </summary>
		/// <param name="health">Health.</param>
		/// <param name="point">Point.</param>
        public TopBar(int health, int point) : base (0, 0, SwinGame.ScreenWidth(), 40)
        {
            _healthText = new UIText(20, 20, 20, 50, "Health: ", health);
            _pointsText = new UIText(140, 20, 20, 50, "Points: ", point);
            _roundText = new UIText(300, 20, 20, 50, "Round: ", 0);
            _background = Color.Tan;
        }


		/// <summary>
		/// Draw the specified health, point and roundnum.
		/// </summary>
		/// <param name="health">Health.</param>
		/// <param name="point">Point.</param>
		/// <param name="roundnum">Roundnum.</param>
        public void Draw(int health, int point, int roundnum)
        {
            SwinGame.FillRectangle(_background, _x, _y, _width, _height);
            _healthText.DrawText(health);
            _pointsText.DrawText(point);
            _roundText.DrawText(roundnum);
        }
	}
}

