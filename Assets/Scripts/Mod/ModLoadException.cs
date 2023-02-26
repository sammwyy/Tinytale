public enum ModLoadExceptionKind
{
    NO_MOD_DESCRIPTOR
}

public class ModLoadException : Exception
{
    private Mod _mod;

    public ModLoadException(ModLoadExceptionKind kind, Mod mod)
    {
        this._mod = mod;

        switch (kind)
        {
            case ModLoadExceptionKind.NO_MOD_DESCRIPTOR:
                this.TranslationKey = "errors.mods.no-mod-descriptor";
                break;
            default:
                break;
        }
    }

    public override string FormatMessage(string message)
    {
        return message.Replace("{mod:dir}", this._mod.Directory);
    }
}