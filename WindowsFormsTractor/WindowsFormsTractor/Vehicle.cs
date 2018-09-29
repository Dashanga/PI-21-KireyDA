using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTractor
{
    abstract class Vehicle : ITransport
    {
        /// <summary>         
        /// Левая координата отрисовки автомобиля         
        /// </summary>         
        protected float _startPosX;


        /// <summary>         
        /// Правая кооридната отрисовки автомобиля         
        /// </summary>         
        protected float _startPosY;


        /// <summary>         
        /// Ширина окна отрисовки         
        /// </summary>         
        protected int _pictureWidth;


        //Высота окна отрисовки         
        protected int _pictureHeight;


        /// <summary>         
        /// Максимальная скорость         
        /// </summary>         
        public int MaxSpeed { protected set; get; }


        /// <summary>         
        /// Вес автомобиля         
        /// </summary>         
        public float Weight { protected set; get; }


        /// <summary>         
        /// Основной цвет кузова         
        /// </summary>         
        public Color MainColor { protected set; get; }

        /// Установка позиции автомобиля       
        /// <param name="x">Координата X</param>         
        /// <param name="y">Координата Y</param>         
        /// <param name="width">Ширина картинки</param>         
        /// <param name="height">Высота картинки</param>  
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = 130;
            _startPosY = 130;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public abstract void DrawCar(Graphics g);

        public abstract void MoveTransport(Direction direction);
    }
}
