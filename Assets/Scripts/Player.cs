using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    public Material Mt;

    public string currentColor;

    public string GetColor;

    public GameManager GM;

    Animator anim;

    private void Start()
    {
        SetRandomColor();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Alter")
        {
            SetRandomColor();
            if (GetColor == currentColor)
            {
                SetRandomColor();
            }
            Destroy(col.gameObject);
            return;
        }

        if (col.tag != currentColor && col.tag != "End")
        {
            Debug.Log("p");
            anim.SetBool("IsHit", true);
            GM.OpenHItUI();
        }

    }

    public void Score(int score)
    {
        FindObjectOfType<GameManager>().AddScore(score);
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                currentColor = "Red";
                Mt.color = Color.red;
                GetColor = currentColor;
                break;
            case 1:
                currentColor = "Yellow";
                Mt.color = Color.yellow;
                GetColor = currentColor;
                break;
            case 2:
                currentColor = "Green";
                Mt.color = Color.green;
                GetColor = currentColor;
                break;

        }
    }
}
