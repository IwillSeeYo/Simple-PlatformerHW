using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _followSpeed = 2f;
    private float _yOffset = 1f;
    private float _freezeCameraPositionZ = -10f;

    private void Update()
    {
        Vector3 position = _player.position;
        
        Vector3 newPos = new Vector3(position.x, position.y + _yOffset, _freezeCameraPositionZ);
        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);
    }
}