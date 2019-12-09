using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Entity
	{
		/// <summary>
		/// The position.
		/// </summary>
        protected float[] _position;
        /// <summary>
        /// The speed.
        /// </summary>
		protected int _speed;
        
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Entity"/> class.
		/// </summary>
        public Entity() : this(200, 200, 10) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Entity"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="speed">Speed.</param>
        public Entity(float x, float y, int speed)
        {
            _position = new float[] {x, y};
            _speed = speed;
        }


		/// <summary>
		/// Draw this instance.
		/// </summary>
        public abstract void Draw();

		/// <summary>
		/// Update this instance.
		/// </summary>
        public abstract void Update();

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

		/// <summary>
		/// Gets the speed.
		/// </summary>
		/// <value>The speed.</value>
        public int Speed
        {
            get { return _speed; }
        }

		/// <summary>
		/// Entities the distance.
		/// </summary>
		/// <returns>The distance.</returns>
		/// <param name="x1">The first x value.</param>
		/// <param name="y1">The first y value.</param>
		/// <param name="x2">The second x value.</param>
		/// <param name="y2">The second y value.</param>
        public double EntityDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2),2));
        }
    }
}

