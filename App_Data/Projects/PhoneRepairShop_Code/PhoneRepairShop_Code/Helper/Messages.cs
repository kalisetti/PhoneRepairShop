﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Common;
using PX.Data;

namespace PhoneRepairShop
{
	[PXLocalizable()]
	public static class Messages
	{
		// Order Types
		public const string SalesOrder = "SO";
		public const string WorkOrder = "WO";

		public const string ReportRS601000Title = "Assigned Work Orders";

		// Exceeding Maximum Number Of Assigned Work Orders
		public const string ExceedingMaximumNumberOfAssignedWorkOrders =
			"Updating the number of assigned work order for the employee " +
			"will lead to exceeding of the maximum number of assigned work orders, which is 10.";

		// Work Order Assigned
		public const string WorkOrderAssigned =
			"The {0} work order has been successfully assigned.";

		// Repair Item Type required for Work Orders
		public const string NoRequiredItem =
			"The work order does not contain a required repair item of the {0} type.";

		// Labor Quantity validation messages
		public const string QuantityCannotBeNegative =
			"The value in the Quantity column cannot be negative.";

		public const string QuantityToSmall =
			"The value in the Quantity column has been converted to " +
			"the minimum possible value.";


		// Error messages
		public const string StockItemIncorrectRepairItemType = "This stock item has a repair item type that differs from {0}.";
		public const string StockItemNotPermitted = "Only non-stock items are permitted Labor charges";


		// Complexity of repair
		public const string High = "High";
		public const string Medium = "Medium";
		public const string Low = "Low";

		//Repair item types
		public const string Battery = "Battery";
		public const string Screen = "Screen";
		public const string ScreenCover = "Screen Cover";
		public const string BackCover = "Back Cover";
		public const string Motherboard = "Motherboard";

		// Work order status
		public const string OnHold = "On Hold";
		public const string PendingPayment = "Pending Payment";
		public const string ReadyForAssignment = "Ready For Assignment";
		public const string Assigned = "Assigned";
		public const string Completed = "Completed";
		public const string Paid = "Paid";

		// Work order priority
		//public const string PriorityLow = "Low";
		//public const string PriorityMedium = "Medium";
		//public const string PriorityHigh = "High";
	}
}
