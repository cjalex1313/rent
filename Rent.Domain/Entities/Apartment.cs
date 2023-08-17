﻿namespace Rent.Domain.Entities;

public class Apartment : Property
{
    public int Floor { get; set; }
    public int BuildingMaxFloor { get; set; }
    public int ApartmentNumber { get; set; }
}