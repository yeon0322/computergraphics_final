using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballcontroller : MonoBehaviour
{
    private scoremanager scoremanager;
    private Animator animator; //애니메이터 컴포넌트 
    private Rigidbody2D rb;

    private bool isExploding = false;

    public int scoreValue = 1;
    public bool isGoodZone;

    public GameObject scorePrefab;  //득점시 점수 프리팹
    public int scoreOnCollision = 10; //충돌 시 추가할 점수 

    public Canvas mainCanvas; //Canvas를 Inspector에서 할당 
    public float displayDuration = 1.0f; //점수 프리팹이 나타나는 시간 

    
    
    void Start()
    {
        // scoreManager 오브젝트를 찾아서 참조를 가져옵니다.
        scoremanager = FindObjectOfType<scoremanager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }


   private void OnCollisionEnter2D(Collision2D collision) 
   {

       if (collision.gameObject.CompareTag("PositiveGround"))
        {
            scoremanager.AddScore(10);
            HandleCollision();
            Destroy(gameObject);
            HandleScore(scoreOnCollision, collision.GetContact(0).point); //득점 처리 함수 호출

        }
        else if (collision.gameObject.CompareTag("NagativeGround")&& !isExploding)
        {
            isExploding = true;
            animator.SetTrigger("Explode"); // 폭발 애니메이션 트리거 설정 
            HandleCollision();
            HandleScore(-scoreOnCollision, collision.GetContact(0).point); //감점 처리 함수 호출 
            
            
        }
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.CompareTag("PositiveGround"))
    {
        
        //SpawnScorePrefab(); //점수 프리팹 생성
    }
   }

   private void SpawnScorePrefab() // 점수 프리팹을 Inspector에서 할당 
   {
        //스폰 위치 설정 
        Vector3 spawnPosition = transform.position; 
        // 점수 프리팹 생성
        GameObject scoreDisplay = Instantiate(scorePrefab, spawnPosition, Quaternion.identity);

        //Canvas의 자식으로 설정 
        scoreDisplay.transform.SetParent(mainCanvas.transform,false);
        
        //프리팹 활성화 상태 확인 및 설정 
        if(!scoreDisplay.activeSelf)
        {
            scoreDisplay.SetActive(true);
        }

        // 일정 시간 후에 점수 표시 삭제 예정 
        Destroy(scoreDisplay,1.0f); 
   }

    // 애니메이션이 끝날 때 호출될 함수 
    public void OnExplosionComplete()
    {
        
        Destroy(gameObject); 
        scoremanager.AddScore(-5);
        
    }
    
    private void HandleCollision() 
    {
        if(isGoodZone)
        {
            scoremanager.AddScore(scoreValue);
            
        }
        else
        {
            scoremanager.AddScore(-scoreValue);
            PlyayExplodeAnimatuon();
        }
    }

    private void PlyayExplodeAnimatuon()
    {
        animator.SetTrigger("Explode");
    }

    //점수 처리 함수 
    private void HandleScore(int score, Vector2 contactPoint)
    {
        scoremanager.AddScore(score); //점수 추가 또는 감소 

        //점수 표시 생성 
        GameObject scoreDisplay = Instantiate(scorePrefab, transform.position, Quaternion.identity);
        Text scoreText = scoreDisplay.GetComponentInChildren<Text>();
        if(scoreText != null)
        {
            scoreText.text = (score > 0 ? "+" : "") + score.ToString(); //점수 텍스트 설정 
        }

        Destroy(scoreDisplay,1.0f); //1초 후에 점수 표시 

        Destroy(gameObject);

    }

   

    
}

   


