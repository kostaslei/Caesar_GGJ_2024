using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //_rigidbody2D.rotation = 45f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rigidbody2D.constraints == RigidbodyConstraints2D.FreezeRotation)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;

        }
        else if (_rigidbody2D.rotation < 1f && _rigidbody2D.rotation > -1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}