using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private GameObject _frontPosition;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.centerOfMass = Vector3.zero;
    }

    void Update()
    {
        #if UNITY_ANDROID || UNITY_IOS && !UNITY_EDITOR
                if (Input.touchCount > 0)
                        {
                            Touch touch = Input.GetTouch(0);

                            if (touch.phase == TouchPhase.Ended)
                            {
                                _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                                _rigidBody.AddForce(new Vector3(-1, 7, 0), ForceMode.Impulse);
                                _rigidBody.AddTorque(new Vector3(0, 0, 10), ForceMode.Impulse);
                            }
                        }
        #endif
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
                {
                    _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                    _rigidBody.AddForce(new Vector3(-1, 7, 0), ForceMode.Impulse);
                    _rigidBody.AddTorque(new Vector3(0, 0, 10), ForceMode.Impulse);
                }
        #endif
    }

    private void FixedUpdate()
    {
        if (_frontPosition.transform.position.x < transform.position.x && _rigidBody.velocity.y !=0)
        {
            _rigidBody.angularVelocity = new Vector3(0, 0, 3);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
