using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTractor
{
    class Tractor
    {
        

        /// Левая координата отрисовки автомобиля    
        private float _startPosX; 
     
        /// Правая кооридната отрисовки автомобиля         
        private float _startPosY; 
        
        /// Ширина окна отрисовки        
        private int _pictureWidth;

        //Высота окна отрисовки         
        private int _pictureHeight; 
        
        /// Ширина отрисовки автомобиля  
        private const int carWidth = 72; 
        
        /// Ширина отрисовки автомобиля  
        private const int carHeight = 42; 
  
        /// Максимальная скорость       
        public int MaxSpeed { private set; get; } 
   
        /// Вес автомобиля         
        public float Weight { private set; get; }

        public Color MainColor { private set; get; }
        
        /// Дополнительный цвет    
        public Color DopColor { private set; get; } 

                
        /// Признак наличия переднего спойлера   
        public bool FrontSpoiler { private set; get; }
       
        /// Признак наличия боковых спойлеров       
        public bool SideSpoiler { private set; get; }
       
        /// Признак наличия заднего спойлера          
        public bool BackSpoiler { private set; get; } 
         
        /// Конструктор         
        /// <param name="maxSpeed">Максимальная скорость</param>         
        /// <param name="weight">Вес автомобиля</param>         
        /// <param name="mainColor">Основной цвет кузова</param>         
        /// <param name="dopColor">Дополнительный цвет</param>         
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>         
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>         
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>  
        ///        
        public Tractor(int maxSpeed, float weight, Color mainColor, Color dopColor, bool frontSpoiler, bool sideSpoiler, bool backSpoiler)
        {             
            MaxSpeed = maxSpeed;             
            Weight = weight;             
            MainColor = mainColor;            
            DopColor = dopColor;             
            FrontSpoiler = frontSpoiler;             
            SideSpoiler = sideSpoiler;             
            BackSpoiler = backSpoiler;
        }
      
    /// Установка позиции автомобиля       
    /// <param name="x">Координата X</param>         
    /// <param name="y">Координата Y</param>         
    /// <param name="width">Ширина картинки</param>         
    /// <param name="height">Высота картинки</param>        
    public void SetPosition(int x, int y, int width, int height)        
    {             
        _startPosX = x;             
        _startPosY = y;             
        _pictureWidth = width;             
        _pictureHeight = height;         
    }

        /// Изменение направления пермещения
        /// <param name="direction">Направление</param> 
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 130 / Weight; switch (direction)
            {                 // вправо                 
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
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
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// Отрисовка автомобиля
        /// <param name="g"></param> 
        public void DrawCar(Graphics g)
        {

            Brush spoiler = new SolidBrush(Color.Yellow);
            g.FillRectangle(spoiler, _startPosX + 1, _startPosY + 5, 50, 15);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 25, 6);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY - 15, 6, 20);

            spoiler = new SolidBrush(Color.Black);
            g.FillRectangle(spoiler, _startPosX +2, _startPosY - 15, 20, 25);
            g.FillEllipse(spoiler, _startPosX + 40, _startPosY + 15, 12, 12);
            g.FillEllipse(spoiler, _startPosX, _startPosY + 15, 12, 12);
            g.FillRectangle(spoiler, _startPosX - 20, _startPosY , 10, 10);
            spoiler = new SolidBrush(Color.LightBlue);
            g.FillRectangle(spoiler, _startPosX + 3 , _startPosY - 10, 7, 15);
        }
    }
}

