using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Shooter : Tower
	{
		/// <summary>
		/// The sniper.
		/// </summary>
        private bool _sniper;
        /// <summary>
        /// The sniper cost.
        /// </summary>
		private int _sniperCost;
        /// <summary>
        /// The double speed.
        /// </summary>
		private bool _doubleSpeed;
        /// <summary>
        /// The double speed cost.
        /// </summary>
		private int _doubleSpeedCost;

		/// <summary>
		/// The angle.
		/// </summary>
        private float _angle;
        /// <summary>
        /// The length of the barrel.
        /// </summary>
		private int _barrelLength;
        /// <summary>
        /// The width of the barrel.
        /// </summary>
		private int _barrelWidth;
        /// <summary>
        /// The point ax.
        /// </summary>
		private float _pointAx;
        /// <summary>
        /// The point ay.
        /// </summary>
		private float _pointAy;
        /// <summary>
        /// The point bx.
        /// </summary>
		private float _pointBx;
        /// <summary>
        /// The point by.
        /// </summary>
		private float _pointBy;
        /// <summary>
        /// The point sx.
        /// </summary>
		private float _pointSx;
        /// <summary>
        /// The point sy.
        /// </summary>
		private float _pointSy;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Shooter"/> class.
		/// </summary>
        public Shooter() : this(200, 200) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Shooter"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Shooter(float x, float y) : base(x, y, 10, 100, 0, 100)
        {
            _barrelLength = 20;
            _barrelWidth = 20;
            _angle = 0;
            _sniperCost = 50;
            _doubleSpeedCost = 120;

            PointTo(0, 0);
    	}


		/// <summary>
		/// Upgrade the specified index and points.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="points">Points.</param>
        public override void Upgrade(int index, ref int points)
        {
            if (index == 1)
            {
                if (points >= _sniperCost && !_sniper)
                {
                    _sniper = true;
                    _barrelLength += 5;
                    _barrelWidth -= 12;
                    _range += 100;
                    points -= _sniperCost;
                }
            }
            else if (index == 2)
            {
                if (points >= _doubleSpeedCost)
                {
                    _doubleSpeed = true;
                    _speed /= 2;
                    points -= _doubleSpeedCost;
                }
            }
        }


		/// <summary>
		/// Point the tower to target X,Y.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public void PointTo(float x, float y)
        {
            _angle = SwinGame.CalculateAngle(_position[0], _position[1], x, y);
            _pointAx = _barrelLength * SwinGame.Cosine(_angle - _barrelWidth) + _position[0];
            _pointAy = _barrelLength * SwinGame.Sine(_angle - _barrelWidth) + _position[1];
            _pointBx = _barrelLength * SwinGame.Cosine(_angle + _barrelWidth) + _position[0];
            _pointBy = _barrelLength * SwinGame.Sine(_angle + _barrelWidth) + _position[1];
            _pointSx = _barrelLength * SwinGame.Cosine(_angle) + _position[0];
            _pointSy = _barrelLength * SwinGame.Sine(_angle) + _position[1];
        }


		/// <summary>
		/// Gets the angle.
		/// </summary>
		/// <returns>The angle.</returns>
        public override float GetAngle()
        {
            return _angle;
        }


		/// <summary>
		/// Draw this instance, draw range if selected, draw barrel with two types depending on upgrade.
		/// </summary>
        public override void Draw() {
            if (_selected)
            {
                DrawRange();
            }
            
            SwinGame.FillCircle(SwinGame.RGBAColor(255, 0, 0, 10), _position[0], _position[1], _size+50);
            SwinGame.FillCircle(Color.Red, _position[0], _position[1], _size);
            if (!_sniper)
            {
                SwinGame.DrawTriangle(Color.Red, _pointAx, _pointAy, _pointBx, _pointBy, _position[0], _position[1]);
            }
            else
            {
                SwinGame.DrawThickLine(Color.Red, _pointSx, _pointSy, _position[0], _position[1], _barrelWidth);
            }
        }


		/// <summary>
		/// Updates pointing to enemies and attack timer.
		/// </summary>
        public override void Update()
        {
            if (_enemiesInRange.Count > 0)
            {
                PointTo(_enemiesInRange[0].X, _enemiesInRange[0].Y);
            }

            _attackTimer -= 1;
        }
	}
}

