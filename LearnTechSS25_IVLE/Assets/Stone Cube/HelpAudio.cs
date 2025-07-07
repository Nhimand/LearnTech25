using UnityEngine;

public class HelpAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip notClip;
    public AudioClip andClip;
    public AudioClip orClip;
    public AudioClip impliesClip;
    public AudioClip eqRelationClip;
    public AudioClip constTrueClip;
    public AudioClip constFalseClip;
    public AudioClip equalClip;
    public AudioClip notEqualClip;
    public AudioClip klammerAufClip;
    public AudioClip klammerZuClip;
    public AudioClip eClip;
    public AudioClip aClip;
    public AudioClip xClip;
    public AudioClip yClip;
    public AudioClip frageClip;

    public void PlayAudioForType(LogicType type)
    {
        AudioClip clipToPlay = null;

        switch (type)
        {
            case LogicType.Not:
                clipToPlay = notClip;
                break;
            case LogicType.And:
                clipToPlay = andClip;
                break;
            case LogicType.Or:
                clipToPlay = orClip;
                break;
            case LogicType.Implies:
                clipToPlay = impliesClip;
                break;
            case LogicType.EqRelation:
                clipToPlay = eqRelationClip;
                break;
            case LogicType.ConstTrue:
                clipToPlay = constTrueClip;
                break;
            case LogicType.ConstFalse:
                clipToPlay = constFalseClip;
                break;
            case LogicType.Equal:
                clipToPlay = equalClip;
                break;
            case LogicType.NotEqual:
                clipToPlay = notEqualClip;
                break;
            case LogicType.KlammerAuf:
                clipToPlay = klammerAufClip;
                break;
            case LogicType.KlammerZu:
                clipToPlay = klammerZuClip;
                break;
            case LogicType.E:
                clipToPlay = eClip;
                break;
            case LogicType.A:
                clipToPlay = aClip;
                break;
            case LogicType.X:
                clipToPlay = xClip;
                break;
            case LogicType.Y:
                clipToPlay = yClip;
                break;
            case LogicType.Frage:
                clipToPlay = frageClip;
                break;
        }

        if (clipToPlay != null && audioSource != null)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }
}
