using System;
using System.Drawing;



public class Solver
{
	private byte[,] inpImgAsByteArr;

	private int captchaW = 170;

	private int captchaH = 50;

	private int w2 = 85;

	private int h2 = 25;

	private string[] findedLetters;

	private int[] findedXs;

	private int[] vertDens2;

	private int countImages0;

	private bool[,,] boolTemplImage0;

	private int[] densSymbol0;

	private int[] w0;

	private int[] h0;

	private int[][] vertDens0;

	private string[] retStr0;

	private int[] orderSearch0;

	private int countImages1;

	private bool[,,] boolTemplImage1;

	private int[] densSymbol1;

	private int[] w1;

	private int[] h1;

	private int[][] vertDens1;

	private string[] retStr1;

	private int[] orderSearch1;

	private bool[,] biteArr;

	public Solver()
	{
		inpImgAsByteArr = new byte[captchaW, captchaH];
		findedLetters = new string[5];
		findedXs = new int[5];
		biteArr = new bool[w2, h2];
		countImages0 = 22;
		orderSearch0 = new int[22]
		{
			13, 16, 6, 9, 17, 14, 2, 4, 11, 5,
			15, 19, 7, 1, 20, 0, 8, 18, 3, 21,
			10, 12
		};
		densSymbol0 = new int[22]
		{
			111, 125, 148, 99, 143, 135, 176, 126, 106, 168,
			95, 140, 92, 219, 163, 135, 181, 164, 104, 129,
			124, 99
		};
		w0 = new int[22]
		{
			13, 16, 16, 14, 16, 21, 19, 13, 12, 18,
			10, 17, 13, 21, 18, 14, 22, 16, 19, 16,
			18, 19
		};
		h0 = new int[22]
		{
			24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
			29, 24, 24, 24, 24, 24, 29, 24, 24, 24,
			24, 24
		};
		retStr0 = new string[22]
		{
			"3", "4", "6", "7", "9", "A", "D", "E", "F", "H",
			"J", "K", "L", "M", "N", "P", "Q", "R", "T", "U",
			"X", "Y"
		};
		vertDens0 = new int[22][]
		{
			new int[13]
			{
				4, 3, 6, 6, 6, 6, 7, 9, 12, 16,
				18, 13, 5
			},
			new int[16]
			{
				3, 5, 5, 4, 5, 5, 5, 5, 5, 5,
				24, 24, 24, 2, 2, 2
			},
			new int[16]
			{
				9, 15, 18, 11, 9, 7, 7, 6, 6, 6,
				7, 7, 10, 13, 11, 6
			},
			new int[14]
			{
				3, 5, 8, 10, 10, 9, 8, 8, 7, 7,
				8, 7, 5, 4
			},
			new int[16]
			{
				5, 11, 13, 10, 6, 7, 6, 6, 6, 6,
				8, 8, 10, 17, 15, 9
			},
			new int[21]
			{
				1, 3, 5, 5, 4, 6, 7, 6, 7, 7,
				7, 9, 11, 10, 10, 9, 8, 8, 7, 4,
				1
			},
			new int[19]
			{
				24, 24, 24, 4, 4, 4, 4, 4, 4, 4,
				4, 5, 4, 6, 7, 11, 17, 13, 9
			},
			new int[13]
			{
				24, 24, 24, 6, 6, 6, 6, 6, 6, 6,
				6, 4, 2
			},
			new int[12]
			{
				24, 24, 24, 4, 4, 4, 4, 4, 4, 4,
				4, 2
			},
			new int[18]
			{
				24, 24, 24, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 24, 24, 24
			},
			new int[10] { 2, 2, 2, 2, 2, 2, 3, 28, 27, 25 },
			new int[17]
			{
				24, 24, 24, 1, 4, 6, 6, 6, 7, 7,
				6, 6, 6, 6, 4, 2, 1
			},
			new int[13]
			{
				24, 24, 24, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2
			},
			new int[21]
			{
				24, 24, 6, 8, 8, 8, 8, 8, 8, 6,
				4, 5, 5, 5, 5, 5, 5, 5, 24, 24,
				24
			},
			new int[18]
			{
				24, 24, 5, 4, 5, 5, 5, 5, 5, 5,
				5, 5, 4, 5, 4, 5, 24, 24
			},
			new int[14]
			{
				24, 24, 24, 4, 4, 4, 4, 4, 4, 6,
				7, 11, 9, 6
			},
			new int[22]
			{
				8, 14, 16, 10, 6, 6, 4, 6, 4, 4,
				4, 4, 4, 7, 6, 9, 9, 12, 19, 16,
				11, 2
			},
			new int[16]
			{
				24, 24, 24, 4, 4, 4, 4, 7, 9, 12,
				16, 14, 11, 4, 2, 1
			},
			new int[19]
			{
				2, 2, 2, 2, 2, 2, 2, 2, 24, 24,
				24, 2, 2, 2, 2, 2, 2, 2, 2
			},
			new int[16]
			{
				19, 21, 22, 4, 3, 3, 2, 2, 2, 2,
				2, 2, 2, 3, 21, 19
			},
			new int[18]
			{
				2, 6, 7, 8, 9, 8, 9, 8, 5, 5,
				9, 9, 8, 8, 8, 7, 6, 2
			},
			new int[19]
			{
				1, 2, 4, 6, 5, 6, 5, 5, 16, 14,
				14, 3, 3, 3, 3, 3, 3, 2, 1
			}
		};
		long[][] array = new long[22][]
		{
			new long[13]
			{
				6291462L, 6291458L, 12589059L, 12589059L, 12589059L, 12589059L, 12590083L, 12598279L, 14694159L, 7370750L,
				8381436L, 4178168L, 1015808L
			},
			new long[16]
			{
				114688L, 126976L, 112640L, 101376L, 100096L, 99200L, 98528L, 98416L, 98332L, 98318L,
				16777215L, 16777215L, 16777215L, 98304L, 98304L, 98304L
			},
			new long[16]
			{
				130816L, 1048544L, 2097144L, 3684476L, 7343134L, 14683142L, 12584455L, 12584451L, 12584451L, 12584451L,
				12586499L, 6295043L, 7879683L, 4192262L, 2093062L, 516096L
			},
			new long[14]
			{
				7L, 12582919L, 16252935L, 16646151L, 4161543L, 516103L, 63495L, 15879L, 3847L, 967L,
				503L, 127L, 31L, 15L
			},
			new long[16]
			{
				992L, 6295544L, 6299644L, 12598302L, 12595206L, 12611587L, 12607491L, 12607491L, 12607491L, 6316035L,
				7352327L, 3682318L, 1973276L, 1048568L, 524272L, 65408L
			},
			new long[21]
			{
				8388608L, 14680064L, 8126464L, 2031616L, 245760L, 129024L, 114176L, 100224L, 98800L, 98428L,
				98335L, 98431L, 99326L, 102384L, 130944L, 261632L, 1044480L, 8355840L, 16646144L, 15728640L,
				8388608L
			},
			new long[19]
			{
				16777215L, 16777215L, 16777215L, 12582915L, 12582915L, 12582915L, 12582915L, 12582915L, 12582915L, 12582915L,
				12582915L, 6291463L, 6291462L, 7340046L, 3932188L, 2031868L, 1048568L, 262112L, 65408L
			},
			new long[13]
			{
				16777215L, 16777215L, 16777215L, 12589059L, 12589059L, 12589059L, 12589059L, 12589059L, 12589059L, 12589059L,
				12589059L, 12582915L, 12582912L
			},
			new long[12]
			{
				16777215L, 16777215L, 16777215L, 6147L, 6147L, 6147L, 6147L, 6147L, 6147L, 6147L,
				6147L, 3L
			},
			new long[18]
			{
				16777215L, 16777215L, 16777215L, 6144L, 6144L, 6144L, 6144L, 6144L, 6144L, 6144L,
				6144L, 6144L, 6144L, 6144L, 6144L, 16777215L, 16777215L, 16777215L
			},
			new long[10] { 201326592L, 402653184L, 402653184L, 402653184L, 402653184L, 402653184L, 234881024L, 268435455L, 134217727L, 33554431L },
			new long[17]
			{
				16777215L, 16777215L, 16777215L, 2048L, 15360L, 32256L, 62208L, 123264L, 245984L, 491632L,
				983064L, 3932172L, 7864326L, 15728643L, 14680065L, 12582912L, 8388608L
			},
			new long[13]
			{
				16777215L, 16777215L, 16777215L, 12582912L, 12582912L, 12582912L, 12582912L, 12582912L, 12582912L, 12582912L,
				12582912L, 12582912L, 12582912L
			},
			new long[21]
			{
				16777215L, 16777215L, 63L, 255L, 2040L, 8160L, 65280L, 522240L, 2088960L, 4128768L,
				3932160L, 2031616L, 253952L, 63488L, 7936L, 1984L, 248L, 62L, 16777215L, 16777215L,
				16777215L
			},
			new long[18]
			{
				16777215L, 16777215L, 31L, 60L, 248L, 496L, 1984L, 3968L, 15872L, 31744L,
				126976L, 253952L, 491520L, 2031616L, 3932160L, 16252928L, 16777215L, 16777215L
			},
			new long[14]
			{
				16777215L, 16777215L, 16777215L, 12291L, 12291L, 12291L, 12291L, 12291L, 6147L, 7175L,
				7694L, 4094L, 2044L, 504L
			},
			new long[22]
			{
				65280L, 524256L, 1048560L, 2031864L, 3670044L, 7340046L, 6291462L, 14680071L, 12582915L, 12582915L,
				12582915L, 12582915L, 12582915L, 31457287L, 31457286L, 66060302L, 121110556L, 102695160L, 235929584L, 201850848L,
				469827328L, 201326592L
			},
			new long[16]
			{
				16777215L, 16777215L, 16777215L, 12291L, 12291L, 12291L, 12291L, 63491L, 129031L, 511503L,
				2035710L, 4065276L, 16253432L, 15728640L, 12582912L, 8388608L
			},
			new long[19]
			{
				3L, 3L, 3L, 3L, 3L, 3L, 3L, 3L, 16777215L, 16777215L,
				16777215L, 3L, 3L, 3L, 3L, 3L, 3L, 3L, 3L
			},
			new long[16]
			{
				524287L, 2097151L, 4194303L, 7864320L, 7340032L, 14680064L, 12582912L, 12582912L, 12582912L, 12582912L,
				12582912L, 6291456L, 6291456L, 3670016L, 2097151L, 524287L
			},
			new long[18]
			{
				8388609L, 14680071L, 7340047L, 1835070L, 917756L, 229872L, 116704L, 32640L, 15872L, 31744L,
				130816L, 516992L, 1016256L, 4063344L, 8126520L, 15728654L, 14680071L, 8388609L
			},
			new long[19]
			{
				1L, 3L, 15L, 63L, 124L, 504L, 992L, 3968L, 16776960L, 16776192L,
				16776192L, 1792L, 896L, 224L, 112L, 28L, 14L, 3L, 1L
			}
		};
		boolTemplImage0 = new bool[countImages0, 25, 30];
		for (int i = 0; i < countImages0; i++)
		{
			int num = w0[i];
			int num2 = h0[i];
			for (int j = 0; j < num; j++)
			{
				long num3 = array[i][j];
				for (int k = 0; k < num2; k++)
				{
					boolTemplImage0[i, j, k] = ((1L << (k & 0x1F)) & num3) != 0;
				}
			}
		}
		countImages1 = 37;
		orderSearch1 = new int[37]
		{
			36, 27, 28, 31, 35, 19, 14, 26, 30, 3,
			5, 10, 32, 8, 0, 34, 22, 4, 13, 18,
			21, 9, 15, 6, 24, 23, 2, 16, 11, 33,
			1, 17, 12, 29, 7, 20, 25
		};
		densSymbol1 = new int[37]
		{
			45, 26, 29, 58, 43, 50, 36, 20, 47, 39,
			50, 28, 22, 42, 68, 39, 29, 26, 41, 69,
			20, 41, 44, 30, 32, 19, 67, 77, 74, 22,
			63, 73, 48, 28, 45, 71, 115
		};
		w1 = new int[37]
		{
			10, 5, 5, 10, 8, 8, 6, 6, 10, 9,
			7, 7, 4, 8, 12, 8, 6, 5, 8, 10,
			8, 9, 9, 8, 9, 8, 10, 9, 10, 5,
			11, 11, 7, 4, 8, 13, 16
		};
		h1 = new int[37]
		{
			12, 12, 12, 13, 12, 13, 13, 13, 13, 10,
			12, 11, 15, 12, 14, 13, 11, 12, 12, 11,
			13, 12, 13, 13, 13, 12, 12, 13, 13, 12,
			13, 16, 13, 15, 13, 15, 15
		};
		retStr1 = new string[37]
		{
			"A", "L", "E", "X", "6", "9", "3", "T", "D", "N",
			"R", "7", "J", "P", "Q", "U", "4", "F", "9", "M",
			"T", "K", "Y", "H", "H", "T", "K", "9", "6", "F",
			"D", "Q", "3", "J", "4", "JJ", "MJ"
		};
		vertDens1 = new int[37][]
		{
			new int[10] { 2, 3, 4, 6, 6, 5, 5, 5, 6, 3 },
			new int[5] { 11, 12, 1, 1, 1 },
			new int[5] { 10, 11, 3, 3, 2 },
			new int[10] { 2, 6, 8, 8, 6, 7, 8, 6, 5, 2 },
			new int[8] { 7, 10, 7, 3, 3, 3, 6, 4 },
			new int[8] { 4, 7, 6, 4, 5, 10, 10, 4 },
			new int[6] { 3, 5, 9, 10, 7, 2 },
			new int[6] { 1, 2, 2, 12, 2, 1 },
			new int[10] { 10, 2, 1, 3, 4, 3, 4, 5, 9, 6 },
			new int[9] { 10, 2, 3, 3, 3, 2, 4, 3, 9 },
			new int[7] { 9, 11, 3, 4, 6, 9, 8 },
			new int[7] { 3, 6, 6, 6, 4, 2, 1 },
			new int[4] { 2, 2, 14, 4 },
			new int[8] { 8, 11, 3, 3, 4, 6, 5, 2 },
			new int[12]
			{
				6, 9, 8, 4, 4, 2, 2, 5, 8, 11,
				8, 1
			},
			new int[8] { 8, 11, 2, 2, 2, 2, 2, 10 },
			new int[6] { 2, 4, 5, 5, 9, 4 },
			new int[5] { 9, 12, 2, 2, 1 },
			new int[8] { 4, 6, 3, 3, 3, 5, 10, 7 },
			new int[10] { 8, 5, 7, 6, 6, 5, 6, 6, 9, 11 },
			new int[8] { 1, 1, 1, 2, 12, 1, 1, 1 },
			new int[9] { 11, 3, 3, 5, 6, 6, 3, 3, 1 },
			new int[9] { 3, 5, 6, 9, 9, 3, 3, 3, 3 },
			new int[8] { 11, 1, 1, 1, 1, 1, 3, 11 },
			new int[9] { 12, 1, 1, 1, 1, 1, 1, 8, 6 },
			new int[8] { 1, 1, 1, 8, 5, 1, 1, 1 },
			new int[10] { 12, 12, 5, 6, 8, 9, 6, 5, 3, 1 },
			new int[9] { 5, 9, 10, 7, 6, 10, 12, 10, 8 },
			new int[10] { 3, 7, 9, 11, 8, 6, 8, 10, 8, 4 },
			new int[5] { 10, 5, 3, 3, 1 },
			new int[11]
			{
				9, 12, 3, 2, 2, 4, 3, 6, 10, 8,
				4
			},
			new int[11]
			{
				8, 10, 6, 5, 3, 2, 4, 7, 14, 12,
				2
			},
			new int[7] { 3, 4, 6, 8, 12, 11, 4 },
			new int[4] { 3, 3, 14, 8 },
			new int[8] { 2, 3, 5, 5, 7, 10, 12, 1 },
			new int[13]
			{
				2, 2, 2, 15, 15, 3, 0, 1, 1, 2,
				13, 13, 2
			},
			new int[16]
			{
				9, 9, 7, 8, 7, 7, 7, 8, 9, 11,
				13, 1, 1, 1, 13, 4
			}
		};
		long[][] array2 = new long[37][]
		{
			new long[10] { 3072L, 3584L, 960L, 504L, 190L, 143L, 188L, 496L, 4032L, 3584L },
			new long[5] { 2047L, 4095L, 2048L, 2048L, 2048L },
			new long[5] { 2046L, 2047L, 2081L, 2081L, 2049L },
			new long[10] { 3L, 3591L, 1950L, 1020L, 504L, 1016L, 1980L, 3852L, 7174L, 4098L },
			new long[8] { 1016L, 2046L, 3175L, 2081L, 2081L, 2081L, 4032L, 1920L },
			new long[8] { 120L, 4348L, 4302L, 4230L, 6278L, 8142L, 4092L, 480L },
			new long[6] { 4162L, 4294L, 6638L, 7676L, 3992L, 1536L },
			new long[6] { 1L, 3L, 6L, 8190L, 6L, 4L },
			new long[10] { 2046L, 2050L, 2048L, 2051L, 6147L, 6146L, 6150L, 7180L, 4088L, 2016L },
			new long[9] { 1023L, 6L, 14L, 28L, 56L, 96L, 480L, 448L, 1022L },
			new long[7] { 1022L, 4094L, 194L, 195L, 486L, 1022L, 1916L },
			new long[7] { 1537L, 1985L, 483L, 126L, 30L, 6L, 2L },
			new long[4] { 24576L, 24576L, 16383L, 15360L },
			new long[8] { 1020L, 4094L, 194L, 194L, 198L, 126L, 124L, 24L },
			new long[12]
			{
				1008L, 2044L, 3870L, 3078L, 3075L, 2049L, 2049L, 7171L, 7950L, 14332L,
				9208L, 8192L
			},
			new long[8] { 1020L, 4094L, 3072L, 6144L, 6144L, 6144L, 3072L, 2046L },
			new long[6] { 96L, 120L, 94L, 79L, 511L, 1920L },
			new long[5] { 1022L, 4095L, 33L, 33L, 1L },
			new long[8] { 30L, 63L, 2113L, 2113L, 2113L, 3649L, 2046L, 508L },
			new long[10] { 1020L, 124L, 254L, 504L, 2016L, 1984L, 1008L, 504L, 1022L, 2047L },
			new long[8] { 4L, 4L, 4L, 12L, 8190L, 2L, 2L, 1L },
			new long[9] { 4094L, 224L, 224L, 496L, 504L, 910L, 1538L, 3073L, 2048L },
			new long[9] { 14L, 62L, 252L, 8176L, 8176L, 112L, 56L, 28L, 14L },
			new long[8] { 8188L, 128L, 64L, 64L, 64L, 64L, 112L, 2047L },
			new long[9] { 4095L, 64L, 64L, 64L, 64L, 64L, 64L, 510L, 8064L },
			new long[8] { 1L, 1L, 1L, 255L, 3841L, 1L, 1L, 1L },
			new long[10] { 4095L, 4095L, 496L, 504L, 1020L, 1022L, 1799L, 3587L, 3073L, 2048L },
			new long[9] { 124L, 6398L, 6399L, 6343L, 6339L, 8163L, 4095L, 2046L, 1020L },
			new long[10] { 224L, 1016L, 2044L, 4094L, 7271L, 6243L, 7395L, 8163L, 4035L, 1920L },
			new long[5] { 4092L, 103L, 67L, 67L, 2L },
			new long[11]
			{
				4088L, 8190L, 6146L, 4098L, 4098L, 6147L, 6146L, 7686L, 4092L, 2040L,
				480L
			},
			new long[11]
			{
				2040L, 4092L, 3102L, 6158L, 4102L, 4098L, 14340L, 31756L, 65532L, 61432L,
				49152L
			},
			new long[7] { 6146L, 6210L, 6339L, 6375L, 8190L, 8188L, 3840L },
			new long[4] { 28672L, 14336L, 16383L, 7695L },
			new long[8] { 384L, 448L, 496L, 376L, 892L, 2046L, 8190L, 256L },
			new long[13]
			{
				24576L, 24576L, 24576L, 32767L, 32767L, 14336L, 0L, 8192L, 8192L, 12288L,
				16382L, 16382L, 6144L
			},
			new long[16]
			{
				2044L, 6652L, 508L, 1020L, 2032L, 4064L, 4064L, 2040L, 2044L, 4094L,
				16382L, 8192L, 16384L, 16384L, 32764L, 15360L
			}
		};
		boolTemplImage1 = new bool[countImages1, 20, 20];
		for (int l = 0; l < countImages1; l++)
		{
			int num4 = w1[l];
			int num5 = h1[l];
			for (int m = 0; m < num4; m++)
			{
				long num6 = array2[l][m];
				for (int n = 0; n < num5; n++)
				{
					boolTemplImage1[l, m, n] = ((1L << (n & 0x1F)) & num6) != 0;
				}
			}
		}
	}

