import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

public class Parking<T extends Vehicle> {
	// / ������ ��������, ������� ������
	private T[] _places;

	// / ������ ���� ���������
	private int PictureWidth;

	private int getPictureWidth() {
		return PictureWidth;
	}

	private void setPictureWidth(int pictureWidth) {
		PictureWidth = pictureWidth;
	}

	// / ������ ���� ���������
	private int PictureHeight;

	private int getPictureHeight() {
		return PictureHeight;
	}

	private void setPictureHeight(int pictureHeight) {
		PictureHeight = pictureHeight;
	}

	// / ������ ������������ ����� (������)
	private int _placeSizeWidth = 210;

	// / ������ ������������ ����� (������)
	private int _placeSizeHeight = 80;

	// / �����������
	// / <param name="sizes">���������� ���� �� ��������</param>
	// / <param name="pictureWidth">������ �������� - ������</param>
	// / <param name="pictureHeight">������ �������� - ������</param>
	@SuppressWarnings("unchecked")
	public Parking(int sizes, int pictureWidth, int pictureHeight) {
		_places = (T[]) new Vehicle[sizes];
		setPictureWidth(pictureWidth);
		setPictureHeight(pictureHeight);
		for (int i = 0; i < _places.length; i++) {
			_places[i] = null;
		}
	}

	// / ���������� ��������� ��������
	// / ������ ��������: �� �������� ����������� ����������
	// / <param name="p">��������</param>
	// / <param name="tractor">����������� ����������</param>
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

	// / ���������� ��������� ���������
	// / ������ ��������: � �������� �������� ����������
	// / <param name="p">��������</param>
	// / <param name="index">������ �����, � �������� �������� �������
	// ������</param>
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

	// / ����� �������� ������������ ������������ ����� (������ �������)
	// / <param name="index">����� ������������ ����� (���������� ����� �
	// �������)</param>
	// / <returns></returns>
	private boolean CheckFreePlace(int index) {
		return _places[index] == null;
	}

	// / ����� ��������� ��������
	// / <param name="g"></param>
	public void Draw(Graphics g) {
		DrawMarking(g);
		for (int i = 0; i < _places.length; i++) {
			if (!CheckFreePlace(i)) {// ���� ����� �� ������
				_places[i].DrawTractor(g);
			}
		}
	}

	// / ����� ��������� �������� ����������� ����
	// / <param name="g"></param>
	private void DrawMarking(Graphics gr) {
		Graphics2D g = (Graphics2D) gr;
		g.setStroke(new BasicStroke(3));
		g.setColor(Color.BLACK);
		// ������� ��������
		g.drawRect(0, 0, (_places.length / 5) * _placeSizeWidth, 480);
		for (int i = 0; i < _places.length / 5; i++) {// ������������, �� 5 ����
														// �� �����
			for (int j = 0; j < 6; ++j) {// ����� �������� �����
				g.drawLine(i * _placeSizeWidth, j * _placeSizeHeight, i
						* _placeSizeWidth + 110, j * _placeSizeHeight);
			}
			g.drawLine(i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
		}
	}
}