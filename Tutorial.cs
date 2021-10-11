using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public List<string> popUpText;
    public List<string> buttonText;


    public GameObject TextBox;
    public GameObject TextBoxPanel;
    public GameObject TutorialCanvas;
    public GameObject GameCanvas;
    public GameObject InfoCanvas;
    public GameObject InfoPanel;
    public GameObject Dim;
    public GameObject ScrollText;
    public GameObject Wheel;
    public GameObject dispX;
    public GameObject timeX;
    public GameObject timeInputBox;
    public GameObject GridBackground;
    public GameObject Car;
    public GameObject StartCarButton;
    public GameObject ClearMarksButton;



    public Button TutorialButton;
    public Button NextButton;
    public Button ExitInfoButton;
    public Button InfoButton;
    public Button GraphButton;

    
    //PopUpIndex is pretty much the number that the currrently displayed popup has in the array
    public int timesNextClicked = 0;
    public bool isTutorialRunning = false;


    void Start()
    {   
        //listener 
        TutorialButton.GetComponent<Button>().onClick.AddListener(TutorialButtonClicked);
        PopUpTextResize(80, 250, 210, 79, 25, 200, 210, 21, 70, 220);
    
        //all popup texts
        /*0*/popUpText.Add("Hey There! Welcome to the tutorial!");
        /*1*/popUpText.Add("Alright, so what we're trying to find out is the relationship between displacment and time when velocity is constant, right?");
        /*2*/popUpText.Add("So let's get started by finding out what exactly displacement and velocity even are.");
        /*3*/popUpText.Add("Click here on \"Instructions\". Definitions are located here."); 
                //must click info button
                //ARROW
        /*4*/popUpText.Add("Tada! Here are all the definitions you need - go ahead and get familiar with them.");
        /*5*/popUpText.Add("The procedures for this lab are also located here. Scroll down and read those, too.");
        /*6*/popUpText.Add("Click the \"Got it\" button at the bottom of the panel to go back to the lab."); 
              // must click got it! button
        /*7*/popUpText.Add("Now we know that we need to do record the displacement of the car every 2 seconds and then make a Displacement vs Time graph.");
        /*8*/popUpText.Add("To do that, start the car and make a mark on the ground every 2 seconds. (Make a mark by pressing \"m\" on your keyboard)");
                //ARROW TO START CAR
        /*9*/popUpText.Add("If want to try making your marks again, then clear the marks, move your car to it's original position (by clicking on it), and try again.");
                //ARROW TO CLEAR MARKS
                //ARROW TO START CAR
        /*10*/popUpText.Add("Now we're gonna record the change in displacement for each mark we made. (To measure: click and drag, and then press the spacebar to record)"); 
        /*11*/popUpText.Add("If you made a mistake measuring, click the red X to delete the lengths you recorded. Then try again.");
                //ARROW TO DISP. X
        /*12*/popUpText.Add("Next, we input our times. Since we recorded displacement every 2 seconds, our times will be: 2, 4, 6, 8, and 10 seconds. (To input a time: type time in box and press enter)");
                //ARROW TO INPUT 
        /*13*/popUpText.Add("Finally, we will graph our displacments and times on a Displacement vs Time graph. Click \"Graph your Data\"."); 
                // must measure once
                //AROW TO GRAPH BUTTON
        /*14*/popUpText.Add("And there's your graph! (We can find out alot of juicy information now)."); 
        /*15*/popUpText.Add("For example, the fact that the graph is increasing tells us that the displacment the car was increasing (which it was).");
                //make X's clickable
        /*16*/popUpText.Add("Think about it: the graph shows us that as time was increasing, the displacement was increasing too.");
        /*17*/popUpText.Add("Then, the fact that the graph is increasing at a constant rate (going up in a straight line) tells us that the car was moving at a constant velocity (which it also was)"); 
        /*18*/popUpText.Add("Think about it: the shows shows us that the car would have the same change in displacement for every same change in time (that's the definition of constant velocity!). Check the graph to prove this statement.");
        /*19*/popUpText.Add("Thats the end of the tutorial!");
                //resize panel
        /*20*/popUpText.Add(" ");

        //all button texts
        /*0*/buttonText.Add("Hi!");
        /*1*/buttonText.Add("Yep.");
        /*2*/buttonText.Add("Good idea.");
        /*3*/buttonText.Add(" "); //NONE 
        /*4*/buttonText.Add("Read 'em.");
        /*5*/buttonText.Add("Ok, I did.");
        /*6*/buttonText.Add(" ");//NONE 
        /*7*/buttonText.Add("Mhm.");
        /*8*/buttonText.Add("Done.");  
        /*9*/buttonText.Add("Good to know.");
        /*10*/buttonText.Add("I finished measuring"); 
        /*11*/buttonText.Add("Gotcha.");
        /*12*/buttonText.Add("Finished inputting."); 
        /*13*/buttonText.Add(""); //NONE
        /*14*/buttonText.Add("Nice.");
        /*15*/buttonText.Add("Cool.");
        /*16*/buttonText.Add("Ohh...");
        /*17*/buttonText.Add("That's neat.");
        /*18*/buttonText.Add("I got it, now.");
        /*19*/buttonText.Add("End the tutorial, please.");
        /*19*/buttonText.Add("");
        
        

        
    }

    public void PopUpTextResize(float panelHeight, float panelWidth, float panelPosX, float panelPosY, float buttonHeight, float buttonWidth, float buttonPosX, float buttonPosY, float textHeight, float textWidth){

        //SETTING UP INFO CANVAS 
        if(timesNextClicked == 5){

            InfoPanel.transform.SetParent(Dim.transform);                                                           //sets info panel parent and dim so both button and scroll are interactable

            ScrollText.transform.localPosition = new Vector2(450, ScrollText.transform.localPosition.y);            //sliding info text & exit button to right so popup fits on left
            ExitInfoButton.transform.localPosition = new Vector2(450, ExitInfoButton.transform.localPosition.y);
        }

            //POPUP TEXT,PANEL, AND BUTTON SIZE & POSITION CHANGES FOR INFO CANVAS
            TextBoxPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(panelWidth, panelHeight);   //textbox grey panel new height and width
            TextBoxPanel.transform.localPosition = new Vector2(panelPosX, panelPosY);                      //text box grey panel new position farther left

            TextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);          //text new height and width. no new position needed since child of textbox panel

            NextButton.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth, buttonHeight);   //next button new hieght and width
            NextButton.transform.localPosition = new Vector2(buttonPosX, buttonPosY);                      //next button new position farther left

    }

    public void TutorialButtonClicked(){

        //tutorial canvas is activated
        TutorialCanvas.SetActive(true);

        //setting up popup default settings
        PopUpTextResize(80, 250, 210, 79, 25, 200, 210, 21, 70, 220);
        TextBox.GetComponent<TMP_Text>().fontSize = 12;
        NextButton.GetComponentInChildren<TMP_Text>().fontSize = 13;
        NextButton.gameObject.SetActive(true);
        
        TextBox.GetComponent<TMP_Text>().text = popUpText[0];
        NextButton.GetComponentInChildren<TMP_Text>().text = buttonText[0];

        //Wheel.transform.position = Wheel.GetComponent<CarBehaviour>().OriginalCarBodyPos;

        //activate listeners for all buttons
        NextButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        ExitInfoButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        InfoButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);

        isTutorialRunning = true;

        //gets rid of all data already collected, if any
        GameCanvas.GetComponent<GameGUI>().RestartDispDropdown();
        GameCanvas.GetComponent<GameGUI>().RestartTimeDropdown();
    }





    public void NextButtonClicked(){

        //count everytime button is clicked
        timesNextClicked++;

        //print info for debugging
        print(timesNextClicked);
        print(popUpText[timesNextClicked]);
        print(buttonText[timesNextClicked]);

        //update popup text for amount of times button clicked
        TextBox.GetComponent<TMP_Text>().text = popUpText[timesNextClicked];
        //print(popUpText[timesNextClicked]);
        NextButton.GetComponentInChildren<TMP_Text>().text = buttonText[timesNextClicked];
        //print(buttonText[timesNextClicked]);

        


        if(timesNextClicked == 3){

            //info button must be selected through dim, so reparented
            InfoButton.transform.SetParent(TutorialCanvas.transform); 
            //next button also therefore not needed
            NextButton.gameObject.SetActive(false); 




        } else if(timesNextClicked == 4){

            //reseting previous reparent and button activations
            NextButton.gameObject.SetActive(true);
            InfoButton.transform.SetParent(GameCanvas.transform, false);
            
            //resizing panel so fits on left
            PopUpTextResize(120, 180, -250, 85, 25, 170, -250, 5, 70, 170);

            //info panel adjustments to the right so text box fits
            InfoPanel.transform.SetParent(Dim.transform);
            ScrollText.transform.localPosition = new Vector2(450, ScrollText.transform.localPosition.y);
            ExitInfoButton.transform.localPosition = new Vector2(450, ExitInfoButton.transform.localPosition.y);




        }else if(timesNextClicked == 6){

            //player must press got it! button
            NextButton.gameObject.SetActive(false); 
            ExitInfoButton.gameObject.SetActive(true);                      




        }else if(timesNextClicked == 7){
            
            //no longer in info so reset popup size
            PopUpTextResize(80, 250, 210, 79, 25, 200, 210, 21, 70, 220);

            //info panel adjustments back to normal
            InfoPanel.transform.SetParent(InfoCanvas.transform, false);
            ScrollText.transform.localPosition = new Vector2(350, ScrollText.transform.localPosition.y);
            ExitInfoButton.transform.localPosition = new Vector2(350, ExitInfoButton.transform.localPosition.y);

            //next button appear
            NextButton.gameObject.SetActive(true); 
        

        }else if(timesNextClicked == 8){
            Car.transform.SetParent(TutorialCanvas.transform);
            StartCarButton.transform.SetParent(TutorialCanvas.transform);

         }else if(timesNextClicked == 9){
            ClearMarksButton.transform.SetParent(TutorialCanvas.transform);

        }else if(timesNextClicked == 11){

            //make X's selectable
            NextButton.gameObject.SetActive(true); 
            dispX.transform.SetParent(TutorialCanvas.transform);
            timeX.transform.SetParent(TutorialCanvas.transform);



        }else if(timesNextClicked == 12){

            //make input selectable
            timeInputBox.transform.SetParent(TutorialCanvas.transform);




        }else if(timesNextClicked == 13){

            //player must select graph button
            GraphButton.transform.SetParent(TutorialCanvas.transform); 
            NextButton.gameObject.SetActive(false); 
            
        


        }else if(timesNextClicked == 14){

            //set parents so that gamecanvas gameobject dont appear on graphcanvas
            GraphButton.transform.SetParent(GameCanvas.transform, false);
            timeInputBox.transform.SetParent(GameCanvas.transform, false); 
            dispX.transform.SetParent(GameCanvas.transform, false);
            timeX.transform.SetParent(GameCanvas.transform, false);

            //resize popup so fits in game canvas
            PopUpTextResize(132, 160, 266, -13, 25, 150, 267, -100, 100, 150);

            NextButton.gameObject.SetActive(true); 


        }else if(timesNextClicked == 19){

            //resize panel & its text so takes up large amount of screen (end of tutorial)
            PopUpTextResize(200, 600, 0, 0, 40, 400, 0, -120, 175, 575);
            TextBox.GetComponent<TMP_Text>().fontSize = 40;
            NextButton.GetComponentInChildren<TMP_Text>().fontSize = 25;




        }else if(timesNextClicked == 20){

            EndTutorial();




            }else{
                //default parents
            InfoButton.transform.SetParent(GameCanvas.transform);
            InfoCanvas.transform.SetParent(null);
            NextButton.gameObject.SetActive(true);
            ExitInfoButton.gameObject.SetActive(false);
    


        }

    }

    public void EndTutorial(){

        //tutorial canvas is deactivated
            TutorialCanvas.SetActive(false);
            isTutorialRunning = false;


        //all default parents
            InfoButton.transform.SetParent(GameCanvas.transform, false);
            GraphButton.transform.SetParent(GameCanvas.transform);
            dispX.transform.SetParent(GameCanvas.transform);
            timeX.transform.SetParent(GameCanvas.transform);
            timeInputBox.transform.SetParent(GameCanvas.transform);

            InfoPanel.transform.SetParent(InfoCanvas.transform, false);
            ScrollText.transform.localPosition = new Vector2(350, ScrollText.transform.localPosition.y);
            ExitInfoButton.transform.localPosition = new Vector2(350, ExitInfoButton.transform.localPosition.y);

            InfoCanvas.transform.SetParent(null);
            Wheel.transform.SetParent(null);


        //gridcanvas & info canvas toggle (if active)
            if(GridBackground.activeInHierarchy == true){
                GameCanvas.GetComponent<GameGUI>().ToggleGridPopUp();
            }

            if(InfoCanvas.activeInHierarchy == true){
                GameCanvas.GetComponent<GameGUI>().ToggleInstructionsPopUp();

            }

        //deactivate listeners for all buttons
            NextButton.GetComponent<Button>().onClick.RemoveListener(NextButtonClicked);
            ExitInfoButton.GetComponent<Button>().onClick.RemoveListener(NextButtonClicked);
            InfoButton.GetComponent<Button>().onClick.RemoveListener(NextButtonClicked);

        //resetting all collected data
            GameCanvas.GetComponent<GameGUI>().RestartDispDropdown();
            GameCanvas.GetComponent<GameGUI>().RestartTimeDropdown();

            timesNextClicked = 0;

        //making sure wheel is in og position
             //Wheel.gameObject.SetActive(true);
             Wheel.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
             Wheel.GetComponent<Rigidbody2D>().angularVelocity = 0;
             Wheel.GetComponent<Rigidbody2D>().isKinematic = true;
             Wheel.transform.position = Wheel.GetComponent<CarBehaviour>().OriginalCarBodyPos;


             


    }
}