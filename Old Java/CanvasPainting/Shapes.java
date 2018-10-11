import java.lang.*;
import java.util.*;
import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.scene.input.*;
import javafx.event.*;
import javafx.geometry.*;
import javafx.collections.*;
import javafx.beans.value.*;
import javafx.scene.canvas.*;
import javafx.scene.paint.*;
import javafx.scene.paint.*;
import javafx.scene.shape.*;



public interface Shapes{
	final double size = 15;
	void remove();
}


class Rectangle implements Shapes{
	Color Colors[] = {Color.GREEN, Color.BLUE, Color.RED, Color.PINK, Color.ORANGE, Color.CYAN, Color.PURPLE};
	GraphicsContext gc;
	int x, y;	

	Rectangle(int x, int y, Canvas can){
		gc = can.getGraphicsContext2D();
		gc.setFill(Colors[Colors.length*(int)Math.random()]);
		gc.fillRect(x, y, size, 2*size);
	}

	public void remove(){
		gc.clearRect(x, y, size, 2*size);
	}
}


class Star implements Shapes{
	Color Colors[] = {Color.GREEN, Color.BLUE, Color.RED, Color.PINK, Color.ORANGE, Color.CYAN, Color.PURPLE};
	GraphicsContext gc;
	int x, y; 			//doesn't use this, only parameters in constructor

	Star(int x, int y, Canvas can){
		gc = can.getGraphicsContext2D();
		gc.setFill(Colors[Colors.length*(int)Math.random()]);
		for(int i = 1; i > -3; i-=2){
			gc.strokeLine(i*x, y-size/2, i*(x+size/6), y-size/6);
			gc.strokeLine(i*(x+size/6), y-size/6, i*(x+size/2), y);
			gc.strokeLine(i*(x+size/2), y, i*(x+size/4), y+size/6);
			gc.strokeLine(i*(x+size/4), y+size/6, i*(x+size/3), y+size/2);
			gc.strokeLine(i*(x+size/3), y+size/2, i*x, y+size/4);
		}
	}

	public void remove(){
		for(int i = 1; i > -3; i-=2){
			gc.setStroke(Color.TRANSPARENT);
			gc.strokeLine(i*x, y-size/2, i*(x+size/6), y-size/6);
			gc.strokeLine(i*(x+size/6), y-size/6, i*(x+size/2), y);
			gc.strokeLine(i*(x+size/2), y, i*(x+size/4), y+size/6);
			gc.strokeLine(i*(x+size/4), y+size/6, i*(x+size/3), y+size/2);
			gc.strokeLine(i*(x+size/3), y+size/2, i*x, y+size/4);
			gc.setStroke(Color.BLACK);
		}
	}
}

class ThreadRunner implements Runnable{
	Color Colors[] = {Color.GREEN, Color.BLUE, Color.RED, Color.PINK, Color.ORANGE, Color.CYAN, Color.PURPLE};
	GraphicsContext gc;
	Canvas canvas;
	Thread th;
	private int currSpeed;
	static int iterations = 10;
	static boolean style = true;

	ThreadRunner(Canvas c){
		gc = c.getGraphicsContext2D();
		canvas = c;  				//refrence to object
		currSpeed = iterations;
		iterations += 10;
		
		th = new Thread(this);
		th.start();
	}


	public void run(){
	  while(true){
		Random rand = new Random();
		for(int y = 0; y < canvas.getHeight(); y+=5){
			for(int x = 0; x < canvas.getWidth(); x+=5){
				int c = rand.nextInt(Colors.length) + 0;
				gc.setFill(Colors[c]);
				int i = 1;
				if(style){
					if(i==0){
						gc.clearRect(0, 0, canvas.getWidth(), canvas.getHeight());
						i = 1;
					}

					gc.fillRect(x, y, 5, 5);
				}
				else{
					gc.strokeRect(x, y, 5, 5);
					i = 0;
				}
				try{
					th.sleep(currSpeed/10);
				}
				catch(InterruptedException exc){
					System.out.println("Error Interruption has occurred");
				}
			}
		}
	   }
	}



	public void changeStyle(){
		style = !style;
	}
}

//Shapes<? extends Shapes> currShape;