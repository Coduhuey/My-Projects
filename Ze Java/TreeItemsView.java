import javafx.application.*;
import javafx.stage.*;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.collections.*;
import javafx.beans.value.*;
import javafx.event.*;
import javafx.geometry.*;

public class TreeItemsView extends Application{

	public static void main(String args[]){
		launch(args);
	}


	public void start(Stage myStage){
		myStage.setTitle("Tree Viewing Items");
		FlowPane fp = new FlowPane(10, 10);
		fp.setAlignment(Pos.CENTER);
		Scene myScene = new Scene(fp, 500, 500);
		myStage.setScene(myScene);


		TreeItem<String> tRoot = new TreeItem<String>("Filage");
		
		TreeItem<String> Connector = new TreeItem<String>("Connectage");
		Connector.getChildren().add(new TreeItem<String>("User"));
		Connector.getChildren().add(new TreeItem<String>("Input"));
		Connector.getChildren().add(new TreeItem<String>("Output"));

		tRoot.getChildren().add(Connector);
		tRoot.getChildren().add(new TreeItem<String>("Application"));

		TreeItem<String> tReasons = new TreeItem<String>("Reasons");
		tReasons.getChildren().add(new TreeItem<String>("Efficiency"));
		tReasons.getChildren().add(new TreeItem<String>("The Passion"));
		tRoot.getChildren().add(tReasons);

		TreeView<String> tvView = new TreeView<String>(tRoot);


		Label response = new Label("");		


		MultipleSelectionModel<TreeItem<String>> msmtv = tvView.getSelectionModel();
		msmtv.selectedItemProperty().addListener(new ChangeListener<TreeItem<String>>(){
			public void changed(ObservableValue<? extends TreeItem<String>> changed, TreeItem<String> oldVal, TreeItem<String> newVal){
				
				if(newVal != null){
					String pathstr = newVal.getValue();
					TreeItem<String> temp = newVal.getParent();
					
					while(temp != null){
						pathstr = temp.getValue() + " -> " + pathstr;
						temp = temp.getParent();
					}
		
					response.setText("Value selected: " + newVal.getValue() + "\n" + 
								"Path taken: " + pathstr);
				}
			}
		});

		

		fp.getChildren().addAll(tvView, response);
		myStage.show();
	}
}