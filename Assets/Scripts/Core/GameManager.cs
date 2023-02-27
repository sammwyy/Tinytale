using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SmoothCamera Camera;
    public Player Player;
    public SoundSystem SoundSystem;
    public World World;

    public ModManager ModManager;
    public ResourceManager ResourceManager;
    public ScriptEngine ScriptEngine;

    void Awake()
    {
        this.ModManager = new ModManager();
        this.ResourceManager = new ResourceManager();
        this.ScriptEngine = new ScriptEngine();

        int mods = this.ModManager.ScanDirectory(Path.Combine(Application.streamingAssetsPath, "mods"));
        int ress = this.ModManager.LoadResources(this.ResourceManager);
        Debug.Log("[GameManager] Loaded " + ress + " resources from " + mods + " mods.");

        this.ScriptEngine.RegisterModule("@core/camera", this.Camera);
        this.ScriptEngine.RegisterModule("@core/player", this.Player);
        this.ScriptEngine.RegisterModule("@core/resources", this.ResourceManager);
        this.ScriptEngine.RegisterModule("@core/soundsystem", this.SoundSystem);
        this.ScriptEngine.RegisterModule("@core/world", this.World);
    }

    void Start()
    {
        this.ScriptEngine.Initialize(this.ModManager.GetMod("tinytale").Gamemode);
    }
}