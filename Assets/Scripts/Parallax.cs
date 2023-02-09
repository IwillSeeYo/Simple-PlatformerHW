using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class Parallax : MonoBehaviour
{

    [SerializeField] private float _speed;
    private RawImage _image;
    private float _scalePositionX;
    


    void Start()
    {
        _image= GetComponent<RawImage>();
    }

    void Update()
    {
        _scalePositionX += _speed * Time.deltaTime;

        _image.uvRect = new Rect(_scalePositionX, 0 , _image.uvRect.width, _image.uvRect.height);
    }
}
