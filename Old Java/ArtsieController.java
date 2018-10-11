import java.util.*;
import java.io.*;
import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.scene.shape.*;
import javafx.scene.paint.*;
import javafx.scene.canvas.*;
import javafx.scene.input.*;
import javafx.geometry.*;
import javafx.event.*;
import javafx.collections.*;
import javafx.beans.value.*;

public class ArtsieController extends Application{
Canvas can;
GraphicsContext gc;

double drawX, drawY;

ArrayList<Icon> icons = new ArrayList<Icon>();
BackgroundColorsBased bcb;
String titles[] = {"Art at its Best!", "Wow it's like a drug trip", "Like whoa dude!", "Hey."};
int x = 50;
int y = 50;
Color backgroundColors[] = new Color[3];;

Scene scenes[];

public static void main(String args[]){
  launch(args);
}

public void start(Stage myStage) throws Exception{
  myStage.setTitle(titles[titles.length*(int)Math.random()]);
  BorderPane bp = new BorderPane();
  Scene myScene = new Scene(bp, 500, 750);
  myStage.setScene(myScene);

  can = new Canvas(500, 700);
  gc = can.getGraphicsContext2D();
  
  bcb = new BackgroundColorsBased(can);

  //Class[] objectList = {Class.forName("Sun"), Class.forName("Moon"), Class.forName("Flowers"), Class.forName("Cultures")};
  String[] posObjects = {"Sun", "Moon", "Flowers", "Cultures"};

  bp.setOnKeyPressed(new EventHandler<KeyEvent>(){
    public void handle(KeyEvent ke){
       if(ke.getCode() == KeyCode.UP){
         
       }
     }
  });

  myScene.setOnMousePressed(new EventHandler<MouseEvent>(){
    public void handle(MouseEvent me){
      drawX = me.getX();
      drawY = me.getY();

      Icon[] is = new Icon[icons.size()];
      for(int i= 0; i < icons.size(); i++){
         is[i] = icons.get(i);
      }

      for(int i = 0; i < icons.size(); i++){
        icons.get(i).adjustPallette(bcb, is);
      }
      bcb.drawBackground();
    }
  });


  myScene.setOnMouseReleased(new EventHandler<MouseEvent>(){
    public void handle(MouseEvent me){
      drawX = 0;
      drawY = 0;

      Icon[] is = new Icon[icons.size()];
      for(int i= 0; i < icons.size(); i++){
         is[i] = icons.get(i);
      }

      for(int i = 0; i < icons.size(); i++){
        icons.get(i).adjustPallette(bcb, is);
      }
      bcb.drawBackground();
    }
  });

  myScene.setOnMouseDragged(new EventHandler <MouseEvent>(){
    public void handle(MouseEvent me){
       gc.strokeLine(drawX, drawY, me.getX(), me.getY());
       
       drawX = me.getX();
       drawY = me.getY();
    }
  });
     
  TextField tf = new TextField("Direct Me!");
   tf.setPrefColumnCount(20);

  bp.setCenter(can);
  bp.setBottom(tf);

   tf.setOnAction(new EventHandler<ActionEvent>(){
      public void handle(ActionEvent ae){
        try{
         if(tf.getText().toLowerCase().equals("stop") || tf.getText().toLowerCase().indexOf("stop") != -1){
           System.exit(1);
         }
         else if(tf.getText().toLowerCase().equals("restart") || tf.getText().toLowerCase().indexOf("restart") != -1){
            BorderPane bp1 = new BorderPane();
            Canvas can1 = new Canvas();
            GraphicsContext gc1 = can1.getGraphicsContext2D();
            bp1.setCenter(can1);
            bp1.setBottom(tf);
            scenes = new Scene[5];
            scenes[0] = new Scene(bp1, 500, 750);
            myStage.setScene(scenes[0]);

            bp1.getChildren().addAll(can1, tf);
             
            x = y = 0;
            for(int i = 2; i < can.getWidth()/50; i++){
               int index = (int)(Math.random()* posObjects.length);
               switch(posObjects[index]){
                  case "Sun":
                       icons.add(new Sun(can1, x+= 50, y+= 50));
                       break;
                   case "Moon":
                        icons.add(new Moon(can1, x+=50, y+=50));
                        break;
                    case "Flowers":
                         icons.add(new Flowers(can1, x+=50, y+=50));
                         break;
                     case "Cultures":
                         icons.add(new Cultures(can1, x+=50, y+= 50));
                         break;
                    }

             }
           }
           else{
              myStage.setScene(myScene);
           }
          }catch(Exception exc){
            System.out.println("Error");
           }
        }
    });
 
 for(int i = 2; i < can.getWidth()/50; i++){

               int index = (int)(Math.random()*posObjects.length);
               switch(posObjects[index]){
                  case "Sun":
                       icons.add(new Sun(can, x+= 50, y+= 50));
                       break;
                   case "Moon":
                        icons.add(new Moon(can, x+=50, y+=50));
                        break;
                    case "Flowers":
                         icons.add(new Flowers(can, x+=50, y+=50));
                         break;
                     case "Cultures":
                         icons.add(new Cultures(can, x+=50, y+= 50));
                         break;
                    }
  }
  System.out.println(icons.get(0));


  myStage.show();
 }

}
  