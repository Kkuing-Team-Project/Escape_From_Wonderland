using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Effact effact;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Rabbit"))
        {
            Player.instance.KillCountNull++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        Vector3 P = this.gameObject.transform.position;
        transform.position += Vector3.right * Time.deltaTime * 12;
        transform.Rotate(0, 0, 90);
        if (pos.x < P.x)
        {
            Destroy(gameObject);
        }
    }

}
