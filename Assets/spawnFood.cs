using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour {


    public GameObject foodPrefab;
    public GameObject bonusFood;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderRight;
    public Transform borderLeft;

    private void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
        InvokeRepeating("spawnBonus", 10, 10);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
    void spawnBonus()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        Instantiate(bonusFood, new Vector2(x, y), Quaternion.identity);
    }


}
