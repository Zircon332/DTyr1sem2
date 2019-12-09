using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Splitter : Enemy
	{
		/// <summary>
		/// The split timer.
		/// </summary>
        private int _splitTimer;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Splitter"/> class.
		/// </summary>
        public Splitter() : this(200, 200) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Splitter"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Splitter(float x, float y) : base(x, y, 1, 5, 1)
        {
            _speed = 2;
            _splitTimer = 60;
        }


		/// <summary>
		/// Draw this instance.
		/// </summary>
        public override void Draw()
        {
            SwinGame.FillCircle(Color.Blue, _position[0], _position[1], _size);
            
        }


		/// <summary>
		/// Update this instance.
		/// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }


		/// <summary>
		/// Update the splitter for its cool timer, movement and split timer.
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

            _splitTimer -= 1;
            if (_splitTimer <= 0)
            {
                _splitTimer = 60;
                _size += 1;
            }
        }
    }
}

