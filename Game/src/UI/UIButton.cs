using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class UIButton : UIObject
	{
		/// <summary>
		/// The text.
		/// </summary>
        private List<string> _text;
        /// <summary>
        /// The color.
        /// </summary>
		private Color _color;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIButton"/> class.
		/// </summary>
        public UIButton() : this(10, 10, 10, 10, new List<string> { "default text" }) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIButton"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="text">Text.</param>
        public UIButton(float x, float y, int width, int height, List<string> text) : base (x, y, width, height)
        {
            _text = text;
            _color = Color.AliceBlue;
        }


		/// <summary>
		/// Draws the button.
		/// </summary>
        public void DrawButton()
        {
            SwinGame.FillRectangle(_color, _x, _y, _width, _height);
            for (int i = 0; i < _text.Count; i++)
            {
                Text.DrawTextOnScreen(_text[i], Color.Black, _x+5, _y + _height/2-12/2+(10*i));
            }
            
        }

		/// <summary>
		/// Changes background color when mouse is on button.
		/// </summary>
        public void Hover()
        {
            if (SwinGame.PointInRect(SwinGame.MousePosition(), _x, _y, _width, _height))
            {
                _color = Color.LightGrey;
            }
            else
            {
                _color = Color.AliceBlue;
            }
        }


		/// <summary>
		/// Checks the click.
		/// </summary>
		/// <returns><c>true</c>, if click was checked, <c>false</c> otherwise.</returns>
        public bool CheckClick()
        {
            if (SwinGame.PointInRect(SwinGame.MousePosition(), _x, _y, _width, _height))
            {
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    return true;
                }
            }
            return false;
        }
	}
}

