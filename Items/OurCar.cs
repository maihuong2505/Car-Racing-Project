using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public class OurCar
    {
        private PictureBox car;
        private int defaultSpeed;
        private int currentSpeed;
        private int collectedCoins;

        public PictureBox Car { get => car; set => car = value; }
        public int DefaultSpeed { get => defaultSpeed; set => defaultSpeed = value; }
        public int CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }
        public int CollectedCoins { get => collectedCoins; set => collectedCoins = value; }

        public OurCar(PictureBox car, int speed)
        {
            Car = car;
            DefaultSpeed = speed;
            CurrentSpeed = speed;
            CollectedCoins = 0;
        }

        public void moveCar(KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Left)
            {
                if (Car.Left > 40)
                    Car.Left -= 7;
            }
            else if (key.KeyCode == Keys.Right)
            {
                if (Car.Left < 350)
                    Car.Left += 7;
            }
        }

        public void accelarate()
        {
            if (CurrentSpeed < 20)
                CurrentSpeed++;
        }

        public void brake()
        {
            while (CurrentSpeed > DefaultSpeed)
                CurrentSpeed -= 2;
            if (CurrentSpeed < DefaultSpeed)
                CurrentSpeed++;
        }

        public void collectCoins(GoldCoins goldCoins, Label collectedCoins)
        {
            for (int i = 0; i < goldCoins.Coins.Count; i++)
            {
                if (Car.Bounds.IntersectsWith(goldCoins.Coins[i].Bounds))
                {
                    goldCoins.relocateCoin(i);
                    CollectedCoins++;
                    collectedCoins.Text = CollectedCoins.ToString();
                }
            }
        }

        public bool crash(EnemyCars enemyCars)
        {
            for (int i = 0; i < enemyCars.Cars.Count; i++)
            {
                if (Car.Bounds.IntersectsWith(enemyCars.Cars[i].Bounds))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
