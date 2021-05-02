using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    #region Unity lifecycle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    #endregion
}
