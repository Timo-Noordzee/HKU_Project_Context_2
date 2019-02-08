using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour {

    public GameObject hpHeart;
    private List<GameObject> hpList = new List<GameObject>();
    private PlayerState playerState;
    private int nowHp;

    // Use this for initialization
    void Start () {
        GameObject obj = GameObject.FindGameObjectsWithTag("Player")[0];
        playerState = obj.GetComponent<PlayerState>();
        nowHp = playerState.hpState;
        for (int i = 0; i < playerState.hpState; i++)
        {
            GameObject temp = Instantiate(hpHeart, transform);
            temp.transform.position = new Vector2(transform.position.x + 160 * i, transform.position.y + 0);
            hpList.Add(temp);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (nowHp < playerState.hpState)
            hpList.Add(GameObject.Instantiate(hpHeart, transform));
        if (nowHp > playerState.hpState)
        {
            for(int i = playerState.hpState; i > nowHp; i--)
            {
                Destroy(hpList[i]);
            }
        }
        nowHp = playerState.hpState;
    }
}
