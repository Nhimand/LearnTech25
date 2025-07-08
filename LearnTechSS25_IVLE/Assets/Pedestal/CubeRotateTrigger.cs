using UnityEngine;
using System.Collections;

public class CubeRotateTrigger : MonoBehaviour
{
    public float rotationSpeed = 45f; // degrees per second

    private bool isRotating = false;
    private bool isPlayingNegClip = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float rotationProgress = 0f;
    private AudioClip[] praiseClips;
    private AudioClip[] failClips;
    private AudioSource rotateSound;

    public AudioSource VirtualAgent;



    private void Start()
    {
        failClips = Resources.LoadAll<AudioClip>("AudioFiles/FailClips");
        praiseClips = Resources.LoadAll<AudioClip>("AudioFiles/PraiseClips");
        Debug.Log(praiseClips.Length);
        rotateSound = GetComponent<AudioSource>();
    }

    private void PlayPraiseAudio() 
    {
        VirtualAgent.PlayOneShot(praiseClips[Random.Range(0, praiseClips.Length)]);
    }
    private IEnumerator PlayFailAudio()
    {
        yield return new WaitForSeconds(1f);
        AudioClip curFailClip = failClips[Random.Range(0, failClips.Length)];
        VirtualAgent.PlayOneShot(curFailClip);
        yield return new WaitForSeconds(curFailClip.length);
        isPlayingNegClip = false;
    }

    public void RiddleSolved(bool lastOfRoom, bool solvedCorrectly) {
        if (solvedCorrectly)
        {
            Debug.Log("Enters solved correctly");
            if (isPlayingNegClip) return;
            if (isRotating) return;

            isRotating = true;
            rotationProgress = 0f;

            startRotation = transform.rotation; // Use world rotation as starting point
            // Rotate around the cube's own local Z axis
            targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);

            rotateSound.Play();
            if (!lastOfRoom)
            {
                PlayPraiseAudio();
            }
        }
        else if (!solvedCorrectly && !isPlayingNegClip)
        {
            if (isPlayingNegClip) return;
            Debug.Log("Enters not solved correctly");
            isPlayingNegClip = true;
            StartCoroutine(PlayFailAudio());
        }
    }

    void Update(){

        if (isRotating)
        {
            rotationProgress += rotationSpeed * Time.deltaTime;
            float t = Mathf.Clamp01(rotationProgress / 180f); // from 0 to 1

            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            if (t >= 1f)
            {
                transform.rotation = targetRotation; // Snap to target to fix small errors
                isRotating = false;
            }
        }
    }
}
