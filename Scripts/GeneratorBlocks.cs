using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBlocks : MonoBehaviour
{
    public GameObject blockPrefbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBlock();
    }

    void CheckBlock() 
    {
        if (transform.childCount <= 0) 
        {
            for (int i = -2; i < 1; i++) {
                Instantiate(blockPrefbs, new Vector2(i*2+2f, 4f),transform.rotation, transform);
            }
            UI.level += 1;
        }
    }
}
