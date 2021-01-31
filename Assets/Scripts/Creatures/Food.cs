using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] internal float cost = 1f;
    internal Transform _transform;

    void Start()
    {
        _transform = transform;
    }
}