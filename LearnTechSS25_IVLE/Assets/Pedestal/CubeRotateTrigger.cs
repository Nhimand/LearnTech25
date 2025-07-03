using UnityEngine;

public class CubeRotateTrigger : MonoBehaviour
{
    public float rotationSpeed = 45f; // degrees per second

    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float rotationProgress = 0f;
    private AudioClip[] praiseClips;
    private AudioSource rotateSound;

    public AudioSource VirtualAgent;



    private void Start()
    {
        praiseClips = Resources.LoadAll<AudioClip>("PraiseClips");
        rotateSound = GetComponent<AudioSource>();
    }

    private void PlayPraiseAudio() {
        if(praiseClips.Length>0)
        {
            VirtualAgent.PlayOneShot(praiseClips[Random.Range(0, praiseClips.Length)]);
        }
        
    }

    public void RiddleSolved(){

        if (isRotating) return;
        
        isRotating = true;
        rotationProgress = 0f;

        startRotation = transform.rotation; // Use world rotation as starting point
        // Rotate around the cube's own local Z axis
        targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);

        rotateSound.Play();
        PlayPraiseAudio();
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
