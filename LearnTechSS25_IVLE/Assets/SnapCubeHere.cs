using System.Collections.Generic;
using UnityEngine;


public class SnapCubeHere : MonoBehaviour
{
    private GameObject puzzleCubeParent;
    private List<Transform> puzzleCubes = new List<Transform>();
    private Vector3 ownPos;
    private Quaternion ownRot;
    private Outline cubeOutline;
    private bool isSet = false;
    
    void Start()
    {
        puzzleCubeParent = transform.parent.GetComponent<LogicEval>().puzzleCubeParent;
        //Debug.Log("IS ENABLED");
        cubeOutline = GetComponent<Outline>();
        ownPos = transform.position;
        ownRot = transform.rotation;
        foreach (Transform child in puzzleCubeParent.transform) 
        {
            puzzleCubes.Add(child);
        }
    }


    void Update()
    {
        foreach (Transform puzzleCube in puzzleCubes) 
        {
            Vector3 cubePos = puzzleCube.position;
            float distance = Vector3.Distance(ownPos, cubePos);
            if (distance < 0.2f)
            {
                //Debug.Log("IS CLOSE");
                if (!isSet)
                {
                    cubeOutline.enabled = true;
                }
                CheckSelected checker = puzzleCube.GetComponent<CheckSelected>();
                if (checker.isDeactivated && !isSet)
                {
                    puzzleCube.SetPositionAndRotation(ownPos, ownRot);
                    puzzleCube.GetComponent<Rigidbody>().isKinematic = true;
                    
                    LogicType cubeType = puzzleCube.GetComponent<LogicBlock>().type; //this cube type
                    LogicBlock targetBlock = transform.GetComponent<LogicBlock>(); // this cube obj
                    targetBlock.CheckSolution(cubeType); 

                    cubeOutline.enabled = false;
                    isSet = true;
                }
                else if (!checker.isDeactivated)
                {
                    isSet = false;
                }
            }
        }

        //if puzzle cube is in range do:
        //its selected->highlight self
        //else snap it to own position
    }
}
