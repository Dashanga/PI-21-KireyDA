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
    public partial class FormParking : Form
    {
        /// Объект от класса-парковки         
        Parking<ITransport> parking;
        public FormParking()
        {
            InitializeComponent();
            parking = new Parking<ITransport>(20, pictureBoxParking.Width,
            pictureBoxParking.Height);
            Draw();
        }

        /// Метод отрисовки парковки         	
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }

        /// Обработка нажатия кнопки "Припарковать автомобиль"              
        /// <param name="sender"></param>         
        /// <param name="e"></param>         	
        private void buttonSetTractor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var tractor = new Tractor(100, 1000, dialog.Color);
                int place = parking + tractor;
                Draw();
            }
        }

        /// Обработка нажатия кнопки "Припарковать гоночный автомобиль" 
        /// <param name="sender"></param>         
        /// <param name="e"></param>         
        private void buttonSetTractorExkavator_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var tractor = new TractorExkavator(100, 1000, dialog.Color,
                    dialogDop.Color, true, true);
                    int place = parking + tractor;
                    Draw();
                }
            }
        }

        /// Обработка нажатия кнопки "Забрать"         
        /// <param name="sender"></param>         
        /// <param name="e"></param>         
        private void buttonTakeTractor_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var tractor = parking - Convert.ToInt32(maskedTextBox.Text);
                if (tractor != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeTractor.Width, pictureBoxTakeTractor.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    tractor.SetPosition(50, 50, pictureBoxTakeTractor.Width, pictureBoxTakeTractor.Height);
                    tractor.DrawTractor(gr);
                    pictureBoxTakeTractor.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeTractor.Width, pictureBoxTakeTractor.Height);
                    pictureBoxTakeTractor.Image = bmp;
                }
                Draw();
            }
        }
    }
}
