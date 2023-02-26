using System;

public class Exception : System.Exception
{
    public string TranslationKey;
    public string TypeTranslationKey;

    public Exception(string translationKey, string typeTranslationKey)
    {
        this.TranslationKey = translationKey;
        this.TypeTranslationKey = typeTranslationKey;
    }

    public Exception(string translationKey) : this(translationKey, null)
    { }

    public Exception() : this("errors.unknown")
    { }

    public virtual string FormatMessage(string message)
    {
        return message;
    }
}