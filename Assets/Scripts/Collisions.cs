using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public LayerMask key;
    public LayerMask door;


    private void OnTriggerEnter(Collider col) {
        if (key == (key | (1 << col.gameObject.layer))) {
            Destroy(col.gameObject);
            Settings.current.SpawnExit();
        } else if (door == (door | (1 << col.gameObject.layer))) {
            Destroy(col.gameObject);
            Settings.current.EndGame();
        } 
    }

}
