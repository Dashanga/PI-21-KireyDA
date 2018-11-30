import java.awt.Graphics;

import javax.swing.JPanel;


public class Panel_pictureBoxTractor extends JPanel {

	private Tractor tractor;
	public Panel_pictureBoxTractor() {
		setBounds(0, 28, 780, 485);
	}
	
	public void addCar(Tractor t){
		this.tractor = t;
	}
	
	public void paint(Graphics gr) {
		super.paint(gr);
		if(tractor != null)
			tractor.DrawCar(gr);
	}
}
