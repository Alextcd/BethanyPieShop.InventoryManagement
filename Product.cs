using System;

public class Product
{
    private int id;
    private string name = string.Empty;
    private string? description;

    private int maxItemsInStock = 0;

    private UnitType unitType;
    private int amountInStock;
    private bool isBelowStockThresold = false;

    public void UseProduct(int items)
    {
        if(items <= amountInStock)
        {
            //use items
            amountInStock -= items;
            Log($"Amount in stock updated. Now {amountInStock} items in stock.");
        }
        else
        {
            Log($"Not enough items on stock {CreateSimpleProductRepresentation()}. {amountInStock} avaible but {items} required.");

        }

    }

    public void IncreaseStock()
    {
        amountInStock++;
    }



}
