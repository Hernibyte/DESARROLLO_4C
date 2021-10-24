using UnityEngine;

public class ReferenceMeleeAttack : MonoBehaviour
{
    MeleeAttack meleeAttack;

    void Start()
    {
        meleeAttack = gameObject.GetComponentInParent<MeleeAttack>();
    }

    public void AttackEvent()
    {
        if (meleeAttack == null)
            return;

        meleeAttack.Attack();
    }
}
