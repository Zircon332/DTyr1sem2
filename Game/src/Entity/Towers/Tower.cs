using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Tower : Entity
	{
        protected int _size;                    // Size of tower for drawing
        protected int _range;                   // Range of tower
        protected int _focus;                   // Main target of tower
        protected List<Enemy> _enemiesInRange;  // List of enmies within range of tower
        protected int _attackTimer;             // Countdown for attacking speed
        protected int _towerCost;               // Cost of tower
        protected bool _selected;               // Whether the tower is selected


        /// <summary>
        /// Tower Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        /// <param name="range"></param>
        /// <param name="focus"></param>
        /// <param name="towerCost"></param>
        public Tower(float x, float y, int size, int range, int focus, int towerCost) : base(x, y, 50)
        {
            _range = range;
            _size = size;
            _range = range;
            _enemiesInRange = new List<Enemy>();
            _towerCost = towerCost;
            _selected = true;
        }


        /// <summary>
        /// Update towers depeding on which part is upgraded
        /// </summary>
        /// <param name="index">upgrade 1 or 2</param>
        /// <param name="points">current points available</param>
        public abstract void Upgrade(int index, ref int points);


        /// <summary>
        /// return angle of tower
        /// </summary>
        /// <returns></returns>
        public virtual float GetAngle() { return 0; }


        /// <summary>
        /// Selling tower regains points for half of its cost
        /// </summary>
        /// <returns>Points the player earn back</returns>
        public int Sell()
        {
            int sellPrice = _towerCost/2;
            return sellPrice;
        }


        /// <summary>
        /// Detects if an enmey is within its range, add it to the list of enemies in range
        /// </summary>
        /// <param name="enemies"></param>
        public void DetectEnemy(List<Enemy> enemies)
        {
            _enemiesInRange = new List<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                if (EntityDistance(enemy.X, enemy.Y, X, Y)  < _range)
                {
                    _enemiesInRange.Add(enemy);
                }
            }
        }

        
        /// <summary>
        /// Override abstract draw
        /// </summary>
        public override abstract void Draw();


        /// <summary>
        /// override abstrace update
        /// </summary>
        public override abstract void Update();


        /// <summary>
        /// virtual method for drawing attack animations
        /// </summary>
        public virtual void DrawAttack() { }


        /// <summary>
        /// Draw the range of the tower
        /// </summary>
        public void DrawRange()
        {
            SwinGame.DrawCircle(Color.Grey, _position[0], _position[1], _range);
        }


        /// <summary>
        /// Virtual method for attacking enemies
        /// </summary>
        /// <param name="enemies"></param>
        public virtual void Attack(List<Enemy> enemies) { }

        
        // Property //

		/// <summary>
		/// Gets or sets the attack timer.
		/// </summary>
		/// <value>The attack timer.</value>
        public int AttackTimer
        {
            get { return _attackTimer; }
            set { _attackTimer = value; }
        }

		/// <summary>
		/// Gets the enemies in range.
		/// </summary>
		/// <value>The enemies in range.</value>
        public List<Enemy> EnemiesInRange
        {
            get { return _enemiesInRange; }
        }

		/// <summary>
		/// Gets the tower cost.
		/// </summary>
		/// <value>The tower cost.</value>
        public int TowerCost
        {
            get { return _towerCost; }
        }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:MyGame.Tower"/> is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}

