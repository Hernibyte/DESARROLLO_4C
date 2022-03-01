using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    #region PUBLIC_METHODS
    public void Destroy()
    {
        Destroy(gameObject);
    }
    #endregion
}
