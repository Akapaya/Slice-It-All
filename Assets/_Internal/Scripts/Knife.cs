using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody _rigidBody;
    [SerializeField] GameObject frente;
    bool lookFront;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.centerOfMass = Vector3.zero;
        
    }

    void Update()
    {
        Debug.Log(frente.transform.position);
        Debug.Log(transform.position);
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
        if (frente.transform.position.x < transform.position.x && _rigidBody.velocity.y !=0)
        {
            _rigidBody.angularVelocity = new Vector3(0, 0, 3);
            lookFront = true;
        }
        else
        {
            lookFront = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            lookFront = false;
        }
        if (other.gameObject.tag == "SlicerObj")
        {
            if (lookFront == false)
            {
                /*_rigidBody.velocity = Vector3.zero;
                _rigidBody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);*/
            }
            else
            {
                if (other.gameObject.TryGetComponent(out SliceObjects slice))
                {
                    slice.slice();
                }
            }
        }
    }
}
