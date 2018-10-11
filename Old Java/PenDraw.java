import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.scene.canvas.*;

public class PenDraw{

GraphicsContext2D gcanvas;
ArtsieController controller;
int x, y;

PenDraw(GraphicsContext2D gc, ArtsieController parentGame){
  gcanvas = gc;
  controller = parentGame;
  x = y = 0;
}

draw(int dx, int dy){
  gc.fillLine(x, y, x += dx, y += dy);
}

move(int dx, int dy){
  x += dx;
  y += dy;
}

erase(int dx, int dy){
  gc.clearLine(x, y, x+= dx, y+= dy);
}
}