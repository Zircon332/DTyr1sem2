using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinGameSDK;

namespace MyGame
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestAddTower()
        {
            Scene scene = new Scene();
            scene.AddTower(TowerType.Shooter);
            scene.AddTower(TowerType.Freeze);

            Assert.AreEqual(scene.Towers[0].GetType(), typeof(Shooter));
            Assert.AreEqual(scene.Towers[1].GetType(), typeof(Freeze));
        }


        [Test]
        public void TestEnemyReachEnd()
        {
            Scene scene = new Scene();
            scene.Enemies.Add(new Rusher(0,0));
            scene.Enemies[0].PointsReached = 5;
            scene.EnemyUpdate();

            Assert.AreEqual(scene.Health, 99);
            Assert.AreEqual(scene.Enemies.Count, 0);
        }


        [Test]
        public void TestProjectileDestroy()
        {
            Scene scene = new Scene();
            scene.Projectiles.Add(new Projectile(-100, -100, 0));
            scene.ProjectileUpdate();
            Assert.AreEqual(scene.Projectiles.Count, 0);
        }


        [Test]
        public void TestCollision()
        {
            Scene scene = new Scene();
            scene.Projectiles.Add(new Projectile(100, 100, 0));
            scene.Enemies.Add(new Splitter(100, 100));

            Assert.AreEqual(scene.Projectiles.Count, 1);
            Assert.AreEqual(scene.Enemies.Count, 1);

            scene.EnemyHitbyProjectile();
            Assert.AreEqual(scene.Projectiles.Count, 0);
            Assert.AreEqual(scene.Enemies.Count, 0);
        }


        [Test]
        public void TestEnemyCreation()
        {
            Splitter splitter = new Splitter(0, 0);
            Assert.AreEqual(splitter.Speed, 2);
            Assert.AreEqual(splitter.Health, 1);
            Assert.AreEqual(splitter.Size, 5);

            Rusher rusher = new Rusher(0, 0);
            Assert.AreEqual(rusher.Speed, 5);
            Assert.AreEqual(rusher.Health, 1);
            Assert.AreEqual(rusher.Size, 10);

            Spiked spiked = new Spiked(0, 0);
            Assert.AreEqual(spiked.Speed, 2);
            Assert.AreEqual(spiked.Health, 1);
            Assert.AreEqual(spiked.Size, 10);

            Regen regen = new Regen(0, 0);
            Assert.AreEqual(regen.Speed, 1);
            Assert.AreEqual(regen.Health, 5);
            Assert.AreEqual(regen.Size, 15);

            Carrier carrier = new Carrier(0, 0);
            Assert.AreEqual(carrier.Speed, 1);
            Assert.AreEqual(carrier.Health, 20);
            Assert.AreEqual(carrier.Size, 50);
        }
    }
}