import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

public class Parking<T extends Vehicle> {
	// / Массив объектов, которые храним
	private T[] _places;

	// / Ширина окна отрисовки
	private int PictureWidth;

	private int getPictureWidth() {
		return PictureWidth;
	}

	private void setPictureWidth(int pictureWidth) {
		PictureWidth = pictureWidth;
	}

	// / Высота окна отрисовки
	private int PictureHeight;

	private int getPictureHeight() {
		return PictureHeight;
	}

	private void setPictureHeight(int pictureHeight) {
		PictureHeight = pictureHeight;
	}

	// / Размер парковочного места (ширина)
	private int _placeSizeWidth = 210;

	// / Размер парковочного места (высота)
	private int _placeSizeHeight = 80;

	// / Конструктор
	// / <param name="sizes">Количество мест на парковке</param>
	// / <param name="pictureWidth">Рамзер парковки - ширина</param>
	// / <param name="pictureHeight">Рамзер парковки - высота</param>
	@SuppressWarnings("unchecked")
	public Parking(int sizes, int pictureWidth, int pictureHeight) {
		_places = (T[]) new Vehicle[sizes];
		setPictureWidth(pictureWidth);
		setPictureHeight(pictureHeight);
		for (int i = 0; i < _places.length; i++) {
			_places[i] = null;
		}
	}

	// / Перегрузка оператора сложения
	// / Логика действия: на парковку добавляется автомобиль
	// / <param name="p">Парковка</param>
	// / <param name="tractor">Добавляемый автомобиль</param>
	// / <returns></returns>
	public int addTractor(Parking<T> p, T tractor) {
		for (int i = 0; i < p._places.length; i++) {
			if (p.CheckFreePlace(i)) {
				p._places[i] = tractor;
				p._places[i].SetPosition(25 + i / 5 * p._placeSizeWidth + 5, i
						% 5 * p._placeSizeHeight + 30, p.getPictureWidth(),
						p.getPictureHeight());
				return i;
			}
		}
		return -1;
	}

	// / Перегрузка оператора вычитания
	// / Логика действия: с парковки забираем автомобиль
	// / <param name="p">Парковка</param>
	// / <param name="index">Индекс места, с которого пытаемся извлечь
	// объект</param>
	// / <returns></returns>
	public T removeTractor(Parking<T> p, int index) {
		if (index < 0 || index > p._places.length) {
			return null;
		}
		if (!p.CheckFreePlace(index)) {
			T tractor = p._places[index];
			p._places[index] = null;
			return tractor;
		}
		return null;
	}

	// / Метод проверки заполнености парковочного места (ячейки массива)
	// / <param name="index">Номер парковочного места (порядковый номер в
	// массиве)</param>
	// / <returns></returns>
	private boolean CheckFreePlace(int index) {
		return _places[index] == null;
	}

	// / Метод отрисовки парковки
	// / <param name="g"></param>
	public void Draw(Graphics g) {
		DrawMarking(g);
		for (int i = 0; i < _places.length; i++) {
			if (!CheckFreePlace(i)) {// если место не пустое
				_places[i].DrawTractor(g);
			}
		}
	}

	// / Метод отрисовки разметки парковочных мест
	// / <param name="g"></param>
	private void DrawMarking(Graphics gr) {
		Graphics2D g = (Graphics2D) gr;
		g.setStroke(new BasicStroke(3));
		g.setColor(Color.BLACK);
		// границы праковки
		g.drawRect(0, 0, (_places.length / 5) * _placeSizeWidth, 480);
		for (int i = 0; i < _places.length / 5; i++) {// отрисовываем, по 5 мест
														// на линии
			for (int j = 0; j < 6; ++j) {// линия рамзетки места
				g.drawLine(i * _placeSizeWidth, j * _placeSizeHeight, i
						* _placeSizeWidth + 110, j * _placeSizeHeight);
			}
			g.drawLine(i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
		}
	}
}