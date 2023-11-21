namespace YAPL.runtime.Values;

using CodeAnalysis;
using Nodes;

public abstract class Value {
	public abstract ValueType Type { get; }
	
	public abstract string Val { get; }

}