using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Projectile : Entity
	{
        private float _direction; 

        public Projectile() : this(0, 0, 0) { }

        public Projectile(float x, float y, float direction) : base(x, y, 15)
        {
            _direction = direction;
        }

        public void Move()
        {
            _position[0] += (_speed * SwinGame.Cosine(_direction));
            _position[1] += (_speed * SwinGame.Sine(_direction));
        }

        public override void Draw()
        {
            SwinGame.FillCircle(Color.DeepPink, _position[0], _position[1], 5);
        }

        public override void Update()
        {
            Move();
        }
	}
}