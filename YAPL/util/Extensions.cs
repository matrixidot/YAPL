namespace YAPL.util; 

public static class Extensions {
	public static StringEnumerator getStringEnumerator(this string str) {
		return new StringEnumerator(str);
	}
	
}