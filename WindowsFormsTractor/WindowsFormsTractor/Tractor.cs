﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTractor
{
   
    class Tractor : Vehicle
    {
        /// Ширина отрисовки автомобиля  
        private const int tractorWidth = 72; 
        
        /// Ширина отрисовки автомобиля  
        private const int tractorHeight = 42; 
       
        public bool Kovsh { private set; get; }

        /// Конструктор         
        /// <param name="maxSpeed">Максимальная скорость</param>         
        /// <param name="weight">Вес автомобиля</param>         
        /// <param name="mainColor">Основной цвет кузова</param>         
        /// <param name="dopColor">Дополнительный цвет</param>
        ///        
        public Tractor(int maxSpeed, float weight, Color mainColor)
        {             
            MaxSpeed = maxSpeed;             
            Weight = weight;             
            MainColor = mainColor;
        }
      
        /// Изменение направления пермещения
        /// <param name="direction">Направление</param> 
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 130 / Weight; switch (direction)
            {                 // вправо                 
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - tractorWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево                 
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх                 
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз                 
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - tractorHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// Отрисовка автомобиля
        /// <param name="g"></param> 
        public override void DrawTractor(Graphics g)
        {
            Brush spoiler = new SolidBrush(Color.Yellow);
            g.FillRectangle(spoiler, _startPosX + 1, _startPosY + 5, 50, 15);
            spoiler = new SolidBrush(Color.Black);
            g.FillRectangle(spoiler, _startPosX +2, _startPosY - 15, 20, 25);
            g.FillEllipse(spoiler, _startPosX + 40, _startPosY + 15, 12, 12);
            g.FillEllipse(spoiler, _startPosX, _startPosY + 15, 12, 12);
            spoiler = new SolidBrush(MainColor);
            g.FillRectangle(spoiler, _startPosX + 3 , _startPosY - 10, 7, 15);
        }
    }
}

