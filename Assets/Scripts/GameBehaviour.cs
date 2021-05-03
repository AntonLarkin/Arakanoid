using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{

    #region Variables

    public GameOverSequence gameOver;
    public List<GameObject> defeatedBlocks;
    [SerializeField] private List<GameObject> blocks;
    [SerializeField] private Text scoreLabel;

    private int currentScore;
    private int totalScore;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        scoreLabel.text = "0";
    }

    private void Update()
    {

        if (gameOver.ReadyToReload)
        {
            ReloadBlocks(blocks);
            defeatedBlocks.Clear();
            gameOver.ReadyToReload = false;
            ReloadScore();
        }

    }

    #endregion


    #region Private methods

    private void CountTotalScore()
    {

        for (int i = 0; i < defeatedBlocks.Count; i++)
        {
            totalScore += defeatedBlocks[i].GetComponent<ScoreUpdater>().Score;
        }
        scoreLabel.text = totalScore.ToString();

    }

    private void ReloadScore()

    {
        currentScore = 0;
        scoreLabel.text = currentScore.ToString();
    }

    private void ReloadBlocks(List<GameObject> baseBlocks)
    {

        for (int i = 0; i < baseBlocks.Count; i++)
        {
            baseBlocks[i].gameObject.SetActive(true);

            for (int j = 0; j < baseBlocks[i].transform.childCount; j++)
            {
                baseBlocks[i].gameObject.transform.GetChild(j).gameObject.SetActive(true);
                baseBlocks[i].gameObject.transform.GetChild(j).gameObject.GetComponent<Blocks>().Stage = 0;
            }

        }

    }

    #endregion


    #region Public methods

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreLabel.text = currentScore.ToString();
    }

    #endregion

}
