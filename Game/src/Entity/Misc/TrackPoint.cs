using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TrackPoint
	{
        private float[] _position;

        public TrackPoint(float x, float y)
        {
            _position = new float[] { x, y };
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.DarkGray, _position[0], _position[1], 5);
        }

        public float X
        {
            get { return _position[0]; }
        }

        public float Y
        {
            get { return _position[1]; }
        }
    }
}

