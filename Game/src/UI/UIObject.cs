using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class UIObject
	{
		/// <summary>
		/// The x.
		/// </summary>
        protected float _x;
        /// <summary>
        /// The y.
        /// </summary>
		protected float _y;
        /// <summary>
        /// The width.
        /// </summary>
		protected int _width;
        /// <summary>
        /// The height.
        /// </summary>
		protected int _height;


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIObject"/> class.
		/// </summary>
        public UIObject() : this(10, 10, 10, 10) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.UIObject"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
        public UIObject(float x, float y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
	}
}

