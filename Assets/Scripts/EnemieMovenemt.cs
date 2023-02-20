using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class EnemieMovenemt : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;

    private SpriteRenderer _spriteRenderer;

    private float _speed = 10f;
    private int _spot;

    private void Start()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoints[_spot].position, _speed * Time.deltaTime);
        _spriteRenderer.flipX = false;

        if (transform.position == _movePoints[_spot].position)
        {
            _spot++;

            if(_spot >= _movePoints.Length )
            {
                _spot = 0;
            }
        }

        if(transform.position.x < _movePoints[_spot].position.x)
        {
            _spriteRenderer.flipX= true;
        }
    }
}