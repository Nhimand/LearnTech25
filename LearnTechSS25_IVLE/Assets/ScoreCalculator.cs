using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject[] taskCollectionsThatGivePoints;
    public Button pressToDisplay;
    private List<LogicEval> tasksThatGivePoints = new List<LogicEval>();
    private float startTime;
    private float passedTimeTotal;
    private int finalScore;
    private int globalMistakeCounter;
    private int timeBonus = 100000;
    private TextMeshProUGUI scoreBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        scoreBoard = GetComponentInChildren<TextMeshProUGUI>();
        scoreBoard.enabled = false;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CountPoints()
    {
        float endTime = Time.time;
        passedTimeTotal = endTime - startTime;
        foreach (GameObject tc in taskCollectionsThatGivePoints)
        {
            foreach (LogicEval eval in tc.GetComponentsInChildren<LogicEval>())
            {
                globalMistakeCounter = globalMistakeCounter + eval.localMistakeCounter;
                finalScore += 1000;
            }
        }
        finalScore = finalScore - (globalMistakeCounter * 500);
        finalScore = finalScore + (timeBonus / (int)passedTimeTotal);
        finalScore = Mathf.Max(finalScore, 420);
    }
    public void OnButtonClick()
    {
        scoreBoard.enabled = true;
        scoreBoard.text = finalScore.ToString();
    }
}
