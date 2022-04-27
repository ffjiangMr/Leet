using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Management;
using System.IO;

namespace LeetCode
{

    public class Bank
    {
        private long[] balance;
        public Bank(long[] balance)
        {
            this.balance = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            bool result = false;
            if ((account1 <= balance.Length) && (balance[account1 - 1] >= money) && (account2 <= balance.Length))
            {
                balance[account1 - 1] -= money;
                balance[account2 - 1] += money;
                result = true;
            }
            return result;
        }

        public bool Deposit(int account, long money)
        {
            bool result = false;

            if (account <= balance.Length)
            {
                balance[account - 1] += money;
                result = true;
            }

            return result;
        }

        public bool Withdraw(int account, long money)
        {
            bool result = false;

            if ((account <= balance.Length) && (balance[account - 1] >= money))
            {
                balance[account - 1] -= money;
                result = true;
            }

            return result;
        }
    }

    public class TripleInOne
    {

        int[][] stacks = new int[3][];
        int[] indexs = new int[3];

        public TripleInOne(int stackSize)
        {
            for (int flag = 0; flag < 3; flag++)
            {
                stacks[flag] = new int[stackSize];
            }
            for (int index = 0; index < 3; index++)
            {
                indexs[index] = 0;
            }
        }

        public void Push(int stackNum, int value)
        {
            if (indexs[stackNum] < stacks[stackNum].Length)
            {
                stacks[stackNum][indexs[stackNum]] = value;
                indexs[stackNum]++;
            }
        }

        public int Pop(int stackNum)
        {
            int result = -1;
            if (indexs[stackNum] > 0)
            {
                indexs[stackNum]--;
                result = stacks[stackNum][indexs[stackNum]];
            }
            return result;
        }

        public int Peek(int stackNum)
        {
            int result = -1;
            if (indexs[stackNum] > 0)
            {
                result = stacks[stackNum][indexs[stackNum] - 1];
            }
            return result;
        }

        public bool IsEmpty(int stackNum)
        {
            return indexs[stackNum] == 0;
        }
    }

    public class DictionaryTree
    {
        private DictionaryTree[] items;
        private int maxLength;

        public DictionaryTree this[int index]
        {
            get
            {
                DictionaryTree item = null;
                if (index < this.maxLength)
                {
                    item = items[index];
                }
                return item;
            }
            set
            {
                if (index < maxLength)
                {
                    items[index] = value;
                }
            }
        }

        public bool IsEnd { get; set; }

        public DictionaryTree()
        {
            this.maxLength = 26;
            this.items = new DictionaryTree[maxLength];
            this.IsEnd = false;
        }
    }

    public class MinStack
    {
        List<int> minValue;
        List<int> buffer;
        /** initialize your data structure here. */
        public MinStack()
        {
            this.minValue = new List<int>();
            this.buffer = new List<int>();
        }

        public void Push(int x)
        {
            this.buffer.Add(x);
            if (this.minValue.Count > 0)
            {
                this.minValue.Add(Math.Min(this.minValue[this.minValue.Count - 1], x));
            }
            else
            {
                this.minValue.Add(x);
            }
        }

        public void Pop()
        {
            this.buffer.RemoveAt(this.buffer.Count - 1);
            this.minValue.RemoveAt(this.minValue.Count - 1);
        }

        public int Top()
        {
            return this.buffer[this.buffer.Count - 1];
        }

