using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace lapshop.Models;

public partial class TbItem
{
    [ValidateNever]
    public int ItemId { get; set; }

    [Required(ErrorMessage ="please enter the name")]
    
    public string ItemName { get; set; } = null!;
    [Required(ErrorMessage = "please enter the sales price")]
    [DataType(DataType.Currency,ErrorMessage ="please enter a currnecy")]
    [Range(5,100000,ErrorMessage ="the price must be between 50 to 100000")]

    public decimal SalesPrice { get; set; }
    [Required(ErrorMessage = "please enter the sales purchis price")]
    [DataType(DataType.Currency, ErrorMessage = "please enter a currnecy")]
    [Range(5, 100000, ErrorMessage = "the price must be between 50 to 100000")]
    public decimal PurchasePrice { get; set; }

    [Required(ErrorMessage = "please enter the category")]
    public int CategoryId { get; set; }

    public string? ImageName { get; set; }

    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Description { get; set; }
    [Required(ErrorMessage ="please enter ")]
    public string? Gpu { get; set; }

    public string? HardDisk { get; set; }

    public int? ItemTypeId { get; set; }

    public string? Processor { get; set; }

    [Range(1,500,ErrorMessage ="please enter ram in range")]
    public int? RamSize { get; set; }

    public string? ScreenReslution { get; set; }

    public string? ScreenSize { get; set; }

    public string? Weight { get; set; }
    [Required(ErrorMessage = "please enter the os")]
    public int? OsId { get; set; }

    [ValidateNever]
    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbItemType? ItemType { get; set; }
  

    public virtual TbO? Os { get; set; }

    public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; } = new List<TbItemDiscount>();

    public virtual ICollection<TbItemImage> TbItemImages { get; set; } = new List<TbItemImage>();

    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; } = new List<TbPurchaseInvoiceItem>();

    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; } = new List<TbSalesInvoiceItem>();

    public virtual ICollection<TbCustomer> Customers { get; set; } = new List<TbCustomer>();
}
