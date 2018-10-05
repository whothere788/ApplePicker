using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Apple Tree")]

    public GameObject applePrefab;
    public float speed = 1f;
    public float leftRightEdge = 10f;
    public float chanceToChangeDir = .1f;
    public float secondsBetweenAppleDrops = 1f;
    
    

	void Start () {
        //dropping apples every second
        Invoke("DropApple", 2f);
		
	}
    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
	
	// Update is called once per frame
	void Update () {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        //change dir
        if(pos.x < -leftRightEdge) {
            speed = Mathf.Abs(speed);
        }else if (pos.x > leftRightEdge){
            speed = -Mathf.Abs(speed);
        }

    }
    void FixedUpdate(){
        if (Random.value < chanceToChangeDir)
        {
            speed *= -1;
        }
    }
        
    }

