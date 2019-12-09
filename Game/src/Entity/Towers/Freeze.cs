using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Freeze : Tower
	{
        private bool _increasedRange;
        private int _increasedRangeCost;
        private bool _fasterRecharge;
        private int _fasterRechargeCost;
        private int _attackTime;

        public Freeze() : this(200, 200) { }

        public Freeze(float x, float y) : base(x, y, 10, 80, 0, 50)
        {
            _speed = 100;
            _attackTimer = _speed;
            _attackTime = 0;
            _increasedRangeCost = 60;
            _fasterRechargeCost = 60;
        }

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


        public override void DrawAttack()
        {
            _attackTime = 5;
        }


        // Freeze enemies
        public override void Attack(List<Enemy> enemies)
        {
            _attackTimer = _speed;
            DetectEnemy(enemies);
            foreach (Enemy enemy in _enemiesInRange)
            {
                enemy.Slowed = true;
            }
        }


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

