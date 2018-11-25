using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class MyButton : Button
    {
        private static Font _normalFont = new Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private static Color _back = System.Drawing.Color.Gray;
        private static Color _border = System.Drawing.Color.RosyBrown;
        private static Color _activeBorder = System.Drawing.Color.Red;
        private static Color _fore = System.Drawing.Color.White;

        private static Padding _margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        private static Padding _padding = new System.Windows.Forms.Padding(1, 1, 1, 1);

        private static Size _minSize = new System.Drawing.Size(100, 30);

        private bool _active;
        public MyButton() : base()
        {
            //base.Font = _normalFont;
            base.BackColor = System.Drawing.Color.CornflowerBlue;
            //base.ForeColor = _fore;
            base.FlatAppearance.BorderColor = _border;
            base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //base.SetStyle(ControlStyles.Selectable, false);
            base.Margin = new Padding(0);
            base.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            //base.Padding = _padding;
            //base.MinimumSize = _minSize;
        }

        public void BackToNormal()
        {
            base.BackColor = System.Drawing.Color.CornflowerBlue;
        }

        //protected override void OnControlAdded(ControlEventArgs e)
        //{
        //    base.OnControlAdded(e);
        //    //UseVisualStyleBackColor = false;
        //}

        //protected override void OnMouseEnter(System.EventArgs e)
        //{
        //    //base.OnMouseEnter(e);
        //    //if (!_active)
        //    //    base.FlatAppearance.BorderColor = _activeBorder;
        //}

        //protected override void OnMouseLeave(System.EventArgs e)
        //{
        //    //base.OnMouseLeave(e);
        //    //if (!_active)
        //    //    base.FlatAppearance.BorderColor = _border;
            
        //}

        //protected override void OnMouseUp(MouseEventArgs mevent)
        //{
        //    base.OnMouseUp(mevent);
        //    //base.SetStyle(ControlStyles.Selectable, false);
        //}

        //protected override void OnMouseDown(MouseEventArgs mevent)
        //{
        //    //do nothing

        //}

        public void SetStateActive()
        {
            _active = true;
            base.FlatAppearance.BorderColor = _activeBorder;
        }

        public void SetStateNormal()
        {
            _active = false;
            base.FlatAppearance.BorderColor = _border;
        }
    }
}
