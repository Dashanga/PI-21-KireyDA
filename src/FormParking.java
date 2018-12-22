import javax.swing.JColorChooser;
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.border.LineBorder;

import java.awt.Color;

import javax.swing.JTextField;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

import javax.swing.JComboBox;


public class FormParking {

	public JFrame frame;
	private Panel_pictureBoxParking panel;
	private static final Panel_pictureBoxTractor pictureBoxTakeTractor = new Panel_pictureBoxTractor();
	private static JComboBox<String> listBoxLevels = new JComboBox<String>();
	private JTextField maskedTextBox;
	
	/// Объект от класса-парковки         
    MultiLevelParking parking;
    
    ///Количество уровней-парковок
    private final int countLevel = 5;
    
    public FormParking() {
		initialize();
		parking = new MultiLevelParking(20, panel.getWidth(), panel.getHeight());
		//заполнение comboBox
        for (int i = 0; i < countLevel; i++)
        {
            listBoxLevels.addItem("Уровень" + (i + 1));
        }
        listBoxLevels.setSelectedIndex(0);
		Draw();
	}
	
	/// Метод отрисовки парковки         	
    private void Draw()
    {
    	panel.setParking(parking.getValue(listBoxLevels.getSelectedIndex()));
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
		btnn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				final int selectedLevel = listBoxLevels.getSelectedIndex();
				if (selectedLevel > -1) {
					JPanel dialog = new JPanel();
					Color color = JColorChooser.showDialog(dialog, "Цвет", Color.BLUE);
		            if (color != null)
		            {
		            	JPanel dialogDop = new JPanel();
		            	Color dopColor = JColorChooser.showDialog(dialogDop, "Дополнительный цвет", Color.GRAY);
		            	if (dopColor != null) {
		                TractorExkavator tractor = new TractorExkavator(100, 1000, color, dopColor, true, true);
			                int place = parking.getValue(listBoxLevels.getSelectedIndex()).addTractor(tractor);
	                        if (place == -1)
	                        {
	                        	JOptionPane.showMessageDialog(frame, "Нет свободных мест");
	                        }
			                Draw();
		            	}
		            }
				}
			}
		});
		btnn.setBounds(527, 101, 251, 23);
		panel_main.add(btnn);
		
		JButton button1 = new JButton("\u041F\u0440\u0438\u043F\u0430\u0440\u043A\u043E\u0432\u0430\u0442\u044C \u0442\u0440\u0430\u043A\u0442\u043E\u0440");
		button1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				final int selectedLevel = listBoxLevels.getSelectedIndex();
				if (selectedLevel > -1) {
					JPanel dialog = new JPanel();
					Color color = JColorChooser.showDialog(dialog, "Цвет", Color.BLUE);
		            if (color != null)
		            {
	                Tractor tractor = new Tractor(100, 1000, color);
		                int place = parking.getValue(listBoxLevels.getSelectedIndex()).addTractor(tractor);
                        if (place == -1)
                        {
                        	JOptionPane.showMessageDialog(frame, "Нет свободных мест");
                        }
                        Draw();
		            }
				}
			}
		});
		button1.setBounds(552, 67, 204, 23);
		panel_main.add(button1);
		
		pictureBoxTakeTractor.setBounds(527, 305, 251, 80);
		panel_main.add(pictureBoxTakeTractor);
		pictureBoxTakeTractor.setLayout(null);
		
		JPanel panel_1 = new JPanel();
		panel_1.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel_1.setBounds(527, 201, 251, 104);
		panel_main.add(panel_1);
		panel_1.setLayout(null);
		
		JLabel label_1 = new JLabel("\u041C\u0435\u0441\u0442\u043E:");
		label_1.setBounds(33, 30, 58, 20);
		panel_1.add(label_1);
		
		JButton buttonTakeTractor = new JButton("\u0417\u0430\u0431\u0440\u0430\u0442\u044C");
		buttonTakeTractor.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				final int selectedLevel = listBoxLevels.getSelectedIndex();
				if (selectedLevel > -1)
	            {
					if (maskedTextBox.getText().isEmpty() == false) {
						Vehicle tractor = parking.getValue(selectedLevel).removeTractor(Integer.parseInt(maskedTextBox.getText()));
		                if (tractor != null)
		                {
                    tractor.SetPosition(50, 50, pictureBoxTakeTractor.getWidth(), pictureBoxTakeTractor.getHeight());
                    pictureBoxTakeTractor.addTractor(tractor);
		                }
		                Draw();
                pictureBoxTakeTractor.repaint();
	            
					}
	            }
            }
		});
		buttonTakeTractor.setBounds(32, 70, 188, 23);
		panel_1.add(buttonTakeTractor);
		
		maskedTextBox = new JTextField();
		maskedTextBox.setBounds(92, 30, 33, 20);
		panel_1.add(maskedTextBox);
		maskedTextBox.setColumns(10);
		
		JLabel label = new JLabel("\u0417\u0430\u0431\u0440\u0430\u0442\u044C \u043C\u0430\u0448\u0438\u043D\u0443");
		label.setBounds(527, 212, 251, 14);
		panel_main.add(label);
		
		listBoxLevels.setMaximumRowCount(countLevel);
		listBoxLevels.addActionListener (new ActionListener () {
		    public void actionPerformed(ActionEvent e) {
		        Draw();
		    }
		});
		listBoxLevels.setBounds(612, 11, 166, 20);
		panel_main.add(listBoxLevels);
		
		JLabel label_2 = new JLabel("\u0423\u0440\u043E\u0432\u0435\u043D\u044C:");
		label_2.setBounds(527, 14, 86, 14);
		panel_main.add(label_2);
	}
}
