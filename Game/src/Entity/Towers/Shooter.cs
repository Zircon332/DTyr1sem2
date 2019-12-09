using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Shooter : Tower
	{
        private bool _sniper;
        private int _sniperCost;
        private bool _doubleSpeed;
        private int _doubleSpeedCost;

        private float _angle;
        private int _barrelLength;
        private int _barrelWidth;
        private float _pointAx;
        private float _pointAy;
        private float _pointBx;
        private float _pointBy;
        private float _pointSx;
        private float _pointSy;

        public Shooter() : this(200, 200) { }

        public Shooter(float x, float y) : base(x, y, 10, 100, 0, 100)
        {
            _barrelLength = 20;
            _barrelWidth = 20;
            _angle = 0;
            _sniperCost = 50;
            _doubleSpeedCost = 120;

            PointTo(0, 0);
    }

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


        public override float GetAngle()
        {
            return _angle;
        }


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

