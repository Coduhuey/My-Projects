import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.layout.*;

public class JavaFXStages extends Application{

	public static void main(String args[]){
		System.out.println("Launching Application");
		launch(args);
	}


	public void init(){
		System.out.println("Initializing Application");
	}

	public void start(Stage myStage){
		myStage.setTitle("JavaFX Skeleton");  //Stages have titles rather than text (such as in a frame or label)
		
		FlowPane rootnodefp = new FlowPane(); //contains the scene and happens to be the first element of the stage

		Scene myScene = new Scene(rootnodefp, 300, 200);
		myStage.setScene(myScene);

		myStage.show();
	}

	public void stop(){
		System.out.println("Stopped Application");
	}
}