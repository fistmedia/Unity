using UnityEngine;

public class Pickupable : MonoBehaviour {    
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            Destroy(this.gameObject);
    }
}
