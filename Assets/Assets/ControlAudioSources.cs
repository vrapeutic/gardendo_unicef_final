using UnityEngine;

public class ControlAudioSources : MonoBehaviour
{
    public void PuaseCurrentAudioClip()
    {
        PuaseCurrentAudioClipRPC();
    }

    public void PuaseCurrentAudioClipRPC()
    {
        gameObject.GetComponent<AudioSource>().Pause();
    }
}
