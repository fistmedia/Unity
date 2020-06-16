using UnityEngine;

public class View : Player {
    [SerializeField]
    Transform _follows = null;
    [SerializeField]
    Vector3 _move_to = Vector3.zero;

    float _fixedDeltaTemp, _temp;

    void Start() {
        if (_move_to != Vector3.zero) // Slowly
            transform.position = _move_to;
    }

    void Awake() {
        _fixedDeltaTemp = Time.fixedDeltaTime;
        _temp = Time.timeScale;
    }

    void OnJump() {
        if (Time.timeScale > 0) {
            _temp = Time.timeScale;
            Time.timeScale = 0;
        } else
            Time.timeScale = _temp;

        Time.fixedDeltaTime = _fixedDeltaTemp * Time.timeScale;
    }

    new void Update() {
        if (_follows) {
            Vector3 direction = _follows.position - transform.position;
            Quaternion target = Quaternion.LookRotation(direction);
            //Debug.DrawRay(transform.position, direction, Color.green);
            speed = _follows.GetComponent<Player>().speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2 * speed);
        }

        base.Update();
    }

    void OnApplicationQuit() {
        Debug.Log("Rage quit again, huh?");
    }
}
