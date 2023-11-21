namespace YAPL.util; 

public class StringEnumerator {
	private readonly string str;

	private readonly char[] array;

	private int index = 0;

	public StringEnumerator(string str) {
		this.str = str;
		array = str.ToCharArray();
	}

	public bool HasNext() {
		return index + 1 <= array.Length;
	}

	public void Step() {
		if (HasNext())
			index++;
	}

	public char Current() {
		try {
			return array[index];
		}
		catch (IndexOutOfRangeException) {
			return char.MinValue;
		}
	}

	public char Shift() {
		char toRet = Current();
		Step();
		return toRet;
	}

	public char Peek(int amount) {
		try {
			return array[index + amount];
		}
		catch (IndexOutOfRangeException) {
			return char.MinValue;
		}
	}

}