using System.Collections;
using UnityEngine;
using Utilities;

public class CameraShake : MyUtilities.MonoBehaviourSingleton<CameraShake>
{
    public IEnumerator Shake(float duration, float magnitud)
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitud;
            float y = Random.Range(-1, 1) * magnitud;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition;
    }

    public void ExecuteShake(float duration, float magnitud)
    {
        StartCoroutine(Shake(duration, magnitud));
    }
}
