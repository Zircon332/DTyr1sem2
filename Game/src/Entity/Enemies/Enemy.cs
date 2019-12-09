using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Enemy : Entity
	{
        protected int _size;            // Size of enemy for drawing
        protected int _damage;          // The damage the enemy does once it reaches end of map
        protected bool _slowed;         // Whether the enemy is slowed down by a freeze tower
        protected int _health;          // Health of enemy
        protected int _pointsReached;   // Which point it has gone past, increments by one everytime it reaches a new track point
        protected int _coolTimer;       // Timer for counting slowed time


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X pos</param>
        /// <param name="y">Y pos</param>
        /// <param name="damage">Damage dealt</param>
        /// <param name="size">Size</param>
        /// <param name="health">Health</param>
        public Enemy(float x, float y, int damage, int size, int health) : base(x, y, 0)
        {
            _damage = damage;
            _size = size;
            _slowed = false;
            _health = health;
            _pointsReached = 0;
            _coolTimer = 180;
        }

        /// <summary>
        /// When enemy receives damage, reduces its health by one
        /// </summary>
        public void Damaged()
        {
            _health -= 1;
        }

        /// <summary>
        /// When enemy reaches end of map, returns the damage it will deal
        /// </summary>
        /// <returns></returns>
        public int Damage()
        {
            return _damage;
        }


        /// <summary>
        /// Countdown timer when slowed
        /// </summary>
        public void CoolTimer()
        {
            if (_slowed)
            {
                _coolTimer -= 1;
                if (_coolTimer <= 0)
                {
                    _slowed = false;
                    _coolTimer = 180;
                }
            }
        }


        /// <summary>
        /// Calculates the angle to move to and moves by speed distance, move half as fast when slowed
        /// </summary>
        /// <param name="destx">destination X</param>
        /// <param name="desty">destination Y</param>
        public void Move(float destx, float desty)
        {
            float angle = SwinGame.CalculateAngle(_position[0], _position[1], destx, desty);

            if (!_slowed)
            {
                _position[0] += (_speed * SwinGame.Cosine(angle));
                _position[1] += (_speed * SwinGame.Sine(angle));
            }
            else
            {
                _position[0] += ((int)(_speed/2) * SwinGame.Cosine(angle));
                _position[1] += ((int)(_speed/2) * SwinGame.Sine(angle));
            }
        }


        /// <summary>
        /// Override abstract draw
        /// </summary>
        public override abstract void Draw();


        /// <summary>
        /// Abstract update for enemies with track
        /// </summary>
        /// <param name="track">Track</param>
        public abstract void Update(Track track);


        /// <summary>
        /// Property for pointsReached
        /// </summary>
        public int PointsReached
        {
            get { return _pointsReached; }
            set { _pointsReached = value; }
        }

        /// <summary>
        /// Property for health
        /// </summary>
        public int Health
        {
            get { return _health; }
        }
        
        /// <summary>
        /// Property for size
        /// </summary>
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Property for slowed
        /// </summary>
        public bool Slowed
        {
            get { return _slowed; }
            set { _slowed = true; }
        }
    }
}

