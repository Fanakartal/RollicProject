using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCounterScript : MonoBehaviour
{
    public int collectibleCount;

    public Text collectibleCountText;
    // Start is called before the first frame update
    void Start()
    {
        collectibleCount = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        collectibleCountText.text = collectibleCount.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            collectibleCount++;
        }
    }
}
