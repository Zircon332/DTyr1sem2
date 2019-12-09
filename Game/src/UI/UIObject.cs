using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class UIObject
	{
        protected float _x;
        protected float _y;
        protected int _width;
        protected int _height;

        public UIObject() : this(10, 10, 10, 10) { }

        public UIObject(float x, float y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
	}
}

