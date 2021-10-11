using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marks : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D RampCollider;
    public Collider2D WheelCollider;
    public GameObject Mark;
    public GameObject Ramp;

    public float MarkAngle;
    public int NumberOfMarks = 0;
    public GameObject Wheel;




    // Update is called once per frame
    void Start(){

        float ImageDimensionsY = 600f;
        float ImageDimensionsX = 1400f;

        float RampY = ImageDimensionsY * Ramp.transform.localScale.y;
        float RampX = ImageDimensionsX * Ramp.transform.localScale.x;

        MarkAngle = (-(((Mathf.Asin(RampY/RampX)) * 180 ) / Mathf.PI))+90;
        print(MarkAngle);

        Mark.transform.rotation = Quaternion.Euler(0, 0, MarkAngle); 


    }
    void Update()
    {
        if (Input.GetKeyDown("m") && WheelCollider.IsTouching(RampCollider)){
            
            SpawnMark();
        }

    }

    public void SpawnMark(){

        GameObject a = Instantiate(Mark);   

        Vector2 MarkPrefabPosition = a.transform.position;

        MarkPrefabPosition.x = Wheel.transform.position.x + ((Wheel.GetComponent<CircleCollider2D>().radius) * Mathf.Sin(MarkAngle+90));
        MarkPrefabPosition.y = Wheel.transform.position.y + ((Wheel.GetComponent<CircleCollider2D>().radius) * Mathf.Cos(MarkAngle+90));
        
        MarkPrefabPosition.x =  MarkPrefabPosition.x - 0.4f;        //add offset so its more on the ramp
        MarkPrefabPosition.y =  MarkPrefabPosition.y - 1.19f;

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

        
