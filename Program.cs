using System;
using System.Linq;

namespace Pokemon_Go_Type
{
	class Program
	{
		static void Main(string[] args)
		{
			TypeManager manager = new TypeManager();

			// print chart
			for (int i = 0; i < (int) Type.Count; ++i)
			{
				Console.WriteLine(
					string.Join(", ", manager.GetVulnerables((Type) i).Select(x => x.ToString()))
					+ "   >   " + (Type) i + "   >   " +
					string.Join(", ", manager.GetStrongs((Type) i).Select(x => x.ToString()))
				);
			}
		}
	}
}
