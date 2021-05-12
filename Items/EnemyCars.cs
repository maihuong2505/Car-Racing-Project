using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public class EnemyCars
    {
        private List<PictureBox> cars;
        private List<PictureBox> coins;

        public List<PictureBox> Cars { get => cars; set => cars = value; }
        public List<PictureBox> Coins { get => coins; set => coins = value; }

        public EnemyCars()
        {
            Cars = new List<PictureBox>();
            Coins = new List<PictureBox>();
        }

        public Point locateCar()
        {
            PictureBox car = new PictureBox
            {
                Size = new Size(50, 90)
            };
            Random random = new Random();
            int x, y;            
            do
            {
                x = random.Next(25, 365);
                y = random.Next(40, 220);
                car.Location = new Point(x, y);
            } while (Cars.Exists(carInList => carInList.Bounds.IntersectsWith(car.Bounds)));
            return car.Location;
        }

        public void relocateCar(int indexOfCar)
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(25, 365);
                y = random.Next(40, 220);
                Cars[indexOfCar].Location = new Point(x, y);
            } while (!canSetCar(indexOfCar));
        }

        private bool canSetCar(int indexOfCar)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                if (i == indexOfCar)
                    continue;
                if (Cars[i].Bounds.IntersectsWith(Cars[indexOfCar].Bounds))
                    return false;               
            }
            if (Coins.Exists(coin => coin.Bounds.IntersectsWith(Cars[indexOfCar].Bounds)))
                return false;
            return true;
        }

        public void moveEnemyCar(int speed)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].Top >= 600)
                    relocateCar(i);
                else
                    Cars[i].Top += speed;
            }
        }
    }
}
