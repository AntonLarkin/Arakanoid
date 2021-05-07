using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    #region Variables

    private int blockCount;

    #endregion


    #region Unity lifecycle
    private void OnEnable()
    {

    }

    private void Start()
    {
        SetBlocksquantity();
    }

    #endregion

    #region Private methods

    public void BlockDestroyed()
    {
        blockCount--;
        print(blockCount);
        if (blockCount <= 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }

    public void SetBlocksquantity()
    {
        Blocks[] allBlocks = FindObjectsOfType<Blocks>();
        blockCount = allBlocks.Length;
    }

    #endregion
}
