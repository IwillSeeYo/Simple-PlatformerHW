using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]

public class EnemieMovenemt : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;

    private float _speed = 10f;
    private int _spot = 0;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoints[_spot].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _movePoints[_spot].position) < 0.2f)
        {
            _spot = (_spot == 1) ? 0 : 1;
        }

        if(transform.position.x < _movePoints[_spot].position.x)
        {
            transform.localScale = new Vector3(-5f,5,5); 
        }
        else
        {
            transform.localScale = new Vector3(5f, 5,5);
        }
    }
}
