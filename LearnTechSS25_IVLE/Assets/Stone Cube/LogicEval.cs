using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect = false;
    public CubeRotateTrigger cubeRotateTrigger;
    public Button active;
    private AudioSource wrongSound;
    public GameObject puzzleCubeParent;
    public RoomEvalChecker roomEval;
    public bool lastOfRoom;
    [HideInInspector] public bool actuallyAllCorrect = false;
    public bool specialAppearanceTrigger = false;
    [HideInInspector] public bool readyForAppearance = false;
    [HideInInspector] public int localMistakeCounter;


    private bool canClick = true;

    private void OnEnable(){
        allCorrect = false;
        actuallyAllCorrect = false;
        wrongSound = GetComponent<AudioSource>();
    }

    public void OnButtonClick(){
        if (!canClick) return;
        canClick = false;
        CheckAllCubes();
        roomEval.OnRoomCheckButton();
        StartCoroutine(ClickCooldown());
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
            cubeRotateTrigger.RiddleSolved(lastOfRoom, true);
        }
        
        active.interactable = false;
        // TODO Do something
    }else{
        cubeRotateTrigger.RiddleSolved(lastOfRoom, false);
        wrongSound.Play();
        localMistakeCounter += 1;
        Debug.Log("Not all blocks correct.");
        // TODO Do something elses
    }
}
    private IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(1f); // 1-second cooldown
        canClick = true;
    }

}
