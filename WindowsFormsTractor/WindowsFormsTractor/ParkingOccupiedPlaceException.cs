using System;
namespace WindowsFormsTractor
{
    /// <summary>
    /// Класс-ошибка "Если место, на которое хотим поставить автомобиль уже занято"
    /// </summary>
    public class ParkingOccupiedPlaceException : Exception
    {
        public ParkingOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит автомобиль")
        { }
    }
}