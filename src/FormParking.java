import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.border.LineBorder;
import java.awt.Color;
import javax.swing.JTextField;


public class FormParking {

	public JFrame frame;
	private Panel_pictureBoxParking panel;
	private JTextField maskedTextBox;
	
    public FormParking() {
		initialize();
		Draw();
	}
	
	/// Метод отрисовки парковки         	
    private void Draw()
    {
    	panel.repaint();
    }

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 804, 452);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel_main = new JPanel();
		frame.getContentPane().add(panel_main);
		panel_main.setLayout(null);
		
		panel = new Panel_pictureBoxParking();
		panel.setBounds(0, 0, 517, 413);
		panel_main.add(panel);
		
		JButton btnn = new JButton("\u041F\u0440\u0438\u043F\u0430\u0440\u043A\u043E\u0432\u0430\u0442\u044C \u0442\u0440\u0430\u043A\u0442\u043E\u0440-\u044D\u043A\u0441\u043A\u0430\u0432\u0430\u0442\u043E\u0440");
		btnn.setBounds(527, 45, 251, 23);
		panel_main.add(btnn);
		
		JButton button1 = new JButton("\u041F\u0440\u0438\u043F\u0430\u0440\u043A\u043E\u0432\u0430\u0442\u044C \u0442\u0440\u0430\u043A\u0442\u043E\u0440");
		button1.setBounds(552, 11, 204, 23);
		panel_main.add(button1);
		
		JLabel pictureBoxTakeCar = new JLabel("");
		pictureBoxTakeCar.setBounds(527, 333, 251, 80);
		panel_main.add(pictureBoxTakeCar);
		
		JPanel panel_1 = new JPanel();
		panel_1.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel_1.setBounds(527, 229, 251, 104);
		panel_main.add(panel_1);
		panel_1.setLayout(null);
		
		JLabel label_1 = new JLabel("\u041C\u0435\u0441\u0442\u043E");
		label_1.setBounds(33, 30, 58, 20);
		panel_1.add(label_1);
		
		JButton button3 = new JButton("\u0417\u0430\u0431\u0440\u0430\u0442\u044C");
		button3.setBounds(32, 70, 188, 23);
		panel_1.add(button3);
		
		maskedTextBox = new JTextField();
		maskedTextBox.setBounds(92, 30, 33, 20);
		panel_1.add(maskedTextBox);
		maskedTextBox.setColumns(10);
		
		JLabel label = new JLabel("\u0417\u0430\u0431\u0440\u0430\u0442\u044C \u043C\u0430\u0448\u0438\u043D\u0443");
		label.setBounds(527, 212, 251, 14);
		panel_main.add(label);
	}
}
