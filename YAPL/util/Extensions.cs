namespace YAPL.util;

using CodeAnalysis.Lexing;

public static class Extensions {
	public static StringIterator GetIterator(this string str) {
		return new StringIterator(str);
	}
	
}