	public string solve(Bitmap im)
	{
		int width = im.Width;
		int height = im.Height;
		if (width != captchaW || height != captchaH)
		{
			return "";
		}
		Color pixel = im.GetPixel(0, 0);
		int a = pixel.A;
		int r = pixel.R;
		int g = pixel.G;
		int b = pixel.B;
		if (a == 0 && r == 0 && g == 0 && b == 0)
		{
			for (int i = 0; i < captchaW; i++)
			{
				for (int j = 0; j < captchaH; j++)
				{
					a = im.GetPixel(i, j).A;
					inpImgAsByteArr[i, j] = (byte)(255 - a);
				}
			}
			return solve0White();
		}
		if (a == 255 && r == 0 && g == 0 && b == 0)
		{
			return solve1Black(im);
		}
		return "";
	}

	public string solve0White()
	{
		string text = "";
		int[] array = new int[captchaW];
		bool[,] array2 = new bool[captchaW, captchaH];
		for (int i = 0; i < captchaW; i++)
		{
			array[i] = 0;
			for (int j = 0; j < captchaH; j++)
			{
				if (inpImgAsByteArr[i, j] < 155)
				{
					array2[i, j] = true;
					array[i]++;
				}
				else
				{
					array2[i, j] = false;
				}
			}
		}
		int k = 0;
		int num = 15;
		for (int l = 0; l < 5; l++)
		{
			bool flag = false;
			for (int m = 0; m < countImages0; m++)
			{
				if (flag)
				{
					break;
				}
				int num2 = orderSearch0[m];
				int num3 = w0[num2];
				int num4 = h0[num2];
				for (int n = k; n <= num; n++)
				{
					if (flag)
					{
						break;
					}
					if (n >= captchaW - num3 + 1)
					{
						break;
					}
					bool flag2 = true;
					for (int num5 = 0; num5 < num3 && flag2; num5++)
					{
						if (vertDens0[num2][num5] > array[num5 + n])
						{
							flag2 = false;
						}
					}
					if (!flag2)
					{
						continue;
					}
					int num6 = 13;
					bool flag3 = true;
					for (int num5 = 0; num5 < num3 && flag3; num5++)
					{
						for (int num7 = 0; num7 < num4 && flag3; num7++)
						{
							if (boolTemplImage0[num2, num5, num7] && !array2[num5 + n, num7 + num6])
							{
								flag3 = false;
							}
						}
					}
					if (flag3)
					{
						flag = true;
						text += retStr0[num2];
						for (k = n + w0[num2] + 2; k < captchaW && array[k] <= 0; k++)
						{
						}
						num = k + 1;
					}
				}
			}
			if (!flag)
			{
				return "";
			}
		}
		return text;
	}

