using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Spiked : Enemy
	{
		/// <summary>
		/// The angle.
		/// </summary>
        private int _angle;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Spiked"/> class.
		/// </summary>
        public Spiked() : this(200, 200) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Spiked"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Spiked(float x, float y) : base(x, y, 10, 10, 1)
        {
            _speed = 2;
        }


		/// <summary>
		/// Draw this instance.
		/// </summary>
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


		/// <summary>
		/// Update this instance.
		/// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }


		/// <summary>
		/// Update the Spiked enemy for its cool timer, angle or rotation and movement.
		/// </summary>
		/// <param name="_track">Track.</param>
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

