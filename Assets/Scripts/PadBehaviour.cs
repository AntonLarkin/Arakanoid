using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadBehaviour : MonoBehaviour
{
    #region Unity lifecycle

    private void Update()
    {
        Vector3 positionInPixels = Input.mousePosition;
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

        Vector3 padPosition = positionInWorld;
        padPosition.y = transform.position.y;
        padPosition.z = 0f;         //хз,прочто почему то во время игры пропадает пад (?)

        transform.position = padPosition;
    }

    #endregion

}
