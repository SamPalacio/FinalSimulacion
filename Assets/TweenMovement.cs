using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenMovement : MonoBehaviour
{

    enum State
    {
        Rotate,
        Transite,
        Stop

    }
    [SerializeField] GameObject launchButton;
    [SerializeField] Dropdown curveSelection;



    State state;
    [SerializeField] AnimationCurve Linear;
    [SerializeField] AnimationCurve Ease;
    [SerializeField] AnimationCurve EaseIn;
    [SerializeField] AnimationCurve EaseOut;
    [SerializeField] AnimationCurve EaseInOut;
    [SerializeField] float duration;
    
    [SerializeField] Text text;
     Transform endPosition;
    AnimationCurve curve;

    Vector3 startPosition;
    float angle = 0;
    float t=0;


    private void Start()
    {
        startPosition = transform.position;
        state=State.Stop;
    }
    private void Update()
    {
        switch (state)
        {
            case State.Rotate:
                Rotate();
                break;  
            case State.Transite:
                Rotate();
                t += (Time.deltaTime / duration);
                transform.position = Vector3.Lerp(startPosition, endPosition.position, curve.Evaluate(t));
                break;
            case State.Stop:
                break;
        }
    }

    public void StopSpaceShip()
    {
        state = State.Stop;
    } 
   
   void Rotate()
    {
        float x = endPosition.position.x - transform.position.x;
        float z = endPosition.position.z - transform.position.z;
        float planetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, planetAngle, 0.01f);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, angle, transform.localEulerAngles.z);
    }
    public void StartTween(Transform nextPos)
    {
        text.text=nextPos.name;
        if (endPosition != null)
        {
            endPosition.GetComponent<Planet>().enabled = false;
        }
        startPosition = transform.position;
        endPosition = nextPos;
        endPosition.GetComponent<Planet>().enabled = true;
        t = 0;
        angle = transform.localEulerAngles.y;
        state = State.Rotate;
        launchButton.SetActive(true);
        curveSelection.gameObject.SetActive(true);


    }
    public void Launch()
    {
        SelectCurve();
        state = State.Transite;
        launchButton.SetActive(false);
        curveSelection.gameObject.SetActive(false);

    }

    public void SelectCurve()
    {
        string curveSelected = curveSelection.options[curveSelection.value].text;
        curveSelected = curveSelected.ToUpper();
        switch (curveSelected)
        {
            case "LINEAR":
                curve = Linear;
                break;
            case "EASE":
                curve = Ease;
                break;
            case "EASEIN":
                curve = EaseIn;
                break;
            case "EASEOUT":
                curve = EaseOut;
                break;
            case "EASEINOUT":
                curve = EaseInOut;
                break;
        }
    }


}
