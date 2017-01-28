using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public float Turnspeed;
    public float Walkspeed;
    public Vector2 WalkDirection;
    private Transform _target;


    private Rigidbody2D _rigidbody2D;


    public Transform Target
    {
        set { _target = value; }
    }

    // Use this for initialization
    void Start ()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            WalkDirection = _target.position - transform.position;
            WalkDirection.Normalize();


            float angle = Mathf.Atan2(WalkDirection.y, WalkDirection.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Turnspeed);
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = WalkDirection*Walkspeed;
    }


}