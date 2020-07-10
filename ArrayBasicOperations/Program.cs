using System;

namespace ArrayBasicOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your array length: ");
            int counter = EnterFreeNumber(false);

            Console.WriteLine("Enter your array:");
            int[] vec1 = EnterArray(counter);
            // int[] vec2 = EnterArray(counter);

            //PrintArrayOneLine(vec1);
            int[] vec2 = new int[1];
            while (true)
            {
                BeginMessage();

                Console.WriteLine("Your enter is:");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        break;
                    case "1":
                        vec1 = ReEnterArrayPart();
                        continue;
                    case "2":
                        RightShiftPart(vec1);
                        continue;
                    case "3":
                        LeftPart(vec1);
                        continue;
                    case "4":
                        ScalarMultPart(vec1);
                        continue;
                    case "5":
                        ScalarDivPart(vec1);
                        continue;
                    case "6":
                        if (AllItemsAreEqual(vec1) == true)
                            Console.WriteLine($"Yes! All items in your array are equal and their value is: {vec1[0]}");
                        else
                            Console.WriteLine("No! The items in your array are not equal. ");
                        continue;
                    case "7":
                        vec2 = EnterAnotherArrayPart();
                        Console.Write("The second array is: ");
                        PrintArrayOneLine(vec2);
                        continue;
                    case "8":
                        TwoArrayMultiplicationPart(vec1, vec2);
                        continue;
                    case "9":
                        TwoArrayDivisionPart(vec1, vec2);
                        continue;
                    case "a":
                        InvertArrayPart(vec1);
                        continue;
                    case "b":
                        // (====****) ---> (****====) switch between two half, 
                        // and the array's length must be even number.
                        SwitchedArrayPart(vec1);
                        continue;
                    case "c":
                        vec1 = ChangeArrayKeepLength(counter);
                        PrintArrayOneLine(vec1);
                        continue;
                    default:
                        continue;
                }
                break;
            }

        }
        private static void BeginMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("---- Press ----");
            Console.WriteLine("(0)............Exit");
            Console.WriteLine("(1)............Re-enter your array");
            Console.WriteLine("(2)............Right shift");
            Console.WriteLine("(3)............Left shift");
            Console.WriteLine("(4)............Scalar multiplication");
            Console.WriteLine("(5)............Scalar division");
            Console.WriteLine("(6)............Eqaul items in your array");
            Console.WriteLine("(7)............Enter another array");
            Console.WriteLine("(8)............(old array)*(new array)");
            Console.WriteLine("(9)............(old array)/(new array)");
            Console.WriteLine("(a)...........The array is inverted");
            Console.WriteLine("(b)...........Switch array function");
            Console.WriteLine("(c)...........Change basic array keeping its length");
        }
        // ---------------------------------------------------------------------------------------
        private static int[] ChangeArrayKeepLength(int counter)
        {
            Console.WriteLine("Enter your array:");
            int[] res = EnterArray(counter);
            return res;
        }
        // ---------------------------------------------------------------------------------------
        private static void SwitchedArrayPart(int[] array)
        {
            // (====****) ---> (****====) switch between two half, 
            // and the array's length must be even number.

            Console.Write("The array is...........: ");
            PrintArrayOneLine(array);

            var res = SwitchArray(array);
            Console.Write("Switched array is......: ");
            PrintArrayOneLine(res);
        }
            private static int[] SwitchArray(int[] arry)
        {
            var nums = CopyArray(arry);
            try
            {
                if (arry.Length % 2 != 0)
                    throw new IndexOutOfRangeException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("please terminate the program and enter array with even length.");
                return EqualItemsArray(arry.Length + 1, 2);
            }
            for (int i = 0; i < nums.Length/2; i++)
            {
                SwitchSwap(nums, i);
            }
            return nums;
        }
        private static void SwitchSwap(int[] array, int indx)
        {
            int temp = array[indx];
            array[indx] = array[(array.Length / 2) + indx];
            array[(array.Length / 2) + indx] = temp;
        }
        // -----------------------------------------------------------------------------------------
        private static void InvertArrayPart(int[] array)
        {
            Console.Write("The array is...........: ");
            PrintArrayOneLine(array);

            var res = InvertArray(array);
            Console.Write("The inverted array is..: ");
            PrintArrayOneLine(res);
        }
        private static int[] InvertArray(int[] array)
        {
            var res = CopyArray(array);
            try
            {
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = (int)1 / res[i];
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please terminate the program and enter an array with non-zero items!");
                return EqualItemsArray(array.Length * 2, 9);
            }
            return res;
        }
        // -----------------------------------------------------------------------------------------
        private static void TwoArrayMultiplicationPart(int[] array1, int[] array2)
        {
            Console.Write("Old array is...............: ");
            PrintArrayOneLine(array1);
            Console.Write("New array is...............: ");
            PrintArrayOneLine(array2);

            var res = TwoArrayMultiplication(array1, array2);
            Console.Write("Multiplication result is...: ");
            PrintArrayOneLine(res);
        }
        private static int[] TwoArrayMultiplication(int[] a, int[] b)
        {
            try
            {
                if (a.Length != b.Length)
                    throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException ex1)
            {
                Console.WriteLine(ex1.Message);
                Console.WriteLine($"Please enter a new array with length {a.Length} using choise (7)!");
                return EqualItemsArray(Math.Min(a.Length, b.Length), 0);
            }
            var result = new int[a.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] * b[i];
            }
            return result;
        }
        // -----------------------------------------------------------------------------------------
        private static void TwoArrayDivisionPart(int[] array1, int[] array2)
        {
            Console.Write("Old array is.........: ");
            PrintArrayOneLine(array1);
            Console.Write("New array is.........: ");
            PrintArrayOneLine(array2);

            var res = TwoArrayDivision(array1, array2);
            Console.Write("Division result is...: ");
            PrintArrayOneLine(res);
        }
        private static int[] TwoArrayDivision(int[] a, int[] b)
        {
            try
            {
                if (a.Length != b.Length)
                    throw new IndexOutOfRangeException();
                if (ZeroItemInArray(b) == true)
                    throw new DivideByZeroException();
            }
            catch (IndexOutOfRangeException ex1)
            {
                Console.WriteLine(ex1.Message);
                Console.WriteLine($"Please enter a new array with length {a.Length} using choise (7)!");
                return EqualItemsArray(Math.Min(a.Length, b.Length), 0);
            }
            catch (DivideByZeroException ex2)
            {
                Console.WriteLine(ex2.Message);
                return EqualItemsArray(a.Length, 9);
            }
            var result = new int[a.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (int)Math.Ceiling((double)a[i] / b[i]);
            }
            return result;
        }
        private static int[] EqualItemsArray(int count, int val)
        {
            var arr = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
            }
            return arr;
        }
        private static bool ZeroItemInArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                    return true;
            }
            return false;
        }
        // #########################################################################################
        private static int[] EnterAnotherArrayPart()
        {
            Console.Write("Enter your array length: ");
            int counter = EnterFreeNumber(false);

            Console.WriteLine("Enter your array:");
            var array = EnterArray(counter);
            return array;
        }
        private static int[] ReEnterArrayPart()
        {
            Console.Write("Enter your array length: ");
            int counter = EnterFreeNumber(false);

            Console.WriteLine("Enter your array:");
            int[] vec1 = EnterArray(counter);
            return vec1;
        }
        // ######################################################################################
        private static bool AllItemsAreEqual(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                    return false;
            }
            return true;
        }
        // #######################################################################################
        private static void ScalarDivPart(int[] array)
        {
            Console.Write("Enter scalar value: ");
            int scalar = EnterFreeNumber(true);
            var div = ScalarDivision(array, scalar);

            Console.Write("Your array is.................: ");
            PrintArrayOneLine(array);
            Console.Write("Your array after scalar div is: ");
            PrintArrayOneLine(div);
        }
        private static int[] ScalarDivision(int[] array, int scalar)
        {
            try
            {
                if (scalar == 0)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.Write("Enter non-zero scalar value: ");
                scalar = EnterFreeNumber(true);
                return ScalarDivision(array, scalar);
            }
            var nums = CopyArray(array);
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = (int)Math.Ceiling((double)nums[i] / scalar);
            }
            return nums;
        }
        // #####################################################################################
        private static void ScalarMultPart(int[] array)
        {
            Console.Write("Enter scalar value: ");
            int scalar = EnterFreeNumber(true);
            var mult = ScalarMultiplication(array, scalar);

            Console.Write("Your array is..................: ");
            PrintArrayOneLine(array);
            Console.Write("Your array after scalar mult is: ");
            PrintArrayOneLine(mult);
        }
        private static int[] ScalarMultiplication(int[] array, int scalar)
        {
            int[] nums = CopyArray(array);
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = scalar * nums[i];
            }
            return nums;
        }
        // ########################################## Left Shift Part #############################
        private static void LeftPart(int[] array)
        {
            Console.Write($"Enter displacement: ");
            int dis = EnterFreeNumber(true);
            var left = LeftShift(array, dis);

            Console.Write("Your array is.........: ");
            PrintArrayOneLine(array);
            Console.Write("Right shifted array is: ");
            PrintArrayOneLine(left);
        }
        private static int[] LeftShift(int[] a, int displacement)
        {
            try
            {
                if (displacement < 0)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.Write("Enter positive integer: ");
                displacement = EnterFreeNumber(true);
                return LeftShift(a, displacement);
            }
            int[] arr = CopyArray(a);

            for (int k = 0; k < displacement; k++)
            {
                int temp = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = temp;
            }
            return arr;
        }
        // ######################################## Right Shift Part #############################
        private static void RightShiftPart(int[] array)
        {
            Console.Write($"Enter displacement: ");
            int dis = EnterFreeNumber(true);
            var right = RightShift(array, dis);

            Console.Write("Your array is.........: ");
            PrintArrayOneLine(array);
            Console.Write("Right shifted array is: ");
            PrintArrayOneLine(right);
        }

        private static int[] RightShift(int[] a, int displacement)
        {
            try
            {
                if (displacement < 0)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.Write("Enter positive integer: ");
                displacement = EnterFreeNumber(true);
                return RightShift(a, displacement);
            }
            int[] arr = CopyArray(a);

            for (int k = 0; k < displacement; k++)
            {
                int temp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = temp;
            }
            return arr;
        }
        // =======================================================================================
        private static int[] EnterArray(int leng)
        {
            int[] array = new int[leng];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = EnterFreeNumber(true);
            }
            return array;
        }
        private static int EnterFreeNumber(bool flag)
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (flag == false && (a < 1 || a > 20))
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterFreeNumber(flag);
            }
            return a;
        }
        private static int[] CopyArray(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        private static void PrintArrayOneLine(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine(" ");
        }
    }
}
