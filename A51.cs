using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
	class A51
	{
		public int reg_x_length = 19, reg_y_length = 22, reg_z_length = 23;
		public int[] reg_x = new int[19];
		public int[] reg_y = new int[22];
		public int[] reg_z = new int[23];
		public string key_one = "";

		public void loadingReg(string key)
		{
			int i = 0;
			while (i < reg_x_length)
			{
				reg_x[i] = int.Parse(key[i].ToString());
				i = i + 1;
			}

			int j = 0;
			int p = reg_x_length;
			while (j < reg_y_length)
			{
				reg_y[j] = int.Parse(key[p].ToString());
				p = p + 1;
				j = j + 1;
			}

			int k = reg_y_length + reg_x_length;
			int r = 0;
			while (r < reg_z_length)
			{
				reg_z[r] = int.Parse(key[k].ToString());
				k = k + 1;
				r = r + 1;
			}
		}

		public bool setKey(string key)
		{
			if (key.Length == 64)
			{
				key_one = key;
				loadingReg(key);
				return true;
			}
			return false;
		}

		public string getKey() { return key_one; }

		public int getMajority(int x, int y, int z)
		{
			if ((x + y + z) > 1)
				return 1;
			else
				return 0;
		}

		//XOR-uje odgovarajuce indekse kljuceva
		public int[] getKeystream(int length)
		{
			int[] x = new int[reg_x_length];
			int[] y = new int[reg_y_length];
			int[] z = new int[reg_z_length];
			reg_x.CopyTo(x, 0);
			reg_y.CopyTo(y, 0);
			reg_z.CopyTo(z, 0);

			
			int[] keystream = new int[length];

			for (int i = 0; i < length; i++)
			{
				int maj = getMajority(x[8], y[10], z[10]);

				int[] x2 = new int[reg_x_length];
				if (x[8] == maj)
				{
					int n = x[13] ^ x[16] ^ x[17] ^ x[18];
					 x.CopyTo(x2,0);

					for (int j = 1; j < x.Length; j++)
						x[j] = x2[j - 1];
					x[0] = n;
				}

				int[] y2 = new int[reg_y_length];
				if (y[10] == maj)
				{
					int n = y[20] ^ y[21];
					y.CopyTo(y2,0);

					for (int j = 1; j < y.Length; j++)
						y[j] = y2[j - 1];
					y[0] = n;
				}

				int[] z2 = new int[reg_z_length];
				if (z[10] == maj)
				{
					int n = z[7] ^ z[20] ^ z[21] ^ z[22];
					z.CopyTo(z2,0);

					for (int j = 1; j < z.Length; j++)
						z[j] = z2[j - 1];
					z[0] = n;
				}

				keystream[i] = x[18] ^ y[21] ^ z[22];
			}
			return keystream;
		}

		public BitArray byteToBinary(byte[] data)
		{
			return new BitArray(data);

		}

		public byte[] binaryToByte(BitArray bits)
		{

			//byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
			//bits.CopyTo(ret, 0);
			//return ret;

			int num_bytes = bits.Length / 8;

			if (bits.Length % 8 != 0)
			{
				num_bytes += 1;
			}

			var bytes = new byte[num_bytes];
			bits.CopyTo(bytes, 0);
			return bytes;
		}

		public byte[] encrypt(byte[] plain)
		{
			BitArray binary = byteToBinary(plain);
			int[] keystream = getKeystream(binary.Length);
			BitArray result =new BitArray(binary.Length);

			for (int i = 0; i < binary.Length; i++)
			{
				result[i]= ((binary[i] ? 1 : 0) ^ keystream[i])==1?true:false ;
			}
			return binaryToByte(result);
		}

		public byte[] decrypt(byte[] plain)
		{
			BitArray plain1 = byteToBinary(plain);
			int[] keystream = getKeystream(plain1.Length);
			BitArray result = new BitArray(plain1.Length);
			
			

			for (int i = 0; i < plain1.Length; i++)
			{

				result[i] = ((plain1[i] ? 1 : 0) ^ keystream[i]) == 1 ? true : false;
			}
			return binaryToByte(result);
		}
	}
}
