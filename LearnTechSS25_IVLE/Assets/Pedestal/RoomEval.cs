using UnityEngine;
using UnityEngine.UI;


public class RoomEvalChecker : MonoBehaviour
{
    public Transform taskCollection; 
    public bool roomSolved = false;
    public Button active;

    private LogicEval[] logicEvals;

    void Start()
    {
        logicEvals = taskCollection.GetComponentsInChildren<LogicEval>();
    }

    public void ValidateAllLogicEvals()
    {
        foreach (LogicEval eval in logicEvals)
        {
            eval.CheckAllCubes();
        }
    }


    public void OnRoomCheckButton()
    {
        if (roomSolved)
        {
            Debug.Log("Room already solved.");
            return;
        }

        ValidateAllLogicEvals(); 

        if (AllTasksCorrect())
        {
            roomSolved = true;
            active.interactable = false;
            Debug.Log("yes");
            // TODO
        }
        else
        {
            Debug.Log("no");
            // TODO
        }
    }

    private bool AllTasksCorrect()
    {
        foreach (LogicEval eval in logicEvals)
        {
            if (!eval.allCorrect)
                return false;
        }
        return true;
    }
}
