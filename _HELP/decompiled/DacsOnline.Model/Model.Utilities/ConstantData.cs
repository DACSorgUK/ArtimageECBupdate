using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Utilities
{
	public class ConstantData
	{
		[DecimalConstant(0, 0, 0, 0, 12500)]
		public readonly static decimal MaxRoyalty;

		[DecimalConstant(0, 0, 0, 0, 1000)]
		public readonly static decimal MinElegibility;

		[DecimalConstant(0, 0, 0, 0, 4)]
		public readonly static decimal Percent4;

		[DecimalConstant(0, 0, 0, 0, 3)]
		public readonly static decimal Percent3;

		[DecimalConstant(0, 0, 0, 0, 1)]
		public readonly static decimal Percent1;

		[DecimalConstant(1, 0, 0, 0, 5)]
		public readonly static decimal Percent05;

		[DecimalConstant(2, 0, 0, 0, 25)]
		public readonly static decimal Percent025;

		public const int interval0 = 0;

		[DecimalConstant(2, 0, 0, 0, 5000000)]
		public readonly static decimal interval50000;

		[DecimalConstant(2, 0, 0, 0, 5000001)]
		public readonly static decimal interval50001;

		[DecimalConstant(2, 0, 0, 0, 20000000)]
		public readonly static decimal interval200000;

		[DecimalConstant(2, 0, 0, 0, 20000001)]
		public readonly static decimal interval200001;

		[DecimalConstant(2, 0, 0, 0, 35000000)]
		public readonly static decimal interval350000;

		[DecimalConstant(2, 0, 0, 0, 35000001)]
		public readonly static decimal interval350001;

		[DecimalConstant(2, 0, 0, 0, 50000000)]
		public readonly static decimal interval500000;

		[DecimalConstant(2, 0, 0, 0, 50000001)]
		public readonly static decimal interval500001;

		static ConstantData()
		{
			ConstantData.MaxRoyalty = new decimal(12500);
			ConstantData.MinElegibility = new decimal(1000);
			ConstantData.Percent4 = new decimal(4);
			ConstantData.Percent3 = new decimal(3);
			ConstantData.Percent1 = new decimal(1);
			ConstantData.Percent05 = new decimal(5, 0, 0, false, 1);
			ConstantData.Percent025 = new decimal(25, 0, 0, false, 2);
			ConstantData.interval50000 = new decimal(5000000, 0, 0, false, 2);
			ConstantData.interval50001 = new decimal(5000001, 0, 0, false, 2);
			ConstantData.interval200000 = new decimal(20000000, 0, 0, false, 2);
			ConstantData.interval200001 = new decimal(20000001, 0, 0, false, 2);
			ConstantData.interval350000 = new decimal(35000000, 0, 0, false, 2);
			ConstantData.interval350001 = new decimal(35000001, 0, 0, false, 2);
			ConstantData.interval500000 = new decimal(50000000, 0, 0, false, 2);
			ConstantData.interval500001 = new decimal(50000001, 0, 0, false, 2);
		}

		public ConstantData()
		{
		}
	}
}