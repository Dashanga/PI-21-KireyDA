﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTractor
{
    public class Parking<T> where T : class, ITransport
    {
        /// Массив объектов, которые храним 
        private T[] _places;

        /// Ширина окна отрисовки    
        private int PictureWidth { get; set; }

        /// Высота окна отрисовки
        private int PictureHeight { get; set; }

        /// Размер парковочного места (ширина)
        private int _placeSizeWidth = 210;

        /// Размер парковочного места (высота)
        private int _placeSizeHeight = 80;

        /// Конструктор
        /// <param name="sizes">Количество мест на парковке</param>         
        /// <param name="pictureWidth">Рамзер парковки - ширина</param>         
        /// <param name="pictureHeight">Рамзер парковки - высота</param>        
        public Parking(int sizes, int pictureWidth, int pictureHeight)
        {
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }

        /// Перегрузка оператора сложения         
        /// Логика действия: на парковку добавляется автомобиль 
        /// <param name="p">Парковка</param>         
        /// <param name="tractor">Добавляемый автомобиль</param>         
        /// <returns></returns>         
        public static int operator +(Parking<T> p, T tractor)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places[i] = tractor;
                    p._places[i].SetPosition(25 + i / 5 * p._placeSizeWidth + 5,
                        i % 5 * p._placeSizeHeight + 30, p.PictureWidth,
                        p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }

        /// Перегрузка оператора вычитания         
        /// Логика действия: с парковки забираем автомобиль  
        /// <param name="p">Парковка</param>         
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>         
        /// <returns></returns>         
        public static T operator -(Parking<T> p, int index)
        {
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckFreePlace(index))
            {
                T tractor = p._places[index];
                p._places[index] = null;
                return tractor;
            }
            return null;
        }


        /// Метод проверки заполнености парковочного места (ячейки массива)      
        /// <param name="index">Номер парковочного места (порядковый номер в массиве)</param>         
        /// <returns></returns>         
        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }

        /// Метод отрисовки парковки         
        /// <param name="g"></param>         
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                if (!CheckFreePlace(i))
                {//если место не пустое                     
                    _places[i].DrawTractor(g);
                }
            }
        }

        /// Метод отрисовки разметки парковочных мест     
        /// <param name="g"></param>         
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы праковки             
            g.DrawRectangle(pen, 0, 0, (_places.Length / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _places.Length / 5; i++)
            {//отрисовываем, по 5 мест на линии                 
                for (int j = 0; j < 6; ++j)
                {//линия рамзетки места                     
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                        i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }
    }
}
