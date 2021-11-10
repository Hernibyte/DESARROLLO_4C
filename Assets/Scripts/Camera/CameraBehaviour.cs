using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] float speedLerp;
    public void LookToPoint(Transform point)
    {
        StartCoroutine(SetLook(point));
        Debug.Log("Entro");
    }

    IEnumerator SetLook(Transform point)
    {
        Vector3 targetPosition = new Vector3(point.position.x, point.position.y, transform.position.z);

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedLerp * Time.fixedDeltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
        yield return null;
        
        //float aux = 0f;
        //Vector3 positionAux = transform.position;
        //for(int i = 0; i < 20; i++)
        //{
        //    if(aux >= 1.0f)
        //        break;
        //    transform.position =  Vector3.LerpUnclamped(positionAux, new Vector3(point.x, point.y, -10), aux);
        //    aux += 0.1f;
        //    yield return new WaitForFixedUpdate();
        //}
    }
}
