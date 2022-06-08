using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !other.gameObject.GetComponent<ITakenDamage>().isAttack)
        {
            FindObjectOfType<CameraController>().CameraShake(0.5f);
            ITakenDamage damageable = other.gameObject.GetComponent<ITakenDamage>();
            damageable.TakenDamage(1);
        }
    }
}
