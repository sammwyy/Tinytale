using Jint;
using Jint.CommonJS;
using Jint.Native;
using Jint.Runtime;
using System.IO;
using UnityEngine;

public class ScriptModuleResolver : IModuleResolver
{
    private string _root;

    public ScriptModuleResolver(string root)
    {
        this._root = root;
    }

    public string ResolvePath(string moduleId, Module fromModule = null)
    {
        return Path.Combine(this._root, moduleId + (moduleId.EndsWith(".js") ? "" : ".js"));
    }
}