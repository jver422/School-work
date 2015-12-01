using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {

    public int TrapDamage = 0;

    void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy")
        {
            EnemyTemp enemy = other.gameObject.GetComponent<EnemyTemp>();
            enemy.TakeDamage(TrapDamage);
            Destroy(this);
        }
    }
}