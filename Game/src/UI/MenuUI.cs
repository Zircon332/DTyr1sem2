using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class MenuUI
	{
		/// <summary>
		/// The topbar.
		/// </summary>
        private TopBar _topbar;
        /// <summary>
        /// The rivate.
        /// </summary>
		private SideBar _sidebar;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.MenuUI"/> class.
		/// </summary>
		/// <param name="health">Health.</param>
		/// <param name="point">Point.</param>
        public MenuUI(int health, int point)
        {
            _topbar = new TopBar(health, point);
            _sidebar = new SideBar();
        }

		/// <summary>
		/// Draw the specified health, point and roundnum.
		/// </summary>
		/// <param name="health">Health.</param>
		/// <param name="point">Point.</param>
		/// <param name="roundnum">Roundnum.</param>
        public void Draw(int health, int point, int roundnum)
        {
            _topbar.Draw(health, point, roundnum);
            _sidebar.Draw();
        }

		/// <summary>
		/// Gets the get side bar.
		/// </summary>
		/// <value>The get side bar.</value>
        public SideBar GetSideBar
        {
            get { return _sidebar; }
        }
	}
}

