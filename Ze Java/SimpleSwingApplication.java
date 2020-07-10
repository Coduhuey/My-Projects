import javax.swing.*;

class SimpleSwingApplication{

	SimpleSwingApplication(){
		
		JFrame jfram = new JFrame("A Simple Swing Application");

		jfram.setSize(275, 100);

		jfram.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 		//forgot JFrame. before EXIT_ON_CLOSE

		
		JLabel jlab = new JLabel("Swing allows for the making of desktop applications");
		
		jfram.add(jlab);
	
		jfram.setVisible(true);

	}


	public static void main(String args[]){

		SwingUtilities.invokeLater(new Runnable(){ //invokes run method after thread for it is made

			public void run(){
	
				new SimpleSwingApplication(); //constructs a new application with all of the swing component, containers, and variations defined in the class constructor
			
			}
		
		}); //all in one parenthesis as one method so it can apply the thread and know what to invoke first
	}
}