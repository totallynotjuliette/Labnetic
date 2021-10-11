using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D WheelF;
    public Rigidbody2D WheelB;
    public Rigidbody2D CarBody;
    public GameObject CarBodyGameobject;
    public GameObject Wall;
    public GameObject CarButtonText;

    HingeJoint2D hingeJointF;
    HingeJoint2D hingeJointB;
    JointMotor2D motorF;
    JointMotor2D motorB;

    //VARIABLES
    float time;
    float motorSpeed = 200f;
    public Vector2 OriginalCarBodyPos;
    public Vector2 OriginalWheelFPos;
    public Vector2 OriginalWheelBPos;
    public bool isTimerRunning = false;
    public string currentColliderName;
    public bool wallHit = false;

    public int timesCarButtonClicked = 0;
    //GUI
    public TextMeshProUGUI TimerText;

    //COLLIDERS
    public Collider2D GroundCollider;
    
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().color = new Color32(200, 200, 200, 255);
        //Car.isKinematic = true;
        OriginalCarBodyPos =  CarBody.transform.position;
        OriginalWheelFPos =  WheelF.transform.position;
        OriginalWheelBPos =  WheelB.transform.position;
        

        hingeJointF = WheelF.GetComponent<HingeJoint2D>();
        hingeJointB = WheelB.GetComponent<HingeJoint2D>();
        motorF = hingeJointF.motor;
        motorB = hingeJointB.motor;

    }

    void Update()
    {
        if (isTimerRunning && wallHit == false){

            time += Time.deltaTime;
            TimerText.SetText("Time: " + time.ToString("F2") + "s");

        }

    }
    public void ClearMarks(){
        
        GameObject.Find("GameCanvas").GetComponent<Marks>().DestoryAllMarks();
    }
    public void CarButton(){ //when clicked
        
        timesCarButtonClicked++;
        print(timesCarButtonClicked);

        if(timesCarButtonClicked % 2 == 0){
            CarButtonText.GetComponent<Text>().text = "START CAR";
        } else {
            CarButtonText.GetComponent<Text>().text = "STOP CAR";
        }

        isTimerRunning = true;
        
        
        //isTimerRunning = !isTimerRunning;


        //reset wall hit var
        if(wallHit == true){
            wallHit = false;
        } 

        //motorF = hingeJointF.motor;
        
        if(motorF.motorSpeed == 0){
            motorF.motorSpeed = motorSpeed;
            motorB.motorSpeed = motorSpeed;
            hingeJointF.motor = motorF;
            hingeJointB.motor = motorB;

        } else {
            motorF.motorSpeed = 0;
            motorB.motorSpeed = 0;
            hingeJointF.motor = motorF;
            hingeJointB.motor = motorB;
        }

        // if(CarBody.GetComponent<Rigidbody2D>().velocity == Vector2.zero){
        //     CarBody.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

        // } else {
        //     CarBody.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // }

        if (!isTimerRunning){ //if wheel is clicked when not rolling (when is either on ground or hovering)


            motorF.motorSpeed = 0;
            motorB.motorSpeed = 0;
            hingeJointF.motor = motorF;
            hingeJointB.motor = motorB;

        //     //CarBody.transform.position = OriginalCarBodyPos;
        //     CarBody.angularVelocity = 0;
        //     CarBody.velocity = Vector2.zero;
        //     CarBody.rotation = 0;

        //    // WheelF.transform.position = OriginalWheelFPos;
        //     WheelF.angularVelocity = 0;
        //     WheelF.velocity = Vector2.zero;

        //     //WheelB.transform.position = OriginalWheelBPos;
        //     WheelB.angularVelocity = 0;
        //     WheelB.velocity = Vector2.zero;

        // GameObject.Find("GameCanvas").GetComponent<GameGUI>().RestartDispDropdown();

        }

    }



    void OnCollisionEnter2D(Collision2D col){

        // print(col.gameObject.name);

        // if(col.gameObject.name == "Ramp"){

        //     GameObject.Find("GameCanvas").GetComponent<Marks>().SpawnMark();


        if(col.gameObject.name == "Wall"){
            wallHit = true;
        }

        // // FOR TUTORIAL
        // }else if(col.gameObject.name == "Wall" && GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialRunning == true && GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().timesNextClicked == 10){
        //     //if tutorial active, fwd to next popup if hits wall (popup 10)
        //     GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().NextButtonClicked();
        //     print("run");

        //     }
            
        }


    void OnMouseOver(){
        //print("mouse over");

        // if(CarCollider.IsTouching(GroundCollider)){
        //     //if not in air, hover is red
        //     gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 167, 167, 255);

        // } else {
        //     //if in air, hover is white
        //     gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        // }

        if(Input.GetMouseButtonDown(0) ) {

            print("car clicked");

            //RESETING ENTIRE CAR

            //Car Body
            CarBody.transform.position = OriginalCarBodyPos;
            CarBody.angularVelocity = 0;
            CarBody.velocity = Vector2.zero;
            CarBody.rotation = 0;

            //Wheel F
            WheelF.transform.position = OriginalWheelFPos;
            WheelF.angularVelocity = 0;
            WheelF.velocity = Vector2.zero;

            //WheelB
            WheelB.transform.position = OriginalWheelBPos;
            WheelB.angularVelocity = 0;
            WheelB.velocity = Vector2.zero;

            //Setting motor speeds to 0
            motorF.motorSpeed = 0;
            motorB.motorSpeed = 0;
            hingeJointF.motor = motorF;
            hingeJointB.motor = motorB;

            //timer reset
            isTimerRunning = false;
            time = 0f;
            TimerText.SetText("Time: " + time.ToString("F3") + "s");

            //car button text reset
            CarButtonText.GetComponent<Text>().text = "START CAR";
            timesCarButtonClicked = 0;


        }
;
    }

    void OnMouseExit(){
        
        // if(isTimerRunning){

        //     gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        // } else {

        //     gameObject.GetComponent<SpriteRenderer>().color = new Color32(200, 200, 200, 255);

        //}

    }

}
