using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxScript : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("is touching");
            collision.GetComponent<ObjectShake>().Shake();
            //collision.GetComponent<Enemy>().hitPoints -= 1;
        }
    }
}
