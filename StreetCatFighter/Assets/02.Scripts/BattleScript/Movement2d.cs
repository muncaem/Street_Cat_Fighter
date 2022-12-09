using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2d : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
