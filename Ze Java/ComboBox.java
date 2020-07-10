import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.beans.value.*;
import javafx.collections.*;
import javafx.event.*;
import javafx.geometry.*;

public class ComboBox extends Application{
	
	public static void main(String args[]){
		launch(args);
	}

	public void start(Stage myStage){
		myStage.setTitle("Combo Box Use");
		FlowPane root = new FlowPane(10, 10);
		root.setAlignment(Pos.CENTER);
		Scene myScene = new Scene(root, 500, 300);
		myStage.setScene(myScene);

		TextField tf = new TextField();
		tf.setPromptText("Search Here");
		tf.setPrefColumnCount(10);
		
		RadioButton rdbtn1 = new RadioButton("Top");
		RadioButton rdbtn2 = new RadioButton("Normal");
		RadioButton rdbtn3 = new RadioButton("Bottom");

		ToggleGroup tg = new ToggleGroup();
		rdbtn1.setToggleGroup(tg);
		rdbtn2.setToggleGroup(tg);
		rdbtn3.setToggleGroup(tg);
	
		RadioButton rdcon = new RadioButton("Confirm Data");

		ObservableList<String> list = FXCollections.observableArrayList("Reo", "Kubo", "Munoz", "BEENS");
		ComboBox cblist = new ComboBox(list);
		cblist.setEditable(true);
		cblist.setValue("Reo");

		Separator sep1 = new Separator();
		Separator sep2 = new Separator();

		Label response = new Label("Enter Values");

		cblist.setOnAction((ae) -> response.setText("Values " + tf.getText() + " " + cblist.getSelectedItem() + " " + tg.getSelectedToggle()));

		rdcon.setOnAction((ae) -> response.setText("Values: " + tf.getText() + " " + cblist.getSelectedItem() + " " + tg.getSelectedToggle()));
		rdcon.setOnAction((ae) -> cblist.getItems().addAll("Huuuuu", "Coo", "Ter"));

		tf.setOnAction((ae) -> response.setText("Values: " + tf.getText() + " " + cblist.getSelectedItem() + " " + tg.getSelectedToggle()));

		
		
		root.getChildren().addAll(rdbtn1, rdbtn2, rdbtn3, cblist, sep1, rdcon, sep2, response);
		myStage.show();
	}
}