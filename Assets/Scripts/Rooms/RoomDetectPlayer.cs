using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateCameraPosition : UnityEvent<Vector2>
{
}

public class RoomDetectPlayer : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] UnityEvent ifPlayerEnter;
    public UpdateCameraPosition updateCameraPosition = new UpdateCameraPosition();

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(MyUtilities.Contains(playerMask, other.gameObject.layer))
        {
            ifPlayerEnter?.Invoke();
            updateCameraPosition?.Invoke(transform.position);
        }
    }
}
