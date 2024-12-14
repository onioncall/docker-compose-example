﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSite.Contracts.Requests;

public record ProductUpdateQuantityRequest
{
	public int ProductId { get; set; }

	public int Quantity { get; set; }
}