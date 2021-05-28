using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    public void Open(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector2.zero;
        gameObject.transform.DOScale(1.0f, 0.7f);
    }
    public void Shake(GameObject gameObject)
    {
        gameObject.transform.DOShakePosition(1.0f, 5.0f, 10, 90.0f, false, true);
    }
    public void Bounce(GameObject gameObject)
    {
        gameObject.transform.DOScale(1.2f, 0.4f);
    }
}
