import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.scene.shape.*;
import javafx.scene.paint.*;
import javafx.scene.canvas.*;
import javafx.geometry.*;
import javafx.event.*;
import javafx.collections.*;
import javafx.beans.value.*;

public class BackgroundColorsBased implements Runnable{
  Canvas can;
  GraphicsContext gc;

  //bp.setStyle(COLOR goes here for background color!!!) )))))))

  int r =152;
  int g =152;
  int b = 152;

  Thread th;

  int startR = 254/2; 
  boolean brighten = false;
  
  static Color bCol1;
  static Color bCol2;
  static Color bCol3;

  BackgroundColorsBased(Canvas c){
    can = c;
    gc = c.getGraphicsContext2D();

    setColor();

    th = new Thread(this);
    th.start();
  }

  synchronized void setColor(){
    startR = r;
    bCol1 = Color.rgb(r, g, b);
    bCol2 = Color.rgb(r-35, g-15, b);
    bCol3 = Color.rgb(r-50, g-25, b);
    drawBackground();
  }

  synchronized void setColor(Icon i){
    r += i.getColor().getRed();
    r /= 2;
    b += i.getColor().getBlue();
    b/= 2;
    g += i.getColor().getGreen();
    g /= 2;

    this.setColor();
  }

  Color[] getColors(){

    Color colors[] = {bCol1, bCol2, bCol3};
     return colors;
  }

  public void run(){
     while(true){
         if(brighten){
           r+=2;
           g+= 1;
           b-= 1;
           if(r <= startR-50 || r<=50) brighten = !brighten;
          }
        else if(!brighten){
          r-=2;
          g-=1;
          b+=1;
          if(r >= startR+50 ||  r >= 255) brighten = !brighten;
        }

        setColor();
        
        try{
          Thread.sleep(500);
        }catch(InterruptedException exc) {
           System.out.println("Error Occured!");
         }
     }
  }

  public void drawBackground(){

    gc.setFill(bCol1);
    for(int dx = 0; dx < can.getWidth(); dx++){
      for(int dy = 0; dy < can.getHeight()/3; dy++){
         gc.fillRect(dx, dy, 1, 1);
       }
    }

     gc.setFill(bCol2);
     for(int dx = 0; dx < can.getWidth(); dx++){
       for(int dy = ((int)can.getHeight()/3); dy < ((int)can.getHeight()*(2/3)); dy++){
         gc.fillRect(dx, dy, 1, 1);
        }
     }

     gc.setFill(bCol3);
     for(int dx = 0; dx < can.getWidth(); dx++){
       for(int dy = ((int)can.getHeight()*(2/3)); dy < can.getHeight(); dy++){
         gc.fillRect(dx, dy, 1, 1);
        }
     }
   }
}