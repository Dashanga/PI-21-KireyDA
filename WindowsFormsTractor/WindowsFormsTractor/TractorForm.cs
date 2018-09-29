using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTractor
{
    public partial class TractorForm : Form
    {
        private ITransport car;
        /// Конструктор
        public TractorForm()
        {
            InitializeComponent();
        }

        //Метод отрисовки машины       
        private void Draw()
        {             
            Bitmap bmp = new Bitmap(pictureBoxTractor.Width, pictureBoxTractor.Height);             
            Graphics gr = Graphics.FromImage(bmp);             
            car.DrawCar(gr);             
            pictureBoxTractor.Image = bmp;         
        }

        // Обработка нажатия кнопки "Создать" 
        /// <param name="sender"></param>         
        /// /// <param name="e"></param> 
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new Tractor(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.LightBlue);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTractor.Width, pictureBoxTractor.Height);
            Draw();
        }

        // Обработка нажатия кнопок управления
        /// <param name="sender"></param>         
        /// /// <param name="e"></param> 
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки             
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    car.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    car.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    car.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    car.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        private void pictureBoxTractor_Click(object sender, EventArgs e)
        {

        }

        private void TractorForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(); car = new TractorExkavator(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.LightBlue, Color.Yellow);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTractor.Width, pictureBoxTractor.Height);
            Draw();
        }
    }
}
