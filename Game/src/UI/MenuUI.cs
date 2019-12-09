using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class MenuUI
	{
        private TopBar _topbar;
        private SideBar _sidebar;

        public MenuUI(int health, int point)
        {
            _topbar = new TopBar(health, point);
            _sidebar = new SideBar();
        }

        public void Draw(int health, int point, int roundnum)
        {
            _topbar.Draw(health, point, roundnum);
            _sidebar.Draw();
        }

        public SideBar GetSideBar
        {
            get { return _sidebar; }
        }
	}
}

