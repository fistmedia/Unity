using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    public float speed = 1;

    Vector2 _move;

    void OnMove(InputValue value) {
        _move = value.Get<Vector2>();
    }

    protected void Update() {
        // FixedUpdate
        transform.Translate(new Vector3(_move.x, 0, _move.y) * speed * Time.deltaTime);
    }
}
