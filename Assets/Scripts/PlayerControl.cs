using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float dragDistance = 50f;
    private Vector3 touchStart;
    private Vector3 touchEnd;

    private PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            OnMobliePlatform();
        }
        else
        {
            OnPCPlatform();
        }
    }

    private void OnMobliePlatform()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }
        else if(touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();
        }
    }

    private void OnPCPlatform()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            OnDragXY();
        }
    }

    private void OnDragXY()
    {
        if(Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance)
        {
            playerMove.MoveTox((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }
        if(touchEnd.y - touchStart.y >= dragDistance)
        {
            playerMove.MoveToY();
            return;
        }
    }
}
