using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Regen : Enemy
	{
        private int _regenTimer = 100;

        public Regen() : this(200, 200) { }

        public Regen(float x, float y) : base(x, y, 1, 15, 5)
        {
            _speed = 1;
        }


        public override void Draw()
        {
            SwinGame.FillCircle(Color.Green, _position[0], _position[1], _size);
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

                _size = 15 -  (5 - _health);

                _regenTimer -= 1;
                if (_regenTimer <= 0)
                {
                    _regenTimer = 100;
                    if (_health != 5)
                    {
                        _health += 1;
                    }
                }
            }
        }
	}
}

