using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController:MonoBehaviour{
    
    public float speed;
    // Start is called before the first frame update
    private int count;
    public Text countText;
    public Text winText;
    private Rigidbody rb;

    public AudioSource hitEffect;
    public AudioSource winEffect;
    public AudioSource backgroundMusic;
    void Start(){
        Debug.Log(gameObject.name);
        Debug.Log(speed);
        rb = GetComponent<Rigidbody>();
        count = 0;
        speed = 1;
        winText.text = "";
       setCountText();
       backgroundMusic.Play();
    }

    // Update is called once per frame
     void FixedUpdate() {
           float moveHorizontal = Input.GetAxis("Horizontal");
           float moveVertical = Input.GetAxis("Vertical");
           Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
           rb.AddForce(movement*speed);
    }
     void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUps")){
            setInvisible(other);
        }
        // when hit speed up cube,speed plue four
        if(other.gameObject.CompareTag("SpeedUp")){
            speed= speed+4;
            setInvisible(other);
        }
         if(other.gameObject.CompareTag("Slowdown")){
           
            if(speed< 5){
                setInvisible(other);
            }else{
                speed = speed -4;
                setInvisible(other);
            }
        }
    }
    void setCountText(){
        countText.text = "Count：" + count.ToString()+"\n"+"Speed："+speed.ToString();
        // win text
        if(count>=11){
            winText.text = "You Win!";
            backgroundMusic.Stop();
        }
    }
    // set Cube Invisible and add Score
    void setInvisible(Collider other){
        other.gameObject.SetActive(false);
        count = count + 1;
        setCountText();
        addSize();
        changerandomColor();
    }
    void addSize(){
        transform.localScale = new Vector3(transform.localScale.x+0.1f,transform.localScale.y+0.1f,transform.localScale.z+0.1f);
    }
    void minusSize(){
        transform.localScale = new Vector3(transform.localScale.x-0.1f,transform.localScale.y-0.1f,transform.localScale.z-0.1f);
    }
    void changeColor(){
        GetComponent<Renderer>().material.color = Color.red;
    }
    void changerandomColor(){
        GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
    }

    void playhitEffext(){
        hitEffect.Play();
    }
    void playwinEffect(){
        winEffect.Play();
    }
    void playbackgroundMusic(){
        backgroundMusic.Play();
    }
}
