using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody _rigidBody;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            _rigidBody.AddForce(new Vector3(-2, 10, 0), ForceMode.Impulse);
            _rigidBody.AddTorque(new Vector3(0, 0, 30), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (collision.gameObject.tag == "SlicerObj")
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
            _rigidBody.AddTorque(new Vector3(0, 0, -50), ForceMode.Impulse);
        }
    }
}
