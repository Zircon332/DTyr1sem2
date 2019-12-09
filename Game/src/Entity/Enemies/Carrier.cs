using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Carrier : Enemy
	{
        
        public Carrier() : this(200, 200) { }

        public Carrier(float x, float y) : base(x, y, 100, 50, 20)
        {
            _speed = 1;
        }


        public override void Draw()
        {
            SwinGame.FillCircle(Color.BlueViolet, _position[0], _position[1], _size);
            
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

