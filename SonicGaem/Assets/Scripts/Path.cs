using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject PlatformShort;
    public GameObject[] Points;
    public int numberOfPoints;
    public float speed;

    private Vector3 actualPosition;
    private int x;


    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = PlatformShort.transform.position;
        PlatformShort.transform.position = Vector3.MoveTowards(actualPosition, Points[x].transform.position, speed * Time.deltaTime);
    
        if(actualPosition == Points[x].transform.position && x != numberOfPoints - 1)
        {
            x++;
        }
    
    }

}
