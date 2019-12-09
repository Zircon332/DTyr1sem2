using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Carrier : Enemy
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyGame.Carrier"/> class.
        /// </summary>
        public Carrier() : this(200, 200) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Carrier"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Carrier(float x, float y) : base(x, y, 100, 50, 20)
        {
            _speed = 1;
        }


		/// <summary>
		/// Draw this instance.
		/// </summary>
        public override void Draw()
        {
            SwinGame.FillCircle(Color.BlueViolet, _position[0], _position[1], _size);
            
        }


		/// <summary>
		/// Update this instance.
		/// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }


		/// <summary>
		/// Update the carrier for its cool timer and movement.
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
            }
        }
    }
}

