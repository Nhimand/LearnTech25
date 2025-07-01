using UnityEngine;
using UnityEngine.UI;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect = true;
    public CubeRotateTrigger cubeRotateTrigger;
    public Button active;

    public void OnButtonClick(){
        CheckAllCubes();

    }

   public void CheckAllCubes(){
    allCorrect = true;

    foreach (Transform cube in logicCubesParent)
    {
        LogicBlock block = cube.GetComponent<LogicBlock>();
        if (block == null)
        {
            Debug.LogWarning("Missing LB");
            allCorrect = false;
            break;
        }

        if(block.Blank){
            if (!block.correct){
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
        active.interactable = false;
        Debug.Log(" All blocks correct!");
        cubeRotateTrigger.RiddleSolved();
        // TODO Do something
    }else{
        Debug.Log("Not all blocks correct.");
        // TODO Do something elses
    }
}

}
