using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Scene
	{
        private int _health;            // Health of player
        private int _points;            // Points for buying/upgrading towers
        private Color _background;      // Background Color
        private List<Tower> _towers;    // List of towers
        private List<Enemy> _enemies;   // List of enemies
        private List<Projectile> _projectiles;  // List of projectiles
        private Track _track;                   // Track containing list of trackpoints
        private TowerType _towerTypeSelected;   // The tower type that will be bought when clicked 
        private Tower _towerSelected;           // Selected tower

        private GameStates _gameState;          // State of the game
        private int _round;                     // Round number
        private int _enemySpawnCounter;         // Counter for enemy spawn timing

        private int _mapStartY = 45;                            // Y value for start of map from UI
        private int _mapEndX = SwinGame.ScreenWidth() - 125;    // X value for end of map from UI

        private MenuUI _menuUI;                 // Game menu containing all UI interfaces

        private List<Projectile> _projRemove;   // List of projectiles to be removed
        private List<Enemy> _enemyRemove;       // List of enemies to be removed


        /// <summary>
        /// Scene constructor
        /// </summary>
        public Scene()
        {
            _health = 100;
            _points = 200;
            _gameState = GameStates.Playing;

            _background = Color.Black;
            _menuUI = new MenuUI(_health, _points);
            _towers = new List<Tower>();
            _projectiles = new List<Projectile>();
            _enemies = new List<Enemy>();
            
            //Map coordinates
            _track = new Track(new List<float>() { 444, 5, 445, 62, 441, 74, 437, 80, 429, 84, 415, 86, 391, 78, 372, 73, 335, 70, 302, 72, 273, 78, 246, 88,
                215, 105, 194, 123, 176, 141, 158, 164, 145, 188, 133, 217, 127, 249, 125, 298, 134, 338, 150, 379, 185, 425, 220, 455, 270, 479, 334, 488, 402,
                477, 440, 458, 474, 432, 498, 403, 499, 376, 482, 357, 457, 350, 431, 363, 404, 385, 378, 398, 331, 407, 282, 397, 236, 367, 216, 340, 203, 308,
                197, 272, 206, 224, 220, 196, 251, 163, 293, 142, 329, 136, 352, 147, 361, 169, 353, 193, 337, 204, 316, 206, 289, 220, 275, 237, 265, 267, 271,
                293, 286, 317, 301, 327, 331, 334, 365, 325, 387, 303, 395, 277, 398, 270, 402, 267, 410, 265, 491, 266, 583, 265, 675, 265 });
            
            _round = 0; // Starting round number
        }


        /// <summary>
        /// Handles key and mouse inputs for selecting towers
        /// </summary>
        public void ManageTower()
        {
            // Key control tower selection with 1 and 2
            if (SwinGame.KeyTyped(KeyCode.vk_1))
            {
                _towerTypeSelected = TowerType.Shooter;
            }
            if (SwinGame.KeyTyped(KeyCode.vk_2))
            {
                _towerTypeSelected = TowerType.Freeze;
            }

            // Tower selection with mouse
            if (SwinGame.MouseClicked(MouseButton.LeftButton) && SwinGame.MousePosition().X < _mapEndX)
            {
                if (_towerSelected != null)
                {
                    _towerSelected.Selected = false;          // reset selected tower
                    _towerSelected = null;
                }
                AddTower(_towerTypeSelected);
            }
            if (SwinGame.MouseClicked(MouseButton.RightButton))
            {
                if (_towerSelected != null)
                {
                    _towerSelected.Selected = false;          // reset selected tower
                    _towerSelected = null;
                }
                _towerSelected = SelectTower();
                
            }
        }
        

        /// <summary>
        /// Returns the tower on mouse position
        /// </summary>
        /// <returns>Tower on mouse position when right clicked</returns>
        public Tower SelectTower()
        {
            foreach (Tower tower in _towers)
            {
                if (tower.EntityDistance(SwinGame.MousePosition().X, SwinGame.MousePosition().Y, tower.X, tower.Y) < 20)
                {
                    tower.Selected = true;
                    return tower;
                }
            }
            return null;
        }


        // Add tower if clicked on empty space
        public void AddTower(TowerType type)
        {
            // if out of map, return map and dont add towers
            if (SwinGame.MousePosition().X > 675 || SwinGame.MousePosition().Y < 45)
            {
                return;
            }
            // if adding tower on another tower, return and dont add towers
            foreach (Tower tower in _towers)
            {
                if (tower.EntityDistance(SwinGame.MousePosition().X, SwinGame.MousePosition().Y, tower.X, tower.Y) < 20)
                {
                    return;
                }
            }
            // if tower is on track, return and dont add tower
            foreach (TrackPoint trackPoint in _track.Points)
            {
                if (Math.Sqrt(Math.Pow(Math.Abs(SwinGame.MousePosition().X - trackPoint.X), 2) + Math.Pow(Math.Abs(SwinGame.MousePosition().Y - trackPoint.Y), 2)) < 20)
                {
                    return;
                }
            }

            // Add tower based on selected type on MousePosition 
            switch (type)
            {
                case TowerType.Shooter:
                    if (_points >= 100)
                    {
                        Shooter shooter = new Shooter(SwinGame.MousePosition().X, SwinGame.MousePosition().Y);
                        _towers.Add(shooter);
                        _points -= shooter.TowerCost;
                        _towerSelected = shooter;
                    }
                    break;
                case TowerType.Freeze:
                    if (_points >= 50)
                    {
                        Freeze freeze = new Freeze(SwinGame.MousePosition().X, SwinGame.MousePosition().Y);
                        _towers.Add(freeze);
                        _points -= freeze.TowerCost;
                        _towerSelected = freeze;
                    }
                    break;
            }
        }


        /// <summary>
        /// Handles spawning of enemies in waves
        /// </summary>
        public void EnemySpawn()
        {
            _enemySpawnCounter += 1;

            // If round has been going on for some time and all enemies are dead, move to next round 
            if (_enemySpawnCounter > 600 && _enemies.Count == 0)
            {
                _round += 1;
                _enemySpawnCounter = 0;
            }
            switch (_round)
            {
                case 0:
                    switch (_enemySpawnCounter)
                    {
                        case 60:
                            _round += 1;
                            _enemySpawnCounter = 0;
                            break;
                    }
                    break;
                case 1:
                    switch (_enemySpawnCounter)
                    {
                        case 1:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 50:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 100:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 150:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 300:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 320:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 330:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 340:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 350:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                    }
                    break;
                case 2:
                    switch (_enemySpawnCounter)
                    {
                        case 50:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 100:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 150:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 350:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 360:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 400:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 450:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 460:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 470:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                    }
                    break;
                case 3:
                    switch (_enemySpawnCounter)
                    {
                        case 50:
                            _enemies.Add(new Carrier(_track.Points[0].X, _track.Points[0].Y));
                            break;
                    }
                    break;
                case 4:
                    switch (_enemySpawnCounter)
                    {
                        case 1:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 20:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 40:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 60:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 80:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 100:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;

                        case 125:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 150:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 175:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 200:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 225:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 250:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 275:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 300:
                            _enemies.Add(new Spiked(_track.Points[0].X, _track.Points[0].Y));
                            break;

                        case 320:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 350:
                            _enemies.Add(new Splitter(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 500:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 510:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 520:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 530:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 540:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 550:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 560:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 570:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 580:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 590:
                            _enemies.Add(new Rusher(_track.Points[0].X, _track.Points[0].Y));
                            break;
                    }
                    break;
                case 5:
                    switch (_enemySpawnCounter)
                    {
                        case 50:
                            _enemies.Add(new Carrier(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 120:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 140:
                            _enemies.Add(new Regen(_track.Points[0].X, _track.Points[0].Y));
                            break;
                        case 250:
                            _enemies.Add(new Carrier(_track.Points[0].X, _track.Points[0].Y));
                            break;
                    }
                    break;
                default:
                    _gameState = GameStates.Won;
                    break;
            }
            

            // For spliiters, add new splitters when duplicating
            List<Enemy> enemiesAdd = new List<Enemy>();
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetType() == typeof(Splitter))
                {
                    if (enemy.Size >= 10)
                    {
                        enemy.Size = 5;
                        enemiesAdd.Add(enemy);
                    }
                }
            }
            foreach (Enemy enemy in enemiesAdd)
            {
                Splitter split = new Splitter(enemy.X-10, enemy.Y-10);
                split.PointsReached = enemy.PointsReached;
                _enemies.Add(split);
            }
        }


        /// <summary>
        /// Handles tower attacks for shooters(create projectiles) and freeze(slows down enemies)
        /// </summary>
        public void TowerAttack()
        {
            foreach (Tower tower in _towers)
            {
                if (tower.EnemiesInRange.Count > 0) {
                    if (tower.AttackTimer <= 0)
                    {
                        if (tower.GetType() == typeof(Shooter))
                        {
                            tower.AttackTimer = tower.Speed;
                            Projectile proj = new Projectile(tower.X, tower.Y, tower.GetAngle());
                            _projectiles.Add(proj);
                        }
                        if (tower.GetType() == typeof(Freeze))
                        {
                            tower.Attack(_enemies);
                            tower.DrawAttack();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Removes enemy if enemy reached end, reduces health
        /// </summary>
        public void EnemyUpdate()
        {
            _enemyRemove = new List<Enemy>();
            foreach (Enemy enemy in _enemies)
            {
                enemy.Update(_track);
                if (enemy.PointsReached == _track.Points.Count)
                {
                    _enemyRemove.Add(enemy);
                    _health -= enemy.Damage();
                }
            }
            foreach (Enemy enemy in _enemyRemove) { _enemies.Remove(enemy); }        // remove enemies
        }


        /// <summary>
        /// Handles projectile despawning when offscreen and movement
        /// </summary>
        public void ProjectileUpdate()
        {
            _projRemove = new List<Projectile>();

            foreach (Projectile proj in _projectiles)
            {
                proj.Update();

                // If projectile leaves screen, remove from list
                if (proj.X < 0 || proj.Y < _mapStartY || proj.X > _mapEndX || proj.Y > SwinGame.ScreenHeight())
                {
                    _projRemove.Add(proj);       // Add proj to listOfProj to remove later
                }
            }
            foreach (Projectile proj in _projRemove) { _projectiles.Remove(proj); }  // remove proj
        }


        // Check if projectile hits an enemy
        public void EnemyHitbyProjectile()
        {
            _projRemove = new List<Projectile>();
            _enemyRemove = new List<Enemy>();

            List<Enemy> enemiesAdd = new List<Enemy>();
            Enemy carrier = null;

            foreach (Projectile proj in _projectiles)
            {
                List<Enemy> enemiesHitByProjectile = new List<Enemy>();            // List of enemies hit by projectile
                foreach (Enemy enemy in _enemies)
                {
                    if (enemy.EntityDistance(enemy.X, enemy.Y, proj.X, proj.Y) < 15)
                    {
                        _projRemove.Add(proj);
                        enemy.Damaged();
                        if (enemy.Health <= 0)
                        {
                            enemiesHitByProjectile.Add(enemy);
                            _points += 10;
                        }
                        if (enemy.GetType() == typeof(Carrier) && enemy.Health <= 0)
                        {
                            carrier = enemy;
                            Rusher rusher = new Rusher(enemy.X+20, enemy.Y+20);
                            enemiesAdd.Add(rusher);
                            rusher = new Rusher(enemy.X, enemy.Y + 20);
                            enemiesAdd.Add(rusher);
                            rusher = new Rusher(enemy.X - 25, enemy.Y + 20);
                            enemiesAdd.Add(rusher);
                            Regen regen = new Regen(enemy.X-15, enemy.Y-15);
                            enemiesAdd.Add(regen);
                            Spiked spiked = new Spiked(enemy.X-20, enemy.Y+20);
                            enemiesAdd.Add(spiked);
                            Splitter splitter = new Splitter(enemy.X+15, enemy.Y-15);
                            enemiesAdd.Add(splitter);
                        }
                    }
                }
                foreach (Enemy enemy in enemiesAdd)
                {
                    enemy.PointsReached = carrier.PointsReached;
                    _enemies.Add(enemy);
                }
                if (enemiesHitByProjectile.Count > 0)
                {
                    _enemies.Remove(enemiesHitByProjectile[0]);                          // Only one enemy dies from one projectile
                }
            }
            foreach (Projectile proj in _projRemove) { _projectiles.Remove(proj); }  // remove proj
        }


        /// <summary>
        /// Calls other updates, handles game loop
        /// </summary>
        public void Update()
        {
            if (_gameState == GameStates.Playing)
            {
                _menuUI.GetSideBar.Update(ref _towerTypeSelected, _towerSelected, ref _points);
                if (_menuUI.GetSideBar.CheckSellTower())
                {
                    _points += _towerSelected.Sell();
                    _towers.Remove(_towerSelected);
                    _towerSelected = null;
                }


                ManageTower();

                foreach (Tower tower in _towers)
                {
                    tower.DetectEnemy(_enemies);
                    tower.Update();
                    TowerAttack();
                }

                EnemySpawn();

                EnemyUpdate();

                ProjectileUpdate();

                EnemyHitbyProjectile();

                
                


                if (_health <= 0)
                {
                    _gameState = GameStates.Lost;
                    //System.Environment.Exit(0);
                }
            }

            Draw();
        }


        /// <summary>
        /// Draw order: Bg, tracks, tower, enemy, projectile, UI
        /// Draws win/lose text when won/lost
        /// </summary>
        public void Draw()
        {
            SwinGame.FillRectangle(_background, 0, 0, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());
            foreach (TrackPoint point in _track.Points) { point.Draw(); }
            foreach (Tower tower in _towers) { tower.Draw(); }
            foreach (Enemy enemy in _enemies) { enemy.Draw(); }
            foreach (Projectile proj in _projectiles) { proj.Draw(); }
            _menuUI.Draw(_health, _points, _round);
            _menuUI.GetSideBar.DrawSelectedTowerButtons(_towerSelected);

            if (_gameState == GameStates.Lost)
            {
                Text.DrawTextOnScreen("You Lose", Color.Red, SwinGame.LoadFont("Cour", 100), 150, 200);
            }
            else if (_gameState == GameStates.Won)
            {
                Text.DrawTextOnScreen("You Win!", Color.Red, SwinGame.LoadFont("Cour", 100), 150, 200);
            }

        }



        // Properties //

        public List<Tower> Towers
        {
            get { return _towers; }
        }

        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        public int Health
        {
            get { return _health; }
        }

        public List<Projectile> Projectiles
        {
            get { return _projectiles; }
        }
    }
}

