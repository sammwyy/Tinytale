public class ScriptEngineModule
{
    public readonly string Name;
    public readonly object Value;

    public ScriptEngineModule(string name, object value)
    {
        this.Name = name;
        this.Value = value;
    }
}