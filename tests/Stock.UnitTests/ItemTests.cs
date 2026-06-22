using Stock.Domain.Enums;
using Stock.Domain.Models;

namespace Stock.UnitTests.Domain;

public class ItemTests
{
    [Fact]
    public void Create_ShouldCreateItem_WhenDataIsValid()
    {
        var item = Item.Create("Notebook", 10, ItemType.Electronic);

        Assert.Equal("Notebook", item.Name);
        Assert.Equal(10, item.Quantity);
        Assert.Equal(ItemType.Electronic, item.Type);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenNameIsEmpty()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            Item.Create("", 10, ItemType.Electronic));

        Assert.Equal("name", exception.ParamName);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenQuantityIsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Item.Create("Notebook", -1, ItemType.Electronic));
    }
}