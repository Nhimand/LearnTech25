using System.Collections.Generic;
using UnityEngine;

public class SnapCubeHere : MonoBehaviour
{
    public GameObject puzzleCubeParent;
    private List<Transform> puzzleCubes = new List<Transform>();
    private Vector3 ownPos;
    private Quaternion ownRot;
    private Outline cubeOutline;
    private bool isSet = false;
    void Start()
    {
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
        cubeOutline.enabled = false;
        foreach (Transform puzzleCube in puzzleCubes) 
        {
            Vector3 cubePos = puzzleCube.position;
            float distance = Vector3.Distance(ownPos, cubePos);
            if (distance < 0.5f) 
            {
                cubeOutline.enabled = true;
                CheckSelected checker = puzzleCube.GetComponent<CheckSelected>();
                if (checker.isDeactivated && !isSet)
                {
                    puzzleCube.SetPositionAndRotation(ownPos, ownRot);
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
