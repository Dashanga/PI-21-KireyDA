using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTractor
{
    public class Parking<T> where T : class, ITransport
    {
        ///Массив объектов, которые храним
        private Dictionary
        <int, T> _places;

        ///Максимальное количество мест на парковке

        private int _maxCount;

        ///Ширинаокнаотрисовки

        private int PictureWidth { get; set; }

        ///Высотаокнаотрисовки

        private int
        PictureHeight { get; set; }

        ///Размер парковочного места (ширина)

        private int _placeSizeWidth = 210;

        ///Размер парковочного места (высота)

        private int _placeSizeHeight = 80;

        ///Конструктор

        ///<param name="sizes">Количество мест на парковке</param>
        ///<param name="pictureWidth">Рамзерпарковки-ширина</param>
        ///<param name="pictureHeight">Рамзерпарковки-высота</param>
        public Parking(
        int sizes,
        int pictureWidth,
        int pictureHeight)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }

        ///Перегрузка оператора сложения
        ///Логика действия: на парковку добавляется автомобиль

        ///<param name="p">Парковка</param>
        ///<param name="car">Добавляемыйавтомобиль</param>
        ///<returns></returns>
        public static int operator +(Parking<T> p, T car)
        {
            if (p._places.Count == p._maxCount)
            {
                throw new ParkingOverflowException();
            }
        
            for
            (int i = 0; i < p._maxCount; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places.Add(i, car);
                    p._places[i].SetPosition(25 + i / 5 * p._placeSizeWidth + 5,
                    i % 5 * p._placeSizeHeight + 35, p.PictureWidth,
                    p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }

        ///Перегрузкаоператоравычитания
        ///Логика действия: с парковки забираем автомобиль

        ///<param name="p">Парковка</param>
        ///<param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        ///<returns></returns>
        public static T operator -(Parking<T> p, int index)
        {
            if (!p.CheckFreePlace(index))
            {
                T car = p._places[index];
                p._places.Remove(index);
                return car;
            }
            throw new ParkingNotFoundException(index);
        }

        ///Метод проверки заполнености парковочного места (ячейки массива)

        ///<param name="index">Номер парковочного места (порядковый номер в массиве)</param>
        ///<returns></returns>
        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }

        ///Методотрисовкипарковки

        ///<param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            var keys = _places.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                _places[keys[i]].DrawCar(g);
            }
        }

        ///Метод отрисовки разметки парковочных мест

        ///<param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границыпраковки
            g.DrawRectangle(pen, 0, 0, (_maxCount / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _maxCount / 5; i++)
            {
                //отрисовываем, по 5 мест на линии
                for (int j = 0; j < 6; ++j)
                {
                    //линиярамзеткиместа
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                    i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public T this[int ind] {
            get {
                if (_places.ContainsKey(ind))
                {
                    return _places[ind];
                }
                throw new ParkingNotFoundException(ind);
            }
            set {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(5 + ind / 5 * _placeSizeWidth + 5, ind % 5 *
                    _placeSizeHeight + 15, PictureWidth, PictureHeight);
                }
                else
                {
                    throw new ParkingOccupiedPlaceException(ind);
                }
            }
        }
    }
}
