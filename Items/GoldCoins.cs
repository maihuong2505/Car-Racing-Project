using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public class GoldCoins
    {
        private List<PictureBox> coins;
        private List<PictureBox> cars;

        public List<PictureBox> Coins { get => coins; set => coins = value; }
        public List<PictureBox> Cars { get => cars; set => cars = value; }

        public GoldCoins()
        {
            Coins = new List<PictureBox>();
            Cars = new List<PictureBox>();
        }

        public Point locateCoin()
        {
            PictureBox coin = new PictureBox
            {
                Size = new Size(30, 30)
            };
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(25, 385);
                y = random.Next(40, 280);
                coin.Location = new Point(x, y);
            } while (Coins.Exists(coinInList => coinInList.Bounds.IntersectsWith(coin.Bounds))
            || Cars.Exists(carInList => carInList.Bounds.IntersectsWith(coin.Bounds)));
            return coin.Location;
        }

        public void relocateCoin(int indexOfCoin)
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(25, 385);
                y = random.Next(40, 280);
                Coins[indexOfCoin].Location = new Point(x, y);
            } while (!canSetCoin(indexOfCoin));
        }

        private bool canSetCoin(int indexOfCoin)
        {
            for (int i = 0; i < Coins.Count; i++)
            {
                if (i == indexOfCoin)
                    continue;
                if (Coins[i].Bounds.IntersectsWith(Coins[indexOfCoin].Bounds))
                    return false;
            }
            if (Cars.Exists(car => car.Bounds.IntersectsWith(Coins[indexOfCoin].Bounds)))
                return false;
            return true;
        }

        public void moveCoin(int speed)
        {
            for (int i = 0; i < Coins.Count; i++)
            {
                if (Coins[i].Top >= 600)
                    relocateCoin(i);
                else
                    Coins[i].Top += speed;
            }
        }
    }
}
