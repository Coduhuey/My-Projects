
class PThreads implements Runnable{
	Thread th;
	int count;

	static String thuserName;	//static variables like static classes/methods are universal for all objects and instance of the class, helpful for relationship between them
	static boolean redLight = false;

	PThreads(String name){

	th = new Thread(this, name);
	
	thuserName = name;
	count = 0;
	}
	
	public void run(){

	System.out.println(th.getName() + "Initiated");

	do{
	
		count++;

		if(thuserName.compareTo(th.getName()) != 0){ 		//searches for changes in thread (with the name) being executed
			thuserName = th.getName();
			System.out.println(thuserName + " Takes priority");
		}
	}while(redLight == false && count < 100000);

	redLight = true;
		
	System.out.println(th.getName() + " is terminated");
 }
}

class DemoP{
public static void main(String args[]){
	
	PThreads p1 = new PThreads("High Priority");
	PThreads p2 = new PThreads("Low Priority");

	p1.th.setPriority(Thread.NORM_PRIORITY+2);

	p2.th.setPriority(Thread.NORM_PRIORITY-2);

	p1.th.start(); 		//forgot .th before start()!!!
	p2.th.start();

	try{
	
	p1.th.join();
	p2.th.join();

	}catch(InterruptedException exc){
		System.out.println("Interruption Occured");
	}
	
	System.out.println("Final Counts /n " + p1.th.getName() + " has a count of " + p1.count);
	
	System.out.println(" " + p2.th.getName() + "has a count of " + p2.count);
}
}