using UnityEngine;

public class Turret : MonoBehaviour {
    [SerializeField]
    Transform _targets = null;

    void Update() {
        if (_targets) {
            Vector3 direction = _targets.position - transform.position;
            Quaternion target = Quaternion.LookRotation(direction);
            //Debug.DrawRay(transform.position, direction, Color.red);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }
    }
}
