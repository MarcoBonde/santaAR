using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject ColumnPrefab;

    public float minY, maxY;

    float timer;
    public float maxTime;
    
    void Start()
    {
        //spawno colonna
        SpawnColumn();
    }

    void Update()
    {
        //spawno colonne ogni x secondi
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            SpawnColumn();
            timer = 0;
        }
    }

    void SpawnColumn()
    {
        float randYPos = Random.Range(minY, maxY);

        GameObject newColumn = Instantiate(ColumnPrefab);
        newColumn.transform.position = new Vector2(transform.position.x, randYPos);
    }
}
