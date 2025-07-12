using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class AppearFromFloor : MonoBehaviour
{
    public AudioClip stoneGrinding;

    private AudioSource thisStatue;
    private List<Transform> ownChildren = new List<Transform>();

    private List<Vector3> upperPos = new List<Vector3>();
    private List<Vector3> lowerPos = new List<Vector3>();

    private LogicEval[] logicEvals;
    private int currentPuzzle = 0;
    private int lastSolvedPuzzle = 0;
    private float clipDuration;
    private bool isAppearing = false;
    private bool allAppeared = false;

    [HideInInspector] public bool isDone = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {
            ownChildren.Add(child);
            upperPos.Add(child.position);
            child.position = new Vector3(child.transform.position.x, child.transform.position.y - 4.3f, child.transform.position.z);
            lowerPos.Add(child.position);
        }
        clipDuration = stoneGrinding.length;
        logicEvals = gameObject.GetComponentsInChildren<LogicEval>();
        thisStatue = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentPuzzle == ownChildren.Count)
        {
            allAppeared = true;
        }
        //Debug.Log("CURRENT:" + currentPuzzle);
        //Debug.Log("LAST:" + lastSolvedPuzzle);
        if (!allAppeared == true)
        {
            if (logicEvals[lastSolvedPuzzle].actuallyAllCorrect && !(logicEvals.Length == lastSolvedPuzzle))
            {
                lastSolvedPuzzle += 1;
            }
            if (logicEvals[lastSolvedPuzzle].specialAppearanceTrigger && !isDone)
            {
                Debug.Log("SHOULD SET RN");
                isDone = true;
                logicEvals[currentPuzzle].readyForAppearance = true;
            }
            if (!logicEvals[currentPuzzle].specialAppearanceTrigger)
            {
                if (lastSolvedPuzzle == currentPuzzle && !isAppearing)
                {
                    StartCoroutine(Appear());
                }
            }
        }
        
    }

    IEnumerator Appear()
    {
        isAppearing = true;
        yield return new WaitForSeconds(2f);
        thisStatue.PlayOneShot(stoneGrinding);
        float elapsed = 0f;
        while (elapsed < clipDuration)
        {
            float t = elapsed / clipDuration;
            ownChildren[currentPuzzle].position = Vector3.Lerp(lowerPos[currentPuzzle], upperPos[currentPuzzle], t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        ownChildren[currentPuzzle].position = upperPos[currentPuzzle];
        currentPuzzle += 1;
        isAppearing = false;
    }    
}

    
