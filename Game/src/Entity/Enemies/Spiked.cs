using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Spiked : Enemy
	{
        private int _angle;

        public Spiked() : this(200, 200) { }

        public Spiked(float x, float y) : base(x, y, 10, 10, 1)
        {
            _speed = 2;
        }


        public override void Draw()
        {
            SwinGame.FillCircle(Color.White, _position[0], _position[1], _size);

            for (int angle = _angle; angle < 360+_angle; angle += 51)
            {
                float pointAx = 10 * SwinGame.Cosine(angle - 30) + _position[0];
                float pointAy = 10 * SwinGame.Sine(angle - 30) + _position[1];
                float pointBx = 10 * SwinGame.Cosine(angle + 30) + _position[0];
                float pointBy = 10 * SwinGame.Sine(angle + 30) + _position[1];
                float pointCx = 15 * SwinGame.Cosine(angle) + _position[0];
                float pointCy = 15 * SwinGame.Sine(angle) + _position[1];
                SwinGame.FillTriangle(Color.White, pointAx, pointAy, pointBx, pointBy, pointCx, pointCy);
            }
            
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }


        public override void Update(Track _track)
        {
            CoolTimer();

            _angle += 1;

            if (_pointsReached != _track.Points.Count)
            {
                double distanceFromNextPoint = EntityDistance(_track.Points[_pointsReached].X, _track.Points[_pointsReached].Y, _position[0], _position[1]);
                Move(_track.Points[_pointsReached].X, _track.Points[_pointsReached].Y);

                if (distanceFromNextPoint < _speed)
                {
                    _pointsReached += 1;
                }
            }
        }
	}
}

