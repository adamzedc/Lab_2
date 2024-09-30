using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine. InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 6;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;
    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2> () ;
    }
    void FixedUpdate () {
        Vector3 movement = new Vector3 (moveValue.x, 0.0f, moveValue.y) ;
        GetComponent <Rigidbody>().AddForce (movement * speed * Time.fixedDeltaTime);
    }

    void Start(){
        count = 0;
        WinText . text = " " ;
        SetCountText () ;

    }
    void OnTriggerEnter ( Collider other ) {
        if( other . gameObject . tag ==  "PickUp"  ) {
            other . gameObject . SetActive ( false ) ;
            count += 1;
            SetCountText();
        }
    }
    private void SetCountText () {
        ScoreText.text = " Score : " + count . ToString () ;
        if( count >= numPickups ) {
            WinText.text = " You win ! " ;
        }
    }
}