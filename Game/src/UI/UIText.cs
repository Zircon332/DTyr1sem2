using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class UIText : UIObject
	{
        private string _text;
        private string _drawtext;

        public UIText(float x, float y, int width, int height, string text) : base(x, y, width, height)
        {
            _drawtext = text;
        }

        public UIText(float x, float y, int width, int height, string text, int num) : base (x, y, width, height)
        {
            _text = text;
            _drawtext = text + num;
        }

        public void DrawText()
        {
            Text.DrawTextOnScreen(_drawtext, Color.Black, _x, _y);
        }

        public void DrawText(int num)
        {
            _drawtext = _text + num.ToString();
            Text.DrawTextOnScreen(_drawtext, Color.Black, _x, _y);
        }
    }
}

