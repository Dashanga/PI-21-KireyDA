import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;

public class TractorForm {

	public JFrame frame;
	private Panel_pictureBoxTractor panel;
	private JButton buttonUp;
	private JButton buttonDown;
	private JButton buttonLeft;
	private JButton buttonRight;
	
	private Tractor tractor;

	/**
	 * Create the application.
	 */
	public TractorForm() {
		InitializeComponent();
	}

    //Метод отрисовки        
    private void Draw()
    {             
        panel.repaint();        
    }

	/**
	 * Initialize the contents of the frame.
	 */
	private void InitializeComponent() {
		frame = new JFrame();
		frame.setBounds(50, 50, 800, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		panel = new Panel_pictureBoxTractor();
		frame.getContentPane().add(panel);
		
		JButton btnInit = new JButton("Создать трактор");
		btnInit.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				tractor = new Tractor(100 + (int)(Math.random() * 300), 1000 + (float)(Math.random() * 2000), Color.BLUE);
				tractor.SetPosition(70, 65, panel.getWidth(),panel.getHeight());
				panel.addCar(tractor);
				Draw();
			}
		});
		btnInit.setBounds(0, 0, 200, 28);
		frame.getContentPane().add(btnInit);
		
		JButton btnInitChild = new JButton("Создать трактор-экскаватор");
		btnInitChild.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				tractor = new TractorExkavator(100 + (int)(Math.random() * 300), 1000 + (float)(Math.random() * 2000), Color.CYAN, Color.YELLOW, true, true);
				tractor.SetPosition(540, 65, panel.getWidth(), panel.getHeight());
				panel.addCar(tractor);
				Draw();
			}
		});
		btnInitChild.setBounds(frame.getWidth()-300, 0, 200, 28);
		frame.getContentPane().add(btnInitChild);
		
		buttonUp = new JButton("^");
		buttonUp.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tractor.MoveTransport(Direction.Up);
				Draw();
			}
		});
		buttonUp.setBounds(686, 515, 49, 23);
		frame.getContentPane().add(buttonUp);
		
		
		buttonDown = new JButton("v");
		buttonDown.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tractor.MoveTransport(Direction.Down);
				Draw();
				
			}
		});
		buttonDown.setBounds(686, 538, 49, 23);
		frame.getContentPane().add(buttonDown);
		

		buttonLeft = new JButton("<");
		buttonLeft.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tractor.MoveTransport(Direction.Left);
				Draw();				
			}
		});
		buttonLeft.setBounds(637, 538, 49, 23);
		frame.getContentPane().add(buttonLeft);
		

		buttonRight = new JButton(">");
		buttonRight.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				tractor.MoveTransport(Direction.Right);
				Draw();
			}
		});
		buttonRight.setBounds(735, 538, 49, 23);
		frame.getContentPane().add(buttonRight);	
	}
}
