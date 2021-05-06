using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player2;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Transform enemy;
    RaycastHit hit;
    public Enemy currentTarget;
    public AudioSource s;
    [SerializeField] AudioClip m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickTarget();
        //currentTarget = GameObject.Find("Enemy").transform;
    }

    public void PlaySong(AudioClip clip)
    {
        s.PlayOneShot(clip);
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, 512);

            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, 512))
            {
                if (hit.collider != null)
                {
                    if (currentTarget != null)
                    {
                        currentTarget.Deselect();
                    }

                    currentTarget = hit.collider.GetComponent<Enemy>();

                    player.MyTarget = currentTarget.Select();

                    //player.MyTarget = hit.transform;
                }
                else
                {
                    if (currentTarget != null)
                    {
                        currentTarget.Deselect();
                    }
                    currentTarget = null;
                    player.MyTarget = null;
                }
            }

            
        }

        if (Input.GetMouseButtonDown(1))
        {
            PlaySong(m);
        }

        if (Input.GetKeyDown("e"))
        {
            currentTarget.healthGroup.alpha = 1;
        }

        if (Input.GetKeyDown("r"))
        {
            currentTarget.healthGroup.alpha = 0;
        }
    }

}
