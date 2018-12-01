using System;
namespace WindowsFormsTractor
{
    /// <summary>
    /// Класс-ошибка "Если не найден автомобиль по определенному месту"
    /// </summary>
    public class ParkingNotFoundException : Exception
    {
        public ParkingNotFoundException(int i) : base("Не найден автомобиль по месту " +
        i)
        { }
    }
}