using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Entity
	{
        protected float[] _position;
        protected int _speed;
        
        public Entity() : this(200, 200, 10) { }

        public Entity(float x, float y, int speed)
        {
            _position = new float[] {x, y};
            _speed = speed;
        }

        public abstract void Draw();

        public abstract void Update();

        public float X
        {
            get { return _position[0]; }
        }

        public float Y
        {
            get { return _position[1]; }
        }

        public int Speed
        {
            get { return _speed; }
        }

        public double EntityDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2),2));
        }
    }
}

