using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class SideBar : UIObject
	{
        private UIText _shopText;
        private Color _background;
        private UIButton _buyShooterButton;
        private UIButton _buyFreezeButton;
        private UIButton _sellTowerButton;
        private UIButton _upgradeShooter1Button;
        private UIButton _upgradeShooter2Button;
        private UIButton _upgradeFreeze1Button;
        private UIButton _upgradeFreeze2Button;


        public SideBar() : base (SwinGame.ScreenWidth()-120, 45, 120, SwinGame.ScreenHeight()-45)
        {
            _shopText = new UIText(_x+40, _y+20, 20, 50, "Shop");
            _buyShooterButton = new UIButton(_x+20, _y+50, 80, 80, new List<string> { "Shooter", "  100" });
            _buyFreezeButton = new UIButton(_x+20, _y+150, 80, 80, new List<string> { "Freeze", "  50" });
            _upgradeShooter1Button = new UIButton(_x+20, _y+300, 80, 80, new List<string> { "Sniper", "  50" });
            _upgradeShooter2Button = new UIButton(_x+20, _y+400, 80, 80, new List<string> { "Double", "Speed", "  120" });
            _upgradeFreeze1Button = new UIButton(_x+20, _y+300, 80, 80, new List<string> { "Increased", "Range", "  60" });
            _upgradeFreeze2Button = new UIButton(_x+20, _y+400, 80, 80, new List<string> { "Faster", "Recharge", "  60" });
            _sellTowerButton = new UIButton(_x + 20, _y + 500, 90, 30, new List<string> { "Sell Tower" });

            _background = Color.Tan;
        }


        public void Update(ref TowerType towertype, Tower selectedTower, ref int points)
        {
            _buyShooterButton.Hover();
            _buyFreezeButton.Hover();
            _upgradeShooter1Button.Hover();
            _upgradeShooter2Button.Hover();
            _upgradeFreeze1Button.Hover();
            _upgradeFreeze2Button.Hover();

            if (_buyShooterButton.CheckClick())
            {
                towertype = TowerType.Shooter;
            }
            else if (_buyFreezeButton.CheckClick())
            {
                towertype = TowerType.Freeze;
            }

            if (selectedTower != null)
            {
                if (_upgradeShooter1Button.CheckClick())
                {
                    selectedTower.Upgrade(1, ref points);
                }
                else if (_upgradeShooter2Button.CheckClick())
                {
                    selectedTower.Upgrade(2, ref points);
                }
                else if (_upgradeFreeze1Button.CheckClick())
                {
                    selectedTower.Upgrade(1, ref points);
                }
                else if (_upgradeFreeze1Button.CheckClick())
                {
                    selectedTower.Upgrade(2, ref points);
                }
            }
        }


        public bool CheckSellTower()
        {
            return _sellTowerButton.CheckClick();
        }


        public void DrawSelectedTowerButtons(Tower selectedTower)
        {
            if (selectedTower != null)
            {
                if ((selectedTower.GetType() == typeof(Shooter)))
                {
                    _upgradeShooter1Button.DrawButton();
                    _upgradeShooter2Button.DrawButton();
                }
                else if ((selectedTower.GetType() == typeof(Freeze)))
                {
                    _upgradeFreeze1Button.DrawButton();
                    _upgradeFreeze2Button.DrawButton();
                }

                _sellTowerButton.DrawButton();
            }
        }

       

        public void Draw()
        {
            SwinGame.FillRectangle(_background, _x, _y, _width, _height);
            _shopText.DrawText();
            _buyShooterButton.DrawButton();
            _buyFreezeButton.DrawButton();
        }
	}
}

