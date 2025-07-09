using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using OmiLAXR.xAPI.Composers;

public class VirtualAgentVoiceLines : MonoBehaviour
{
    public float curRoom;
    private int curStep = 1;
    private (float, int) curTuple;

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

    private int thisRoomsMistakeCounter;
    private bool isUnlocked = false;
    



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
            clipPlayed = true;
            StartCoroutine(PlayAudioExplanation());
        }
        if (curTask < specialTasks.Length)
        {
            if (specialTasks[curTask].GetComponentInChildren<LogicEval>().readyForAppearance == true)
            {
                specialTasks[curTask].GetComponentInChildren<LogicEval>().readyForAppearance = false;
                Debug.Log("set to false");
                clipPlayed = false;
            }
        }
        if (curStep == 2 && clipPlayed == false) {
            Debug.Log("should speak 2");
            clipPlayed = true;
            StartCoroutine(PlayAudioExplanation());
        }
        if (thisRoomsMistakeCounter>=5 && !isUnlocked) {
            isUnlocked = true;
            UnlockBranchingRoom();
        }
    }

    IEnumerator PlayAudioExplanation() {

        
        //These are the cases for each room - room 1 = case 1 etc.
        //In the inspector you need to add all audio clips for you current room and enter the int for the room nr
        //Then create the respective case here

        switch (curTuple)
        {
            case (1f, 1):
                //yield return new WaitForSeconds(PlayCurClip());
                AppearCurCube();
                AppearCurCube();
                //yield return new WaitForSeconds(PlayCurClip());
                AppearCurCube();
                //yield return new WaitForSeconds(PlayCurClip());
                AppearCurCube();
                //yield return new WaitForSeconds(PlayCurClip()-3f);
                AppearCurTask();
                //yield return new WaitForSeconds(6f);
                //yield return new WaitForSeconds(PlayCurClip());
                //TODO appear ? cube
                AppearCurCube();
                //yield return new WaitForSeconds(PlayCurClip());

                specialTasks[curTask].GetComponentInParent<AppearFromFloor>().isDone = false;
                break;
            case (1f, 2):
                AppearCurCube();
                AppearCurCube();
                yield return new WaitForSeconds(PlayCurClip());
                yield return new WaitForSeconds(PlayCurClip());
                yield return new WaitForSeconds(PlayCurClip());
                AppearCurTask();
                break;
                
            case (2f,1): //für alles bis zur nächsten special appearance
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
        curStep += 1;
    }
    private void UnlockBranchingRoom() { 
        
    }
}
