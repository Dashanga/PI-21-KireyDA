using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTractor
{
    class TractorExkavator : Tractor
    {
        /// <summary>         
        /// Конструктор         
        /// </summary>         
        /// <param name="maxSpeed">Максимальная скорость</param>         
        /// <param name="weight">Вес автомобиля</param>         
        /// <param name="mainColor">Основной цвет кузова</param>         
        /// <param name="dopColor">Дополнительный цвет</param>  
        /// <param name="kovsh">Признак наличия ковша</param> 

        public Color DopColor { private set; get; }

        /// Признак наличия ковша      
        public bool Kovsh { private set; get; }

        /// Признак наличия ковша      
        public bool KovshBack { private set; get; }

        public TractorExkavator(int maxSpeed, float weight, Color mainColor, 
        Color dopColor, bool kovsh, bool kovsh2) : base (maxSpeed, weight, mainColor)         
        {
            DopColor = dopColor;
            Kovsh = kovsh;
            KovshBack = kovsh2;
        }

        public TractorExkavator(string info) : base(info)
{
            string[] strs = info.Split(';');
            if (strs.Length == 6)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Kovsh = Convert.ToBoolean(strs[4]);
                KovshBack = Convert.ToBoolean(strs[5]);
            }
        }
        public override void DrawCar(Graphics g)
        {
            if (Kovsh)
            {
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 25, 6);
                g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 6, 20);
                spoiler = new SolidBrush(Color.Black);
                g.FillRectangle(spoiler, _startPosX - 20, _startPosY, 10, 10);
            }
            if (KovshBack)
            {
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX + 50, _startPosY + 10 , 20, 6);
                spoiler = new SolidBrush(Color.Black);
                g.FillRectangle(spoiler, _startPosX + 60, _startPosY+5, 15, 15);
            }
            base.DrawCar(g);
        }

        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + Kovsh + ";" +
            KovshBack;
        }
    }
}
