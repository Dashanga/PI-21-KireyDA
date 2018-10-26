import java.awt.Color;
import java.awt.Graphics;

class Tractor extends Vehicle {
	// Длина отрисовки трактора
	private int carWidth = 72;
	// Ширина отрисовки трактора
	private int carHeight = 42;
	

    // Максимальная скорость  
	private int MaxSpeed;
	@Override
    public int getMaxSpeed() {
    	return MaxSpeed;
    }
//    private void setMaxSpeed(int value) {
//    	MaxSpeed = value;
//    }
    
    /// Вес трактора         
    private float Weight;
	@Override
    public float getWeight() { 
    	return Weight; 
    }
//    private void setWeight(float value) {
//    	Weight = value;
//    }
	

	// Основной цвет
	private Color MainColor;
	@Override
	public Color getMainColor() {
		return MainColor;
	}

    /*
     * Конструктор
        /// <param name="maxSpeed">Максимальная скорость</param>         
        /// <param name="weight">Вес автомобиля</param>         
        /// <param name="mainColor">Основной цвет кузова</param>         
        /// <param name="dopColor">Дополнительный цвет</param>         
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>         
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>         
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>  
     */
	public Tractor(int maxSpeed, float weight, Color mainColor) {
        MaxSpeed = maxSpeed; //или setMaxSpeed(maxSpeed);             
        Weight = weight; //или setWeight(weight);          
        MainColor = mainColor;      
	}
	
	/// Изменение направления пермещения
    /// <param name="direction">Направление</param> 
    public void MoveTransport(Direction direction)
    {
        float step = MaxSpeed * 130 / Weight; 
        switch (direction) {                 
        	// вправо                 
            case Right:
            	toRight();
                break;
            //влево                 
            case Left:
                toLeft();
                break;
            //вверх                 
            case Up:
                Up();
                break;
            //вниз                 
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

	//Отрисовка трактора
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
