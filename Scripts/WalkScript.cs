using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{

    [SerializeField] Transform[] Points;
    
    [SerializeField]
    private float moveSpeed = 2f;

    private int PointIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[PointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     if(PointIndex <= Points.Length-1)
        
        {

            transform.position = Vector2.MoveTowards(transform.position, Points[PointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == Points[PointIndex].transform.position)
            {

                PointIndex+=1;

            }
        
        
     
     }


        
    }
}

    

