import java.awt.Color;
import java.awt.Graphics;


abstract class Vehicle implements ITransport {
	/// <summary>         
    /// ����� ���������� ��������� ����������         
    /// </summary>         
    protected int _startPosX;


    /// <summary>         
    /// ������ ���������� ��������� ����������         
    /// </summary>         
    protected int _startPosY;


    /// <summary>         
    /// ������ ���� ���������         
    /// </summary>         
    protected int _pictureWidth;


    //������ ���� ���������         
    protected int _pictureHeight;


    /// <summary>         
    /// ������������ ��������         
    /// </summary>         
    public abstract int getMaxSpeed();


    /// <summary>         
    /// ��� ����������         
    /// </summary>         
    public abstract float getWeight();


    /// <summary>         
    /// �������� ���� ������         
    /// </summary>         
    public abstract Color getMainColor();

    /// ��������� ������� ����������       
    /// <param name="x">���������� X</param>         
    /// <param name="y">���������� Y</param>         
    /// <param name="width">������ ��������</param>         
    /// <param name="height">������ ��������</param>  
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
