using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTargetController : MonoBehaviour
{
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;
    [SerializeField]
    private GameObject[] bodyParts;
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
        for(int i =0; i < bodyParts.Length; i++)
        {
            if(gameObject.tag == bodyParts[i].tag)
            {
                SetIKTransformPosition(bodyParts[i], 0.1f);
            }
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

    private void SetIKTransformPosition(GameObject bodyPart, float maxDistance)
    {
        if (Mathf.Abs(gameObject.transform.position.x - bodyPart.transform.position.x) <= maxDistance &&
        Mathf.Abs(gameObject.transform.position.y - bodyPart.transform.position.y) <= maxDistance)
        {
            Debug.Log("if calisiyor!");
            transform.position = GetMouseWorldPos() + mOffset;

        }
        else
        {
            Debug.Log("ELSE calisiyor!");

            bodyIKTransform.position += new Vector3((gameObject.transform.position.x - bodyPart.transform.position.x) - maxDistance,
                (gameObject.transform.position.y - bodyPart.transform.position.y) - maxDistance, 0);

        }
    }
}
