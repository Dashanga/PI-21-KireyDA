import java.awt.Graphics;
import javax.swing.JPanel;


public class Panel_pictureBoxParking extends JPanel {

	private Tractor tractor;
	
	public void addCar(Tractor t){
		this.tractor = t;
	}
	
	public void paint(Graphics gr) {
		super.paint(gr);
		if(tractor != null)
			tractor.DrawCar(gr);
	}
}
