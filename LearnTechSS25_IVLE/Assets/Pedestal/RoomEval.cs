using UnityEngine;
using UnityEngine.UI;


public class RoomEvalChecker : MonoBehaviour
{
    public Transform taskCollection; 
    public bool roomSolved = false;
    public DoorPullUp doorPullUp;
    public DoorPullUp secretDoorPullUp;
    public AudioSource audioSource;


    private LogicEval[] logicEvals;
    private bool clicked = false;
    private int thisRoomsMistakeCounter;
    //private AudioClip[] praiseClips;
    //private AudioClip[] failClips;

    void Start()
    {
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
            if (thisRoomsMistakeCounter >= 5)
            {
                //play voiceline v2
                secretDoorPullUp.OnButtonClick();
            }
            else 
            { 
                //play voiceline v1
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
