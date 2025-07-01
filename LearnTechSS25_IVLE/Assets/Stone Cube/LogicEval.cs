using UnityEngine;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect;

   public void CheckAllCubes(){
    allCorrect = false; 

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
            Debug.Log("wrong ");
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
        // Do something
    }
    else
    {
        Debug.Log("Not all blocks correct.");
        // Do something else
    }
}

}
