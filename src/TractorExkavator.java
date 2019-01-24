import java.awt.Color;
import java.awt.Graphics;

class TractorExkavator extends Tractor {

	/// Дополнительный цвет
	private Color DopColor;

	public boolean getDopColor() {
		return Kovsh;
	}

	/// Признак наличия ковша
	private boolean Kovsh;

	public boolean getKovsh() {
		return Kovsh;
	}

	/// Признак наличия ковша
	private boolean KovshBack;

	public boolean getKovshBack() {
		return KovshBack;
	}

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="maxSpeed">Максимальная скорость</param>
	/// <param name="weight">Вес автомобиля</param>
	/// <param name="mainColor">Основной цвет кузова</param>
	/// <param name="dopColor">Дополнительный цвет</param>
	/// <param name="kovsh">Признак наличия ковша</param>
	public TractorExkavator(int maxSpeed, float weight, Color mainColor, Color dopColor, boolean kovsh,
			boolean kovsh2) {
		super(maxSpeed, weight, mainColor);
		DopColor = dopColor;
		Kovsh = kovsh;
		KovshBack = kovsh2;
	}

	@Override
	public void DrawTractor(Graphics g) {
		if (Kovsh) {
			g.setColor(DopColor);
			g.fillRect(_startPosX - 20, _startPosY - 15, 6, 20);
			g.fillRect(_startPosX - 20, _startPosY - 15, 25, 6);

			g.setColor(Color.BLACK);
			g.fillRect(_startPosX - 20, _startPosY, 10, 10);
		}
		if (KovshBack) {
			g.setColor(DopColor);
			g.fillRect(_startPosX + 50, _startPosY + 10, 20, 6);
			g.setColor(Color.BLACK);
			g.fillRect(_startPosX + 60, _startPosY + 5, 15, 15);
		}
		super.DrawTractor(g);
	}
}