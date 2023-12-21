using System;
using System.Security.Cryptography;

internal sealed class Class69 : SymmetricAlgorithm, IDisposable, ICryptoTransform
{
	private Random random_0;

	public bool CanReuseTransform => true;

	public bool CanTransformMultipleBlocks => true;

	public int InputBlockSize => 16;

	public int OutputBlockSize => 16;

	public Class69()
	{
		random_0 = new Random(DateTime.Now.Millisecond);
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(128, 128, 0)
		};
		KeySize = 128;
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(128, 128, 0)
		};
		BlockSize = 128;
	}

	public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
	{
		rgbKey.CopyTo(Key, 0);
		rgbIV.CopyTo(IV, 0);
		return this;
	}

	public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
	{
		rgbKey.CopyTo(Key, 0);
		rgbIV.CopyTo(IV, 0);
		return this;
	}

	public override void GenerateIV()
	{
		byte[] array = new byte[16];
		random_0.NextBytes(array);
		IV = array;
	}

	public override void GenerateKey()
	{
		byte[] array = new byte[16];
		random_0.NextBytes(array);
		Key = array;
	}

	public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
	{
		int num = Key.Length;
		int num2 = IV.Length;
		for (int i = 0; i < inputCount; i++)
		{
			int num3 = IV[i % num2];
			outputBuffer[i + outputOffset] = (byte)(inputBuffer[i + inputOffset] ^ Key[num3 % num]);
		}
		return inputCount;
	}

	public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		byte[] array = new byte[inputCount];
		((ICryptoTransform)this).TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
		return array;
	}
}
