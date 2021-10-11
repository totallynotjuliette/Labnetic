using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Wheel;

    //VARIABLES
    float time;
    public Vector2 OriginalWheelPos;
    public bool isTimerRunning = false;
    public string currentColliderName;

    //GUI
    public TextMeshProUGUI TimerText;

    //COLLIDERS
    public Collider2D WheelCollider;
    public Collider2D GroundCollider;
    public Collider2D RampCollider;
    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(200, 200, 200, 255);
        Wheel.isKinematic = true;
        OriginalWheelPos =  Wheel.transform.position;
    }

    void Update()
    {
        if (isTimerRunning && WheelCollider.IsTouching(RampCollider)){

            time += Time.deltaTime;
            TimerText.SetText("Time: " + time.ToString("F2") + "s");

        } 

    }

    public void WheelButton(){ //when clicked
        
        isTimerRunning = !isTimerRunning;
        
        Wheel.isKinematic = !Wheel.isKinematic;

        if (!isTimerRunning){ //if wheel is clicked when not rolling (when is either on ground or hovering)

            //RESTART 

            time = 0f;
            TimerText.SetText("Time: " + time.ToString("F3") + "s");
            GameObject.Find("GameCanvas").GetComponent<Marks>().DestoryAllMarks();

            Wheel.transform.position = OriginalWheelPos;
            Wheel.angularVelocity = 0;
            Wheel.velocity = Vector2.zero;

            //GameObject.Find("GameCanvas").GetComponent<GameGUI>().RestartDispDropdown();

        }

    }



    void OnCollisionEnter2D(Collision2D col){

        print(col.gameObject.name);

        if(col.gameObject.name == "Ramp"){

            GameObject.Find("GameCanvas").GetComponent<Marks>().SpawnMark();




        // FOR TUTORIAL
        }else if(col.gameObject.name == "Wall" && GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialRunning == true && GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().timesNextClicked == 10){
            //if tutorial active, fwd to next popup if hits wall (popup 10)
            GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().NextButtonClicked();
            print("run");

            }
            
        }


    void OnMouseOver(){

        if(WheelCollider.IsTouching(RampCollider) || WheelCollider.IsTouching(GroundCollider)){
            //if not in air, hover is red
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 167, 167, 255);

        } else {
            //if in air, hover is white
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }

        if(Input.GetMouseButtonDown(0) ) {

            WheelButton();


        }
;
    }

    void OnMouseExit(){

        if(isTimerRunning){

            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        } else {

            gameObject.GetComponent<SpriteRenderer>().color = new Color32(200, 200, 200, 255);

        }

    }

}
