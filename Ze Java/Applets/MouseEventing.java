import objectdraw.*;
import java.awt.*;

public class MouseEventing extends WindowController{

	public static void main(String args[]){
		new Acme.MainFrame(new MouseEventing(), args, 200, 250);
	}


	double width = 50;
	double height = 30;

	public void begin(){
		new Text("Touch somewhere", 50, 50, canvas);
	}

	public void OnMousePressed(Location point){
		canvas.clear();
		new Text("Touched here", point.getX(), point.getY(), canvas);
		new FilledRect(10, 50, width, height, canvas);
		new FilledOval(140, 175, width, height, canvas);
	}

	public void OnMouseReleased(Location point){
		canvas.clear();
		new Text("Released", point.getX(), point.getY(), canvas);
		new FramedRect(10, 50, width, height, canvas);
		new FramedOval(140, 175, width, height, canvas);
		
		Thread.sleep(2000);
		canvas.clear();
	}


}