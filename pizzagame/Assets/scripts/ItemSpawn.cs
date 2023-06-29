using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSpawn : MonoBehaviour
{
    public GameObject RightSide; // правый конец спавна объектов
    public GameObject[] items; // массив объектов

    public Sprite[] Bad_Item_Pic; // массив спрайтов для плохих предметов
    public Sprite[] Ingred_Pic; // массив спрайтов для ингредиентов
    public SpriteRenderer spriteRenderer1; // рендерер спрайтов для ингредиентов
    public SpriteRenderer spriteRenderer2; // рендерер спрайтов для плохих предметов
    private int rand; // случайное значение
    public int goodItemFallChance; // шанс выпадения ингредиента
    public int goodItemsCount = 25; // количество выпадения ингредиентов
    public int badItemsCount = 10; // количество выпадения плохих предметов
    public float startDelay, repeatRate; // задержка спавна на старте и частота спавна
    public static bool gameOver = false; // конец игры
    public GameObject gameOverScreen; // панель конца игры
    public Text scoreGameOver;

    void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    void Spawn()
    {
        if (goodItemsCount > 0)
        {
            Vector3 pos = new Vector3(Random.Range(gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, 0);

            rand = Random.Range(1, 100);

            GameObject item = (1 <= rand && rand <= goodItemFallChance) ? items[0] : items[1];

            if (badItemsCount <= 0)
            {
                item = items[0];
            }
            if (goodItemsCount <= 0)
            {
                item = items[1];
            }

            if (item.gameObject.tag == "Bad")
            {
                badItemsCount--;
                rand = Random.Range(0, Bad_Item_Pic.Length);
                spriteRenderer2.sprite = Bad_Item_Pic[rand];
            }
            else
            {
                goodItemsCount--;
                rand = Random.Range(0, Ingred_Pic.Length);
                spriteRenderer1.sprite = Ingred_Pic[rand];
            }
            Instantiate(item, pos, gameObject.transform.rotation);
        }
        else
        {
            Invoke("GameOver", 3);
        }
    }

    void Update()
    {
        if (itemChecker.health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOver = true;
        gameOverScreen.SetActive(true);
        scoreGameOver.text = itemChecker.score.ToString();

    }
}