using UnityEngine;
using UnityEngine.UI;


public class RoomEvalChecker : MonoBehaviour
{
    public Transform taskCollection; 
    public bool roomSolved = false;
    public DoorPullUp doorPullUp;
    public DoorPullUp secretDoorPullUp;
    public GameObject virtualAgent;
    public bool lastRoom = false;
    public ScoreCalculator scoreCalc;

    private LogicEval[] logicEvals;
    private bool clicked = false;
    private int thisRoomsMistakeCounter;
    [HideInInspector] public AudioSource virtualAgentSource = null;

    public AudioClip withoutBranch;
    public AudioClip withBranch;

    void Start()
    {
        if (virtualAgent != null) {
            virtualAgentSource = virtualAgent.GetComponentInChildren<AudioSource>();
        }
        logicEvals = taskCollection.GetComponentsInChildren<LogicEval>();
        //praiseClips = Resources.LoadAll<AudioClip>("PraiseClips");
        //failClips = Resources.LoadAll<AudioClip>("FailClips");
    }

    public void ValidateAllLogicEvals()
    {
        Debug.Log("4.1");
        foreach (LogicEval eval in logicEvals)
        {
            Debug.Log("4.2");
            if (!eval.actuallyAllCorrect) {
                return;
            }
            //eval.CheckAllCubes();
            Debug.Log("4.3");
        }
        Debug.Log("4.4");
    }


    public void OnRoomCheckButton()
    {   
        Debug.Log("1");
        if (clicked)
            return;
        Debug.Log("2");
        clicked = true;  
        Debug.Log("3");
        if (roomSolved)
        {
            Debug.Log("3");
            Debug.Log("Room already solved.");
            return;
        }
        Debug.Log("4");
        ValidateAllLogicEvals(); 
        Debug.Log("5");
        if (AllTasksCorrect())
        {
            doorPullUp.OnButtonClick();
            if (virtualAgentSource != null) { 
                if (thisRoomsMistakeCounter >= 5 && withBranch != null)
                {
                    virtualAgentSource.PlayOneShot(withBranch);
                    secretDoorPullUp.OnButtonClick();
                }
                else if (withoutBranch != null)
                {
                    virtualAgentSource.PlayOneShot(withoutBranch);
                }
            }
            if (lastRoom) {
                scoreCalc.CountPoints();
            }
            roomSolved = true;
            Debug.Log("yes");
            // TODO
        }
        else
        {
            clicked = false;
            Debug.Log("no");
            // TODO
        }
        Debug.Log("6");
    }

    private bool AllTasksCorrect()
    {
        Debug.Log("7");
        int tempMistakes = 0;
        foreach (LogicEval eval in logicEvals)
        {
            tempMistakes = tempMistakes + eval.localMistakeCounter;
            Debug.Log("8");
            if (!eval.actuallyAllCorrect){
                Debug.Log("801");
                return false;
            }
        }
        thisRoomsMistakeCounter = tempMistakes;
        Debug.Log("9");
        return true;
    }
}
