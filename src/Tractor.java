import java.awt.Color;
import java.awt.Graphics;

class Tractor {
	/// <summary>         
    /// ����� ���������� ��������� ����������         
    /// </summary>         
    protected int _startPosX;

    /// <summary>         
    /// ������ ���������� ��������� ����������         
    /// </summary>         
    protected int _startPosY;
    
	// ����� ��������� ��������
	private int carWidth = 72;
	// ������ ��������� ��������
	private int carHeight = 42;
	       
    // ������ ���� ���������         
    protected int _pictureWidth;
    //������ ���� ���������         
    protected int _pictureHeight;

    // ������������ ��������  
	private int MaxSpeed;
    public int getMaxSpeed() {
    	return MaxSpeed;
    }
//    private void setMaxSpeed(int value) {
//    	MaxSpeed = value;
//    }
    
    /// ��� ��������         
    private float Weight;
    public float getWeight() { 
    	return Weight; 
    }
//    private void setWeight(float value) {
//    	Weight = value;
//    }

    /*
     * �����������
        /// <param name="maxSpeed">������������ ��������</param>         
        /// <param name="weight">��� ����������</param>         
        /// <param name="mainColor">�������� ���� ������</param>         
        /// <param name="dopColor">�������������� ����</param>         
        /// <param name="frontSpoiler">������� ������� ��������� ��������</param>         
        /// <param name="sideSpoiler">������� ������� ������� ���������</param>         
        /// <param name="backSpoiler">������� ������� ������� ��������</param>  
     */
	public Tractor(int maxSpeed, float weight, Color mainColor) {
        MaxSpeed = maxSpeed; //��� setMaxSpeed(maxSpeed);             
        Weight = weight; //��� setWeight(weight); 
	}

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
	
	/// ��������� ����������� ����������
    /// <param name="direction">�����������</param> 
    public void MoveTransport(Direction direction)
    {
        float step = MaxSpeed * 130 / Weight; 
        switch (direction) {                 
        	// ������                 
            case Right:
            	toRight();
                break;
            //�����                 
            case Left:
                toLeft();
                break;
            //�����                 
            case Up:
                Up();
                break;
            //����                 
            case Down:
                Down();
                break;
        }
    }

	private void toRight() {
		if (_startPosX < 700)
			_startPosX += 20;
	}

	private void toLeft() {
		if (_startPosX > 35)
			_startPosX -= 20;
	}

	private void Down() {
		if (_startPosY < 440)
			_startPosY += 20;
	}

	private void Up() {
		if (_startPosY > 30)
			_startPosY -= 20;
	}

	//��������� ��������
	public void DrawCar(Graphics g) {
		g.setColor(Color.yellow);
		g.fillRect(_startPosX + 1, _startPosY + 5, 50, 15);
        g.fillRect(_startPosX - 20, _startPosY - 15, 25, 6);
        g.fillRect(_startPosX - 20, _startPosY - 15, 6, 20);
		
		g.setColor(Color.BLACK);
		g.fillRect(_startPosX + 2, _startPosY - 15, 20, 25);
		g.fillOval(_startPosX + 40, _startPosY + 15, 12, 12);
        g.fillRect(_startPosX - 20, _startPosY , 10, 10);
		g.fillOval(_startPosX, _startPosY + 15, 12, 12);
		
		g.setColor(Color.CYAN);
		g.fillRect(_startPosX + 3, _startPosY - 10, 7, 15);
	}
}
