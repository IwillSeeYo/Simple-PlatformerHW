
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnPoint;

    private int _gemsCount = 0;

    public event UnityAction<int> GemsChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Gem gem))
        {
            _gemsCount++;
            Destroy(collision.gameObject);
            GemsChanged?.Invoke(_gemsCount);
        }

        if(collision.TryGetComponent(out Enemie enemie)) 
        {
            transform.position = _spawnPoint;
        }
    }
}