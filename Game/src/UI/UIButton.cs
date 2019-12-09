using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class UIButton : UIObject
	{
        private List<string> _text;
        private Color _color;

        public UIButton() : this(10, 10, 10, 10, new List<string> { "default text" }) { }

        public UIButton(float x, float y, int width, int height, List<string> text) : base (x, y, width, height)
        {
            _text = text;
            _color = Color.AliceBlue;
        }

        public void DrawButton()
        {
            SwinGame.FillRectangle(_color, _x, _y, _width, _height);
            for (int i = 0; i < _text.Count; i++)
            {
                Text.DrawTextOnScreen(_text[i], Color.Black, _x+5, _y + _height/2-12/2+(10*i));
            }
            
        }

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

