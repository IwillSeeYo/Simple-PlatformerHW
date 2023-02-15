using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _followSpeed = 2f;
    private float _yOffset = 1f;
    
    private void Update()
    {
        Vector3 position = _player.position;
        position.z = -10f;

        Vector3 newPos = new Vector3(position.x, position.y + _yOffset, position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);
    }
}