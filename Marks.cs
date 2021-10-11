using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Marks : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D GroundCollider;
    public Collider2D WheelCollider;
    public GameObject Mark;

    public float MarkAngle;
    public int NumberOfMarks = 0;
    public GameObject WheelF;




    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown("m")){
            
            SpawnMark();
        }

    }

    public void SpawnMark(){

        GameObject a = Instantiate(Mark);   

        Vector2 MarkPrefabPosition = a.transform.position;

        MarkPrefabPosition.x = WheelF.transform.position.x + ((WheelF.GetComponent<CircleCollider2D>().radius));
        MarkPrefabPosition.y = WheelF.transform.position.y + ((WheelF.GetComponent<CircleCollider2D>().radius) - ((float)3));
        
        // MarkPrefabPosition.x =  MarkPrefabPosition.x - 0.4f;        //add offset so its more on the ramp
        // MarkPrefabPosition.y =  MarkPrefabPosition.y - 1.19f;

        a.transform.position = MarkPrefabPosition;

        NumberOfMarks++;

    } 
    
    public void DestoryAllMarks(){


        var clones = GameObject.FindGameObjectsWithTag("Mark");
 
        foreach (var Mark in clones){

             Destroy(Mark);
           }

      }

    public void ToggleMarkVisibilty(){


        var clones = GameObject.FindGameObjectsWithTag("Mark");
 
        foreach (var Mark in clones){

             Mark.SetActive(!Mark.activeInHierarchy);
           }

      }





/*
   public void CalculateGraphPoints(){

       GameObject.Find("Grid Background").GetComponentInChildren<UILineRenderer>().pointList.Clear();

        for (int i = 0; i < NumberOfMarks ; i++){

            Displacements.Add(Mathf.RoundToInt(Vector2.Distance(MarkPositions[0], MarkPositions[i]))); //calculate every point's dist from OG Point and store in list
            GameObject.Find("Grid Background").GetComponentInChildren<UILineRenderer>().pointList.Add(new Vector2(i, Displacements[i] ));
            //GameObject.Find("Grid Background").GetComponentInChildren<UILineRenderer>().points.Add(new Vector2(i * timeInterval, Displacements[i] ));
            

            }
        }*/
         





    
    
    
    
    }

        
