﻿namespace DemoApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }


    public virtual UserAddress? Address { get; set; }
}
