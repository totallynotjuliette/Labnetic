using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Unity.Mathematics;

public class GameGUI : MonoBehaviour
{
    public GameObject InstructionsCanvas;
    public GameObject GridCanvas;
    public GameObject Grid;
    public GameObject Ramp;
    public GameObject Wheel;

    public TMP_Dropdown TimeDropdown;
    public TMP_Dropdown DispDropdown;
    public TMP_InputField TimeInputField;
    public Button GraphButton;
    

    public List<float> TimeListFloat;
    public List<string> TimeListStr;
    public List<float> DispListFloat;
    public List<string> DispListStr;


    public bool x2ButtonPressed = false;
    int timesGridClicked = 0;

    //public string DispDropdownLabel = "Distances: ";
    //public string TimeDropdownLabel = "Times: ";    

//---------------------------------------------------------------------
//GUI
  void Start(){

    //clears all values/measurements and deletes all grid labels

    Grid.GetComponent<UIGridRenderer>().DestoryAllNumLabels();
    
    RestartDispDropdown();
    RestartTimeDropdown();

    
  }


 void Update () {

    //when user clicks enter when something in input box, number is sumbitted
    //aka: shows in dropdown and recorded in list
    if (TimeInputField.text.Length > 0 && Input.GetKeyDown(KeyCode.Return)) {
          OnSubmit();
      }
    //deletes the blockers of the dropdowns (so user can click on other UI)
    UnityEngine.UI.Dropdown.Destroy(GameObject.Find("Blocker"));

    }


  
//-----------------
  public void ToggleInstructionsPopUp(){

    //Toggle visibility of instructions, game canvas, wheel, and ramp
    InstructionsCanvas.SetActive(!InstructionsCanvas.activeInHierarchy);
    gameObject.SetActive(!gameObject.activeInHierarchy);
    Wheel.SetActive(!Wheel.activeInHierarchy);
    Ramp.SetActive(!Ramp.activeInHierarchy);

    //if clicked and instruction has been turned OFF, turn dropdowns ON
    //if clicked and intrusction has been turned ON, turn dropdowns OFF
    if(InstructionsCanvas.activeInHierarchy == false){

      TimeDropdown.Show();
      DispDropdown.Show();

    } else {

      TimeDropdown.Hide();
      DispDropdown.Hide();
    }
  }

//------------------


  public void ToggleGridPopUp(){
    //count every time button is clicked (only used for toggling dropdowns)
    //even = grid to be turned off
    //odd = grid to be turned on

    //grid only pops up if both have more than 2 points
    if(DispListStr.Count >=2 && TimeListStr.Count >=2){

      timesGridClicked++;

      //toggle visibility of grid, gamecanvas, wheel, ramp, and marks
      GridCanvas.SetActive(!GridCanvas.activeInHierarchy);
      gameObject.SetActive(!gameObject.activeInHierarchy);
      Wheel.SetActive(!Wheel.activeInHierarchy);
      Ramp.SetActive(!Ramp.activeInHierarchy);
      gameObject.GetComponent<Marks>().ToggleMarkVisibilty();

      //the code to toggle the dropdowns is done differently than for every other UI bececause
      //showing/hiding the dropdowns can not be as easily toggled using [!] operator
      //if even clicks (so if grid clicked to be turned off), then show dropdowns, else hide the dropdowns
      //destory the num labels when 
      if(timesGridClicked%2 == 0){

        TimeDropdown.Show();
        DispDropdown.Show();

        } else {
          
          GridCanvas.GetComponentInChildren<UIGridRenderer>().DestoryAllNumLabels();
          TimeDropdown.Hide();
          DispDropdown.Hide();

        } 

        if(GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialRunning == true){

          GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().NextButtonClicked();
        }
    }

  }



  public void x2Button(){

    Grid.GetComponent<UIGridRenderer>().DestoryAllNumLabels();
    GridCanvas.SetActive(false);
    x2ButtonPressed = true;
    GridCanvas.SetActive(true);

    GameObject.Find("X-axis Label").GetComponent<TMP_Text>().text = "Time²(s²)";
  }



  public void xButton(){

    Grid.GetComponent<UIGridRenderer>().DestoryAllNumLabels();
    GridCanvas.SetActive(false);
    x2ButtonPressed = false;
    GridCanvas.SetActive(true);
  }

//------------------------------------------------------------------

  public void RestartTimeDropdown(){

      TimeDropdown.ClearOptions();

      TimeListFloat.Clear();
      TimeListStr.Clear();

      TimeListStr.Add("");
      TimeDropdown.AddOptions(TimeListStr);
      TimeInputField.text = "";
      
      TimeDropdown.Hide();
  }



    public void RestartDispDropdown(){
        
        DispDropdown.ClearOptions();

        DispListFloat.Clear();
        DispListStr.Clear();

        DispListStr.Add("");
        DispDropdown.AddOptions(DispListStr);

        DispDropdown.Hide();
    }



    public void OnSubmit(){

      float inputtedTime = float.Parse(TimeInputField.text);
      string inputtedTimeStr = TimeInputField.text;

      TimeListFloat.Add(inputtedTime);
      TimeListStr.Add(inputtedTimeStr);

      TimeDropdown.Hide();
      TimeDropdown.ClearOptions();
      TimeInputField.text = "";
 
      TimeDropdown.AddOptions(TimeListStr);
      TimeDropdown.Show();
    }


}





