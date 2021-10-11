using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MeasuringTape : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    Vector3 endPos;
    Camera cam;
    LineRenderer lineRenderer;
    public TMP_Dropdown DispDropdown;
    Vector3 camOffset = new Vector3(0, 0, 10);
    public List<float> DispListFloatRef;
    public List<string> DispListStrRef;

    public GameObject InfoCanvas;
    public GameObject GridCanvas;


    void Start()
    {      
        //setting up variables
        cam = Camera.main;
        DispListFloatRef =  GameObject.Find("GameCanvas").GetComponent<GameGUI>().DispListFloat;
        DispListStrRef = GameObject.Find("GameCanvas").GetComponent<GameGUI>().DispListStr;
        
        //restart at beginning to clear errors/changes
        GameObject.Find("GameCanvas").GetComponent<GameGUI>().RestartDispDropdown();

        //ensures linerenderer is always defined
        if(lineRenderer == null){
            
                lineRenderer = gameObject.GetComponent<LineRenderer>();
            }

        //linerenderer should only be enabled when mouse button down
        lineRenderer.enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(InfoCanvas.activeInHierarchy == false && GridCanvas.activeInHierarchy == false){

            if(Input.GetMouseButtonDown(0)){
                
                //enable measuring tape when mouse button down
                lineRenderer.enabled = true;

                //has 2 positions: startpos and endpos
                lineRenderer.positionCount = 2;

                //startpos = where mouse button went down
                startPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;

                //position 0 (one end of line) = startpos
                lineRenderer.SetPosition(0, startPos);

                lineRenderer.useWorldSpace = true;
                //print("enabled");

            }

            if(Input.GetMouseButton(0)){
                
                //while mouse button is being held:

                //endpos = where mouse button is
                endPos = cam.ScreenToWorldPoint(Input.mousePosition) + camOffset;

                //position 1 (other end of line) = endpos
                lineRenderer.SetPosition(1, endPos);
            }

            if(Input.GetMouseButtonUp(0)){

                //when mouse button is let go, tape disappears
                lineRenderer.enabled = false;

                //print("disabled");

            }

            if (Input.GetKeyDown("space") && lineRenderer.enabled == true ){

                        /*if(DispToString[0] ==  GameObject.Find("GameCanvas").GetComponent<GameGUI>().DispDropdownLabel){

                                DispToString.Remove(DispToString[0]);

                            }*/

                        //disp is calculated using the end and start pos
                        //when space is pressed while line is existing, disp calculated and disp sumbitted to list

                        float disp = (float)System.Math.Round((Vector2.Distance(startPos, endPos)), 2);

                        DispListFloatRef.Add(disp);
                        DispListStrRef.Add(disp.ToString());

                            
                        DispDropdown.Hide();
                        DispDropdown.ClearOptions();
                        DispDropdown.AddOptions(DispListStrRef);
                            
                        DispDropdown.Show();

                        lineRenderer.enabled = false;
                        
                        //FOR TUTORIAL

                        if(GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialRunning == true && GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().timesNextClicked == 14){

                            GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().NextButtonClicked();

                        }
                    }

        }
    }   



}
