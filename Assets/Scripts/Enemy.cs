using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup healthGroup;
    [SerializeField] private PlayerMovement player;


    public virtual void Deselect()
    {

    }

    public virtual Transform Select()
    {
        healthGroup.alpha = 1;
        Debug.Log("test");

        return player.hitbox;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
