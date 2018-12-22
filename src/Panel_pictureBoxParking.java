import java.awt.Graphics;

import javax.swing.JPanel;


public class Panel_pictureBoxParking extends JPanel {

	private Tractor tractor;
	
	/// Объект от класса-парковки
	private Parking<Vehicle> parking;
	public void setParking(Parking<Vehicle> parking) {
		this.parking = parking;
	}
	
	public void addCar(Tractor t){
		this.tractor = t;
	}
	
	public void paint(Graphics gr) {
		super.paint(gr);
		parking.Draw(gr);
		if(tractor != null)
			tractor.DrawTractor(gr);
	}
}
