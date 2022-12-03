using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D = null;
    private GroundedChecker _groundedChecker = null;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public GroundedChecker GroundedChecker => _groundedChecker;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundedChecker = GetComponent<GroundedChecker>();
    }

    public void Move()
    {
        
    }
    public void Jump()
    {

    }
}
