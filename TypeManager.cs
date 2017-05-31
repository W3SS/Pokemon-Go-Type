using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace Pokemon_Go_Type
{
	public enum Type : byte
	{
		Normal,
		Fighting,
		Flying,
		Poison,
		Ground,
		Rock,
		Bug,
		Ghost,
		Steel,
		Fire,
		Water,
		Grass,
		Electric,
		Psychic,
		Ice,
		Dragon,
		Dark,
		Fairy,

		Count
	}

	public class TypeManager
	{
		public int typeCount;
		public float[,] values;

		public TypeManager()
		{
			typeCount = (int) Type.Count;

			values = new[,]
			{
				// data based on https://pokeassistant.com/typechart
				{1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 0.8f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
				{1.25f, 1.0f, 0.8f, 0.8f, 1.0f, 1.25f, 0.8f, 0.8f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.25f, 1.0f, 1.25f, 0.8f},
				{1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 0.8f, 1.25f, 1.0f, 0.8f, 1.0f, 1.0f, 1.25f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
				{1.0f, 1.0f, 1.0f, 0.8f, 0.8f, 0.8f, 1.0f, 0.8f, 0.8f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f},
				{1.0f, 1.0f, 0.8f, 1.25f, 1.0f, 1.25f, 0.8f, 1.0f, 1.25f, 1.25f, 1.0f, 0.8f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
				{1.0f, 0.8f, 1.25f, 1.0f, 0.8f, 1.0f, 1.25f, 1.0f, 0.8f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f},
				{1.0f, 0.8f, 0.8f, 0.8f, 1.0f, 1.0f, 1.0f, 0.8f, 0.8f, 0.8f, 1.0f, 1.25f, 1.0f, 1.25f, 1.0f, 1.0f, 1.25f, 0.8f},
				{0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 0.8f, 1.0f},
				{1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 0.8f, 0.8f, 0.8f, 1.0f, 0.8f, 1.0f, 1.25f, 1.0f, 1.0f, 1.25f},
				{1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.25f, 1.0f, 1.25f, 0.8f, 0.8f, 1.25f, 1.0f, 1.0f, 1.25f, 0.8f, 1.0f, 1.0f},
				{1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.25f, 1.0f, 1.0f, 1.0f, 1.25f, 0.8f, 0.8f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f},
				{1.0f, 1.0f, 0.8f, 0.8f, 1.25f, 1.25f, 0.8f, 1.0f, 0.8f, 0.8f, 1.25f, 0.8f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f},
				{1.0f, 1.0f, 1.25f, 1.0f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 0.8f, 0.8f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f},
				{1.0f, 1.25f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f, 0.8f, 1.0f},
				{1.0f, 1.0f, 1.25f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 0.8f, 0.8f, 0.8f, 1.25f, 1.0f, 1.0f, 0.8f, 1.25f, 1.0f, 1.0f},
				{1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 0.8f},
				{1.0f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.0f, 1.0f, 0.8f, 0.8f},
				{1.0f, 1.25f, 1.0f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 0.8f, 0.8f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.25f, 1.25f, 1.0f},
			};
		}

		public float GetEffectiveValue(Type attack, Type defense)
		{
			return values[(int)attack, (int)defense];
		}

		private Type[] GetTypes(int target, Func<int, int, bool> checkFunc)
		{
			List<Type> types = new List<Type>();

			for (int i = 0; i < typeCount; ++i)
			{
				if (checkFunc(target, i))
				{
					types.Add((Type) i);
				}
			}

			return types.ToArray();
		}

		public Type[] GetStrongs(Type type)
		{
			return GetTypes((int) type, (t, i) => values[t, i] > 1.0f);
		}

		public Type[] GetWeaks(Type type)
		{
			return GetTypes((int)type, (t, i) => values[t, i] < 1.0f);
		}

		public Type[] GetResistants(Type type)
		{
			return GetTypes((int)type, (t, i) => values[i, t] < 1.0f);
		}

		public Type[] GetVulnerables(Type type)
		{
			return GetTypes((int)type, (t, i) => values[i, t] > 1.0f);
		}
	}
}
