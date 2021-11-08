using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHitPoints = 5;
    public int curHitPoints;
    public GameObject adsObject;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        curHitPoints = MaxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if( curHitPoints <= 0)
        {
            adsObject.GetComponent<IrenstialAd>().LoadAd();
            adsObject.GetComponent<IrenstialAd>().ShowAd();
            adsObject.GetComponent<BannerAds>().HideBannerAd();

            player.GetComponent<PlayerManager>().adsBusted += 1;
            player.GetComponent<PlayerManager>().powerLevel += 1;
            MaxHitPoints += 2;
            curHitPoints = MaxHitPoints;
            gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            //Destroy(gameObject);
            //Debug.Log("object destroyed");

        }
    }


}