        public int GetMin()
        {
            return this.minValue[this.minValue.Count - 1];
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class AllOneNode
    {
        public AllOneNode Pre { get; set; }
        public AllOneNode Next { get; set; }
        private HashSet<String> items = new HashSet<String>();
        private int count = 0;
        public int Count { get { return this.count; } }

        public int Size { get { return this.items.Count; } }

        public string GetAnyItem()
        {
            return this.items.Count > 0 ? this.items.ElementAt(0) : "";
        }

        public AllOneNode(int count, string item)
        {
            this.count = count;
            this.items.Add(item);
        }

        public void Insert(AllOneNode node)
        {
            node.Next = this.Next;
            node.Next.Pre = node;
            this.Next = node;
            node.Pre = this;
        }

        public void InsertItem(string item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(string item)
        {
            this.items.Remove(item);
            if (this.Size == 0)
            {
                this.RemoveNode();
            }
        }

        private void RemoveNode()
        {
            this.Pre.Next = this.Next;
            this.Next.Pre = this.Pre;
        }

    }

    public class AllOne
    {
        public Dictionary<String, int> map { get; set; }
        public Dictionary<int, AllOneNode> table { get; set; }
        private int max = int.MinValue;
        private int min = int.MaxValue;
        public AllOne()
        {
            this.table = new Dictionary<int, AllOneNode>();
            this.map = new Dictionary<string, int>();
        }

        public void Inc(string key)
        {
            if (this.map.ContainsKey(key) == false)
            {
                this.map[key] = 0;
            }
            this.map[key]++;
            this.max = this.max < this.map[key] ? this.map[key] : this.max;
            this.min = this.min > this.map[key] ? this.map[key] : this.min;
            if (this.table.ContainsKey(this.map[key]) == false)
            {
                this.table[this.map[key]] = new AllOneNode(this.map[key], key);
                if (this.table.ContainsKey(this.map[key] - 1) == true)
                {
                    this.table[this.map[key]].Insert(this.table[this.map[key] - 1]);
                }
            }
            else
            {
                this.table[this.map[key]].InsertItem(key);
            }
            if (this.table.ContainsKey(this.map[key] - 1) == true)
            {
                this.table[this.map[key] - 1].RemoveItem(key);
                if (this.table[this.map[key] - 1].Size == 0)
                {
                    if (this.min == this.map[key] - 1)
                    {
                        this.min = this.map[key];
                    }
                    this.table.Remove(this.map[key] - 1);
                }
            }
        }

        public void Dec(string key)
        {
            if (this.map.ContainsKey(key) == true)
            {
                this.map[key]--;
                this.max = this.max < this.map[key] ? this.map[key] : this.max;
                this.min = this.min > this.map[key] ? this.map[key] : this.min;
                if (this.table.ContainsKey(this.map[key]) == false)
                {
                    this.table[this.map[key]] = new AllOneNode(this.map[key], key);
                    if (this.table.ContainsKey(this.map[key] + 1) == true)
                    {
                        this.table[this.map[key] + 1].Insert(this.table[this.map[key]]);
                    }
                }
                else
                {
                    this.table[this.map[key]].InsertItem(key);
                }
            }
        }

        public string GetMaxKey()
        {
            string result = string.Empty;
            if (this.table.ContainsKey(this.max) == true)
            {
                result = this.table[this.max].GetAnyItem();
            }
            return result;
        }

        public string GetMinKey()
        {
            string result = string.Empty;
            if (this.table.ContainsKey(this.min) == true)
            {
                result = this.table[this.min].GetAnyItem();
            }
            return result;
        }
    }

    internal class Program
    {
        struct demo
        {
            double c;
            int b;
            char aa;
            char a;
        };
        static void Main(string[] args)
        {
            Dictionary<int, int> ttt = new Dictionary<int, int>()
            {

            };
            unsafe
            {
                var charS = sizeof(char);
                var ints = sizeof(int);
                var doubles = sizeof(double);
                var demos = sizeof(demo);
                Console.WriteLine($"charS : {charS}");
                Console.WriteLine($"ints : {ints}");
                Console.WriteLine($"doubles : {doubles}");
                Console.WriteLine($"demos : {demos}");
            }
            var url = new Uri("https://www.snagajob.com/jobs/695952735");

            string par = ".*[a-z]";
            var sd = Regex.Match("Windows", par);
            //ListNode l1 = new ListNode(1);
            //l1.next = new ListNode(2);
            //l1.next.next = new ListNode(4);

            //ListNode l2 = new ListNode(1);
            //l2.next = new ListNode(3);
            //l2.next.next = new ListNode(4);

            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            /// l2.next.next = l1;
            var l3 = new ListNode(2);
            l3.next = new ListNode(6);
            l3.next.next = new ListNode(5);
            /// l3.next.next.next = l1;
            int[] sss = new int[] { };
            int[][] fd = new int[][] { new int[] { 3, 4 }, new int[] { 1, 2 } };
            /// NextPermutation(new int[] { 1,2 });
            /// Rotate(new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15 }, new int[] { 16, 17, 18, 19, 20 }, new int[] { 21, 22, 23, 24, 25 } });
            MoveZeroes(new int[] { 0 });
            var temp = ToGoatLatin("Each word consists of lowercase and uppercase letters only");
            Console.WriteLine();

            Console.Read();
        }

        static public string ToGoatLatin(string sentence)
        {
            StringBuilder result = new StringBuilder();
            HashSet<char> tables = new HashSet<char>() { 'a','A', 'e','E','i','I','o','O', 'u','U' };
            int index = 0;            
            var items = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                index++;
                if (tables.Contains(item[0]))
                {
                    result.Append(item).Append("ma");
                }
                else
                {
                    result.Append(item.Substring(1)).Append(item[0]).Append("ma");
                }
                for (int flag = 0; flag < index; flag++)
                {
                    result.Append("a");
                }
                result.Append(" ");
            }
            return result.ToString().Trim();
        }

        static public int LengthLongestPath(string input)
        {
            int result = 0;
            var items = input.Split('\n');
            int deep = 0;
            int current = 0;
            List<int> indexs = new List<int>();
            string path = "";
            foreach (var item in items)
            {
                current = 0;
                int index = 0;
                while (item[index] == '\t')
                {
                    current++;
                    index++;
                }
                if (current <= deep)
                {
                    while ((deep >= current) && (indexs.Count() > 0))
                    {
                        path = path.Substring(0, indexs[indexs.Count() - 1]);
                        indexs.RemoveAt(indexs.Count() - 1);
                        deep--;
                    }
                }
                if (current >= deep)
                {
                    indexs.Add(path.Length);
                    if (current != 0)
                    {
                        path += "/" + item.Substring(index);
                    }
                    else
                    {
                        path = item.Substring(index);
                    }
                }
                if (item.Contains("."))
                {
                    result = Math.Max(result, path.Length);
                }
                deep = current;
            }

            return result;
        }

        static public void MoveZeroes(int[] nums)
        {

            int fast = 0;
            int slow = 0;
            while (slow < nums.Length)
            {
                while ((fast < nums.Length) && (nums[fast] == 0))
                {
                    fast++;
                }
                if (fast < nums.Length)
                {
                    nums[slow++] = nums[fast++];
                }
                else
                {
                    nums[slow++] = 0;
                }
            }
        }


        static public int[] PlusOne(int[] digits)
        {
            int carry = 1;
            for (int index = digits.Length - 1; index > -1; index--)
            {
                var temp = carry + digits[index];
                carry = (temp) / 10;
                digits[index] = temp % 10;
            }
            int length = carry > 0 ? digits.Length + 1 : digits.Length;
            int[] result = new int[length];
            result[0] = 1;
            Array.Copy(digits, 0, result, length - digits.Length, digits.Length);
            return result;
        }

        public int SingleNumber(int[] nums)
        {
            int result = nums[0];
            for (int index = 1; index < nums.Length; index++)
            {
                result ^= nums[index];
            }
            return result;
        }

        public string LongestWord(string[] words)
        {
            string result = String.Empty;
            Array.Sort(words);
            HashSet<string> table = new HashSet<string>();
            foreach (var item in words)
            {
                if ((item.Length > 1) && (table.Contains(item.Substring(0, item.Length - 1)) == false))
                {
                    continue;
                }
                table.Add(item);
                result = result.Length >= item.Length ? result : item;
            }
            return result;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            bool result = false;
            HashSet<int> set = new HashSet<int>();
            foreach (var item in nums)
            {
                if (set.Add(item) == false)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        static public void Rotate(int[] nums, int k)
        {
            if (k > 0)
            {
                int mod = nums.Length;
                int temp = nums[0];
                int current = nums[0];
                int flag = 0;
                int index = 0;
                int count = 0;
                while (index < mod)
                {
                    current = temp;
                    flag = (flag + k) % mod;
                    temp = nums[flag];
                    nums[flag] = current;
                    count += k;
                    if ((count % nums.Length) == 0)
                    {
                        count = 0;
                        flag = (flag + 1) % mod;
                        temp = nums[flag];
                    }

                    index++;
                }
            }
        }

        static public int MaxProfit(int[] prices)
        {
            int[][] dp = new int[prices.Length][];
            dp[0] = new int[2];
            dp[0][0] = 0;
            dp[0][1] = -prices[0];
            for (int index = 1; index < prices.Length; index++)
            {
                dp[index] = new int[2];
                dp[index][0] = Math.Max(dp[index - 1][1] + prices[index], dp[index - 1][0]);
                dp[index][1] = Math.Max(dp[index - 1][1], dp[index - 1][0] - prices[index]);
            }
            return dp[prices.Length - 1][0];
        }

        static public int CountMaxOrSubsets(int[] nums)
        {
            int max = 0;
            int count = 0;
            DFS(ref nums, ref max, ref count, 0, 0);
            return count;
        }

        static public void DFS(ref int[] nums, ref int max, ref int count, int index, int val)
        {
            if (index == nums.Length)
            {
                if (val > max)
                {
                    max = val;
                    count = 1;
                }
                else if (val == max)
                {
                    count++;
                }
            }
            else
            {
                DFS(ref nums, ref max, ref count, index + 1, val);
                DFS(ref nums, ref max, ref count, index + 1, val | nums[index]);
            }
        }



        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> table = new Dictionary<string, int>();
            for (int index = 0; index < list1.Length; index++)
            {
                table[list1[index]] = index;
            }
            int min = int.MaxValue;
            for (int index = 0; index < list2.Length; index++)
            {
                if (table.ContainsKey(list2[index]) == true)
                {
                    if (index + table[list2[index]] == min)
                    {
                        result.Add(list2[index]);
                    }
                    else if (index + table[list2[index]] < min)
                    {
                        result.Clear();
                        result.Add(list2[index]);
                        min = index + table[list2[index]];
                    }
                }
            }

            return result.ToArray();
        }

        public IList<int> Preorder(Node root)
        {
            IList<int> list = new List<int>();
            DFS(root, ref list);
            return list;
        }

        private void DFS(Node root, ref IList<int> result)
        {
            if (root != null)
            {
                result.Add(root.val);
                if (root.children != null)
                {
                    foreach (var item in root.children)
                    {
                        DFS(item, ref result);
                    }
                }
            }
        }

        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] result = new int[n];

            for (int index = 0; index < bookings.Length; index++)
            {
                result[bookings[index][0] - 1] += bookings[index][2];
                if (bookings[index][1] < n)
                {
                    result[bookings[index][1]] -= bookings[index][2];
                }
            }

            for (int flag = 1; flag < n; flag++)
            {
                result[flag] += result[flag - 1];
            }

            return result;
        }

        static public int BestRotation(int[] nums)
        {
            int[] max = new int[nums.Length];
            int[] min = new int[nums.Length];
            int[] cal = new int[nums.Length];
            int maxCount = -1;
            int maxIndex = int.MaxValue;
            int mod = nums.Length;
            for (int index = 0; index < nums.Length; index++)
            {
                var temp = (mod - nums[index] + index) % mod;
                max[index] = temp;
                temp = (mod + nums[index] - index) % mod;
                min[index] = temp;
            }
            for (int index = 0; index < nums.Length; index++)
            {

            }

            return maxIndex;
        }

        static public int[] PlatesBetweenCandles(string s, int[][] queries)
        {
            int[] result = new int[queries.Length];
            int[] sum = new int[s.Length];
            for (int index = 0, temp = 0; index < s.Length; index++)
            {
                if (s[index] == '*')
                {
                    temp++;
                }
                sum[index] = temp;
            }
            int[] right = new int[s.Length];
            for (int index = s.Length - 1, r = -1; index >= 0; index--)
            {
                if (s[index] == '|')
                {
                    r = index;
                }
                right[index] = r;
            }

            int[] left = new int[s.Length];
            for (int index = 0, l = -1; index < s.Length; index++)
            {
                if (s[index] == '|')
                {
                    l = index;
                }
                left[index] = l;
            }
            for (int index = 0; index < queries.Length; index++)
            {
                result[index] = (left[queries[index][1]] == -1) ||
                                (right[queries[index][0]] == -1) ||
                                right[queries[index][0]] > left[queries[index][1]] ? 0 :
                                sum[left[queries[index][1]]] - sum[right[queries[index][0]]];
            }
            return result;
        }

        static public string ConvertToBase7(int num)
        {
            StringBuilder result = new StringBuilder();
            int symbol = num != 0 ? num / Math.Abs(num) : 1;
            num = Math.Abs(num);
            while ((num / 7) != 0)
            {
                result.Insert(0, num % 7);
                num /= 7;
            }
            result.Insert(0, num);
            if (symbol == -1)
            {
                result.Insert(0, "-");
            }
            return result.ToString();
        }

        static public long SubArrayRanges(int[] nums)
        {
            long result = 0;
            int[][] table = new int[nums.Length * nums.Length][];

            return result;
        }

        static public int AddDigits(int num)
        {
            int result = 0;

            while ((num > 0) || (result / 10) > 0)
            {
                if (num / 10 > 0)
                {
                    result += num % 10;
                    num = num / 10;
                }
                else
                {
                    result += num % 10;
                    num = result / 10 > 0 ? result : 0;
                    result = num / 10 > 0 ? 0 : result;
                }
            }
            return result;
        }

        static public int MaximumRequests(int n, int[][] requests)
        {
            int result = requests.Length;
            int[,] table = new int[n, n];
            int[] temp = new int[n];
            foreach (var item in requests)
            {
                table[item[0], item[1]]++;
                temp[item[0]]--;
                temp[item[1]]++;
            }

            for (int r = 0; r < n; r++)
            {
                for (int f = 0; f < n; f++)
                {
                    while (table[r, f] > 0)
                    {
                        if (DFS(n, table, new Boolean[n], f, r, ref result) == true)
                        {
                            if (r != f)
                            {
                                table[r, f]--;
                                result++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }

        static public Boolean DFS(int n, int[,] table, bool[] views, int origin, int purpose, ref int count)
        {
            Boolean result = false;

            for (int flag = 0; flag < n; flag++)
            {
                if ((table[origin, flag] > 0) && (views[flag] == false))
                {
                    views[flag] = true;
                    if (flag != purpose)
                    {
                        if (flag != origin)
                        {
                            result = DFS(n, table, views, flag, purpose, ref count);
                        }
                    }
                    else
                    {
                        result = true;
                    }
                    if (result == true)
                    {
                        table[origin, flag]--;
                        count++;
                        break;
                    }
                }
            }

            return result;
        }

        static public string ReverseOnlyLetters(string s)
        {
            char[] buffer = s.ToArray();
            int offset = 0;
            for (int index = s.Length - 1; index > -1; index--)
            {
                if (((64 < s[index]) && (s[index] < 91)) ||
                    ((96 < s[index]) && (s[index] < 123)))
                {
                    while ((((64 < s[offset]) && (s[offset] < 91)) ||
                           ((96 < s[offset]) && (s[offset] < 123))) == false)
                    {
                        offset++;
                    }
                    buffer[offset++] = s[index];
                }
            }
            return new string(buffer);
        }

        static int[] PRIMES = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        static int NUM_MAX = 30;
        static int MOD = 1000000007;

        static public int NumberOfGoodSubsets(int[] nums)
        {
            int[] freq = new int[NUM_MAX + 1];
            foreach (int num in nums)
            {
                ++freq[num];
            }

            int[] f = new int[1 << PRIMES.Length];
            f[0] = 1;
            for (int i = 0; i < freq[1]; ++i)
            {
                f[0] = f[0] * 2 % MOD;
            }

            for (int i = 2; i <= NUM_MAX; ++i)
            {
                if (freq[i] == 0)
                {
                    continue;
                }

                // 检查 i 的每个质因数是否均不超过 1 个
                int subset = 0, x = i;
                bool check = true;
                for (int j = 0; j < PRIMES.Length; ++j)
                {
                    int prime = PRIMES[j];
                    if (x % (prime * prime) == 0)
                    {
                        check = false;
                        break;
                    }
                    if (x % prime == 0)
                    {
                        subset |= (1 << j);
                    }
                }
                if (!check)
                {
                    continue;
                }

                // 动态规划
                for (int mask = (1 << PRIMES.Length) - 1; mask > 0; --mask)
                {
                    if ((mask & subset) == subset)
                    {
                        if (mask == 1 || mask == 2 || mask == 3)
                        {
                            Console.WriteLine("");
                        }
                        f[mask] = (int)((f[mask] + ((long)f[mask ^ subset]) * freq[i]) % MOD);
                    }
                }
            }

            int ans = 0;
            for (int mask = 1, maskMax = (1 << PRIMES.Length); mask < maskMax; ++mask)
            {
                ans = (ans + f[mask]) % MOD;
            }

            return ans;
        }

        static public string PushDominoes(string dominoes)
        {
            Queue<int> steps = new Queue<int>();
            var buffer = dominoes.ToCharArray();
            Queue<int> times = new Queue<int>();
            for (int index = 0; index < buffer.Length; index++)
            {
                if (buffer[index] != '.')
                {
                    steps.Enqueue(index);
                    times.Enqueue(0);
                }
            }
            int lastTime = 0;
            while (steps.Count > 0)
            {
                var index = steps.Dequeue();
                var time = times.Dequeue();
                if (lastTime < time)
                {
                    dominoes = new String(buffer);
                    lastTime = time;
                }
                if (buffer[index] == 'L')
                {
                    if ((index - 1 > -1) && (dominoes[index - 1] == '.'))
                    {
                        if (((index - 2 > -1) && (dominoes[index - 2] != 'R')) || (index - 2 == -1))
                        {
                            buffer[index - 1] = 'L';
                            steps.Enqueue(index - 1);
                            times.Enqueue(time + 1);
                        }
                    }
                }
                else if (buffer[index] == 'R')
                {
                    if ((index + 1 < dominoes.Length) && (dominoes[index + 1] == '.'))
                    {
                        if (((index + 2 < dominoes.Length) && (dominoes[index + 2] != 'L')) || (index + 2 == dominoes.Length))
                        {
                            buffer[index + 1] = 'R';
                            steps.Enqueue(index + 1);
                            times.Enqueue(time + 1);
                        }
                    }
                }
            }

            return dominoes;
        }

        static public int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            Stack<int> buffer = new Stack<int>();
            buffer.Push(-1);
            for (int index = 0; index < s.Length; index++)
            {
                if (s[index] == '(')
                {
                    buffer.Push(index);
                }
                else
                {
                    buffer.Pop();
                    if (buffer.Count == 0)
                    {
                        buffer.Push(index);
                    }
                    maxLength = Math.Max(maxLength, index - buffer.Peek());
                }
            }
            return maxLength;
        }

        static public int FindCenter(int[][] edges)
        {
            return edges[0][0] == edges[1][0] ? edges[0][0] :
                   edges[0][0] == edges[1][1] ? edges[0][0] :
                   edges[0][1];

        }

        static public bool IsMatch(string s, string p)
        {
            int[,] dp = new int[s.Length + 1, p.Length + 1];
            dp[0, 0] = 1;
            for (int index = 1; index <= p.Length; index++)
            {
                if (p[index - 1] == '*')
                {
                    dp[0, index] = 1;
                }
                else
                {
                    break;
                }
            }
            for (int index_s = 1; index_s < s.Length + 1; index_s++)
            {
                for (int index_p = 1; index_p < p.Length + 1; index_p++)
                {
                    if (p[index_p - 1] == '*')
                    {
                        dp[index_s, index_p] = dp[index_s, index_p - 1] | dp[index_s - 1, index_p];
                    }
                    else if ((p[index_p - 1] == s[index_s - 1]) || (p[index_p - 1] == '?'))
                    {
                        dp[index_s, index_p] = dp[index_s - 1, index_p - 1];
                    }
                }
            }
            return dp[s.Length, p.Length] == 1;
        }

        static public double KnightProbability(int n, int k, int row, int column)
        {
            double result = 1;
            if (k > 0)
            {
                int[] r = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
                int[] c = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
                double[,,] dp = new double[k + 1, n, n];
                for (int step = 0; step <= k; step++)
                {
                    for (int c_r = 0; c_r < n; c_r++)
                    {
                        for (int c_c = 0; c_c < n; c_c++)
                        {
                            if (step == 0)
                            {
                                dp[step, c_r, c_c] = 1;
                            }
                            else
                            {
                                for (int flag = 0; flag < 8; flag++)
                                {
                                    var next_r = c_r + r[flag];
                                    var next_c = c_c + c[flag];
                                    if ((next_r < n) && (next_c < n) && (next_r > -1) && (next_c > -1))
                                    {
                                        dp[step, c_r, c_c] += dp[step - 1, next_r, next_c] / 8;
                                    }
                                }
                            }
                        }
                    }
                }
                result = dp[k, row, column];
            }
            else if ((row < n) && (column < n))
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public int CheckWays(int[][] pairs)
        {
            Dictionary<int, ISet<int>> adj = new Dictionary<int, ISet<int>>();
            foreach (int[] p in pairs)
            {
                if (!adj.ContainsKey(p[0]))
                {
                    adj.Add(p[0], new HashSet<int>());
                }
                if (!adj.ContainsKey(p[1]))
                {
                    adj.Add(p[1], new HashSet<int>());
                }
                adj[p[0]].Add(p[1]);
                adj[p[1]].Add(p[0]);
            }
            /* 检测是否存在根节点*/
            int root = -1;
            foreach (KeyValuePair<int, ISet<int>> pair in adj)
            {
                int node = pair.Key;
                ISet<int> neighbours = pair.Value;
                if (neighbours.Count == adj.Count - 1)
                {
                    root = node;
                }
            }
            if (root == -1)
            {
                return 0;
            }

            int res = 1;
            foreach (KeyValuePair<int, ISet<int>> pair in adj)
            {
                int node = pair.Key;
                ISet<int> neighbours = pair.Value;
                /* 如果当前节点为根节点 */
                if (node == root)
                {
                    continue;
                }
                int currDegree = neighbours.Count;
                int parent = -1;
                int parentDegree = int.MaxValue;

                /* 根据 degree 的大小找到 node 的父节点 parent */
                foreach (int neighbour in neighbours)
                {
                    if (adj[neighbour].Count < parentDegree && adj[neighbour].Count >= currDegree)
                    {
                        parent = neighbour;
                        parentDegree = adj[neighbour].Count;
                    }
                }
                if (parent == -1)
                {
                    return 0;
                }

                /* 检测父节点的集合是否包含所有的孩子节点 */
                foreach (int neighbour in neighbours)
                {
                    if (neighbour == parent)
                    {
                        continue;
                    }
                    if (!adj[parent].Contains(neighbour))
                    {
                        return 0;
                    }
                }
                if (parentDegree == currDegree)
                {
                    res = 2;
                }
            }
            return res;
        }

        static public IList<int> LuckyNumbers(int[][] matrix)
        {
            IList<int> result = new List<int>();
            int row = matrix.Length;
            int col = matrix[0].Length;
            int[] minRow = new int[row];
            for (int i = 0; i < row; i++)
            {
                minRow[i] = int.MaxValue;
            }
            int[] maxCol = new int[col];
            for (int i = 0; i < col; i++)
            {
                maxCol[i] = int.MinValue;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    minRow[i] = Math.Min(minRow[i], matrix[i][j]);
                    maxCol[j] = Math.Max(maxCol[j], matrix[i][j]);
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (minRow[i] == matrix[i][j] && maxCol[j] == matrix[i][j])
                    {
                        result.Add(minRow[i]);
                    }
                }
            }
            return result;
        }

        static public int SingleNonDuplicate(int[] nums)
        {
            int result = nums[0];
            int begin = 0;
            int end = nums.Length - 1;
            while (begin < end)
            {
                var mid = (end + begin) / 2;
                if (nums[mid] == nums[mid + 1])
                {
                    if ((mid % 2) == 0)
                    {
                        begin = mid + 2;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else if (nums[mid] == nums[mid - 1])
                {
                    if (((mid - 1) % 2) == 0)
                    {
                        begin = mid + 1;
                    }
                    else
                    {
                        end = mid - 2;
                    }
                }
                else
                {
                    begin = mid;
                    break;
                }
            }
            result = nums[begin];
            return result;
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode result = null;
            HashSet<ListNode> table = new HashSet<ListNode>();
            var temp = head;
            while (temp != null)
            {
                if (table.Add(temp) == false)
                {
                    result = temp;
                    break;
                }
                temp = temp.next;
            }
            //ListNode slow = head;
            //ListNode fast = head;
            //while (fast != null)
            //{
            //    slow = slow.next;
            //    if (fast.next == null)
            //    {
            //        break;
            //    }
            //    fast = fast.next.next;
            //    if (fast == slow)
            //    {
            //        ListNode cal = head;
            //        while (cal != slow)
            //        {
            //            cal = cal.next;
            //            slow = slow.next;
            //        }
            //        result = cal;
            //        break;
            //    }
            //}
            return result;
        }

        static public int MinimumDifference(int[] nums, int k)
        {
            int result = int.MaxValue;

            Array.Sort(nums);
            for (int flag = 0; flag < nums.Length - k + 1; flag++)
            {
                result = result > (nums[flag + k - 1] - nums[flag]) ? (nums[flag + k - 1] - nums[flag]) : result;
            }

            return result;
        }

        static public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var a = headA;
            var b = headB;
            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }
            return a;
        }

        static public IList<string> SimplifiedFractions(int n)
        {
            IList<string> result = new List<string>();
            Dictionary<int, HashSet<int>> table = new Dictionary<int, HashSet<int>>();
            for (int flag = 1; flag < n; flag++)
            {
                for (int index = flag + 1; index <= n; index++)
                {
                    var temp = Dicisor(index, flag);
                    if (table.ContainsKey(index / temp) == false)
                    {
                        table[index / temp] = new HashSet<int>();
                    }
                    if (table[index / temp].Add(flag / temp) == true)
                    {
                        result.Add($"{flag}/{index}");
                    }
                }
            }
            return result;
        }

        static public int Dicisor(int num1, int num2)
        {
            int result = 1;
            var temp = num1 % num2;
            while (temp != 0)
            {
                num1 = num2;
                num2 = temp;
                temp = num1 % num2;
            }
            result = num2;
            return result;
        }

        static public int CountKDifference(int[] nums, int k)
        {
            int result = 0;
            Dictionary<int, int> table = new Dictionary<int, int>();
            int low = 0;
            int high = 0;
            foreach (var item in nums)
            {
                low = item - k;
                high = item + k;
                if (table.ContainsKey(low) == true)
                {
                    result += table[low];
                }
                if ((low != high) && (table.ContainsKey(high) == true))
                {
                    result += table[high];
                }
                if (table.ContainsKey(item) == false)
                {
                    table[item] = 0;
                }
                table[item]++;
            }
            return result;
        }
        static public int[][] HighestPeak(int[][] isWater)
        {
            int[] dr = new int[] { -1, 1, 0, 0 };
            int[] dc = new int[] { 0, 0, -1, 1 };
            int rows = isWater.Length;
            int cols = isWater[0].Length;
            int[][] result = new int[rows][];
            Queue<KeyValuePair<int, int>> points = new Queue<KeyValuePair<int, int>>();
            for (int r = 0; r < rows; r++)
            {
                result[r] = new int[cols];
                for (int c = 0; c < cols; c++)
                {
                    if (isWater[r][c] == 1)
                    {
                        points.Enqueue(new KeyValuePair<int, int>(r, c));
                        result[r][c] = 0;
                    }
                    else
                    {
                        result[r][c] = -1;
                    }
                }
            }
            while (points.Count > 0)
            {
                var point = points.Dequeue();
                for (int flag = 0; flag < 4; flag++)
                {
                    var row = point.Key + dr[flag];
                    var col = point.Value + dc[flag];
                    if (row < 0 || row >= rows || col < 0 || col >= cols)
                    {
                        continue;
                    }
                    else if (result[row][col] > 0)
                    {
                        continue;
                    }
                    else
                    {
                        result[row][col] = result[point.Key][point.Value] + 1;
                    }
                    points.Enqueue(new KeyValuePair<int, int>(row, col));
                }
            }
            return result;
        }

        static public int NumberOfWeakCharacters(int[][] properties)
        {
            int result = 0;
            Array.Sort(properties, (o1, o2) =>
            {
                return o1[0] == o2[0] ? (o1[1] - o2[1]) : (o2[0] - o1[0]);
            });
            int maxDef = 0;
            foreach (int[] p in properties)
            {
                if (p[1] < maxDef)
                {
                    result++;
                }
                else
                {
                    maxDef = p[1];
                }
            }
            return result;
        }

        static public int CountValidWords(string sentence)
        {
            int result = 0;

            var tokens = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool isTrue;
            foreach (var token in tokens)
            {
                isTrue = true;
                bool isHave = false;
                for (int index = 0; index < token.Length; index++)
                {
                    if (char.IsDigit(token[index]) == true)
                    {
                        isTrue = false;
                        break;
                    }
                    else if (token[index] == '-')
                    {
                        if ((index == 0) ||
                         (index == token.Length - 1) ||
                         (char.IsLetter(token[index - 1]) == false) ||
                         (char.IsLetter(token[index + 1]) == false) ||
                         isHave == true)
                        {
                            isTrue = false;
                            break;
                        }
                        isHave = true;
                    }
                    else if (((token[index] == '!') ||
                            (token[index] == '.') ||
                            (token[index] == ',')) &&
                            (index != token.Length - 1))
                    {
                        isTrue = false;
                        break;
                    }
                }
                if (isTrue)
                {
                    result++;
                }
            }

            return result;
        }

        public int KthToLast(ListNode head, int k)
        {
            List<int> buffer = new List<int>();
            while (head != null)
            {
                buffer.Add(head.val);
                head = head.next;
            }
            return buffer[buffer.Count - k];
        }


        static public int NumberOfMatches(int n)
        {
            int result = 0;
            var temp = 0;
            while (n != 1)
            {
                temp = n % 2;
                n = n / 2;
                result += n;
                n += temp;
            }

            return result;
        }

        static public int MinJumps(int[] arr)
        {
            int result = 0;
            Dictionary<int, List<int>> table = new Dictionary<int, List<int>>();
            for (int index = 0; index < arr.Length; index++)
            {
                if (table.ContainsKey(arr[index]) == false)
                {
                    table[arr[index]] = new List<int>();
                }
                table[arr[index]].Add(index);
            }
            HashSet<int> indexs = new HashSet<int>();
            indexs.Add(0);
            Queue<int[]> steps = new Queue<int[]>();
            steps.Enqueue(new int[] { 0, 0 });
            while (steps.Count > 0)
            {
                var item = steps.Dequeue();
                result = item[1];
                if (item[0] == arr.Length - 1)
                {
                    break;
                }
                result++;
                if (table.ContainsKey(arr[item[0]]) == true)
                {
                    foreach (var index in table[arr[item[0]]])
                    {
                        if (indexs.Add(index))
                        {
                            steps.Enqueue(new int[] { index, result });
                        }
                    }
                    table.Remove(arr[item[0]]);
                }
                if (item[0] + 1 < arr.Length && indexs.Add(item[0] + 1))
                {
                    steps.Enqueue(new int[] { item[0] + 1, result });
                }
                if (item[0] - 1 >= 0 && indexs.Add(item[0] - 1))
                {
                    steps.Enqueue(new int[] { item[0] - 1, result });
                }
            }
            return result;
        }

        static public int Step(ref int[] arr, ref Dictionary<int, List<int>> table, HashSet<int> buffer, int currentStep, int currentIndex, ref int maxStep, ref Dictionary<int, int> maxSteps)
        {
            var step1 = maxStep;
            var step2 = int.MaxValue;
            var step3 = int.MaxValue;
            if ((currentStep < maxStep) && (buffer.Contains(currentIndex) == false))
            {
                if (currentIndex != arr.Length - 1)
                {
                    if ((maxSteps.ContainsKey(currentIndex) == true) && (maxSteps[currentIndex] < currentStep))
                    {
                        step1 = maxSteps[currentIndex];
                    }
                    else
                    {
                        buffer.Add(currentIndex);
                        if (currentIndex < arr.Length)
                        {
                            step1 = Math.Min(Step(ref arr, ref table, buffer, currentStep + 1, currentIndex + 1, ref maxStep, ref maxSteps), step1);
                        }
                        if (currentIndex > 0)
                        {
                            step2 = Math.Min(Step(ref arr, ref table, buffer, currentStep + 1, currentIndex - 1, ref maxStep, ref maxSteps), step2);
                        }
                        if (currentIndex < arr.Length)
                        {
                            foreach (var item in table[arr[currentIndex]])
                            {
                                if (item != currentIndex)
                                {
                                    step3 = Math.Min(Step(ref arr, ref table, buffer, currentStep + 1, item, ref maxStep, ref maxSteps), step3);
                                }
                            }
                        }
                        buffer.Remove(currentIndex);
                        step1 = Math.Min(maxStep, step1);
                        step1 = Math.Min(step1, step2);
                        step1 = Math.Min(step1, step3);
                        if (maxSteps.ContainsKey(currentIndex) == false)
                        {
                            maxSteps[currentIndex] = step1;
                        }
                        else if (step1 < maxSteps[currentIndex])
                        {
                            maxSteps[currentIndex] = step1;
                        }
                    }
                }
                else
                {
                    step1 = currentStep;
                }
            }
            maxStep = step1;
            return step1;
        }


        public bool IsPalindrome(ListNode head)
        {
            bool result = true;
            List<int> buffer = new List<int>();
            while (head != null)
            {
                buffer.Add(head.val);
                head = head.next;
            }
            for (int flag = 0; flag < buffer.Count / 2; flag++)
            {
                if (buffer[flag] != buffer[buffer.Count - flag - 1])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static public ListNode RemoveDuplicateNodes(ListNode head)
        {
            ListNode result = new ListNode();
            var temp = result;
            HashSet<int> table = new HashSet<int>();
            while (head != null)
            {
                if (table.Contains(head.val) == false)
                {
                    temp.next = new ListNode(head.val);
                    temp = temp.next;
                    table.Add(head.val);
                }
                head = head.next;
            }
            return result.next;
        }

        static public bool IsFlipedString(string s1, string s2)
        {
            bool result = false;
            if (s1.Length == s2.Length)
            {
                result = (s2 + s2).IndexOf(s1) != -1;
            }

            return result;
        }

        static public bool StoneGameIX(int[] stones)
        {
            bool result = false;
            int cnt0 = 0, cnt1 = 0, cnt2 = 0;
            foreach (int val in stones)
            {
                int type = val % 3;
                if (type == 0)
                {
                    ++cnt0;
                }
                else if (type == 1)
                {
                    ++cnt1;
                }
                else
                {
                    ++cnt2;
                }
            }
            if (cnt0 % 2 == 0)
            {
                result = cnt1 >= 1 && cnt2 >= 1;
            }
            else
            {
                result = cnt1 - cnt2 > 2 || cnt2 - cnt1 > 2;
            }
            return result;
        }

        static public IList<IList<int>> Permute(int[] nums)
        {
            var buffer = new HashSet<int>();
            return Generate(nums, ref buffer);
        }
        static public IList<IList<int>> Generate(int[] nums, ref HashSet<int> buffer)
        {
            List<IList<int>> result = new List<IList<int>>();
            for (int index = 0; index < nums.Length; index++)
            {
                if (buffer.Contains(index) == false)
                {
                    if (buffer.Count == (nums.Length - 1))
                    {
                        result.Add(new List<int>() { nums[index] });
                    }
                    else
                    {
                        buffer.Add(index);
                        var temp = Generate(nums, ref buffer);
                        foreach (var item in temp)
                        {
                            item.Add(nums[index]);
                        }
                        result.AddRange(temp);
                        buffer.Remove(index);
                    }
                }
            }
            return result;
        }

        static public void SetZeroes(int[][] matrix)
        {
            HashSet<int> rowTable = new HashSet<int>();
            HashSet<int> columnTable = new HashSet<int>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[row].Length; column++)
                {
                    if (matrix[row][column] == 0)
                    {
                        rowTable.Add(row);
                        columnTable.Add(column);
                    }
                }
            }
            foreach (var row in rowTable)
            {
                for (int index = 0; index < matrix[row].Length; index++)
                {
                    matrix[row][index] = 0;
                }
            }
            for (int flag = 0; flag < matrix.Length; flag++)
            {
                if (rowTable.Contains(flag) == false)
                {
                    foreach (var column in columnTable)
                    {
                        matrix[flag][column] = 0;
                    }
                }
            }
        }

        static public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int flag = 0; flag < n / 2; flag++)
            {
                int cha_c = n - flag - 1;
                for (int column = flag; column < n - flag - 1; column++)
                {
                    /// 1 
                    var temp = matrix[column][cha_c];
                    matrix[column][cha_c] = matrix[flag][column];
                    /// 2
                    temp += matrix[cha_c][n - column - 1];
                    matrix[cha_c][n - column - 1] = temp - matrix[cha_c][n - column - 1];
                    temp -= matrix[cha_c][n - column - 1];
                    /// 3
                    temp += matrix[n - column - 1][n - cha_c - 1];
                    matrix[n - column - 1][n - cha_c - 1] = temp - matrix[n - column - 1][n - cha_c - 1];
                    temp -= matrix[n - column - 1][n - cha_c - 1];
                    /// 4
                    temp += matrix[n - cha_c - 1][column];
                    matrix[n - cha_c - 1][column] = temp - matrix[n - cha_c - 1][column];
                }
            }
        }

        static public bool OneEditAway(string first, string second)
        {
            bool result = false;

            if (Math.Abs(first.Length - second.Length) < 2)
            {
                int index1 = 0;
                int index2 = 0;
                bool isDiff = false;
                if ((String.IsNullOrEmpty(first) == false) && (String.IsNullOrEmpty(second) == false))
                {
                    while ((index1 < first.Length) && (index2 < second.Length))
                    {
                        if ((first[index1] != second[index2]))
                        {
                            if (isDiff == false)
                            {
                                isDiff = true;
                                if (first.Length > second.Length)
                                {
                                    index1++;
                                    continue;
                                }
                                else if (first.Length < second.Length)
                                {
                                    index2++;
                                    continue;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        index1++;
                        index2++;
                    }
                }
                if (isDiff == false)
                {
                    result = true;
                }
                else if ((index1 == first.Length) && (index2 == second.Length))
                {
                    result = true;
                }
            }
            return result;
        }

        static public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            bool result = false;
            Dictionary<int, int> table = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
            {
                if (table.ContainsKey(nums[index]) == true)
                {
                    if (Math.Abs(table[nums[index]] - index) <= k)
                    {
                        result = true;
                        break;
                    }
                }
                table[nums[index]] = index;
            }

            return result;
        }

        static public string CompressString(string S)
        {
            StringBuilder result = new StringBuilder();
            if (String.IsNullOrWhiteSpace(S) == false)
            {
                int count = 0;
                for (int index = 0; index < S.Length - 1; index++)
                {
                    count++;
                    if (S[index] != S[index + 1])
                    {
                        result.Append(S[index]).Append(count);
                        count = 0;
                    }
                }
                result.Append(S[S.Length - 1]).Append(count + 1);
            }
            return result.Length < S.Length ? result.ToString() : S;
        }

        static public bool CanPermutePalindrome(string s)
        {
            bool result = true;
            bool isOdd = (s.Length % 2) != 0;
            Dictionary<char, int> table = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (table.ContainsKey(item) == false)
                {
                    table[item] = 0;
                }
                table[item]++;
            }
            foreach (var item in table)
            {
                if ((item.Value % 2) != 0)
                {
                    if (isOdd == true)
                    {
                        isOdd = false;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        static public int FindMinDifference(IList<string> timePoints)
        {
            int result = int.MaxValue;
            List<string> buffer = new List<string>(timePoints);
            buffer.Sort();
            for (int flag = 0; flag < timePoints.Count - 1; flag++)
            {
                var date1 = buffer[flag].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var date2 = buffer[flag + 1].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var temp = ((Convert.ToInt32(date2[0]) - Convert.ToInt32(date1[0])) * 60 + Convert.ToInt32(date2[1]) - Convert.ToInt32(date1[1]));
                if (temp > 720)
                {
                    temp = 720 - (temp % 720);
                }
                result = result > temp ? temp : result;
            }
            var first = buffer[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var end = buffer[timePoints.Count - 1].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var cross = ((Convert.ToInt32(end[0]) - Convert.ToInt32(first[0])) * 60 + Convert.ToInt32(end[1]) - Convert.ToInt32(first[1]));
            if (cross > 720)
            {
                cross = 720 - (cross % 720);
            }
            result = result > cross ? cross : result;

            return result;
        }


        public int CountVowelPermutation(int n)
        {
            int result = 0;
            long[] buffer = new long[5];
            long[] temp = new long[5];
            int mod = (int)(1E9 + 7);
            for (int index = 0; index < 5; index++)
            {
                buffer[index] = 1;
            }
            for (int flag = 2; flag <= n; flag++)
            {
                temp[0] = (buffer[1] + buffer[2] + buffer[4]) % mod;
                temp[1] = (buffer[0] + buffer[2]) % mod;
                temp[2] = (buffer[1] + buffer[3]) % mod;
                temp[3] = (buffer[2]) % mod;
                temp[4] = (buffer[2] + buffer[3]) % mod;
                Array.Copy(temp, 0, buffer, 0, 5);
            }
            for (int index = 0; index < 5; index++)
            {
                result = (int)((result + buffer[index]) % mod);
            }
            return result;
        }

        static public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            SortedDictionary<int, List<int>> table = new SortedDictionary<int, List<int>>();
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            int index_1 = 0;
            int index_2 = 0;
            while ((index_1 < nums1.Length) && (index_2 < nums2.Length) && (k > 0))
            {
                if (buffer.ContainsKey(index_1) == false)
                {
                    buffer[index_1] = -1;
                }
                if (buffer[index_1] < nums2.Length - 1)
                {
                    index_2 = ++buffer[index_1];
                    result.Add(new List<int>() { nums1[index_1], nums2[buffer[index_1]] });
                    k--;
                }
                else
                {
                    index_2 = buffer[index_1];
                }
                if (index_1 < nums1.Length - 1)
                {
                    if (buffer.ContainsKey(index_1 + 1) == false)
                    {
                        table[nums1[index_1 + 1] + nums2[0]] = table[nums1[index_1 + 1] + nums2[0]] ?? new List<int>();
                        if (table[nums1[index_1 + 1] + nums2[0]].Contains(index_1 + 1) == false)
                        {
                            table[nums1[index_1 + 1] + nums2[0]].Add(index_1 + 1);
                        }
                    }
                    else if (index_2 < nums2.Length - 1)
                    {
                        table[nums1[index_1 + 1] + nums2[buffer[index_1 + 1] + 1]] = table[nums1[index_1 + 1] + nums2[buffer[index_1 + 1] + 1]] ?? new List<int>();
                        if (table[nums1[index_1 + 1] + nums2[buffer[index_1 + 1] + 1]].Contains(index_1 + 1) == false)
                        {
                            table[nums1[index_1 + 1] + nums2[buffer[index_1 + 1] + 1]].Add(index_1 + 1);
                        }
                    }
                    else
                    {
                        table[nums1[index_1 + 1] + nums2[nums2.Length - 1]] = table[nums1[index_1 + 1] + nums2[nums2.Length - 1]] ?? new List<int>();
                        if (table[nums1[index_1 + 1] + nums2[nums2.Length - 1]].Contains(index_1 + 1) == false)
                        {
                            table[nums1[index_1 + 1] + nums2[nums2.Length - 1]].Add(index_1 + 1);
                        }
                    }
                }
                if (index_2 < nums2.Length - 1)
                {
                    table[nums1[index_1] + nums2[index_2 + 1]] = table[nums1[index_1] + nums2[index_2 + 1]] ?? new List<int>();
                    if (table[nums1[index_1] + nums2[index_2 + 1]].Contains(index_1 + 1) == false)
                    {
                        table[nums1[index_1] + nums2[index_2 + 1]].Add(index_1);
                    }
                }
                if (table.Count > 0)
                {
                    index_1 = table[table.Keys.ElementAt(0)].ElementAt(0);
                    if (table[table.Keys.ElementAt(0)].Count == 0)
                    {
                        table.Remove(table.Keys.ElementAt(0));
                    }
                }
                else
                {
                    break;
                }
                if (k <= 0)
                {
                    break;
                }
            }

            return result;
        }

        static public void Calculate(int[] nums1, int[] nums2, ref int k, int index_1, int index_2, int maxValue, Dictionary<int, int> buffer, ref IList<IList<int>> result)
        {
            while ((index_1 < nums1.Length) && (index_2 < nums2.Length) && (k > 0))
            {
                if (buffer.ContainsKey(index_1) == false)
                {
                    buffer[index_1] = -1;
                }
                if (buffer[index_1] < nums2.Length - 1)
                {
                    index_2 = ++buffer[index_1];
                    result.Add(new List<int>() { nums1[index_1], nums2[buffer[index_1]] });
                    k--;
                }
                else
                {
                    index_2 = buffer[index_1];
                    /// minIndex = buffer[minIndex] == nums2.Length - 1 ? minIndex++ : minIndex;
                }
                if (k <= 0)
                {
                    break;
                }
                int diff_1 = index_1 < nums1.Length - 1 ? nums1[index_1 + 1] + nums2[index_2] : int.MaxValue;
                int diff_2 = index_2 < nums2.Length - 1 ? nums2[index_2 + 1] + nums1[index_1] : int.MaxValue;
                if ((diff_1 <= diff_2) && (diff_1 <= maxValue))
                {
                    Calculate(nums1, nums2, ref k, index_1 + 1, index_2, Math.Min(diff_2, maxValue), buffer, ref result);
                    if ((diff_2 > maxValue) || (k <= 0))
                    {
                        break;
                    }
                    /// var temp = Math.Min(maxValue, buffer[index_1] < nums2.Length - 1 ? nums2[buffer[index_1] + 1] + nums1[index_1] : int.MaxValue);
                    Calculate(nums1, nums2, ref k, index_1, index_2, maxValue, buffer, ref result);
                }
                else if ((diff_2 <= diff_1) && (diff_2 <= maxValue))
                {
                    Calculate(nums1, nums2, ref k, index_1, index_2 + 1, Math.Min(diff_1, maxValue), buffer, ref result);
                    if ((diff_1 > maxValue) || (k <= 0))
                    {
                        break;
                    }
                    var temp = Math.Min(maxValue, buffer[index_1] < nums2.Length - 1 ? nums2[buffer[index_1] + 1] + nums1[index_1] : int.MaxValue);
                    Calculate(nums1, nums2, ref k, index_1 + 1, index_2, temp, buffer, ref result);
                }
                else
                {
                    break;
                }
            }
        }

        static public void NextPermutation(int[] nums)
        {
            int index = nums.Length - 2;
            while (index >= 0 && nums[index] >= nums[index + 1])
            {
                index--;
            }
            if (index >= 0)
            {
                int flag = nums.Length - 1;
                while (flag >= 0 && nums[index] >= nums[flag])
                {
                    flag--;
                }
                var temp = nums[index];
                nums[index] = nums[flag];
                nums[flag] = temp;
            }
            Array.Sort(nums, index + 1, nums.Length - index - 1);
        }

        static public void NextPermutation_(int[] nums)
        {
            int low = nums.Length - 1;
            int high = -1;
            var temp = 0;
            var temp_ = 0;
            var temp_before = 0;
            var temp_before_ = 0;
            for (int index = nums.Length - 1; index > 0; index--)
            {
                for (int flag = index - 1; flag >= 0; flag--)
                {
                    var ret = Compare(nums[index], nums[flag]);
                    if ((ret > 0) && (high <= flag))
                    {
                        if ((high == flag) && (Compare(nums[index], nums[low]) > 0))
                        {
                            continue;
                        }
                        high = flag;
                        low = index;
                    }
                }
            }
            if (high != -1)
            {
                temp = nums[low];
                nums[low] = nums[high];
                nums[high] = temp;
                Array.Sort(nums, (item1, item2) =>
                 {
                     return Compare(item1, item2);
                 });
            }
            else
            {
                Array.Sort(nums, (item1, item2) =>
                {
                    return Compare(item1, item2);
                });
            }
        }

        static public int Compare(int item1, int item2)
        {
            var temp1 = item1;
            var temp1_ = 1;
            while (temp1 > 9)
            {
                temp1_ = temp1 % 10;
                temp1 = temp1 / 10;
            }
            if (item1 == 100)
            {
                temp1_ = -1;
            }
            var temp2 = item2;
            var temp2_ = 1;
            while (temp2 > 9)
            {
                temp2_ = temp2 % 10;
                temp2 = temp2 / 10;
            }
            if (item2 == 100)
            {
                temp2_ = -1;
            }
            return (temp1 - temp2) * 10 + (temp1_ - temp2_);
        }


        static public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();
            Dictionary<string, int> buffer = new Dictionary<string, int>();
            int totalLength = words[0].Length * words.Length;
            int length = words[0].Length;
            foreach (var item in words)
            {
                if (buffer.ContainsKey(item) == false)
                {
                    buffer[item] = 0;
                }
                buffer[item]++;
            }

            for (int index = 0; index < s.Length - length + 1; index++)
            {
                var sub = s.Substring(index, length);
                if (buffer.ContainsKey(sub) == true)
                {
                    if (IsMatch(ref s, index, new Dictionary<string, int>(buffer), length, words.Length) == true)
                    {
                        result.Add(index);
                    }
                }
            }

            return result;
        }

        static public bool IsMatch(ref string s, int index, Dictionary<string, int> buffer, int length, int count)
        {
            for (; (index <= s.Length - length) && (count > 0); index += length, count--)
            {
                var sub = s.Substring(index, length);
                if (buffer.ContainsKey(sub) == true)
                {
                    buffer[sub]--;
                    if (buffer[sub] == 0)
                    {
                        buffer.Remove(sub);
                    }
                }
                else
                {
                    return false;
                }
            }
            return count == 0;
        }

        public string ReplaceSpaces(string S, int length)
        {
            StringBuilder buffer = new StringBuilder();
            for (int index = 0; (index < length) && (index < S.Length); index++)
            {
                if (S[index] == ' ')
                {
                    buffer.Append("%20");
                }
                else
                {
                    buffer.Append(S[index]);
                }
            }
            return buffer.ToString();
        }

        static public bool CheckPermutation(string s1, string s2)
        {
            Dictionary<char, int> buffer = new Dictionary<char, int>();
            foreach (var item in s1)
            {
                if (buffer.ContainsKey(item) == false)
                {
                    buffer[item] = 0;
                }
                buffer[item]++;
            }
            foreach (var item in s2)
            {
                if (buffer.ContainsKey(item) == false)
                {
                    return false;
                }
                buffer[item]--;
                if (buffer[item] == 0)
                {
                    buffer.Remove(item);
                }
            }
            return buffer.Keys.Count == 0;
        }

        static public bool IsUnique(string astr)
        {
            HashSet<char> table = new HashSet<char>();
            foreach (var item in astr)
            {
                if (table.Contains(item))
                {
                    return false;
                }
                table.Add(item);
            }
            return true;
        }

        static Dictionary<int, int> table = new Dictionary<int, int>()
        {
            { 0,0},
            { 1,1}
        };

        static public int Fib(int n)
        {
            int result = 0;

            for (int flag = 2; flag <= n; flag++)
            {
                table[flag] = (table[flag - 1] + table[flag - 2]) % ((int)(1E9 + 7));
            }

            return table[n];
        }

        static public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length > 2)
            {
                int[] min = new int[nums.Length];
                int minValue = int.MaxValue;
                int[] max = new int[nums.Length];
                int maxValue = int.MinValue;
                for (int index = 0; index < nums.Length; index++)
                {
                    if (minValue > nums[index])
                    {
                        min[index] = nums[index];
                        minValue = nums[index];
                    }
                    else
                    {
                        min[index] = minValue;
                    }
                }
                for (int index = nums.Length - 1; index > 0; index--)
                {
                    if (maxValue < nums[index])
                    {
                        max[index] = nums[index];
                        maxValue = nums[index];
                    }
                    else
                    {
                        max[index] = maxValue;
                    }
                }
                for (int index = 1; index < nums.Length - 1; index++)
                {
                    if ((nums[index] > min[index]) && (nums[index] < max[index]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static public int DominantIndex(int[] nums)
        {
            int result = -1;
            int max = -1;
            int second = -1;
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] > max)
                {
                    second = max;
                    max = nums[index];
                    result = index;
                }
                else if (nums[index] > second)
                {
                    second = nums[index];
                }
            }
            return max < (2 * second) ? -1 : result;
        }

        static public bool _IncreasingTriplet(int[] nums)
        {
            bool result = false;

            if (nums.Length > 2)
            {
                int first = nums[0];
                int second = int.MaxValue;
                for (int flag = 1; flag < nums.Length; flag++)
                {
                    if (nums[flag] > second)
                    {
                        result = true;
                        break;
                    }
                    else if (nums[flag] > first)
                    {
                        second = nums[flag];
                    }
                    else
                    {
                        first = flag;
                    }
                }
            }

            return result;
        }

        static public int[] Ladder(int[] a, int[] b)
        {
            int[] result = new int[a.Length];
            Dictionary<int, int> lTable = new Dictionary<int, int>()
            {
                { 1,1},
                { 2,2}
            };
            int max = 2;
            for (int flag = 0; flag < a.Length; flag++)
            {
                if (lTable.ContainsKey(a[flag]) == false)
                {
                    for (int index = max + 1; index < a[flag]; index++)
                    {
                        lTable[index] = lTable[max] + lTable[max - 1];
                    }
                    max = a[flag];
                }
            }
            Dictionary<int, int> pTable = new Dictionary<int, int>();
            for (int flag = 1; flag < 31; flag++)
            {
                pTable[flag] = (int)Math.Pow(flag, 2);
            }
            for (int index = 0; index < result.Length; index++)
            {
                result[index] = lTable[a[index]] % pTable[b[index]];
            }
            return result;
        }

        static public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
        {
            bool result = true;

            if (blocked.Length > 1)
            {
                Array.Sort(blocked, (a, b) =>
                {
                    return a[0] - b[0];
                });
                Dictionary<int, int> buf = new Dictionary<int, int>();
                Dictionary<int, SortedSet<int>> set = new Dictionary<int, SortedSet<int>>();
                foreach (var item in blocked)
                {
                    if (set.ContainsKey(item[0]) == false)
                    {
                        set[item[0]] = new SortedSet<int>();
                    }
                    set[item[0]].Add(item[1]);
                }
                int row = blocked[0][0];
                int col = blocked[0][1];
                int maxRow = blocked[blocked.Length - 1][0];
                bool isCircle = row < 0;

            }

            return result;
        }

        static public bool IsConnect(Dictionary<int, SortedSet<int>> set, int[] last, int row, Dictionary<int, int> buf, int maxRow)
        {
            bool result = false;
            double maxDis = Math.Sqrt(2);
            while (set.ContainsKey(row) == true)
            {
                foreach (var col in set[row])
                {
                    if (maxDis >= CalDis(last, new int[] { row, col }))
                    {
                        buf[row] = col;
                        if (row < maxRow)
                        {
                            result = IsConnect(set, new int[] { row, col }, row + 1, buf, maxRow);
                        }
                        else
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        static public double CalDis(int[] a, int[] b)
        {
            return Math.Sqrt(Math.Pow((a[0] - b[0]), 2) + Math.Pow((a[1] - b[1]), 2));
        }


        static int nums = 0;

        static public bool IsAdditiveNumber(string num)
        {
            bool result = false;
            int firIndex = 0;

            for (int firLength = 1; firLength <= num.Length / 2; firLength++)
            {
                for (int secLength = 1; secLength <= num.Length / 2; secLength++)
                {
                    nums = 2;
                    if (Cal(num, firIndex, firLength, firIndex + firLength, secLength) == true)
                    {
                        if (nums > 2)
                        {
                            return true;
                        }
                    }
                }
            }
            return result;
        }

        static public bool Cal(string num, int firIndex, int firLength, int secIndex, int secLength)
        {
            bool result = false;
            if (secIndex + secLength < num.Length)
            {
                var sum = string.Empty;
                int carry = 0;
                int temp = 0;
                int tempLength = secLength;
                if (((firLength > 0) && (firLength + firIndex - 1) < secIndex) &&
                    ((secLength > 0) && ((secIndex + secLength - 1) < (num.Length - Math.Max(firLength, secLength)))))
                {
                    var str1 = num.Substring(firIndex, firLength);
                    var str2 = num.Substring(secIndex, secLength);
                    if (((str1.Length > 1) && str1.StartsWith("0") == true) ||
                        ((str2.Length > 1) && str2.StartsWith("0") == true))
                    {
                        sum = "*";
                    }
                    else
                    {
                        for (int index = Math.Max(firLength, secLength); index > 0; index--)
                        {
                            temp = firLength > 0 ? num[firIndex + firLength - 1] - 48 : 0;
                            temp += (secLength > 0 ? num[secIndex + secLength - 1] - 48 : 0);
                            firLength--;
                            secLength--;
                            temp += carry;
                            carry = temp / 10;
                            temp = temp % 10;
                            sum = temp.ToString() + sum;
                        }
                        sum = carry > 0 ? "1" + sum : sum;
                    }
                }
                if ((sum.Length > 0) && (Find(num, secIndex + tempLength, sum) == true))
                {
                    nums++;
                    result = Cal(num, secIndex, tempLength, secIndex + tempLength, sum.Length);
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        static public bool Find(string num, int index, string sum)
        {
            bool result = true;
            for (int i = 0; (i < sum.Length) && (index < num.Length); i++, index++)
            {
                if (sum[i] != num[index])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static public string SimplifyPath(string path)
        {
            string result = String.Empty;
            var items = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> buffer = new Stack<string>();
            foreach (var item in items)
            {
                if (item == ".")
                {
                    continue;
                }
                else if (item == "..")
                {
                    if (buffer.Count > 0)
                    {
                        buffer.Pop();
                    }
                }
                else
                {
                    buffer.Push(item);
                }
            }
            while (buffer.Count > 0)
            {
                result = ("/" + buffer.Pop()) + result;
            }
            result = result.Length > 0 ? result : "/";
            return result;
        }
        static public string ModifyString(string s)
        {
            List<char> table = new List<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            int temp = 0;
            char[] buffer = new char[s.Length];
            char last = '\0';
            char befor = '\0';
            char end = '\0';
            for (int index = 0; index < s.Length; index++)
            {
                if (s[index] == '?')
                {
                    if ((index > 0) && (index < s.Length - 1))
                    {
                        befor = s[index - 1] == '?' ? last : s[index - 1];
                        end = s[index + 1];
                    }
                    else if ((index == 0) && (index < s.Length - 1))
                    {
                        befor = '\0';
                        end = s[index + 1];
                    }
                    else if ((index > 0) && (index == s.Length - 1))
                    {
                        befor = s[index - 1] == '?' ? last : s[index - 1];
                        end = '\0';
                    }
                    else
                    {
                        befor = '\0';
                        end = '\0';
                    }
                    while (table[temp] == befor || table[temp] == end)
                    {
                        temp = temp < table.Count - 1 ? temp + 1 : 0;
                    }
                    buffer[index] = table[temp];
                    last = table[temp];
                }
                else
                {
                    buffer[index] = s[index];
                }
            }
            return String.Concat(buffer);
        }

        static public int Divide(int dividend, int divisor)
        {
            int result = 0;
            if (dividend != 0 && divisor != 0)
            {
                result = -1;
                int symbol = (dividend >> 31) ^ (divisor >> 31);
                dividend = dividend > 0 ? -dividend : dividend;
                divisor = divisor > 0 ? -divisor : divisor;
                int flag = 0;
                int temp = dividend;
                while (temp < divisor)
                {
                    temp >>= 1;
                    flag++;
                }
                temp = divisor;
                while (flag > 1)
                {
                    temp <<= 1;
                    result += result;
                    flag--;
                }
                int tempResult = 0;
                while (dividend < 0)
                {
                    dividend -= temp;
                    if (temp != divisor)
                    {
                        if (dividend < 0)
                        {
                            tempResult += result;
                        }
                        else
                        {
                            dividend += temp;
                            temp >>= 1;
                            result >>= 1;
                        }
                    }
                    else
                    {
                        if (dividend <= 0)
                        {
                            tempResult += result;
                        }
                    }
                }
                result = tempResult;
                if (symbol > -1)
                {
                    if (tempResult == int.MinValue)
                    {
                        result = int.MaxValue;
                    }
                    else
                    {
                        result = -tempResult;
                    }
                }
            }

            return result;
        }

        static public bool CheckPerfectNumber(int num)
        {
            Int64 sum = num > 1 ? 1 : 0;

            for (int index = 2; index * index <= num; index++)
            {
                if (num % index == 0)
                {
                    sum += index;
                    if (index * index < num)
                    {
                        sum += num / index;
                    }
                }
            }

            return sum == num;
        }

        static public int StrStr(string haystack, string needle)
        {
            int result = -1;

            for (int index = 0; index < haystack.Length - needle.Length + 1; index++)
            {
                int flag = 0;
                while (flag < needle.Length)
                {
                    if (haystack[index + flag] != needle[flag])
                    {
                        break;
                    }
                    flag++;
                }
                if (flag == needle.Length)
                {
                    result = index;
                    break;
                }
            }

            return result;
        }

        static public bool IsNStraightHand(int[] hand, int groupSize)
        {
            bool result = false;
            if ((hand.Length % groupSize) == 0)
            {
                Array.Sort(hand);
                Dictionary<int, int> table = new Dictionary<int, int>();
                foreach (var item in hand)
                {
                    if (table.ContainsKey(item) == false)
                    {
                        table[item] = 0;
                    }
                    table[item]++;
                }
                int temp = 0;
                result = true;
                while (table.Count > 0)
                {
                    temp = table.Keys.ElementAt(0);
                    for (int index = 0; index < groupSize; index++)
                    {
                        if (table.ContainsKey(temp + index) == false)
                        {
                            table.Clear();
                            result = false;
                            break;
                        }
                        table[temp + index]--;
                        if (table[temp + index] <= 0)
                        {
                            table.Remove(temp + index);
                        }
                    }
                }
            }

            return result;
        }

        static public int LeastBricks(IList<IList<int>> wall)
        {
            int result = 0;
            Dictionary<Int64, int> buffer = new Dictionary<Int64, int>();
            Int64 temp = 0;
            int max = 0;
            for (int row = 0; row < wall.Count; row++)
            {
                temp = 0;
                for (int column = 0; column < wall[row].Count - 1; column++)
                {
                    temp += wall[row][column];
                    if (buffer.ContainsKey(temp) == false)
                    {
                        buffer[temp] = 0;
                    }
                    buffer[temp]++;
                    if (buffer[temp] > max)
                    {
                        max = buffer[temp];
                    }
                }
            }
            result = wall.Count - max;
            return result;
        }

        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Physical Address ........................ : {0}",
                           adapter.GetPhysicalAddress().ToString());
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                /// ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                Console.WriteLine("  DNS suffix .............................. : {0}",
                    properties.DnsSuffix);

                string label;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    Console.WriteLine("  MTU...................................... : {0}", ipv4.Mtu);
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            label = "  WINS Servers ............................ :";
                            /// ShowIPAddresses(label, winsServers);
                        }
                    }
                }

                Console.WriteLine("  DNS enabled ............................. : {0}",
                    properties.IsDnsEnabled);
                Console.WriteLine("  Dynamically configured DNS .............. : {0}",
                    properties.IsDynamicDnsEnabled);
                Console.WriteLine("  Receive Only ............................ : {0}",
                    adapter.IsReceiveOnly);
                Console.WriteLine("  Multicast ............................... : {0}",
                    adapter.SupportsMulticast);
                /// ShowInterfaceStatistics(adapter);

                Console.WriteLine();
            }
        }

        static public int RemoveElement(int[] nums, int val)
        {
            int result = 0;
            for (int flag = 0; flag < nums.Length; flag++)
            {
                if (nums[flag] != val)
                {
                    nums[result++] = nums[flag];
                }
            }

            return result;
        }

        static public int CountQuadruplets(int[] nums)
        {
            int result = 0;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int flag = nums.Length - 1; flag > 2; flag--)
            {
                if (buffer.ContainsKey(nums[flag]) == true)
                {
                    buffer[nums[flag]]++;
                }
                else
                {
                    buffer[nums[flag]] = 1;
                }
                for (int a = 0; a < flag - 2; a++)
                {
                    for (int b = a + 1; b < flag - 1; b++)
                    {
                        var sum = nums[a] + nums[b] + nums[flag - 1];
                        if (buffer.ContainsKey(sum) == true)
                        {
                            result += buffer[sum];
                        }
                    }
                }
            }
            return result;
        }

        static public int RemoveDuplicates(int[] nums)
        {
            int result = 0;
            int index = 0;
            while (index < nums.Length)
            {
                nums[result++] = nums[index++];
                while ((index < nums.Length) && (nums[index] == nums[index - 1]))
                {
                    index++;
                }
            }

            return result;
        }

        static public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode result = null;
            List<ListNode> buffer = new List<ListNode>();
            while (head != null)
            {
                buffer.Add(head);
                head = head.next;
            }
            result = Reverse(ref buffer, 0, k);

            return result;
        }

        static public ListNode Reverse(ref List<ListNode> buffer, int index, int k)
        {
            ListNode result = null;
            if ((buffer.Count - index) >= k)
            {
                int start = index;
                int end = index + k - 1;
                var next = Reverse(ref buffer, index + k, k);
                ListNode temp = null;
                while (end > start)
                {
                    temp = buffer[start];
                    buffer[start] = buffer[end];
                    buffer[start].next = null;
                    buffer[end] = temp;
                    buffer[end].next = null;
                    if (start > index)
                    {
                        buffer[start - 1].next = buffer[start];
                    }
                    buffer[start].next = buffer[start + 1];
                    buffer[end - 1].next = buffer[end];
                    if (end < (index + k - 1))
                    {
                        buffer[end].next = buffer[end + 1];
                    }
                    start++;
                    end--;
                }
                buffer[index + k - 1].next = next;
            }
            result = index < buffer.Count ? buffer[index] : null;
            return result;
        }

        static public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            DictionaryTree root = new DictionaryTree();
            IList<string> result = new List<string>();
            Array.Sort(words, (a, b) =>
            {
                return a.Length - b.Length;
            });
            foreach (var item in words)
            {
                if (Find(ref root, item, 0) == true)
                {
                    result.Add(item);
                }
                else
                {
                    Insert(ref root, item);
                }
            }
            return result;
        }

        static public bool Find(ref DictionaryTree tree, string word, int index)
        {
            bool result = false;
            DictionaryTree temp = tree;
            for (; index < word.Length; index++)
            {
                if (temp[word[index] - 'a'] != null)
                {
                    temp = temp[word[index] - 'a'];
                    if (temp.IsEnd == true)
                    {
                        if (index < (word.Length - 1))
                        {
                            if (Find(ref tree, word, index + 1) == true)
                            {
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            result = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }


        static public void Insert(ref DictionaryTree tree, string word)
        {
            var temp = tree;
            for (int index = 0; index < word.Length; index++)
            {
                if (temp[word[index] - 'a'] == null)
                {
                    temp[word[index] - 'a'] = new DictionaryTree();
                }
                temp = temp[word[index] - 'a'];
            }
            temp.IsEnd = true;
        }

        public string[] FindOcurrences(string text, string first, string second)
        {
            List<string> buff = new List<string>();

            var split = text.Split(new char[] { ' ' });
            for (int index = 0; index < split.Length - 2; index++)
            {
                if ((split[index] == first) && (split[index + 1] == second))
                {
                    buff.Add(split[index + 2]);
                }
            }
            return buff.ToArray();
        }

        static public ListNode SwapPairs(ListNode head)
        {
            ListNode result = head;

            if ((result != null) && (result.next != null))
            {
                result = result.next;
                head.next = SwapPairs(result.next);
                result.next = head;
            }

            return result;
        }

        static public int NumFriendRequests(int[] ages)
        {
            int result = 0;
            Array.Sort(ages);
            int left = 0;
            int right = 0;
            foreach (var item in ages)
            {
                if (item < 15)
                {
                    continue;
                }
                while (ages[left] <= (0.5 * item + 7))
                {
                    left++;
                }
                while ((right < ages.Length) && (ages[right] <= item))
                {
                    right++;
                }
                result += (right - left - 1);
            }

            return result;
        }


        static public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = null;
            if (lists.Length > 0)
            {
                result = Sort(ref lists, 0, (lists.Length - 1) / 2, lists.Length - 1);
            }
            return result;
        }

        public static ListNode Sort(ref ListNode[] lists, int left, int mid, int right)
        {
            if (right <= left)
            {
                return lists[right];
            }
            var f = Sort(ref lists, left, (left + mid) / 2, mid);
            var s = Sort(ref lists, mid + 1, (right + mid + 1) / 2, right);
            return Merge(ref f, ref s);
        }

        public static ListNode Merge(ref ListNode l, ref ListNode r)
        {
            ListNode result = new ListNode();
            var temp = result;
            while (l != null || r != null)
            {
                var num_l = l == null ? Int32.MaxValue : l.val;
                var num_r = r == null ? Int32.MaxValue : r.val;
                if (num_l < num_r)
                {
                    temp.next = l;
                    l = l?.next;
                }
                else
                {
                    temp.next = r;
                    r = r?.next;
                }
                temp = temp?.next;
            }

            return result.next;
        }

        static public int EatenApples(int[] apples, int[] days)
        {
            int result = 0;
            SortedList<int, int> dayList = new SortedList<int, int>();
            int index = 0;
            while (index < apples.Length)
            {
                while ((dayList.Count > 0) && (dayList.ElementAt(0).Key <= index))
                {
                    dayList.RemoveAt(0);
                }
                if (apples[index] > 0)
                {
                    if (dayList.ContainsKey(index + days[index]) == false)
                    {
                        dayList[index + days[index]] = 0;
                    }
                    dayList[index + days[index]] += apples[index];
                }
                if (dayList.Count > 0)
                {
                    if (dayList.ElementAt(0).Value > 0)
                    {
                        dayList[dayList.ElementAt(0).Key]--;
                        result++;
                    }
                    if (dayList.ElementAt(0).Value == 0)
                    {
                        dayList.RemoveAt(0);
                    }
                }
                index++;
            }
            while (dayList.Count > 0)
            {
                while ((dayList.Count > 0) && (dayList.ElementAt(0).Key <= index))
                {
                    dayList.RemoveAt(0);
                }
                if (dayList.Count > 0)
                {
                    if (dayList.ElementAt(0).Value > 0)
                    {
                        dayList[dayList.ElementAt(0).Key]--;
                        result++;
                    }
                    if (dayList.ElementAt(0).Value == 0)
                    {
                        dayList.RemoveAt(0);
                    }
                    index++;
                }
            }
            return result;
        }

        static public string LongestDupSubstring(string s)
        {
            string result = string.Empty;
            int start = -1;
            int length = 0;
            int[] buffer = new int[s.Length];
            int code_1 = 29;
            int code_2 = 37;
            Int64 mod_1 = (Int64)Math.Pow(code_1, 7) + 1;
            Int64 mod_2 = (Int64)Math.Pow(code_2, 7) + 1;
            for (int index = 0; index < s.Length; index++)
            {
                buffer[index] = s[index] - 'a';
            }
            int middle = s.Length / 2;
            while (middle > 0)
            {
                ///var temp = Check(buffer, middle, code_1, code_2, mod_1, mod_2);
                var temp = Find(ref buffer, middle, ref code_1, ref mod_1, ref code_2, ref mod_2);
                if (temp != -1)
                {
                    if (length < middle)
                    {
                        start = temp;
                        length = middle;
                        middle = length + ((s.Length - length) > middle ? middle : (s.Length - length)) / 2;
                        if (middle == length)
                        {
                            middle++;
                        }
                    }
                }
                else if (middle <= length)
                {
                    break;
                }
                else
                {
                    middle = length + (middle - length) / 2;
                    if (middle == length)
                    {
                        break;
                    }
                }
            }
            if (start != -1)
            {
                result = s.Substring(start, length);
            }
            return result;
        }

        static public int Find(ref int[] buffer, int length, ref int code_1, ref Int64 mode_1, ref int code_2, ref Int64 mode_2)
        {
            int result = -1;
            Int64 hash_1 = 0;
            Int64 hash_2 = 0;
            Int64 pow_1 = Pow(code_1, length, mode_1);
            Int64 pow_2 = Pow(code_2, length, mode_2);
            HashSet<Int64> set = new HashSet<long>();
            for (int index = 0; index < length; index++)
            {
                hash_1 = (hash_1 * code_1 % mode_1 + buffer[index]) % mode_1;
                hash_2 = (hash_2 * code_2 % mode_2 + buffer[index]) % mode_2;
                if (hash_1 < 0)
                {
                    hash_1 += mode_1;
                }
                if (hash_2 < 0)
                {
                    hash_2 += mode_2;
                }
            }
            set.Add(hash_1 * mode_2 % mode_1 + hash_2 * mode_1 % mode_2);
            for (int index = 1; index < buffer.Length - length + 1; index++)
            {
                hash_1 = (hash_1 * code_1 % mode_1 - buffer[index - 1] * pow_1 % mode_1 + buffer[index + length - 1]) % mode_1;
                hash_2 = (hash_2 * code_2 % mode_2 - buffer[index - 1] * pow_2 % mode_2 + buffer[index + length - 1]) % mode_2;
                if (hash_1 < 0)
                {
                    hash_1 += mode_1;
                }
                if (hash_2 < 0)
                {
                    hash_2 += mode_2;
                }
                if (set.Contains(hash_1 * mode_2 % mode_1 + hash_2 * mode_1 % mode_2) == true)
                {
                    result = index;
                    break;
                }
                else
                {
                    set.Add(hash_1 * mode_2 % mode_1 + hash_2 * mode_1 % mode_2);
                }
            }
            return result;
        }

        static public long Pow_(ref int code, int length, ref Int64 mod)
        {
            Int64 result = 1;
            while (length > 0)
            {
                result = result * code % mod;
                if (result < 0)
                {
                    result += mod;
                }
                length--;
            }

            return result;
        }


        static public string LongestDupSubstring_(string s)
        {
            Random random = new Random();
            // 生成两个进制
            int a1 = random.Next(26, 101);
            int a2 = random.Next(26, 101);
            // 生成两个模
            long mod1 = random.Next(1000000006, int.MaxValue) + 1;
            long mod2 = random.Next(1000000006, int.MaxValue) + 1;

            a1 = 29;
            a2 = 37;
            mod1 = (Int64)Math.Pow(a1, 7) + 1;
            mod2 = (Int64)Math.Pow(a2, 7) + 1;

            int n = s.Length;
            // 先对所有字符进行编码
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = s[i] - 'a';
            }
            // 二分查找的范围是[1, n-1]
            int l = 1, r = n - 1;
            int length = 0, start = -1;
            while (l <= r)
            {
                int m = l + (r - l + 1) / 2;
                int idx = Check(arr, m, a1, a2, mod1, mod2);
                if (idx != -1)
                {
                    // 有重复子串，移动左边界
                    l = m + 1;
                    length = m;
                    start = idx;
                }
                else
                {
                    // 无重复子串，移动右边界
                    r = m - 1;
                }
            }
            return start != -1 ? s.Substring(start, length) : "";
        }

        static public int Check(int[] arr, int m, int a1, int a2, long mod1, long mod2)
        {
            int n = arr.Length;
            long aL1 = Pow(a1, m, mod1);
            long aL2 = Pow(a2, m, mod2);
            long h1 = 0, h2 = 0;
            for (int i = 0; i < m; ++i)
            {
                h1 = (h1 * a1 % mod1 + arr[i]) % mod1;
                h2 = (h2 * a2 % mod2 + arr[i]) % mod2;
                if (h1 < 0)
                {
                    h1 += mod1;
                }
                if (h2 < 0)
                {
                    h2 += mod2;
                }
            }
            // 存储一个编码组合是否出现过
            ISet<long> seen = new HashSet<long>();
            seen.Add(h1 * mod2 + h2);
            for (int start = 1; start <= n - m; ++start)
            {
                h1 = (h1 * a1 % mod1 - arr[start - 1] * aL1 % mod1 + arr[start + m - 1]) % mod1;
                h2 = (h2 * a2 % mod2 - arr[start - 1] * aL2 % mod2 + arr[start + m - 1]) % mod2;
                if (h1 < 0)
                {
                    h1 += mod1;
                }
                if (h2 < 0)
                {
                    h2 += mod2;
                }

                long num = h1 * mod2 + h2;
                // 如果重复，则返回重复串的起点
                if (!seen.Add(num))
                {
                    return start;
                }
            }
            // 没有重复，则返回-1
            return -1;
        }

        static public long Pow(int a, int m, Int64 mod)
        {
            long ans = 1;
            long contribute = a;
            while (m > 0)
            {
                if (m % 2 == 1)
                {
                    ans = ans * contribute % mod;
                    if (ans < 0)
                    {
                        ans += mod;
                    }
                }
                contribute = contribute * contribute % mod;
                if (contribute < 0)
                {
                    contribute += mod;
                }
                m /= 2;
            }
            return ans;
        }


        static public IList<string> GenerateParenthesis(int n)
        {
            return Cal(0, "", n);
        }

        static public IList<string> Cal(int stack, string buff, int n)
        {
            IList<string> result = new List<string>();
            if (stack > 0)
            {
                var temp = buff + ')';
                foreach (var item in Cal(stack - 1, temp, n))
                {
                    result.Add(item);
                }
                if (n > 0)
                {
                    temp = buff + '(';
                    foreach (var item in Cal(stack + 1, temp, n - 1))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (n > 0)
            {
                var temp = buff + '(';
                foreach (var item in Cal(stack + 1, temp, n - 1))
                {
                    result.Add(item);
                }
            }
            else
            {
                result.Add(buff);
            }
            return result;
        }

        static public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int length = 0;
            var buf = new ListNode(0, head);
            var temp = buf;
            while (temp != null)
            {
                temp = temp.next;
                length++;
            }
            temp = buf;
            for (int flag = 0; flag < length - n - 1; flag++)
            {
                temp = temp.next;
            }
            if (temp.next != null)
            {
                temp.next = temp.next.next;
            }
            return buf.next;
        }

        static public int RepeatedStringMatch(string a, string b)
        {
            int result = -1;
            int temp = 0;
            int index = 0;
            int flag = -1;
            int start = 0;
            while (start < a.Length)
            {
                flag = a.IndexOf(b[index], start);
                if (flag != -1)
                {
                    while (index < b.Length)
                    {
                        for (; flag < a.Length && index < b.Length; flag++, index++)
                        {
                            if (a[flag] == b[index])
                            {
                                temp++;
                            }
                        }
                        if (temp == b.Length)
                        {
                            result = result == -1 ? 1 : result + 1;
                            start = a.Length;
                            break;
                        }
                        else if (temp == index)
                        {
                            result = result == -1 ? 1 : result + 1;
                            flag = 0;
                        }
                        else
                        {
                            temp = 0;
                            index = 0;
                            result = -1;
                            start++;
                            break;
                        }
                        if (temp > (a.Length * 2))
                        {
                            var last = b.LastIndexOf(a);
                            if (String.IsNullOrEmpty(b.Substring(last + a.Length)) == false)
                            {
                                if (RepeatedStringMatch(a, b.Substring(last + a.Length)) == -1)
                                {
                                    result = -1;
                                    start = a.Length;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        static public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            int index_a = 0;
            int index_d = nums.Length - 1;
            int index_c, index_b;
            for (; index_a < nums.Length - 3; index_a++)
            {
                if ((index_a > 0) && (nums[index_a]) == nums[index_a - 1])
                {
                    continue;
                }
                for (index_d = nums.Length - 1; index_d > 2; index_d--)
                {
                    if ((index_d < nums.Length - 1) && (nums[index_d]) == nums[index_d + 1])
                    {
                        continue;
                    }
                    index_b = index_a + 1;
                    index_c = index_d - 1;
                    while (index_c > index_b)
                    {
                        var temp = nums[index_a] + nums[index_b] + nums[index_c] + nums[index_d];
                        if (temp == target)
                        {
                            result.Add(new List<int>()
                                {
                                    nums[index_a],
                                    nums[index_b],
                                    nums[index_c],
                                    nums[index_d]
                                });
                            index_c--;
                            while ((index_c > (index_a + 1)) && (index_c < index_d - 1) && (nums[index_c]) == nums[index_c + 1])
                            {
                                index_c--;
                            }
                        }
                        else if (temp < target)
                        {
                            index_b++;
                            while (((index_b < index_d - 1)) && (index_b > index_a + 1) && (nums[index_b]) == nums[index_b - 1])
                            {
                                index_b++;
                            }
                        }
                        else
                        {
                            index_c--;
                            while ((index_c > (index_a + 1)) && (index_c < index_d - 1) && (nums[index_c]) == nums[index_c + 1])
                            {
                                index_c--;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        static public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode result = null;

            if (list1 == null)
            {
                result = list2;
            }
            else if (list2 == null)
            {
                result = list1;
            }
            else if (list1.val < list2.val)
            {
                result = list1;
                list1.next = MergeTwoLists(list1.next, list2);
            }
            else
            {
                result = list2;
                list2.next = MergeTwoLists(list1, list2.next);
            }

            return result;
        }

        static public int DayOfYear(string date)
        {
            int result = 0;
            Dictionary<int, int> map = new Dictionary<int, int>()
            {
                { 1,31},
                { 2,28},
                { 3,31},
                { 4,30},
                { 5,31},
                { 6,30},
                { 7,31},
                { 8,31},
                { 9,30},
                { 10,31},
                { 11,30},
                { 12,31}
            };
            DateTime d = Convert.ToDateTime(date);
            if (((d.Year % 400) == 0) || ((d.Year % 4 == 0) && (d.Year % 100 != 0)))
            {
                map[2] = 29;
            }
            for (int flag = 1; flag < d.Month; flag++)
            {
                result += map[flag];
            }
            result += d.Day;

            return result;
        }

        static public bool IsValid(string s)
        {
            HashSet<char> input = new HashSet<char>() { '(', '{', '[' };
            Dictionary<char, char> output = new Dictionary<char, char>()
            {
                { ')','('},
                { ']','['},
                { '}','{'}
            };

            List<int> sss = new List<int>();


            int[] ddd = new int[88];

            bool result = true;
            Stack<char> buffer = new Stack<char>();
            foreach (var item in s)
            {
                if (input.Contains(item))
                {
                    buffer.Push(item);
                }
                else if (output.ContainsKey(item))
                {
                    if ((buffer.Count == 0) || (buffer.Pop() != output[item]))
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    result = false;
                    break;
                }
            }
            result = result && (buffer.Count == 0);
            return result;
        }

        static public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            Dictionary<char, string> map = new Dictionary<char, string>()
            {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                { '9', "wxyz"}
            };
            StringBuilder buffer = new StringBuilder();
            BackTrack(ref map, ref buffer, digits, 0, result);
            return result;

        }

        static public void BackTrack(ref Dictionary<char, string> map, ref StringBuilder buffer, string digits, int index, IList<string> result)
        {
            if (index < digits.Length)
            {
                var item = digits[index];
                index++;
                foreach (var c in map[item])
                {
                    buffer.Append(c);
                    if (index < digits.Length)
                    {
                        BackTrack(ref map, ref buffer, digits, index, result);
                    }
                    if (index == digits.Length)
                    {
                        result.Add(buffer.ToString());
                    }
                    buffer.Remove(index - 1, 1);
                }
            }
        }

        static public int FindRadius(int[] houses, int[] heaters)
        {
            int result = int.MinValue;
            int min = int.MaxValue;
            Array.Sort(houses);
            Array.Sort(heaters);
            int flag = 0;
            foreach (var house in houses)
            {
                if (flag < heaters.Length)
                {
                    min = Math.Abs(house - heaters[flag]);
                    while ((flag < heaters.Length - 1) &&
                          (min >= Math.Abs(house - heaters[flag + 1])))
                    {
                        flag++;
                        min = Math.Abs(house - heaters[flag]);
                    }
                }
                result = result < min ? min : result;
            }

            return result;
        }

        static public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int result = (int)1e8;
            int flag = 0, end = 0;
            int temp;
            for (int begin = 0; begin < nums.Length - 2; begin++)
            {
                if ((begin > 0) && (nums[begin] == nums[begin - 1]))
                {
                    continue;
                }
                end = nums.Length - 1;
                flag = begin + 1;
                while (end > flag)
                {
                    temp = nums[begin] + nums[flag] + nums[end];
                    if (temp > target)
                    {
                        end--;
                        while ((end > flag) && (end < nums.Length - 1) && (nums[end] == nums[end + 1]))
                        {
                            end--;
                        }
                    }
                    else
                    {
                        flag++;
                        while ((flag < end) && (nums[flag] == nums[flag - 1]))
                        {
                            flag++;
                        }
                    }
                    result = Math.Abs(target - result) > Math.Abs(target - temp) ? temp : result;
                    if (result == target)
                    {
                        end = flag;
                    }
                }
                if (result == target)
                {
                    break;
                }
            }
            return result;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Dictionary<int, List<int>> buffer = new Dictionary<int, List<int>>();
            HashSet<int> second = new HashSet<int>();
            Array.Sort(nums);
            int max = Int32.MaxValue;
            int count = 0;
            for (int index = 0; index < nums.Length; index++)
            {
                if (buffer.ContainsKey(nums[index]) == false)
                {
                    buffer[nums[index]] = new List<int>();
                }
                buffer[nums[index]].Add(index);
            }
            for (int begin = 0; begin < nums.Length; begin++)
            {
                if (nums[begin] > 0)
                {
                    break;
                }
                if ((begin > 0) && (nums[begin] == nums[begin - 1]))
                {
                    continue;
                }
                for (int end = nums.Length - 1; end >= 0; end--)
                {
                    if (nums[end] < 0)
                    {
                        break;
                    }
                    if ((end < (nums.Length - 1)) && (nums[end] == nums[end + 1]))
                    {
                        continue;
                    }
                    max = 0 - (nums[end] + nums[begin]);
                    count = nums[begin] == nums[end] ? 2 : 1;
                    if ((buffer.ContainsKey(max) == true) &&
                        (max <= nums[end]) &&
                        (max >= nums[begin]) &&
                        (((buffer[max].Contains(begin) || buffer[max].Contains(end)) && (buffer[max].Count > count)) ||
                        ((buffer[max].Contains(begin)) == false && (buffer[max].Contains(end) == false))))
                    {
                        result.Add(new List<int>() { nums[begin], nums[end], max });
                    }
                }
            }

            return result as IList<IList<int>>;
        }


        static int[] Counter(int N, int[] A)
        {
            int[] result = new int[N];
            int max = 0;
            int last = 0;
            for (int index = 0; index < A.Length; index++)
            {
                if (A[index] > N)
                {
                    last = max;
                }
                else
                {
                    result[A[index] - 1] = (result[A[index] - 1] > last) ? result[A[index] - 1] + 1 : last + 1;
                    max = result[A[index] - 1] > max ? result[A[index] - 1] : max;
                }
            }
            for (int index = 0; index < N; index++)
            {
                result[index] = (result[index] > last) ? result[index] : last;
            }
            return result;
        }

        static int Cal(int[] A)
        {
            int result = 0;

            Dictionary<int, List<int>> buffer = new Dictionary<int, List<int>>();
            for (int index = 0; index < A.Length; index++)
            {
                if (buffer.ContainsKey(A[index]) == false)
                {
                    buffer[A[index]] = new List<int>();
                }
                buffer[A[index]].Add(index);
            }
            List<int> indexs = null;
            int max = 0;
            int min = 0;
            foreach (var item in buffer)
            {
                if (max < item.Value.Count)
                {
                    indexs = item.Value;
                    max = item.Value.Count;
                }
            }
            if ((indexs != null) && (indexs.Count > (A.Length / 2)))
            {
                for (int index = 0; index < indexs.Count - 1; index++)
                {
                    max = 2 * index < indexs[index + 1] ? 2 * index : indexs[index + 1] - 1;
                    if (max >= indexs[index])
                    {
                        min = A.Length - 2 * indexs.Count + 2 * index + 2;
                        min = min < indexs[index] ? indexs[index] : min;
                        result += (max - min < 0 ? 0 : max - min + 1);
                    }
                }
            }
            return result;
        }

        public static string longestCommonPrefix(string[] strs)
        {
            string result = string.Empty;

            Array.Sort(strs);
            for (int index = 0; index < strs[0].Length; index++)
            {
                if (strs[0][index] == strs[strs.Length - 1][index])
                {
                    result += strs[0][index];
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }

    public class DetectSquares
    {
        private Dictionary<int, Dictionary<int, int>> xTable;
        private Dictionary<int, Dictionary<int, int>> yTable;
        public DetectSquares()
        {
            this.xTable = new Dictionary<int, Dictionary<int, int>>();
            this.yTable = new Dictionary<int, Dictionary<int, int>>();
        }

        public void Add(int[] point)
        {
            if (this.xTable.ContainsKey(point[0]) == false)
            {
                this.xTable[point[0]] = new Dictionary<int, int>();
                this.xTable[point[0]][point[1]] = 0;
            }
            else if (this.xTable[point[0]].ContainsKey(point[1]) == false)
            {
                this.xTable[point[0]][point[1]] = 0;
            }
            if (this.yTable.ContainsKey(point[1]) == false)
            {
                this.yTable[point[1]] = new Dictionary<int, int>();
                this.yTable[point[1]][point[0]] = 0;
            }
            else if (this.yTable[point[1]].ContainsKey(point[0]) == false)
            {
                this.yTable[point[1]][point[0]] = 0;
            }
            this.xTable[point[0]][point[1]]++;
            this.yTable[point[1]][point[0]]++;
        }

        public int Count(int[] point)
        {
            int result = 0;
            if ((xTable.ContainsKey(point[0]) == true) && (yTable.ContainsKey(point[1]) == true))
            {
                var x_yPoints = xTable[point[0]];
                var y_xPoints = yTable[point[1]];
                foreach (var x_y in x_yPoints)
                {
                    if (x_y.Key != point[1])
                    {
                        var xPoint = yTable[x_y.Key];
                        foreach (var x in xPoint)
                        {
                            if (x.Key != point[0])
                            {
                                if (y_xPoints.ContainsKey(x.Key))
                                {
                                    if (Math.Abs(x.Key - point[0]) == Math.Abs(point[1] - x_y.Key))
                                    {
                                        result += ((y_xPoints[x.Key] * x.Value * x_y.Value));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

}
