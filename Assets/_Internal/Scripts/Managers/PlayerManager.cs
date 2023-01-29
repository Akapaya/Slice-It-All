using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private Knife _knifeScript;
    [SerializeField] private Rigidbody _rigidBody;

    public delegate void DesactivePlayerDelegate();
    public static DesactivePlayerDelegate DesactivePlayerEvent;

    private void OnEnable()
    {
        DesactivePlayerEvent += DesactivePlayer;
    }

    private void OnDisable()
    {
        DesactivePlayerEvent -= DesactivePlayer;
    }

    private void DesactivePlayer()
    {
        _knifeScript.enabled = false;
        _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
