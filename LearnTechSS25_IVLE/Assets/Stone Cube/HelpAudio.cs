using UnityEngine;

public class HelpAudio : MonoBehaviour
{
    public AudioSource audioSource;

    // Arrays of audio variants
    public AudioClip[] andClips;
    public AudioClip[] orClips;
    public AudioClip[] trueClips;
    public AudioClip[] falseClips;
    public AudioClip[] xClips;
    public AudioClip[] yClips;
    public AudioClip[] equalClips;
    public AudioClip[] notEqualClips;

    public void PlayAudioForType(LogicType type)
    {
        AudioClip[] clipsToPickFrom = null;

        switch (type)
        {
            case LogicType.And:
                clipsToPickFrom = andClips;
                break;
            case LogicType.Or:
                clipsToPickFrom = orClips;
                break;
            case LogicType.ConstTrue:
                clipsToPickFrom = trueClips;
                break;
            case LogicType.ConstFalse:
                clipsToPickFrom = falseClips;
                break;
            case LogicType.X:
                clipsToPickFrom = xClips;
                break;
            case LogicType.Y:
                clipsToPickFrom = yClips;
                break;
            case LogicType.Equal:
                clipsToPickFrom = equalClips;
                break;
            case LogicType.NotEqual:
                clipsToPickFrom = notEqualClips;
                break;
        }

        if (clipsToPickFrom != null && clipsToPickFrom.Length > 0)
        {
            AudioClip randomClip = clipsToPickFrom[Random.Range(0, clipsToPickFrom.Length)];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
