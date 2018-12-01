using NLog;
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
        ///Объект от класса многоуровневой парковки

        MultiLevelParking parking;

        /// <summary>
        /// Форма для добавления
        /// </summary>
        FormTractorConfig form;

        ///Количествоуровней-парковок

        private const int countLevel = 5;
        /// <summary>
        /// Логгер
        /// </summary>
        private Logger logger;

        
        public FormParking()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            parking = new MultiLevelParking(countLevel, pictureBoxParking.Width,
            pictureBoxParking.Height);
            //заполнение listBox
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
       //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
Bitmap bmp = new Bitmap(pictureBoxParking.Width,
pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parking[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeCar_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBox.Text != "")
                {
                    try
                    {
                        var car = parking[listBoxLevels.SelectedIndex] -
                    Convert.ToInt32(maskedTextBox.Text);
                   
                        Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                        pictureBoxTakeCar.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        car.SetPosition(25, 15, pictureBoxTakeCar.Width,
                        pictureBoxTakeCar.Height);
                        car.DrawCar(gr);
                        pictureBoxTakeCar.Image = bmp;
                        logger.Info("Изъят автомобиль " + car.ToString() + " с места " +
maskedTextBox.Text);
                        Draw();
                    }
catch (ParkingNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                pictureBoxTakeCar.Height);
                pictureBoxTakeCar.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
/// <summary>
/// Метод обработки выбора элемента на listBoxLevels
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void listBoxLevels_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetCar_Click_1(object sender, EventArgs e)
        {
            form = new FormTractorConfig();
            form.AddEvent(AddCar);
            form.Show();
        }
        /// <summary>
        /// Метод добавления машины
        /// </summary>
        /// <param name="car"></param>
        private void AddCar(ITransport car)
        {
            if (car != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    int place = parking[listBoxLevels.SelectedIndex] + car;
                    logger.Info("Добавлен автомобиль " + car.ToString() + " на место " +
     place);
                    Draw();
                }
                catch (ParkingOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    parking.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    parking.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                }
                catch (ParkingOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }
    }
}