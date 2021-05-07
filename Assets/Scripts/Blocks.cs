using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blocks : MonoBehaviour
{

    #region Variables

    [SerializeField] private GameBehaviour gameBehaviour;
    [SerializeField] private GameObject[] blocksByStages;
    [SerializeField] private ScoreUpdater score;

    private LevelManager levelManager;

    #endregion


    #region Properties

    public int Stage { get; set; }

    #endregion

    public static event Action<GameObject, int> OnBlockDestroyed;

    public void Reload()
    {
        gameObject.SetActive(true);
        Stage = 0;

        for (int i = 0; i < blocksByStages.Length; i++)
        {
            blocksByStages[i].SetActive(true);
        }
    }

    #region Unity lifecycle

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Stage == blocksByStages.Length - 1)
        {
            levelManager.BlockDestroyed();
            gameObject.SetActive(false);
            OnBlockDestroyed?.Invoke(gameObject, score.Score);
            return;
        }
        blocksByStages[Stage].SetActive(false);
        Stage++;
        blocksByStages[Stage].SetActive(true);

    }

    #endregion

}
