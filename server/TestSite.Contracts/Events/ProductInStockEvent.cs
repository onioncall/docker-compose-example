using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSite.Contracts.Events;

public record ProductInStockEvent
{
	public int ProductId { get; set; }
}