using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceObjects : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _direction = 1;
    [SerializeField] private int _value = 10;

    public LayerMask layer;
    // This would cast rays only against colliders in layer 8.
    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    
    private void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0.25f), transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layer))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0.25f), transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0, 0.25f), transform.TransformDirection(Vector3.up) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            if(_direction == -1)
            {
                RaycastHit hit;
                if (!Physics.Raycast(transform.position + new Vector3(0, 0, 0.25f), transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layer))
                {
                    _rigidBody.constraints = RigidbodyConstraints.None;
                    _rigidBody.AddForce(new Vector3(0, 2, 15 * _direction), ForceMode.Impulse);
                    UiManager.UpdateCoinsEvent?.Invoke(_value);
                }
            }
            else
            {
                _rigidBody.constraints = RigidbodyConstraints.None;
                _rigidBody.AddForce(new Vector3(0, 2, 15 * _direction), ForceMode.Impulse);
                UiManager.UpdateCoinsEvent?.Invoke(_value);
            }
        }
    }
}
