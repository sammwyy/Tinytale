using Jint;
using Jint.CommonJS;
using System.Collections.Generic;

public class ScriptEngine
{
    private Engine engine;
    private List<ScriptEngineModule> modules;

    public ScriptEngine()
    {
        this.modules = new List<ScriptEngineModule>();
    }

    public void RegisterModule(string name, object value)
    {
        this.modules.Add(new ScriptEngineModule(name, value));
    }

    public void Initialize(string scriptsDir, string mainFile)
    {
        ModuleLoadingEngine cjs = new Engine().CommonJS();
        cjs.Resolver = new ScriptModuleResolver(scriptsDir);

        foreach (ScriptEngineModule module in this.modules)
        {
            cjs.RegisterInternalModule(module.Name, module.Value);
        }

        cjs.RunMain("main.js");
        this.engine = cjs.engine;
    }

    public void Initialize(ModGamemode gamemode)
    {
        this.Initialize(gamemode.Root, gamemode.Main);
    }
}