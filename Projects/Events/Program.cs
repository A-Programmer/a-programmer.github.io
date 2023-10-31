namespace EventsProject;

public static class Program
{
  public static void Main(string[] args)
  {
    Product monitor = new("LG", 500);

    monitor.PriceChanged += Product_PriceChanged;
    monitor.NameChanged += Product_NameChanged;

    monitor.ChangePrice(450);
    monitor.ChangeName("Samsung");

    void Product_PriceChanged(object sender, PriceChangedEventArgs e)
    {
      Console.WriteLine($"{((Product)sender).Name} price has been changed to {e.NewPrice}");
    }

    void Product_NameChanged(object sender, ProductNameChangedEventArgs e)
    {
      Console.WriteLine($"Product name has been changed to {((Product)sender).Name}");
    }
  }
}

public class Product
{
  public Product(string name, decimal price)
  {
    Price = price;
    Name = name;
  }

  public event EventHandler<PriceChangedEventArgs> PriceChanged;
  public event EventHandler<ProductNameChangedEventArgs> NameChanged;

  protected void OnPriceChanged(PriceChangedEventArgs e)
  {
    PriceChanged?.Invoke(this, e);
  }

  protected void OnNameChanged(ProductNameChangedEventArgs e)
  {
    NameChanged?.Invoke(this, e);
  }

  public string Name { get; private set; }
  public decimal Price { get; private set; }

  public void ChangeName(string newName)
  {
    string oldName = Name;
    Name = newName;
    OnNameChanged(new ProductNameChangedEventArgs(oldName, Name));
  }

  public void ChangePrice(decimal newPrice)
  {
    decimal oldPrice = Price;
    Price = newPrice;
    OnPriceChanged(new PriceChangedEventArgs(oldPrice, Price));
  }


}

public class PriceChangedEventArgs : EventArgs
{
  public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
  {
    OldPrice = oldPrice;
    NewPrice = newPrice;
  }

  public decimal OldPrice { get; private set; }
  public decimal NewPrice { get; private set; }
}
public class ProductNameChangedEventArgs : EventArgs
{
  public ProductNameChangedEventArgs(string oldName, string newName)
  {
    OldName = oldName;
    NewName = newName;
  }

  public string OldName { get; private set; }
  public string NewName { get; private set; }
}


