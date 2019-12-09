using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Projectile : Entity
	{
		/// <summary>
		/// The direction.
		/// </summary>
        private float _direction; 

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Projectile"/> class.
		/// </summary>
        public Projectile() : this(0, 0, 0) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Projectile"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="direction">Direction.</param>
        public Projectile(float x, float y, float direction) : base(x, y, 15)
        {
            _direction = direction;
        }

		/// <summary>
		/// Move this instance to the direction its facing in speed amount.
		/// </summary>
        public void Move()
        {
            _position[0] += (_speed * SwinGame.Cosine(_direction));
            _position[1] += (_speed * SwinGame.Sine(_direction));
        }

		/// <summary>
		/// Draw this instance.
		/// </summary>
        public override void Draw()
        {
            SwinGame.FillCircle(Color.DeepPink, _position[0], _position[1], 5);
        }

		/// <summary>
		/// Update this instance.
		/// </summary>
        public override void Update()
        {
            Move();
        }
	}
}