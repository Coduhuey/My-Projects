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


public class RefrencesMain extends Application{

	int h = 0;
	int index = 0;
	Shapes currShapes[] = new Shapes[10];
	double prevX;
	double prevY;

	public static void main(String args[]){
		launch(args);
	}

	public void start(Stage myStage){
		myStage.setTitle("Spawn Refrences");
		FlowPane fp = new FlowPane();
		fp.setAlignment(Pos.CENTER);
		Scene myScene = new Scene(fp, 750, 600);
		myStage.setScene(myScene);
	
		Canvas canvas = new Canvas(750, 600);
		GraphicsContext gc = canvas.getGraphicsContext2D();
		
		/*for(int i = 0; i<5; i++){*/
			new ThreadRunner(canvas);
		/*}*/

		myScene.setOnMousePressed(new EventHandler<MouseEvent>(){
			public void handle(MouseEvent me){
				prevX = me.getX();
				prevY = me.getY();
				h++;
			  	if(h==1){
					currShapes[index++] = new Rectangle((int)me.getX(), (int)me.getY(), canvas);
				}
				if(h==2){
					h=0;
					currShapes[index++] = new Star((int)me.getX(), (int)me.getY(), canvas);
				}

				int y = currShapes.length;
				if(index >= currShapes.length){
					Shapes sh[] = new Shapes[index];
					for(Shapes s : currShapes) sh[y++] = s;
					currShapes = sh;
				}
			}
		});

		myScene.setOnMouseDragged(new EventHandler<MouseEvent>(){
			public void handle(MouseEvent me){
				Paint prevColor = gc.getStroke();
				gc.setStroke(Color.BEIGE);
				gc.strokeLine(prevX, prevY, me.getX(), me.getY());
				gc.setStroke(prevColor);
				prevX = me.getX();
				prevY = me.getY();
			}
		});

		/*myScene.setOnMouseExited(new EventHandler<MouseEvent>(){
			public void handle(MouseEvent me){
				for(Shapes s : currShapes)
					s.remove();
				}
			});	
		*/
		
		fp.getChildren().add(canvas);
		myStage.show();			
	}
}