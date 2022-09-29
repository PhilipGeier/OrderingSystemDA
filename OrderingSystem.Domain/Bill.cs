using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingSystem.Domain.Enums;

namespace OrderingSystem.Domain;

public class Bill
{
    public int BillNumber { get; init; }
    public Company Company { get; init; }
    public DateTime PrintDate { get; init; }
    public string TableId { get; set; }
    public IDictionary<Guid, int> SortedItems { get; init; }
    public PaymentMethods PaymentMethod { get; init; }
    public Guid RegisterId { get; init; }
    public float Sum { get; init; }
    public float SumExclTax { get; init; }
}

