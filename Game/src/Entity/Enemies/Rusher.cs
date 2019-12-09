using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Rusher : Enemy
	{
        public Rusher() : this(200, 200) { }

        public Rusher(float x, float y) : base(x, y, 1, 10, 1)
        {
            _speed = 5;
        }
        

        public override void Draw()
        {
            SwinGame.FillCircle(Color.Yellow, _position[0], _position[1], _size);
        }


        public override void Update()
        {
            throw new NotImplementedException();
        }


        public override void Update(Track _track)
        {
            CoolTimer();

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

