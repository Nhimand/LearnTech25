using UnityEngine;

public class LogicEval : MonoBehaviour
{
    public Transform logicCubesParent;
    public bool allCorrect;

    public void CheckAllCubes()
    {
        foreach (Transform cube in logicCubesParent)
        {
            LogicBlock block = cube.GetComponent<LogicBlock>();

            if (!block.correct || block == null)
            {
                allCorrect = false;
            }
            else
            {
                allCorrect = true;
            }
        }

        if (allCorrect)
        {
            Debug.Log("correct");
            // TODO: Do something
        }
        else
        {
            Debug.Log("not correct");
            // TODO: Do something
        }
    }
}
