using System.Collections.Generic;
using UnityEngine;

public class SnapCubeHere : MonoBehaviour
{
    public GameObject puzzleCubeParent;
    private List<Transform> puzzleCubes = new List<Transform>();
    private Vector3 ownPos = new Vector3();
    private Outline cubeOutline;
    void Start()
    {
        cubeOutline = gameObject.GetComponent<Outline>();
        ownPos = gameObject.transform.position;
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
            if (distance < 1f) 
            {
                cubeOutline.enabled = true;
                CheckSelected checker = puzzleCube.GetComponent<CheckSelected>();
                if (checker.isDeactivated)
                {
                    puzzleCube.position = ownPos;
                }
                else
                {
                    
                }
            }

        }

        //if puzzle cube is in range do:
        //its selected->highlight self
        //else snap it to own position
    }
}
