using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    public GameObject ps;

    private Vector3 direction;

    private int score = 0;

    public Text scoreText;

    public GameObject resetBtn;

    private bool isDead;
    // Start is called before the first frame update

    void Start()
    {
        isDead = false;
        direction = Vector3.zero;
    }





    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            score ++;
            scoreText.text = score.ToString();
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(direction * amountToMove);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            score += 3;
            scoreText.text = score.ToString();
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, -Vector3.up);

            if (!Physics.Raycast(downRay, out hit))
            {
                isDead = true;
                resetBtn.SetActive(true);
                if (transform.childCount > 0)
                {
                    transform.GetChild(0).transform.parent = null;
                }

            }
        }
    }
}
