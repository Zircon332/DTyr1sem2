using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class UIText : UIObject
	{
		/// <summary>
		/// The text.
		/// </summary>
        private string _text;
        /// <summary>
        /// The text to draw.
        /// </summary>
		private string _drawtext;


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIText"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="text">Text.</param>
        public UIText(float x, float y, int width, int height, string text) : base(x, y, width, height)
        {
            _drawtext = text;
        }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIText"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="text">Text.</param>
		/// <param name="num">Number.</param>
        public UIText(float x, float y, int width, int height, string text, int num) : base (x, y, width, height)
        {
            _text = text;
            _drawtext = text + num;
        }


		/// <summary>
		/// Draws the text.
		/// </summary>
        public void DrawText()
        {
            Text.DrawTextOnScreen(_drawtext, Color.Black, _x, _y);
        }


		/// <summary>
		/// Draws the text.
		/// </summary>
		/// <param name="num">Number.</param>
        public void DrawText(int num)
        {
            _drawtext = _text + num.ToString();
            Text.DrawTextOnScreen(_drawtext, Color.Black, _x, _y);
        }
    }
}

