using UnityEngine;
using UnityEngine.UI;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect = true;
    public CubeRotateTrigger cubeRotateTrigger;
    public Button active;
    private AudioSource wrongSound;
    public GameObject puzzleCubeParent;
    public RoomEvalChecker roomEval;
    public bool lastOfRoom;
    [HideInInspector] public bool actuallyAllCorrect = false;
    public bool specialAppearanceTrigger = false;
    [HideInInspector] public bool readyForAppearance = false;

    private void OnEnable(){
        wrongSound = GetComponent<AudioSource>();
    }

    public void OnButtonClick(){
        CheckAllCubes();
        roomEval.OnRoomCheckButton();
    }

    public void CheckAllCubes(){
    allCorrect = true;

    foreach (Transform cube in logicCubesParent)
    {
        LogicBlock block = cube.GetComponent<LogicBlock>();
        if (block == null)
        {
            wrongSound.Play();
            Debug.LogWarning("Missing LB");
            allCorrect = false;
            break;
        }

        if(block.Blank){
            if (!block.correct){
                wrongSound.Play();
                Debug.Log("wrong");
                allCorrect = false;
                break; 
            }else{
                Debug.Log("right");
            }
        }else{
            block.correct = true;

        }
    }

    if (allCorrect){

        actuallyAllCorrect = true;
        Debug.Log(" All blocks correct!");

        if(active.interactable==true)
        {
            cubeRotateTrigger.RiddleSolved(lastOfRoom);
        }
        
        active.interactable = false;
        // TODO Do something
    }else{ 
        wrongSound.Play();
        Debug.Log("Not all blocks correct.");
        // TODO Do something elses
    }
}

}
