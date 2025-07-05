using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VirtualAgentVoiceLines : MonoBehaviour
{
    public int curRoom;

    public AudioSource ourAgent;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;

    public GameObject cubeToSetActive1;
    public GameObject cubeToSetActive2;
    public GameObject cubeToSetActive3;
    
    public GameObject player;
    private float distance;
    private bool clipPlayed = false;
    private int currentClip = 1;

    public GameObject thisRoomsTasks;



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

        /*ourAgent.PlayOneShot(clip1);
        yield return new WaitForSeconds(clip1.length + 1f);
        cubeToSetActive1.SetActive(true);
        cubeToSetActive2.SetActive(true);
        ourAgent.PlayOneShot(clip2);
        yield return new WaitForSeconds(clip2.length + 1f);
        cubeToSetActive3.SetActive(true);
        ourAgent.PlayOneShot(clip3);
        yield return new WaitForSeconds(clip3.length + 1f);*/
        Transform neededHere = thisRoomsTasks.transform.GetChild(0);
        Transform task1 = neededHere.transform.Find("Task1");
        task1.GetComponentInChildren<LogicEval>().specialAppearanceTrigger = false;
        yield return new WaitForSeconds(4f);
        ourAgent.PlayOneShot(clip4);
        yield return new WaitForSeconds(clip4.length + 1f);
    }
}
