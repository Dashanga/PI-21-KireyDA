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
    public partial class FormTractorConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        ITransport tractor = null;
        /// <summary>
        /// Событие
        /// </summary>
        private event tractorDelegate eventAddTractor;

        public FormTractorConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelGold.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }
        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawTractor()
        {
            if (tractor != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxTractor.Width, pictureBoxTractor.Height);
                Graphics gr = Graphics.FromImage(bmp);
                tractor.SetPosition(30, 20, pictureBoxTractor.Width, pictureBoxTractor.Height);
                tractor.DrawTractor(gr);
                pictureBoxTractor.Image = bmp;
            }
        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(tractorDelegate ev)
        {
            if (eventAddTractor == null)
            {
                eventAddTractor = new tractorDelegate(ev);
            }
            else
            {
                eventAddTractor += ev;
            }
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTractor_MouseDown(object sender, MouseEventArgs e)
        {
            labelTractor.DoDragDrop(labelTractor.Text, DragDropEffects.Move |
            DragDropEffects.Copy);
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTractorExkavator_MouseDown(object sender, MouseEventArgs e)
        {
            labelTractorExkavator.DoDragDrop(labelTractorExkavator.Text, DragDropEffects.Move |
            DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTractor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTractor_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный трактор":
                    tractor = new Tractor(100, 500, Color.White);
                    break;
                case "Трактор-экскаватор":
                    tractor = new TractorExkavator(100, 500, Color.White, Color.Black, true, true);
                    break;
            }
            DrawTractor();
        }
        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
            DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tractor != null)
            {
                tractor.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawTractor();
            }
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tractor != null)
            {
                if (tractor is TractorExkavator)
                {
                    (tractor as TractorExkavator).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawTractor();
                }
            }
        }
        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     

        private void buttonOk_Click_1(object sender, EventArgs e)
        {
            eventAddTractor?.Invoke(tractor);
            Close();
        }
    }
}