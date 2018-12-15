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
        private Tractor tractor;
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
            tractor.DrawTractor(gr);             
            pictureBoxTractor.Image = bmp;         
        }

        // Обработка нажатия кнопки "Создать" 
        /// <param name="sender"></param>         
        /// <param name="e"></param> 
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tractor = new Tractor(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue, Color.Yellow, true);
            tractor.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTractor.Width, pictureBoxTractor.Height);
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
                    tractor.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    tractor.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    tractor.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    tractor.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
