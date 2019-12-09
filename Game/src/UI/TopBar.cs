using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TopBar : UIObject
	{
        private UIText _healthText;
        private UIText _pointsText;
        private UIText _roundText;
        private Color _background;

        public TopBar(int health, int point) : base (0, 0, SwinGame.ScreenWidth(), 40)
        {
            _healthText = new UIText(20, 20, 20, 50, "Health: ", health);
            _pointsText = new UIText(140, 20, 20, 50, "Points: ", point);
            _roundText = new UIText(300, 20, 20, 50, "Round: ", 0);
            _background = Color.Tan;
        }

        public void Draw(int health, int point, int roundnum)
        {
            SwinGame.FillRectangle(_background, _x, _y, _width, _height);
            _healthText.DrawText(health);
            _pointsText.DrawText(point);
            _roundText.DrawText(roundnum);
        }
	}
}

