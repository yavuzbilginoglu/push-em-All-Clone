using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed = 500;

    private Touch touch; //ekrana dokundugumuzu test ediyor.

    public Animator animator;

    private Vector3 touchDown; //karakterin ne tarafa döneceðinin belirliycez (karakter hep ileri gidiyor)
    private Vector3 touchUp;

    private bool dragStarted;//sürükleme kontrolü
    public bool isMoving;//karakterin haraketi
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)//DOKUNMA BAÞLADIGINDA
            {
                dragStarted = true;
                isMoving = true;
                animator.SetBool("isMoving", true);
                touchDown = touch.position;
                touchUp = touch.position;
            }
            if (dragStarted)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    touchDown = touch.position;
                    isMoving = true;
                    animator.SetBool("isMoving", true);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    touchDown = touch.position;
                    isMoving = false;
                    animator.SetBool("isMoving", false);
                    dragStarted = false;
                }
                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            }
        }
    }
    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (touchDown - touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;

        return temp;
    }
}
