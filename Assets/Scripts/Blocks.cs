using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    #region Variables

    public GameBehaviour gameBehaviour;

    [SerializeField] private GameObject[] blocksLifecycle;
    private int stage;

    #endregion


    #region Properties

    public int Stage { get; set; }

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Stage == blocksLifecycle.Length - 1)
        {
            blocksLifecycle[Stage].SetActive(false);
            transform.parent.gameObject.SetActive(false);
            gameBehaviour.defeatedBlocks.Add(transform.parent.gameObject);
            gameBehaviour.UpdateScore(transform.parent.gameObject.GetComponent<ScoreUpdater>().Score);
        }

        blocksLifecycle[Stage].SetActive(false);  //Если уничтожать каждую "стадию", то выдает ошибку, мол, я уничтожаю ассет, хотя я уничтожаю префаб!!!!  \_"з_/
        Stage++;

    }

    #endregion

}
