using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPlacements : MonoBehaviour
{
    [SerializeField] private Transform leftFootIKTransform;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //ray'in carptigi cismin pozisyonunu mouse'a bagli degistiriyor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            if (hit.transform.tag == "IKTransform")
            {
                hit.transform.position = hit.point;
            }

        }
    }

    public void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);

            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootIKTransform.position);

        }
    }
}
