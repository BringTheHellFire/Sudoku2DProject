using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenTest : MonoBehaviour
{
    [SerializeField] private float ButtonMoveHeight = 0.5f;
    [SerializeField] private float ButtonMovementTime = 0.5f;

    public void ButtonReact_OnClick()
    {
        LeanTween.moveY(gameObject, transform.position.y + ButtonMoveHeight, ButtonMovementTime).setEaseShake();
    }
}