	private string solve1Black(Bitmap im)
	{
		string text = "";
		for (int i = 0; i < 5; i++)
		{
			findedLetters[i] = "";
			findedXs[i] = -1;
		}
		prepare(im);
		vertDens2 = getVertDens();
		int num = 0;
		int num2 = 55;
		int num3 = 0;
		int num4 = w2;
		for (int j = 0; j < 5; j++)
		{
			bool flag = false;
			for (int k = 0; k < countImages1; k++)
			{
				if (flag)
				{
					break;
				}
				int num5 = orderSearch1[k];
				int num6 = w1[num5];
				int num7 = h1[num5];
				for (int l = num3; l <= num4; l++)
				{
					if (flag)
					{
						break;
					}
					if (l > w2 - num6)
					{
						break;
					}
					bool flag2 = true;
					for (int m = 0; m < num6 && flag2; m++)
					{
						if (vertDens1[num5][m] > vertDens2[m + l])
						{
							flag2 = false;
						}
					}
					if (!flag2)
					{
						continue;
					}
					for (int n = num; n <= num2 && n <= h2 - num7 && flag2; n++)
					{
						if (flag)
						{
							break;
						}
						bool flag3 = true;
						for (int m = 0; m < num6 && flag3; m++)
						{
							for (int num8 = 0; num8 < num7 && flag3; num8++)
							{
								if (boolTemplImage1[num5, m, num8] && !biteArr[m + l, num8 + n])
								{
									flag3 = false;
								}
							}
						}
						if (!flag3)
						{
							continue;
						}
						text += retStr1[num5];
						findedLetters[j] = retStr1[num5];
						findedXs[j] = l + (int)Math.Round(0.5f * (float)w1[num5]);
						if (j == 5)
						{
							return orderedString();
						}
						for (int m = 0; m < num6; m++)
						{
							for (int num9 = 0; num9 < num7; num9++)
							{
								if (boolTemplImage1[num5, m, num9])
								{
									biteArr[m + l, num9 + n] = false;
								}
							}
						}
						for (int num10 = 0; num10 < h2; num10++)
						{
							for (int m = l; m < l + w1[num5] - 1; m++)
							{
								biteArr[m, num10] = false;
							}
						}
						vertDens2 = getVertDens();
						flag = true;
					}
				}
			}
		}
		return orderedString();
	}

