using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Regen : Enemy
	{
		/// <summary>
		/// The regen timer.
		/// </summary>
        private int _regenTimer = 100;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Regen"/> class.
		/// </summary>
        public Regen() : this(200, 200) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Regen"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Regen(float x, float y) : base(x, y, 1, 15, 5)
        {
            _speed = 1;
        }


		/// <summary>
		/// Draw this instance.
		/// </summary>
        public override void Draw()
        {
            SwinGame.FillCircle(Color.Green, _position[0], _position[1], _size);
        }


		/// <summary>
		/// Update this instance.
		/// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }


		/// <summary>
		/// Update the Regen for its cool timer, movement and health regeneration.
		/// </summary>
		/// <param name="_track">Track.</param>
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

