using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed);
    }
}
