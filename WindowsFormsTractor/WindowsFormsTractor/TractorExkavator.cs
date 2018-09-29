﻿using System;
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
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>         
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>         
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>  
        
        public Color DopColor { private set; get; }
        public TractorExkavator(int maxSpeed, float weight, Color mainColor, Color dopColor) : base (maxSpeed, weight, mainColor)         
        {
            DopColor = dopColor;
        }

        public override void DrawCar(Graphics g)
        {
            base.DrawCar(g);
            Brush spoiler = new SolidBrush(DopColor);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 25, 6);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 6, 20);
            spoiler = new SolidBrush(Color.Black);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY, 10, 10);
        }
    }
}
