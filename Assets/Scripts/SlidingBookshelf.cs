using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBookshelf : InteractiveObject
{

    [SerializeField] private GameObject bookshelfToSlide;

    [SerializeField] private GameObject targetOfSlide;


    [SerializeField] private float slideSpeed = .5f;

    public override void InteractWith()
    {
        Debug.Log(targetOfSlide.transform.position + "Bottle Position");
        base.InteractWith();
        bookshelfToSlide.transform.position = Vector3.MoveTowards(bookshelfToSlide.transform.position, targetOfSlide.transform.position, slideSpeed);

    }

}
