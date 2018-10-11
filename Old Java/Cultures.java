import java.lang.*;
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

public class Cultures  extends Icon{
  GraphicsContext gc;
  int x;
  int y;
  boolean reverse = true;

  Color iC;

  Cultures(Canvas c, int a, int b){
    //super(g, a, b);
    gc = c.getGraphicsContext2D();
    x = a;
    y = b;

    iC = Color.rgb((int)Math.random()*255, (int)Math.random()*255, (int)Math.random()*255);

    gc.setFill(iC);
    gc.setStroke(iC);

    gc.strokeRect(x-15, y-15, 30, 30);
    gc.fillOval(x+4, y+5, 4, 4);
    gc.strokeOval(x+6, y, 5, 5);
    gc.fillOval(x+5, y-7, 3, 3);
    gc.strokeOval(x+7, y+6, 2, 2);
    gc.fillOval(x+9, y, 5, 5);
    gc.strokeOval(x+10, y-5, 5, 5);
  }

  void reDraw(int x, int y){
    gc.strokeRect(x-15, y-15, 30, 30);
    gc.fillOval(x+4, y+5, 4, 4);
    gc.strokeOval(x+6, y, 5, 5);
    gc.fillOval(x+5, y-7, 3, 3);
    gc.strokeOval(x+7, y+6, 2, 2);
    gc.fillOval(x+9, y, 5, 5);
    gc.strokeOval(x+10, y-5, 5, 5);

    this.x = x;
    this.y = y;
  }

  void erase(){
    gc.clearRect(x-15, y-15, 30, 30);
    gc.clearRect(x+4, y+5, 4, 4);
    gc.clearRect(x+6, y, 5, 5);
    gc.clearRect(x+5, y-7, 3, 3);
    gc.clearRect(x+7, y+6, 2, 2);
    gc.clearRect(x+9, y, 5, 5);
    gc.clearRect(x+10, y-5, 5, 5);
  }

  private void animateErase(){
    gc.clearRect(x+4, y+5, 4, 4);
    gc.clearRect(x+6, y, 5, 5);
    gc.clearRect(x+5, y-7, 3, 3);
    gc.clearRect(x+7, y+6, 2, 2);
    gc.clearRect(x+9, y, 5, 5);
    gc.clearRect(x+10, y-5, 5, 5);
   }

   private void animateRedraw(int x, int y){
    gc.fillOval(x+4, y+5, 4, 4);
    gc.strokeOval(x+6, y, 5, 5);
    gc.fillOval(x+5, y-7, 3, 3);
    gc.strokeOval(x+7, y+6, 2, 2);
    gc.fillOval(x+9, y, 5, 5);
    gc.strokeOval(x+10, y-5, 5, 5);
   }

  void adjustPallette(BackgroundColorsBased bcb, Icon[] ic){
    for(int i = 0; i < ic.length; i++){
       bcb.setColor(ic[i]);  //256, 256, 256 formulaic repeatedly average
    }

    gc.setStroke(bcb.getColors()[1]);
    erase();
    reDraw(this.x, this.y);
  }

  Color getColor(){
     return iC;
   }


  void addShadow(){  }

  public void run(){ 
     while(true){
      animateErase();

      if(reverse){
        animateRedraw(x+=5, y-=5);
      }
      else if(!reverse){
        animateRedraw(x-=5, y+=5);
      }

       reverse = !reverse;
      try{
        Thread.sleep(500);
       }catch(InterruptedException exc){
          System.out.println("Error In Flowers.class!");
       }
    }
  }

}
