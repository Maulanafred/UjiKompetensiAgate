using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DogHandler : MonoBehaviour
{
    public Image foodAmount;

    public GameObject vfxdead;

    public float maxfood = 1f;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        foodAmount.fillAmount = maxfood;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.transform.position + Vector3.back * speed * Time.deltaTime;

        if(maxfood >= 1f){
            ScoreManager.instance.AddScore(25);
            
            var positionvfx = new Vector3(0f,1f,0f);
            GameObject vfx = Instantiate(vfxdead,transform.position,Quaternion.identity);

            AudioManager.instance.PlaySFX(0);


            Destroy(vfx,2f);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Skill")){
            Destroy(other.gameObject);
            maxfood += 0.25f;

            

            foodAmount.fillAmount = maxfood;

        
            Debug.Log("Kena hit");

        }
    }
}
