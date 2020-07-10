import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.layout.*;
import javafx.scene.control.*;
import javafx.scene.paint.*;
import javafx.scene.effect.*;
import javafx.scene.transform.*;
import javafx.beans.value.*;
import javafx.event.*;
import javafx.geometry.*;


public class SFX extends Application{

	Button btnScale = new Button("Scale");
	Button btnRotate = new Button("Rotate");
	Button btnGlow = new Button("Glow");
	Button btnins = new Button("InnerShadow");

	double scaleFactor = 1.5;
	double angle = 0;					//defined changing variables, effects, transforms, and controls/nodes that will be altered in events
	double glowPower = 0;
	boolean shadowOn = true;

	Scale scale = new Scale(scaleFactor, scaleFactor);
	Rotate rotate = new Rotate(angle, 0, 0);
	Glow glow = new Glow(glowPower);
	InnerShadow ins = new InnerShadow(10, Color.RED); 				//an innershadow is a glow that is behind a node but can be in a different color

	

	public static void main(String args[]){
		launch(args);
	}



	public void start(Stage myStage){
		myStage.setTitle("COOL EFFECTS and MOVES(defining the changes)");
		FlowPane fp = new FlowPane(10, 10);
		fp.setAlignment(Pos.CENTER);
		Scene myScene = new Scene(fp, 500, 600);
		myStage.setScene(myScene);

		
		btnScale.getTransforms().add(scale);
		btnRotate.getTransforms().add(rotate);
		btnGlow.setEffect(glow);
		btnins.setEffect(ins);

		btnScale.setOnAction(new EventHandler<ActionEvent>(){
			public void handle(ActionEvent ae){
				scaleFactor += 2;			//FIRST MANIPULATE the variable!!!
			
				if(scaleFactor >= 10)
					scaleFactor = 4;

				scale.setX(scaleFactor);
				scale.setY(scaleFactor);
			}
		});
	
		btnRotate.setOnAction(new EventHandler<ActionEvent>(){
			public void handle(ActionEvent ae){
				angle += 30;

				rotate.setAngle(angle);
				rotate.setPivotX(btnRotate.getWidth()/2);
				rotate.setPivotY(btnRotate.getWidth()/2);

			}
		});

		btnGlow.setOnAction(new EventHandler<ActionEvent>(){
			public void handle(ActionEvent ae){
				glowPower += .1;

				if(glowPower > 1)
					glowPower = .4;

				glow.setLevel(glowPower);
			}
		});


		btnins.setOnAction(new EventHandler<ActionEvent>(){
			public void handle(ActionEvent ae){
				shadowOn = !shadowOn;

				if(shadowOn){
					btnins.setEffect(ins);
					btnins.setText("Shadow on");
				}
				else{
					btnins.setEffect(null);
					btnins.setText("Shadow off");
				}
			}
		});

		
		fp.getChildren().addAll(btnScale, btnRotate, btnGlow, btnins);

		myStage.show();

	}
}

				