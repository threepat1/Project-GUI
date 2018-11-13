using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthBar.health -= 1;
            print("Attack");
        }
    }
}
