using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class MainButton
    {
        private Button _button;

        public MainButton(string text, Size screenSize, int verticalOffset, Color color)
        {
            _button = new Button();
            _button.Text = text;
            _button.Size = new Size(100, 50);
            _button.BackColor = color;
            _button.ForeColor = Color.White;
            _button.Font = new Font("Times New Roman", 14);

            _button.Location = new Point(screenSize.Width/2 - _button.Width/2, _button.Height/2 + verticalOffset);
        }
        
        public Button Button
        {
            get { return _button; }
        }

    }
}
