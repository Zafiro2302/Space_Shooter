using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    private float temporizador = 0.5f;
    private float vidas = 100;
    public GameObject finJuego;
    public GameObject menuPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        Disparar();
        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(Time.timeScale == 0f)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }

        }
    }
    void Movimiento()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
    }
    void DelimitarMovimiento()
    {
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }
    void Disparar()
    {
        temporizador += 1 * Time.deltaTime; 
        if(Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo)
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
        {
            vidas -= 20;
            Destroy(elOtro.gameObject);
            if(vidas<=0)
            {
                KillPlayer();
                Destroy(this.gameObject);
            }
        }
    }
    
    private void KillPlayer()
    {
        finJuego.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menuPause.SetActive(false);

    }
}
