using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Freeze : Tower
	{
		/// <summary>
		/// The increased range.
		/// </summary>
        private bool _increasedRange;
        /// <summary>
        /// The increased range cost.
        /// </summary>
		private int _increasedRangeCost;
        private bool _fasterRecharge;
        /// <summary>
        /// The faster recharge cost.
        /// </summary>
		private int _fasterRechargeCost;
        /// <summary>
        /// The attack time.
        /// </summary>
		private int _attackTime;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Freeze"/> class.
		/// </summary>
        public Freeze() : this(200, 200) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Freeze"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
        public Freeze(float x, float y) : base(x, y, 10, 80, 0, 50)
        {
            _speed = 100;
            _attackTimer = _speed;
            _attackTime = 0;
            _increasedRangeCost = 60;
            _fasterRechargeCost = 60;
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
                if (points >= _increasedRangeCost)
                {
                    _increasedRange = true;
                    _range += 40;
                    points -= _increasedRangeCost;
                }
            }
            if (index == 2)
            {
                if (points >= _fasterRechargeCost)
                {
                    _fasterRecharge = true;
                    _speed /= 3;
                    points -= _fasterRechargeCost;
                }
            }
        }


		/// <summary>
		/// Draw this instance, draw range when selected, draw attack when attacking.
		/// </summary>
        public override void Draw()
        {
            if (_selected)
            {
                DrawRange();
            }
            if (_attackTime > 0)
            {
                SwinGame.DrawCircle(Color.AliceBlue, _position[0], _position[1], _range);
            }
            SwinGame.FillCircle(Color.Aqua, _position[0], _position[1], _size);
        }


		/// <summary>
		/// Draws the attack.
		/// </summary>
        public override void DrawAttack()
        {
            _attackTime = 5;
        }


        /// <summary>
        /// Freeze the specified enemies.
        /// </summary>
        /// <param name="enemies">Enemies.</param>
        public override void Attack(List<Enemy> enemies)
        {
            _attackTimer = _speed;
            DetectEnemy(enemies);
            foreach (Enemy enemy in _enemiesInRange)
            {
                enemy.Slowed = true;
            }
        }


		/// <summary>
		/// Update attack timer.
		/// </summary>
        public override void Update()
        {
            _attackTimer -= 1;
            if (_attackTime > 0)
            {
                _attackTime -= 1;
            }
        }
	}
}

