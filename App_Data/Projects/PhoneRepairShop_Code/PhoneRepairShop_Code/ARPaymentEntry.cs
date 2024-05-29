using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using PX.Common;
using PX.Data;
using PX.Objects.AR.Standalone;
using PX.Objects.Common;
using PX.Objects.AR.MigrationMode;
using PX.Objects.AR.CCPaymentProcessing;
using PX.Objects.CA;
using PX.Objects.CM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.GL;
using SOAdjust = PX.Objects.SO.SOAdjust;
using SOOrder = PX.Objects.SO.SOOrder;
using SOOrderEntry = PX.Objects.SO.SOOrderEntry;
using SOOrderType = PX.Objects.SO.SOOrderType;
using PX.Objects.AR.CCPaymentProcessing.Common;
using PX.Objects.AR.CCPaymentProcessing.Helpers;
using PX.Objects.AR.CCPaymentProcessing.Interfaces;
using PX.Objects.Common.Bql;
using PX.Objects.EP;
using PX.Objects.Common.Extensions;
using PX.Objects.Common.GraphExtensions.Abstract;
using PX.Objects.Common.GraphExtensions.Abstract.DAC;
using PX.Objects.Common.GraphExtensions.Abstract.Mapping;
using PX.Objects.GL.FinPeriods.TableDefinition;
using PX.Objects.GL.FinPeriods;
using PX.Objects.GL.Attributes;
using PX.Objects.Extensions.PaymentTransaction;
using PX.Objects.IN;
using PX.Objects.PM;
using PX.Objects.CM.Standalone;
using PX.Objects.Common.Utility;
using PX.Objects;
using PX.Objects.AR;
using PX.Data.BQL.Fluent;
using PhoneRepairShop;
using PX.Objects.CN.Compliance.AR.CacheExtensions;

namespace PX.Objects.AR {
	public class ARPaymentEntry_Extension : PXGraphExtension<ARPaymentEntry> {
		#region Event Handlers
		public virtual void _(Events.FieldDefaulting<ARRegister, ARRegisterExt.usrPrepaymentPercent> e) {
			ARRegister payment = (ARRegister)e.Row;
			RSSVSetup setupRecord = SelectFrom<RSSVSetup>.View.Select(Base);
			e.NewValue = setupRecord.PrepaymentPercent;
		}
		#endregion
	}
}