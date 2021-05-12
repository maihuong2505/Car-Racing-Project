using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public class RoadLines
    {
        private List<PictureBox> lines;

        public List<PictureBox> Lines { get => lines; set => lines = value; }

        public RoadLines()
        {
            Lines = new List<PictureBox>();
        }


        public void moveLine(int speed)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Top >= 500)
                    Lines[i].Top = 0;
                else
                    Lines[i].Top += speed;
            }
        }
    }
}
