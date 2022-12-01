using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    [SerializeField]
    private Vector3 _groundCheckSize = default;
    [SerializeField]
    private Vector3 _groundCheckPosOffset = default;
    [SerializeField]
    private LayerMask _targetLayer = default;
    [SerializeField]
    private Color _gizmoColor = Color.red;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = CheckGrounded();
    }
    private void OnDrawGizmosSelected()
    {
        var pos = transform.position + _groundCheckPosOffset;
        Gizmos.DrawCube(pos, _groundCheckSize);
    }
    private bool CheckGrounded()
    {
        var pos = transform.position + _groundCheckPosOffset;
        var colliders =
            Physics2D.OverlapBoxAll(pos, _groundCheckSize, 0f, _targetLayer);
        return colliders.Length > 0;
    }
}
