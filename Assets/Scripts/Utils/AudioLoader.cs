using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class AudioLoader
{
    public static AudioClip LoadClip(string path)
    {
        AudioClip clip = null;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
        {
            uwr.SendWebRequest();

            long start = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            while (uwr.downloadProgress != 1.0)
            {
                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (now - start > 5000)
                {
                    break;
                }
            }

            try
            {
                if (uwr.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log($"{uwr.error}");
                }
                else
                {
                    clip = DownloadHandlerAudioClip.GetContent(uwr);
                }
            }
            catch (Exception err)
            {
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
        }

        return clip;
    }
}