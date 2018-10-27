import java.awt.Color;
import java.awt.Graphics;


abstract class Vehicle implements ITransport {
	/// <summary>         
    /// Левая координата отрисовки автомобиля         
    /// </summary>         
    protected int _startPosX;


    /// <summary>         
    /// Правая кооридната отрисовки автомобиля         
    /// </summary>         
    protected int _startPosY;


    /// <summary>         
    /// Ширина окна отрисовки         
    /// </summary>         
    protected int _pictureWidth;


    //Высота окна отрисовки         
    protected int _pictureHeight;


    /// <summary>         
    /// Максимальная скорость         
    /// </summary>         
    public abstract int getMaxSpeed();


    /// <summary>         
    /// Вес автомобиля         
    /// </summary>         
    public abstract float getWeight();


    /// <summary>         
    /// Основной цвет кузова         
    /// </summary>         
    public abstract Color getMainColor();

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

    public abstract void DrawCar(Graphics g);

    public abstract void MoveTransport(Direction direction);
}
