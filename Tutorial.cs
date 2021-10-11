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



    public Button TutorialButton;
    public Button NextButton;
    public Button ExitInfoButton;
    public Button InfoButton;
    public Button GraphButton;
    public Button GraphTButton;
    public Button GraphT2Button;

    
    //PopUpIndex is pretty much the number that the currrently displayed popup has in the array
    public int timesNextClicked = 0;
    public bool isTutorialRunning = false;


    void Start()
    {   
        //listener 
        TutorialButton.GetComponent<Button>().onClick.AddListener(TutorialButtonClicked);
        PopUpTextResize(80, 250, 210, -11, 25, 200, 210, -69, 70, 220);
    
        //all popup texts
        /*0*/popUpText.Add("Hey There! Welcome to the tutorial!");
        /*1*/popUpText.Add("Doesn't matter, I'm just really good at this stuff.");
        /*2*/popUpText.Add("You probably noticed in the title, but in this lab, we'll be trying to find the relationship between velocity, time, and acceleration.");
        /*3*/popUpText.Add("Let's get started by figuring out what exactly velocity and acceleration even are.");
        /*4*/popUpText.Add("The \"Background Info\" Book will help us do that. You can open the book just by clicking on it."); 
                //must click info button
        /*5*/popUpText.Add("Here are all the definitions! Go ahead and get familiar with them.");
        /*6*/popUpText.Add("If you scroll down a bit, you'll find the procedures we'll be following for this lab. Read those, too!"); 
                //scroll down
        /*7*/popUpText.Add("Notice how since we want to investigate time, velocity, and acceleration, we'll be collecting displacement.");
        /*8*/popUpText.Add("Now click the \"Got it\" button at the bottom of the panel to close the book."); 
                // must click got it! button
        /*9*/popUpText.Add("Alright! So from reading the book, now we know that the first thing we need to do is drop the wheel and make marks on the ramp every second.");
        /*10*/popUpText.Add("You drop the wheel by clicking on it. You make marks on the ramp by pressing the letter m on your keyboard. Try it out!");
        /*11*/popUpText.Add("*psst!* Make sure to notice how the spacing between the marks get bigger and bigger and the wheel goes down the ramp. Also notice how the wheel rolls faster and faster!");
                //must drop wheel and make marks
        /*12*/popUpText.Add("Also, if you aren't happy with your accuracy, click on the wheel anytime after you've let it go and try again. Just let me know when you're done."); 
        /*13*/popUpText.Add("Okay, the next thing we have to do is measure how far each mark is from the wheel's initial position. In other words, measure the wheel's displacement after each second.");
        /*14*/popUpText.Add("Use your measuring tape by clicking and holding your mouse button, dragging, and then pressing the spacebar on your keyboard. Try it out!"); 
                // must measure once
        /*15*/popUpText.Add("You can see your measurement pop up now. Cool, eh?"); 
        /*16*/popUpText.Add("It's also good to know that if you're unsatisfied your data, you can click the red X next to that data type and measure again. It's good practice to make sure you have accurate data!");
                    //make X's clickable
        /*17*/popUpText.Add("Now just keep on measuring how far each mark is from the initial position. Let me know when you're done!");
        /*18*/popUpText.Add("The last thing we need to do is record the amount of time that elapsed between each mark. We know this from the procedures, remember? The difference is going to be 1 second."); 
        /*19*/popUpText.Add("Enter each time in this text box and then press enter. Tell me when you finish!");
                //make text box clickable
        /*20*/popUpText.Add("Now all of our data is collected: we have our diplacements and our times. Now we just have to make sense of our data. A graph would help a whole lot.");
        /*21*/popUpText.Add("Click on the book labeled \"Graphing\". It'll plot all of our points for us.");
                //make graph book clickable
        /*22*/popUpText.Add("Our data is graphed now. Wooo!");
        /*23*/popUpText.Add("You probably noticed already, but it has put time(t) on the x-axis since it's our indepedent variable and the displacement(Δx) on the y-axis since it's our dependent variable.");
        /*24*/popUpText.Add("You also probably noticed that you have absolutely no idea what your looking at. It's ok, it just takes a bit of creativity to figure data out, sometimes.");
        /*25*/popUpText.Add("Notice how the graph grows steeper and steeper as time increases. Remind you of how the wheel would get faster an faster as the time increased?");
        /*26*/popUpText.Add("It should, because the slope of this graph, and any other \"X vs T\" graph, respresents velocity. So the steeper the slope of the graph, the faster velocity at that time.");
        /*27*/popUpText.Add("So, if you collected your data correctly and with enough presicion, your graph should look like a top-opening parabola (kinda like the letter U).");
        /*28*/popUpText.Add("Top-opening parabolas form in graphs where the x is directly proportional to the y² (that just means that the x increases at the same rate as the y²).");
        /*29*/popUpText.Add("So, for example, if we were to square the time so that the graph becomes \"X vs T²\", the graph would no longer be curved and instead be straight.");
        /*30*/popUpText.Add("This process is called linearization. Click the button labeled \"X vs T²\" to do that");
                //make button clickable
        /*31*/popUpText.Add("Now, if you've taken algebra, then you know that the slope of a line is rise/run. In our case, the units of our rise/run is X/T². Look familiar?");
        /*32*/popUpText.Add("YES!!! So the slope of the \"X vs T²\" graph represents the acceleration of the wheel. Try calculating it!");
        /*33*/popUpText.Add("The wheel's actual acceleration down the ramp is about 4.5 m/s². Give yourself a pat on the back if you got something close.");
        /*34*/popUpText.Add("After all that, we have our answer to our lab question now \"How are veloctity, time, and acceleration related?\"");
        /*35*/popUpText.Add("Acceleration is equal to the displacement divided by the time². In other words, a=x/(t²).");
        /*36*/popUpText.Add("Thats the end of the tutorial!");
                //resize panel
        /*37*/popUpText.Add(" ");



        //all button texts
        /*0*/buttonText.Add("Hi! Wait, who are you?");
        /*1*/buttonText.Add("Makes sense, I guess");
        /*2*/buttonText.Add("Yep! I'm just kinda lost right now.");
        /*3*/buttonText.Add("Good idea.");
        /*4*/buttonText.Add(" "); //NONE 
        /*5*/buttonText.Add("Read 'em. Now what?");
        /*6*/buttonText.Add("Ok, I did.");
        /*7*/buttonText.Add("Interesting..");
        /*8*/buttonText.Add(" ");//NONE 
        /*9*/buttonText.Add("Alright.");
        /*10*/buttonText.Add(" "); //NONE 
        /*11*/buttonText.Add("Hm..");
        /*12*/buttonText.Add("Done!");
        /*13*/buttonText.Add("How do I do that, though?");
        /*14*/buttonText.Add(" "); //NONE 
        /*15*/buttonText.Add("Mhm!");
        /*16*/buttonText.Add("I'll keep that in mind.");
        /*17*/buttonText.Add("Done.");
        /*18*/buttonText.Add("How do I enter it?");
        /*19*/buttonText.Add("Finished. What now?");
        /*20*/buttonText.Add("Uh oh..");
        /*21*/buttonText.Add(" ");
        /*22*/buttonText.Add("WOO!!");
        /*23*/buttonText.Add("I noticed.");
        /*24*/buttonText.Add("So then what now?");
        /*25*/buttonText.Add("It does, actually.");
        /*26*/buttonText.Add("That makes sense.");
        /*27*/buttonText.Add("Right..");
        /*28*/buttonText.Add("Gotcha.");
        /*29*/buttonText.Add("Ohhh...");
        /*30*/buttonText.Add(" "); //none
        /*31*/buttonText.Add("Isn't that acceleration?");
        /*32*/buttonText.Add("I'll try..");
        /*33*/buttonText.Add("Nice!");
        /*34*/buttonText.Add("FINALLY!!!!!");
        /*35*/buttonText.Add("COOL!"); 
        /*36*/buttonText.Add("End tutorial."); 
        /*37*/buttonText.Add(" "); 
        
        

        
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
        PopUpTextResize(80, 250, 210, -11, 25, 200, 210, -69, 70, 220);
        TextBox.GetComponent<TMP_Text>().fontSize = 12;
        NextButton.GetComponentInChildren<TMP_Text>().fontSize = 13;
        NextButton.gameObject.SetActive(true);
        
        TextBox.GetComponent<TMP_Text>().text = popUpText[0];
        NextButton.GetComponentInChildren<TMP_Text>().text = buttonText[0];

        Wheel.transform.position = Wheel.GetComponent<WheelBehaviour>().OriginalWheelPos;

        //activate listeners for all buttons
        NextButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        ExitInfoButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        InfoButton.GetComponent<Button>().onClick.AddListener(NextButtonClicked);
        GraphT2Button.GetComponent<Button>().onClick.AddListener(NextButtonClicked);

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

        


        if(timesNextClicked == 4){

            //info button must be selected through dim, so reparented
            InfoButton.transform.SetParent(TutorialCanvas.transform); 
            //next button also therefore not needed
            NextButton.gameObject.SetActive(false); 




        } else if(timesNextClicked == 5){

            //reseting previous reparent and button activations
            NextButton.gameObject.SetActive(true);
            InfoButton.transform.SetParent(GameCanvas.transform, false);
            
            //resizing panel so fits on left
            PopUpTextResize(120, 180, -250, 85, 25, 170, -250, 5, 70, 170);

            //info panel adjustments to the right so text box fits
            InfoPanel.transform.SetParent(Dim.transform);
            ScrollText.transform.localPosition = new Vector2(450, ScrollText.transform.localPosition.y);
            ExitInfoButton.transform.localPosition = new Vector2(450, ExitInfoButton.transform.localPosition.y);




        }else if(timesNextClicked == 8){

            //player must press got it! button
            NextButton.gameObject.SetActive(false); 
            ExitInfoButton.gameObject.SetActive(true);                      




        }else if(timesNextClicked == 9){
            
            //no longer in info so reset popup size
            PopUpTextResize(80, 250, 210, -11, 25, 200, 210, -69, 70, 220);

            //info panel adjustments back to normal
            InfoPanel.transform.SetParent(InfoCanvas.transform, false);
            ScrollText.transform.localPosition = new Vector2(350, ScrollText.transform.localPosition.y);
            ExitInfoButton.transform.localPosition = new Vector2(350, ExitInfoButton.transform.localPosition.y);

            //next button appear
            NextButton.gameObject.SetActive(true); 
        



        }else if(timesNextClicked == 10){

            //player must click wheel
            NextButton.gameObject.SetActive(false); 
            Wheel.transform.SetParent(TutorialCanvas.transform);




        }else if(timesNextClicked == 11){

            //reset wheel & make next button appear again
            NextButton.gameObject.SetActive(true); 
            Wheel.transform.SetParent(TutorialCanvas.transform);




        }else if(timesNextClicked == 14){
            
             NextButton.gameObject.SetActive(false);    
            



        }else if(timesNextClicked == 15){

            //make X's selectable
            NextButton.gameObject.SetActive(true); 
            dispX.transform.SetParent(TutorialCanvas.transform);
            timeX.transform.SetParent(TutorialCanvas.transform);




        }else if(timesNextClicked == 16){

            //move popup so that table numbers can be viewed
            PopUpTextResize(75, 290, -115, 112, 25, 180, -115, 61, 60, 270);
            
            


        }else if(timesNextClicked == 18){

            //make input selectable
            timeInputBox.transform.SetParent(TutorialCanvas.transform);




        }else if(timesNextClicked == 21){

            //player must select graph button
            GraphButton.transform.SetParent(TutorialCanvas.transform); 
            NextButton.gameObject.SetActive(false); 
            
        


        }else if(timesNextClicked == 22){

            //set parents so that gamecanvas gameobject dont appear on graphcanvas
            GraphButton.transform.SetParent(GameCanvas.transform, false);
            timeInputBox.transform.SetParent(GameCanvas.transform, false); 
            dispX.transform.SetParent(GameCanvas.transform, false);
            timeX.transform.SetParent(GameCanvas.transform, false);

            //resize popup so fits in game canvas
            PopUpTextResize(132, 160, 266, -13, 25, 150, 267, -100, 100, 150);
            GraphTButton.transform.localPosition = new Vector2(270, 125);
            GraphT2Button.transform.localPosition = new Vector2(270, 82);

            NextButton.gameObject.SetActive(true); 




        }else if(timesNextClicked == 30){

            //make t^2 graph button selectable
            GraphT2Button.transform.SetParent(TutorialCanvas.transform);
            NextButton.gameObject.SetActive(false); 




        }else if(timesNextClicked == 31){

            //make t^2 graph button not selectable
            GraphT2Button.transform.SetParent(GridBackground.transform);
            NextButton.gameObject.SetActive(true); 




        }else if(timesNextClicked == 36){

            //resize panel & its text so takes up large amount of screen (end of tutorial)
            PopUpTextResize(200, 600, 0, 0, 40, 400, 0, -120, 175, 575);
            TextBox.GetComponent<TMP_Text>().fontSize = 40;
            NextButton.GetComponentInChildren<TMP_Text>().fontSize = 25;




        }else if(timesNextClicked == 37){

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

            GraphTButton.transform.localPosition = new Vector2(270, 54);
            GraphT2Button.transform.localPosition = new Vector2(270, 0);


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
            GraphT2Button.GetComponent<Button>().onClick.RemoveListener(NextButtonClicked);

        //resetting all collected data
            GameCanvas.GetComponent<GameGUI>().RestartDispDropdown();
            GameCanvas.GetComponent<GameGUI>().RestartTimeDropdown();

            timesNextClicked = 0;

        //making sure wheel is in og position
             //Wheel.gameObject.SetActive(true);
             Wheel.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
             Wheel.GetComponent<Rigidbody2D>().angularVelocity = 0;
             Wheel.GetComponent<Rigidbody2D>().isKinematic = true;
             Wheel.transform.position = Wheel.GetComponent<WheelBehaviour>().OriginalWheelPos;


             


    }
}