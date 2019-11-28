using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    private GameObject go;
    public GameObject sphere;
    public GameObject cube;
    public GameObject capsule;
    private GameObject[] goArray;

    public float minTime = 2.0f;
    public float maxTime = 5.0f;
    private float time;
    private float spawnTime;
    // private  float _xAxis;
    // private  float _yAxis;
    // private  float _zAxis; //If you need this, use it
    
    // Start is called before the first frame update
    void Start()
    {
        // _xAxis = UnityEngine.Random.Range(-8.5f, 8.0f);
        //_yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        // _zAxis = UnityEngine.Random.Range(0.2f, 16.7f);
        SetSpawnTime();
        goArray = new GameObject[]{sphere, cube, capsule};
        

        // for(int i =0; i <= 360; i++)
        // {
        //     Vector3 spawnPosition = Random.onUnitSphere * (10f);
        //     go = goArray[Random.Range(0, goArray.Length)];
        //     Instantiate(go, spawnPosition, Quaternion.identity);
        // }   

    }

    // Update is called once per frame
    void Update()
    {
        //_randomPosition = new Vector3(_xAxis, 15.0f, _zAxis );
        // Vector3 spawnPosition = new Vector3(0f, 15.0f, 8.2f) + (Random.onUnitSphere * 8f);
        // go = goArray[Random.Range(0, goArray.Length)];
        // Instantiate(go, spawnPosition, Quaternion.identity);

        
    }

    void FixedUpdate ()
     {
        //Counts up
        time += Time.deltaTime;
        if(time>spawnTime){
            SpawnObject();
            time = 0;
            SetSpawnTime();
        }
     }

    void SpawnObject(){
        Vector3 spawnPosition = new Vector3(0f, 30.0f, 8.2f) + (Random.onUnitSphere * 8f);
        go = goArray[Random.Range(0, goArray.Length)];
        //Instantiate(go, spawnPosition, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
        Instantiate(go, spawnPosition, Quaternion.identity);
    }

    void SetSpawnTime(){
        spawnTime = Random.Range(minTime, maxTime);
    }
}
