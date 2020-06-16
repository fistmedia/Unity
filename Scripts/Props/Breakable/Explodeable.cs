using UnityEngine;

public class Explodeable : Breakable {
    [SerializeField]
    float _force = 500;
    [SerializeField]
    float _radius = 1;

    new void OnDestroy() {
		base.OnDestroy();

        if (effect_i) {
            Rigidbody[] bodies = effect_i.GetComponentsInChildren<Rigidbody>();

            if (bodies != null) // .Lenght > 0
                foreach(Rigidbody body in bodies)
                    body.AddExplosionForce(_force, transform.position, _radius);
        }
    }
}
