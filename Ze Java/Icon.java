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

public abstract class Icon implements Runnable{
  GraphicsContext gc;
  int x;
  int y;

  Color iC;
/*
  Icon(GraphicsContext g, int a, int b){
     gc = g;
     x = a;
     y = b;
   }
*/

  void reDraw(int x, int y){ }

  void erase(){  }

  void adjustPallette(BackgroundColorsBased bcb, Icon[] ic){  }

  void addShadow(){  }

  int getX(){
    return x;
  }

  int getY(){
    return y;
  }

  Color getColor(){
     return iC;
   }

  public void run(){   }

}

  