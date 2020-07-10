public class SelfClasssss{
	
	private String str;
	static int a;

	SelfClasssss(){
	  str = "Class";
	  a = 5;
	}

	SelfClasssss(int b){
	  str = "Class" + b;
	  a = b;
	}


	private String printer(){
	  return this.printer(a);
	}

	private String printer(int val){
	  return this.str + "val";
	}

	public static void main(String args[]){
	  SelfClasssss ref1;
	  SelfClasssss ref2;

	  ref1 = new SelfClasssss(6);
	  ref2 = new SelfClasssss(8);

	  int h = 6;
	  int k = 53;

	  boolean z = !(h >= 42 || k != 37);

	  System.out.println(z);

	  z = (h < 42) && (k == 37);

	  System.out.println(z);
	}
}