	private string orderedString()
	{
		string text = "";
		int num = findedXs.Length;
		for (int i = 0; i < num - 1; i++)
		{
			for (int j = 0; j < num - 1; j++)
			{
				if (findedXs[j] > findedXs[j + 1])
				{
					int num2 = findedXs[j + 1];
					findedXs[j + 1] = findedXs[j];
					findedXs[j] = num2;
					string text2 = findedLetters[j + 1];
					findedLetters[j + 1] = findedLetters[j];
					findedLetters[j] = text2;
				}
			}
		}
		for (int k = 0; k < num; k++)
		{
			text += findedLetters[k];
		}
		if (text.Length < 5)
		{
			return "";
		}
		return text;
	}

	private int[] getVertDens()
	{
		int[] array = new int[w2];
		for (int i = 0; i < w2; i++)
		{
			array[i] = 0;
			for (int j = 0; j < h2; j++)
			{
				if (biteArr[i, j])
				{
					array[i]++;
				}
			}
		}
		return array;
	}

	private void prepare(Bitmap img)
	{
		for (int i = 0; i < captchaW; i++)
		{
			for (int j = 0; j < captchaH; j++)
			{
				int r = img.GetPixel(i, j).R;
				if (r < 1 || r == 230)
				{
					inpImgAsByteArr[i, j] = byte.MaxValue;
				}
				else
				{
					inpImgAsByteArr[i, j] = 0;
				}
			}
		}
		for (int k = 1; k < captchaW - 2; k++)
		{
			for (int l = 1; l < captchaH - 1; l++)
			{
				if (inpImgAsByteArr[k, l] == byte.MaxValue && inpImgAsByteArr[k - 1, l] == 0 && inpImgAsByteArr[k + 2, l] == 0)
				{
					inpImgAsByteArr[k, l] = 0;
					inpImgAsByteArr[k + 1, l] = 0;
				}
			}
		}
		for (int m = 1; m < captchaH - 2; m++)
		{
			for (int n = 1; n < captchaW - 1; n++)
			{
				if (inpImgAsByteArr[n, m] == byte.MaxValue && inpImgAsByteArr[n, m - 1] == 0 && inpImgAsByteArr[n, m + 2] == 0)
				{
					inpImgAsByteArr[n, m] = 0;
					inpImgAsByteArr[n, m + 1] = 0;
				}
			}
		}
		for (int num = 1; num < captchaW - 1; num++)
		{
			for (int num2 = 1; num2 < captchaH - 1; num2++)
			{
				int num3 = 0;
				bool flag = false;
				if (inpImgAsByteArr[num, num2] != byte.MaxValue)
				{
					continue;
				}
				for (int num4 = -1; num4 < 2; num4++)
				{
					if (flag)
					{
						break;
					}
					for (int num5 = -1; num5 < 2; num5++)
					{
						if (flag)
						{
							break;
						}
						if (inpImgAsByteArr[num + num4, num2 + num5] > 100)
						{
							num3++;
							if (num3 > 8)
							{
								inpImgAsByteArr[num, num2] = 200;
								flag = true;
							}
						}
					}
				}
			}
		}
		for (int num6 = 1; num6 < captchaW - 1; num6++)
		{
			for (int num7 = 1; num7 < captchaH - 1; num7++)
			{
				if (inpImgAsByteArr[num6, num7] != byte.MaxValue)
				{
					continue;
				}
				int num8 = 0;
				bool flag2 = false;
				for (int num9 = -1; num9 < 2; num9++)
				{
					if (flag2)
					{
						break;
					}
					for (int num10 = -1; num10 < 2; num10++)
					{
						if (flag2)
						{
							break;
						}
						if (inpImgAsByteArr[num6 + num9, num7 + num10] == 0)
						{
							num8++;
							if (num8 > 3)
							{
								inpImgAsByteArr[num6, num7] = 100;
								flag2 = true;
							}
						}
					}
				}
			}
		}
		for (int num11 = 0; num11 < captchaW; num11++)
		{
			inpImgAsByteArr[num11, 0] = 200;
			inpImgAsByteArr[num11, captchaH - 1] = 200;
		}
		for (int num12 = 0; num12 < captchaH; num12++)
		{
			inpImgAsByteArr[0, num12] = 200;
			inpImgAsByteArr[captchaW - 1, num12] = 200;
		}
		for (int num13 = 1; num13 < captchaW - 1; num13++)
		{
			for (int num14 = 1; num14 < captchaH - 1; num14++)
			{
				if (inpImgAsByteArr[num13, num14] == byte.MaxValue && (inpImgAsByteArr[num13 - 1, num14] == 200 || inpImgAsByteArr[num13 + 1, num14] == 200 || inpImgAsByteArr[num13, num14 - 1] == 200 || inpImgAsByteArr[num13, num14 + 1] == 200))
				{
					inpImgAsByteArr[num13, num14] = 200;
				}
			}
		}
		for (int num15 = 1; num15 < captchaW - 1; num15++)
		{
			for (int num16 = captchaH - 2; num16 > 0; num16--)
			{
				if (inpImgAsByteArr[num15, num16] == byte.MaxValue && (inpImgAsByteArr[num15 - 1, num16] == 200 || inpImgAsByteArr[num15 + 1, num16] == 200 || inpImgAsByteArr[num15, num16 - 1] == 200 || inpImgAsByteArr[num15, num16 + 1] == 200))
				{
					inpImgAsByteArr[num15, num16] = 200;
				}
			}
		}
		for (int num17 = captchaW - 2; num17 > 0; num17--)
		{
			for (int num18 = 1; num18 < captchaH - 1; num18++)
			{
				if (inpImgAsByteArr[num17, num18] == byte.MaxValue && (inpImgAsByteArr[num17 - 1, num18] == 200 || inpImgAsByteArr[num17 + 1, num18] == 200 || inpImgAsByteArr[num17, num18 - 1] == 200 || inpImgAsByteArr[num17, num18 + 1] == 200))
				{
					inpImgAsByteArr[num17, num18] = 200;
				}
			}
		}
		for (int num19 = captchaW - 2; num19 > 0; num19--)
		{
			for (int num20 = captchaH - 2; num20 > 0; num20--)
			{
				if (inpImgAsByteArr[num19, num20] == byte.MaxValue && (inpImgAsByteArr[num19 - 1, num20] == 200 || inpImgAsByteArr[num19 + 1, num20] == 200 || inpImgAsByteArr[num19, num20 - 1] == 200 || inpImgAsByteArr[num19, num20 + 1] == 200))
				{
					inpImgAsByteArr[num19, num20] = 200;
				}
			}
		}
		for (int num21 = 0; num21 < captchaW; num21++)
		{
			for (int num22 = 0; num22 < captchaH; num22++)
			{
				if (inpImgAsByteArr[num21, num22] == 200)
				{
					inpImgAsByteArr[num21, num22] = byte.MaxValue;
				}
				else
				{
					inpImgAsByteArr[num21, num22] = 0;
				}
			}
		}
		for (int num23 = 0; num23 < w2; num23++)
		{
			for (int num24 = 0; num24 < h2; num24++)
			{
				if (inpImgAsByteArr[2 * num23, 2 * num24] < 101 || inpImgAsByteArr[2 * num23 + 1, 2 * num24] < 101 || inpImgAsByteArr[2 * num23 + 1, 2 * num24 + 1] < 101 || inpImgAsByteArr[2 * num23, 2 * num24 + 1] < 101)
				{
					biteArr[num23, num24] = true;
				}
				else
				{
					biteArr[num23, num24] = false;
				}
			}
		}
	}
}
