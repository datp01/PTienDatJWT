﻿using System;
using System.Collections.Generic;

namespace Models.Entites;

public partial class Product
{
   public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? ExpDate { get; set; } 
    public int Status { get; set; }
    public int Price { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set;}
}
