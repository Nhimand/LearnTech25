using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using OmiLAXR.xAPI.Composers;

public class VirtualAgentVoiceLines : MonoBehaviour
{
    public int curRoom;
    private int curStep;
    private (int, int) curTuple;

    public AudioSource ourAgent;

    public AudioClip[] audioClips;
    public GameObject[] interactableCubes;
    public GameObject[] specialTasks;
    
    public GameObject player;
    private float distance;
    private bool clipPlayed = false;
    private int curClip = 0;
    private int curCube = 0;
    private int curTask = 0;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        curTuple = (curRoom, curStep);
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5.0 && curStep == 1 && clipPlayed == false) {
            Debug.Log("should speak");
            curStep += 1;
            clipPlayed = true;
            StartCoroutine(PlayAudioExplanation());
        }
        if (curStep == 1 && clipPlayed == false) {
            curStep += 1;
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
        yield return new WaitForSeconds(clip3.length + 1f);
        Transform neededHere = thisRoomsTasks.transform.GetChild(0);
        Transform task1 = neededHere.transform.Find("Task1");
        task1.GetComponentInChildren<LogicEval>().specialAppearanceTrigger = false;
        yield return new WaitForSeconds(4f);
        ourAgent.PlayOneShot(clip4);
        yield return new WaitForSeconds(clip4.length + 1f);*/

        //These are the cases for each room - room 1 = case 1 etc.
        //In the inspector you need to add all audio clips for you current room and enter the int for the room nr
        //Then create the respective case here

        switch (curTuple)
        {
            case (1, 1):
                yield return new WaitForSeconds(PlayCurClip());
                AppearCurCube();
                AppearCurCube();
                yield return new WaitForSeconds(PlayCurClip());
                AppearCurCube();
                yield return new WaitForSeconds(PlayCurClip()-3f);
                AppearCurTask();
                yield return new WaitForSeconds(6f);
                yield return new WaitForSeconds(PlayCurClip());
                //TODO appear ? cube
                yield return new WaitForSeconds(PlayCurClip());
                break;
            case (1, 2):
                AppearCurCube();
                AppearCurCube();
                yield return new WaitForSeconds(PlayCurClip());
                yield return new WaitForSeconds(PlayCurClip());
                break;
        }
    }

    private float PlayCurClip() {
        //Plays the audio clip passed, returns the length of the clip as float +1 sec
        ourAgent.PlayOneShot(audioClips[curClip]);
        float res = audioClips[curClip].length + 1f;
        curClip += 1;
        return res;
    }
    private void AppearCurCube()
    {
        //Lets next cube from array appear
        interactableCubes[curCube].SetActive(true);
        curCube += 1;
    }
    private void AppearCurTask() {
        //Sets the special trigger condition that prevents tasks from just appearing after completion of previous task
        specialTasks[curTask].GetComponentInChildren<LogicEval>().specialAppearanceTrigger = false;
        curTask += 1;
    }
}
