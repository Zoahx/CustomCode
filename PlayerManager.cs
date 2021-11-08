using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Animator myAnim;
    private bool isAttacking;
    public GameObject curTarget;
    public GameObject adsObject;
    public int adsBusted = 0;
    public int powerLevel = 0;
    public GameObject adsBustedText;
    public GameObject powerLevelText;
    public GameObject attackBox;



    // Start is called before the first frame update
    void Start()
    {
        myAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        adsBustedText.GetComponent<Text>().text = adsBusted.ToString();
        powerLevelText.GetComponent<Text>().text = powerLevel.ToString();

        Movement();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("is touching");
            curTarget = collision.gameObject;

            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("is hitting");
                curTarget.GetComponent<ObjectShake>().Shake();
                //curTarget.GetComponent<Enemy>().hitPoints -= 1;
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(AttackSequence());
       
    }

    IEnumerator AttackSequence()
    {
        myAnim.SetBool("isAttacking", true);
        myAnim.SetTrigger("Attack");
        Debug.Log("is hitting");
        yield return new WaitForSeconds(0.5f);
        curTarget.GetComponent<ObjectShake>().Shake();
        curTarget.GetComponent<Enemy>().curHitPoints -= 1;
        myAnim.SetBool("isAttacking", false);
        //yield return new WaitForSeconds(5);
    }
        
    public void Movement()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {

            myAnim.SetBool("isMoving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(Vector3.right * Time.deltaTime * 24f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myAnim.SetBool("isMoving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(Vector3.left * Time.deltaTime * 24f);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            myAnim.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.X) && isAttacking == false)
        {
            isAttacking = true;
            myAnim.SetBool("isAttacking", true);
            myAnim.SetTrigger("Attack");
            attackBox.SetActive(true);


        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
            attackBox.SetActive(false);

        }
    }
}
