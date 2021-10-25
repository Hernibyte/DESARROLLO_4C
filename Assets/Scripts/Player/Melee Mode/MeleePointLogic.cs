using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePointLogic : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePosition;
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        rb.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 0.5f, transform.parent.position.z);
    }
    void FixedUpdate()
    {
        Vector2 directionShoot = mousePosition - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(directionShoot.y, directionShoot.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
