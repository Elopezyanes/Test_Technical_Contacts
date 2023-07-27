using System;
using System.Collections.Generic;

namespace ContactList.Model;

public partial class Contact
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public DateTime? DateBirth { get; set; }

    public string? Adresses { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Image { get; set; }
}
