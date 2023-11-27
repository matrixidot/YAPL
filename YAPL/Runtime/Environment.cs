using YAPL.Runtime.Values;

public class Environment {
    private Environment? Parent { get; }
    private Dictionary<string, RuntimeValue> Variables { get; }


    public Environment(Environment? parent = null) {
        Parent = parent;
        Variables = new();
    }

    public RuntimeValue DeclareVar(string name, RuntimeValue value) {
        if (Variables.ContainsKey(name))
            throw new VariableAlreadyDeclaredError($"Cannot declare {name}, it is already declared.");
        
        Variables.Add(name, value);
        return value;
    }

    public RuntimeValue AssignVar(string name, RuntimeValue value) {
        Environment env = Resolve(name);
        Variables[name] = value;
        return value;
    }

    public RuntimeValue LookupVar(string name) {
        Environment env = Resolve(name);
        return env.Variables[name];
    }

    public Environment Resolve(string name) {
        if (Variables.ContainsKey(name))
            return this;
        if (Parent is null)
            throw new CannotResolveVarError($"Cannot resolve {name} as it does not exist.");
        return Parent.Resolve(name);
    }
}