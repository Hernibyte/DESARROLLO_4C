using System.Collections;
using UnityEngine;

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
        float finalSpeedLerp=0;

        /*Aumentamos la velocidad un poco cuando es
        horizontal debido a que la distancia recorrida
        es mas grande*/

        if (targetPosition.y == transform.position.y)
            finalSpeedLerp = speedLerp * 1.5f;
        else
            finalSpeedLerp = speedLerp;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, finalSpeedLerp * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
        yield return null;
    }
}