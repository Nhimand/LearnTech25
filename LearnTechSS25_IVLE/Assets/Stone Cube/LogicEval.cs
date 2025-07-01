using UnityEngine;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect;

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
            break;
        }

        if (!block.correct)
        {
            Debug.Log("wrong");
            allCorrect = false;
            break; 
        }
        else
        {
            Debug.Log("right");
        }
    }

    if (allCorrect)
    {
        Debug.Log(" All blocks correct!");
        // TODO Do something
    }
    else
    {
        Debug.Log("Not all blocks correct.");
        // TODO Do something else
    }
}

}
