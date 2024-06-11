using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emarket.Models;

public class OrderItemModel {

    [Key]
    public String OrderId {get; set;}
    [ForeignKey("Purchased")]
    public String PurchasedItem {get; set;}
    public ItemViewModel Purchased {get; set;}
    public int PurchasedAmount {get; set;}
}