using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float moveXWidth = 1.5f;
    private float moveTimeX = .1f;
    private bool isXMove = false;


    private float originY = 0.55f;
    private float gravity = -9.81f;
    private float moveTimeY = .3f;
    private bool isJump = false;

    [SerializeField]    
    private float moveSpeed = 20.0f;
    private float roatateSpeed = 300;
    private float limitY = -1f;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right * roatateSpeed * Time.deltaTime);
        if(transform.position.y < limitY)
        {
            Debug.Log("Á×À½");
        }
    }

    public void MoveTox(int x)
    {
        if (isXMove == true) return;
        if(x>0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
        else if (x < 0 && transform.position.x > -moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
    }

    public void MoveToY()
    {
        if (isJump == true) return;
        StartCoroutine(OnMoveToY());
    }
    private IEnumerator OnMoveToX(int dir)
    {
        float cur = 0;
        float per = 0;
        float start = transform.position.x;
        float end = transform.position.x + dir * moveXWidth;

        isXMove = true;

        while(per < 1)
        {
            cur += Time.deltaTime;
            per = cur / moveTimeX;

            float x = Mathf.Lerp(start, end, per);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }
        isXMove = false;
    }
    private IEnumerator OnMoveToY()
    {
        float cur = 0;
        float per = 0;
        float v0 = -gravity;

        isJump = true;
        rigidbody.useGravity = false;

        while(per < 1)
        {
            cur += Time.deltaTime;
            per = cur / moveTimeY;

            float y = originY + (v0 * per) + (gravity * per * per);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }
        isJump = false;
        rigidbody.useGravity = true;
    }
}
