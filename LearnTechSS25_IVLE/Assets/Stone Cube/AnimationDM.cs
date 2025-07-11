using UnityEngine;

public class AnimationDM : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;


    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDMAnimation()
    {
        Debug.Log("fsd");
        animator.Play("DM", 0, 0f);
        audioSource.Play();
    }
}
