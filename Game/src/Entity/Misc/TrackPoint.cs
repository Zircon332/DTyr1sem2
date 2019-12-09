using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TrackPoint
	{
		/// <summary>
		/// The position.
		/// </summary>
        private float[] _position;


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.TrackPoint"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public TrackPoint(float x, float y)
        {
            _position = new float[] { x, y };
        }

		/// <summary>
		/// Draw this instance.
		/// </summary>
        public void Draw()
        {
            SwinGame.FillCircle(Color.DarkGray, _position[0], _position[1], 5);
        }

		/// <summary>
		/// Gets the x.
		/// </summary>
		/// <value>The x.</value>
        public float X
        {
            get { return _position[0]; }
        }

		/// <summary>
		/// Gets the y.
		/// </summary>
		/// <value>The y.</value>
        public float Y
        {
            get { return _position[1]; }
        }
    }
}

