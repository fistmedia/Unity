using UnityEngine;

public class Breakable : MonoBehaviour {
    [SerializeField]
    GameObject _drops = null;
    [SerializeField]
    GameObject _effect = null;

    protected GameObject effect_i;

    protected void OnDestroy() {
        if (_drops)
            Instantiate(_drops, transform.position, Quaternion.identity);

        if (_effect)
            effect_i = Instantiate(_effect, transform.position, Quaternion.identity);
    }
}
