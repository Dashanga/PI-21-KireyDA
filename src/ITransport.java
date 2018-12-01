import java.awt.Graphics;

interface ITransport {
	/// <summary>         
    /// ��������� ������� ����������         
    /// </summary>         
    /// <param name="x">���������� X</param>         
    /// <param name="y">���������� Y</param>         
    /// <param name="width">������ ��������</param>         
    /// <param name="height">������ ��������</param>         
    void SetPosition(int x, int y, int width, int height);
    
    /// <summary>         
    /// ��������� ����������� ����������         
    /// </summary>         
    /// <param name="direction">�����������</param>         
    void MoveTransport(Direction direction);
    
    /// <summary>         
    /// ��������� ����������         
    /// </summary>         
    /// <param name="g"></param>         
    void DrawCar(Graphics g);
}