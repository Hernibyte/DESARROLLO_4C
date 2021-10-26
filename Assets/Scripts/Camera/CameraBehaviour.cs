using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraBehaviour : MonoBehaviour
{
    public void LookToPoint(Vector2 point)
    {
        StartCoroutine(SetLook(point));
    }

    IEnumerator SetLook(Vector2 point)
    {
        float aux = 0f;
        Vector3 positionAux = transform.position;
        for(int i = 0; i < 10; i++)
        {
            transform.position =  Vector3.Lerp(positionAux, new Vector3(point.x, point.y, -10), aux);
            aux += 0.1f;
            yield return new WaitForFixedUpdate();
        }
    }
}
