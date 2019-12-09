using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Splitter : Enemy
	{
        private int _splitTimer;

        public Splitter() : this(200, 200) { }

        public Splitter(float x, float y) : base(x, y, 1, 5, 1)
        {
            _speed = 2;
            _splitTimer = 60;
        }


        public override void Draw()
        {
            SwinGame.FillCircle(Color.Blue, _position[0], _position[1], _size);
            
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

            _splitTimer -= 1;
            if (_splitTimer <= 0)
            {
                _splitTimer = 60;
                _size += 1;
            }
        }
    }
}

