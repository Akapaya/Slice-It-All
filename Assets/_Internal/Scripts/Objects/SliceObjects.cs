using UnityEngine;

public class SliceObjects : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _direction = 1;
    [SerializeField] private int _value = 10;

    
    private void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            _rigidBody.constraints = RigidbodyConstraints.None;
            _rigidBody.AddForce(new Vector3(0, 2, 15 * _direction), ForceMode.Impulse);
            UiManager.UpdateCoinsEvent?.Invoke(_value);
        }
    }
}
