using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    public Sprite ArrowSprite;

    public GameObject Arrow = new GameObject(); //Create the GameObject
    private bool isActiveArrow = false;
    private Vector2 firstPosition = new Vector3();
    public GameObject target;
    public GameObject Ball;

    public GameObject BallPrefab;
    public bool isMovementBall = false;

    private float force = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        TouchCheck();
        RespawnBall();
    }

    void TouchCheck()
    {
        Arrow.SetActive(isActiveArrow);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                isActiveArrow = true;
                firstPosition = touch.position;
                Arrow.GetComponent<RectTransform>().transform.position = firstPosition;
                //Debug.Log("first pos");
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
            {
                PlayerControll(touch);
                //Debug.Log("Moved");
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (!isMovementBall)
                {
                    Ball.GetComponent<Rigidbody>().AddForce(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, force*3, ForceMode.Impulse);
                    isMovementBall = true;
                }
                transform.position = new Vector2(0, -3.44f);
                firstPosition = new Vector3(0, 0, 0);
                //Debug.Log("end first pos");
                isActiveArrow = false;
            }
        }
    }
    Vector2 Abs(Vector2 v2) {
        return new Vector2(Mathf.Abs(v2.x), Mathf.Abs(v2.y));
    }

    void PlayerControll(Touch touch) 
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Player")
            {
                transform.position = -(firstPosition - touch.position) * 0.01f + new Vector2(0, -3.44f);
                target.transform.position = (firstPosition - touch.position) * 0.01f + new Vector2(0, -3.44f);

                Arrow.GetComponent<RectTransform>().rotation = Quaternion.LookRotation(target.transform.position - transform.position);
                //Debug.Log(Quaternion.LookRotation(target.transform.position - transform.position));
                Arrow.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, Mathf.Abs(firstPosition.y - touch.position.y) * 0.01f);
                if (Arrow.GetComponent<RectTransform>().localScale.z > 3)
                {
                    Arrow.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 3f);
                }
                else if (Arrow.GetComponent<RectTransform>().localScale.z < 0.1f)
                {
                    Arrow.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0.1f);
                }
                force = Arrow.GetComponent<RectTransform>().localScale.z;
            }
        }
    }

    void RespawnBall() 
    {
        if (!Ball) 
        {
            Ball = Instantiate(BallPrefab);
            Ball.name = "Ball";
            isMovementBall = false;
        }
    }
}
