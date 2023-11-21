namespace YAPL.runtime;

using CodeAnalysis.Exceptions;
using Values;

public class Environment {
	private Environment? Parent;
	private Dictionary<string, Value> Variables = new();

	public Environment(Environment? parent) {
		Parent = parent;
	}

	public Value DeclareVar(string name, Value value) {
		if (Variables.ContainsKey(name)) {
			throw new VariableAleadyDefinedError($"Cannot declare variable {name}, it is already defined.");
		}
		Variables.Add(name, value);
		return value;
	}

	public Value AssignVar(string name, Value value) {
		Environment env = Resolve(name);
		env.Variables[name] = value;
		return value;
	}

	public Value LookupVar(string name) {
		Environment env = Resolve(name);
		return env.Variables[name];
	}

	private Environment Resolve(string name) {
		if (Variables.ContainsKey(name))
			return this;
		if (Parent == null)
			throw new CannotResolveVariableError($"Cannot resolve \"{name}\", it does not exist.");
		return Parent.Resolve(name);
	}
}