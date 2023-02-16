using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject parallax;
    [SerializeField] private GameObject blur;
    [SerializeField] private GameObject[] products;
    [SerializeField] private Sprite product;
    [SerializeField] private Text productLabel;
    private UIManager uıManager;
    [SerializeField] private string productName;
    [SerializeField] private int price;
    [SerializeField] private bool isPurchased;

    private void Start()
    {
        if (!isPurchased)
        {
            productLabel.text = productName + " - " + price.ToString() + "$";
        }
        uıManager = GameObject.FindObjectOfType<UIManager>();
    }

    public void PurchaseSpaceShip()
    {
        if (!isPurchased)
        {
            if (player.GetComponent<Character>().Gold >= price)
            {
                player.GetComponent<Character>().Gold -= price;
                uıManager.GoldUpdate(player.GetComponent<Character>().Gold.ToString());
                isPurchased = true;
            }
        }
        if (isPurchased)
        {
            player.GetComponent<SpriteRenderer>().sprite = product;
            blur.SetActive(false);
            ChangeProductLabel(true);
            SpaceShipsUpdate();
        }
    }

    private void SpaceShipsUpdate()
    {
        foreach (GameObject item in products)
        {
            Product product = item.GetComponent<Product>();
            if (product.isPurchased)
            {
                string name = product.productName;
                product.blur.SetActive(true);
                product.productLabel.text = name;
            }
        }
    }

    public void PurchaseGalaxy()
    {
        if (!isPurchased)
        {
            if (player.GetComponent<Character>().Gold >= price)
            {
                player.GetComponent<Character>().Gold -= price;
                uıManager.GoldUpdate(player.GetComponent<Character>().Gold.ToString());
                isPurchased = true;
            }
        }
        if (isPurchased)
        {
            parallax.GetComponentsInChildren<SpriteRenderer>()[1].sprite = product;
            parallax.GetComponentsInChildren<SpriteRenderer>()[2].sprite = product;
            blur.SetActive(false);
            ChangeProductLabel(true);
            GalaxiesUpdate();
        }

    }

    private void GalaxiesUpdate()
    {
        foreach (GameObject item in products)
        {
            Product product = item.GetComponent<Product>();
            if (product.isPurchased)
            {
                string name = product.productName;
                product.blur.SetActive(true);
                product.productLabel.text = name;
            }
        }
    }

    private void ChangeProductLabel(bool isActive)
    {
        if (isActive)
        {
            productLabel.text = "Active";
        }
        else
        {
            productLabel.text = productName;
        }
    }

}