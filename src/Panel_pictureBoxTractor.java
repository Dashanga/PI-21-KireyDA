import java.awt.Graphics;

import javax.swing.JPanel;


public class Panel_pictureBoxTractor extends JPanel {

	private Vehicle tractor;
	
	public void addTractor(Vehicle t){
		this.tractor = t;
	}
	
	public void paint(Graphics gr) {
		super.paint(gr);
		if(tractor != null)
			tractor.DrawTractor(gr);
	}
}
