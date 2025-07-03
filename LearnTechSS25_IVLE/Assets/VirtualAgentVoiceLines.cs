using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VirtualAgentVoiceLines : MonoBehaviour
{
    public AudioSource ourAgent;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public GameObject cubeToSetActive1;
    public GameObject cubeToSetActive2;
    public GameObject cubeToSetActive3;
    public GameObject cubeToSetActive4;

    public GameObject player;
    private float distance;
    private bool clipPlayed = false;
    private int currentClip = 1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ourAgent.clip = clip1;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5.0 && !clipPlayed) {
            Debug.Log("should speak");
           
            clipPlayed = true;
            StartCoroutine(PlayAudioExplanation());
        }
    }

    IEnumerator PlayAudioExplanation() {

        //ourAgent.PlayOneShot(clip1);
        yield return new WaitForSeconds(clip1.length + 1f);
        cubeToSetActive1.SetActive(true);
        cubeToSetActive2.SetActive(true);
        //ourAgent.PlayOneShot(clip2);
        yield return new WaitForSeconds(clip2.length + 1f);
        //ourAgent.PlayOneShot(clip3);
        cubeToSetActive3.SetActive(true);
    }
}
