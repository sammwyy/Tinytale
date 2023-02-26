using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;
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
        Debug.Log("Loaded " + ress + " resources from " + mods + " mods.");

        this.ScriptEngine.RegisterModule("@core/player", this.Player);
        this.ScriptEngine.RegisterModule("@core/resources", this.ResourceManager);
        this.ScriptEngine.RegisterModule("@core/soundsystem", SoundSystemAccessor.Instance);
        this.ScriptEngine.RegisterModule("@core/world", this.World);
    }

    void Start()
    {
        //Resource<Sound> cancion = this.ResourceManager.GetSound("tinytale:bgm_rude_buster");
        //SoundSystem.PlayBGM(cancion);
        this.ScriptEngine.Initialize(this.ModManager.GetMod("tinytale").Gamemode);
    }
}