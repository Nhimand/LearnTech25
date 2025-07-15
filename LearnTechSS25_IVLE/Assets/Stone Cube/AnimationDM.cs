using UnityEngine;
using System.Collections;

public class AnimationDM : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDMAnimation()
    {
        Debug.Log("fsd");
        animator.Play("DM", 0, 0f);
        StartCoroutine(PlaySequentially());
    }

    IEnumerator PlaySequentially()
    {
        audioSource.PlayOneShot(clip1);
        yield return new WaitForSeconds(clip1.length); 
        audioSource.PlayOneShot(clip2);
    }
}
