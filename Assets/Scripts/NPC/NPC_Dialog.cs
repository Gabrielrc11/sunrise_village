using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    public float dialogRange;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialog();
    }

    void ShowDialog()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogRange, playerLayer);

        if(hit != null)
        {
            
        }
        else
        {

        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogRange);
    }
}
