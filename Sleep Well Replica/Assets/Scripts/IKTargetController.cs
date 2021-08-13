using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetController : MonoBehaviour
{
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;

    [SerializeField] private Transform bodyIKTransform;



    private Vector3 mOffset;

    private float mZCoord;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if (Mathf.Abs(gameObject.transform.position.x - leftFoot.transform.position.x) <= 0.1f &&
            Mathf.Abs(gameObject.transform.position.y - leftFoot.transform.position.y) <= 0.1f)
        {
            Debug.Log("if calisiyor!");
            transform.position = GetMouseWorldPos() + mOffset;

        }
        else
        {
            Debug.Log("ELSE calisiyor!");

            bodyIKTransform.position += new Vector3((gameObject.transform.position.x - leftFoot.transform.position.x) - 0.1f,
                (gameObject.transform.position.y - leftFoot.transform.position.y) - 0.1f, 0);

        }

        if (Mathf.Abs(gameObject.transform.position.x - rightFoot.transform.position.x) <= 0.1f &&
            Mathf.Abs(gameObject.transform.position.y - rightFoot.transform.position.y) <= 0.1f)
        {
            Debug.Log("if calisiyor!");
            transform.position = GetMouseWorldPos() + mOffset;

        }
        else
        {
            Debug.Log("ELSE calisiyor!");

            bodyIKTransform.position += new Vector3((gameObject.transform.position.x - rightFoot.transform.position.x) - 0.1f,
                (gameObject.transform.position.y - rightFoot.transform.position.y) - 0.1f, 0);

        }
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
