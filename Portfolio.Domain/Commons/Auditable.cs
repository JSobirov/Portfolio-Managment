﻿namespace Portfolio.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsDeleted { get; set; } 
}
