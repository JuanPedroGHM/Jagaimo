using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private CharacterDirections _facingDir;
    private CharacterDirections _lastFacingDir;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        var velocity = _rigidbody2D.velocity.normalized;
        float speedx = velocity.x;
        float speedy = velocity.y;

        _facingDir = GetFacingDir(speedx, speedy);

        if (_facingDir == _lastFacingDir) return;

        _lastFacingDir = _facingDir;
        SetAnimatorAccordingToDirection(_facingDir);
        HandleLeftRight(speedx);
    }

    private CharacterDirections GetFacingDir(float inputx, float inputy)
    {
        CharacterDirections dir;
        if (inputx > 0.5f)
        {
            dir = CharacterDirections.Right;
        }
        else if (inputx < -0.5f)
        {
            dir = CharacterDirections.Left;
        }
        else if (inputy > 0.5f)
        {
            dir = CharacterDirections.Top;
        }
        else
        {
            dir = CharacterDirections.Bottom;
        }
        return dir;
    }

    private void SetAnimatorAccordingToDirection(CharacterDirections facingDir)
    {
        switch (facingDir)
        {
            case CharacterDirections.Top:
                _animator.Play("Top");
                break;
            case CharacterDirections.Bottom:
                _animator.Play("Bottom");
                break;
            case CharacterDirections.Left:
                _animator.Play("Side");
                break;
            case CharacterDirections.Right:
                _animator.Play("Side");
                break;
            default:
                throw new ArgumentOutOfRangeException("facingDir", facingDir, null);
        }
    }

    private void HandleLeftRight(float speedx)
    {
        if (_facingDir == CharacterDirections.Right
        && !_spriteRenderer.flipX)
        {
            Flip();
        }else if (_facingDir == CharacterDirections.Left
        && _spriteRenderer.flipX
        )
        {
            Flip();
        }
    }

    void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}