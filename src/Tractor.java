import java.awt.Color;
import java.awt.Graphics;

class Tractor extends Vehicle {
	// ����� ��������� ��������
	private int carWidth = 72;
	// ������ ��������� ��������
	private int carHeight = 42;
	

    // ������������ ��������  
	private int MaxSpeed;
	@Override
    public int getMaxSpeed() {
    	return MaxSpeed;
    }
//    private void setMaxSpeed(int value) {
//    	MaxSpeed = value;
//    }
    
    /// ��� ��������         
    private float Weight;
	@Override
    public float getWeight() { 
    	return Weight; 
    }
//    private void setWeight(float value) {
//    	Weight = value;
//    }
	

	// �������� ����
	private Color MainColor;
	@Override
	public Color getMainColor() {
		return MainColor;
	}

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
        MainColor = mainColor;      
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
		
		g.setColor(Color.BLACK);
		g.fillRect(_startPosX + 2, _startPosY - 15, 20, 25);
		g.fillOval(_startPosX + 40, _startPosY + 15, 12, 12);
		g.fillOval(_startPosX, _startPosY + 15, 12, 12);
		
		g.setColor(MainColor);
		g.fillRect(_startPosX + 3, _startPosY - 10, 7, 15);
	}
}
